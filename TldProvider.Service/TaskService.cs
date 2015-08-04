using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace TldProvider.Service
{
    internal class TaskService : ITaskService
    {
        public void Start()
        {
            string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("Service started");
        }

        public void Stop()
        {
            Console.WriteLine("Service stopped");
        }
    }
}