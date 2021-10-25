using Autofac;
using StudentRecordViewer.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SutdentRecordViewer.BL.Startup
{
    public static class BLAutofacRegistry
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(StudentRecords).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(StudentRespository).Assembly).AsImplementedInterfaces();
        }
    }
}
