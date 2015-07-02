using SweetFly.Model.Entities.UserCracker;
using System.Threading.Tasks;

namespace SweetFly.Repository.contract
{
    public interface IUserCrackRepository
    {
        //void Insert(userpassword model);

        //void InsertMany(IEnumerable<userpassword> list);

        Task<userpassword> GetOne(int skip);

        Task SaveSuccessUserInfo(CmrUserInfo entity);

        Task SavePosition(long position);
    }
}