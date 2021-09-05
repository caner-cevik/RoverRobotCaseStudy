using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RoverRobotCaseStudy.Entities;
using RoverRobotCaseStudy.Enums;
using RoverRobotCaseStudy.Interfaces;
using RoverRobotCaseStudy.Service;
using System;

namespace RoverRobotCaseStudyTest
{
    [TestFixture]
    public class MarsRoverCaseStudySolutionTest
    {
        private readonly IServiceProvider _serviceProvider;
        public MarsRoverCaseStudySolutionTest()
        {

            var containerBuilder = new ContainerBuilder();
            var serviceCollection = new ServiceCollection();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<MarsRoverCaseStudySolutionService>().As<IMarsRoverCaseStudySolutionService>().SingleInstance();
            var container = containerBuilder.Build();

            this._serviceProvider = new AutofacServiceProvider(container);
        }

        [Test(Description = "Scenario 1 -  get expected coordinates( 1,3,N) and coordinates are not null( Rover Robot can move )")]
        public void Scenario1()
        {
            var currentCoordinates = new Coordinates()
            {
                X = 1,
                Y = 2,
                direction = Directions.N,
                maxX = 5,
                maxY = 5,
            };
            var movement = "LMLMLMLMM";

            var expectedCoordinates = new Coordinates()
            {
                X = 1,
                Y = 3,
                direction = Directions.N,
            };

            var coordinates = _serviceProvider.GetService<IMarsRoverCaseStudySolutionService>().TakeAction(currentCoordinates, movement);

            Assert.NotNull(coordinates);
            Assert.AreEqual(coordinates.X, expectedCoordinates.X);
            Assert.AreEqual(coordinates.Y, expectedCoordinates.Y);
            Assert.AreEqual(coordinates.direction, expectedCoordinates.direction);


        }

        [Test(Description = "Scenario 2 -  get expected coordinates( 5,1,E) and coordinates are not null( Rover Robot can move )")]
        public void Scenario2()
        {
            var currentCoordinates = new Coordinates()
            {
                X = 3,
                Y = 3,
                direction = Directions.E,
                maxX = 5,
                maxY = 5,
            };
            var movement = "MMRMMRMRRM";

            var expectedCoordinates = new Coordinates()
            {
                X = 5,
                Y = 1,
                direction = Directions.E,
            };

            var coordinates = _serviceProvider.GetService<IMarsRoverCaseStudySolutionService>().TakeAction(currentCoordinates, movement);

            Assert.NotNull(coordinates);
            Assert.AreEqual(coordinates.X, expectedCoordinates.X);
            Assert.AreEqual(coordinates.Y, expectedCoordinates.Y);
            Assert.AreEqual(coordinates.direction, expectedCoordinates.direction);


        }

        [Test(Description = "Scenario 3 -  get coordinates that are null( Rover Robot can not move )")]
        public void Scenario3()
        {
            var currentCoordinates = new Coordinates()
            {
                X = 1,
                Y = 2,
                direction = Directions.N,
                maxX = 5,
                maxY = 5,
            };
            var movement = "MMMMMM";

            var coordinates = _serviceProvider.GetService<IMarsRoverCaseStudySolutionService>().TakeAction(currentCoordinates, movement);

            Assert.Null(coordinates);

        }

    }
}
