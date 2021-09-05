using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RoverRobotCaseStudy.Interfaces;
using RoverRobotCaseStudy.Service;
using System;

namespace RoverRobotCaseStudy.Configuration
{
    internal static class ContainerConfiguration
    {
        /// <summary>
        /// Registering types
        /// </summary>
        public static IServiceProvider Configure()
        {
            var containerBuilder = new ContainerBuilder();
            var serviceCollection = new ServiceCollection();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<MarsRoverCaseStudySolutionService>().As<IMarsRoverCaseStudySolutionService>().SingleInstance();
            containerBuilder.RegisterType<DisposeResourcesServices>().As<IDisposables>().SingleInstance();

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
