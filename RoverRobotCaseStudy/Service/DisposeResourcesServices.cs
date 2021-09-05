using RoverRobotCaseStudy.Interfaces;
using System;

namespace RoverRobotCaseStudy.Service
{
    public class DisposeResourcesServices : IDisposables
    {
        /// <summary>
        /// disposing services
        /// </summary>
        public void DisposeResources(IServiceProvider _serviceProvider)
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }


    }
}
