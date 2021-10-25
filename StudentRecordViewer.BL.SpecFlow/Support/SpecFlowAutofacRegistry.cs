using Autofac;
using SpecFlow.Autofac;
using StudentRecordViewer.BL.SpecFlow.Steps;
using SutdentRecordViewer.BL.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordViewer.BL.SpecFlow.Support
{
    public class SpecFlowAutofacRegistry
    {
        [ScenarioDependencies]
        public static ContainerBuilder RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(SearchStudentIDSteps).Assembly).SingleInstance();
            BLAutofacRegistry.Register(builder);
            return builder;
        }
    }
}
