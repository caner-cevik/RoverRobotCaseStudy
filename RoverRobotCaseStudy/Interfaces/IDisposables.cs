using System;

namespace RoverRobotCaseStudy.Interfaces
{
    public interface IDisposables
    {
        void DisposeResources(IServiceProvider _serviceProvider);
    }
}
