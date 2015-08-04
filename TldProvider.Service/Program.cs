using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TldProvider.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ITaskService>(s =>
                {
                    s.ConstructUsing(() => new TaskService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDisplayName("TLD Provider Service");
                x.SetServiceName("TLDProviderService");
                x.SetDescription("Gets Amazon documentation and extracts the supported TLD list");

                x.StartAutomatically();

                x.EnableServiceRecovery(s =>
                {
                    s.RestartService(1);
                    s.RestartService(2);
                    s.RestartService(5);
                });
            });
        }
    }
}
