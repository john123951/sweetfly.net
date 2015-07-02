using SweetFly.Job.Models.Cmr;
using System.Collections.Generic;
using System.Linq;

namespace Sweet.Cmr.GenerateXml.Handlers
{
    using EntitySubjectModule = SweetFly.Model.Entities.Cmr.cn.SubjectModule;

    public abstract class GenerateHandler
    {
        private static List<EntitySubjectModule> _modules;

        public static void setModules(List<EntitySubjectModule> modules)
        {
            _modules = modules;
        }

        public abstract List<SubjectModule> Process(string strResponse, int moduleId);

        protected static int GetId(int moduleId, string title)
        {
            var find = _modules.FirstOrDefault(x => x.Name == title);
            return find == null ? 0 : find.Id;
        }
    }
}