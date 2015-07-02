using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet.Cmr.GenerateXml.Handlers
{
    public static class HandlerFactory
    {

        public static GenerateHandler CreateHandler(int type)
        {
            switch (type)
            {
                case 1: return new GenerateNormalHandler(); break;
                case 2: return new GenOldHandler(); break;
                default:
                    break;
            }
            return null;
        }
    }
}
