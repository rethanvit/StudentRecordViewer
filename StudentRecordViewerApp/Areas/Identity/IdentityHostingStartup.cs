using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StudentRecordViewerApp.Areas.Identity.IdentityHostingStartup))]
namespace StudentRecordViewerApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}