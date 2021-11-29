using Autofac;
using StudentRecordViewer.DL;

namespace SutdentRecordViewer.BL.Startup
{
    public static class BLAutofacRegistry
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(StudentDetail).Assembly).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(typeof(StudentRespository).Assembly).AsImplementedInterfaces();
        }
    }
}
