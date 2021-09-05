using RoverRobotCaseStudy.Configuration;
using RoverRobotCaseStudy.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace RoverRobotCaseStudy
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var maxPointsXandY = Console.ReadLine().Split(' ');
            var roverCurrentLocation = Console.ReadLine().Split(' ');
            var movement = Console.ReadLine();

            // Registering types via Autofac IoC container 
            var serviceProvider = ContainerConfiguration.Configure();

            // Getting service object of IMarsRoverCaseStudySolutionService
            var marsRoverCaseStudySolutionService = serviceProvider.GetService<IMarsRoverCaseStudySolutionService>();

            var coordinates =  marsRoverCaseStudySolutionService.GetCoordinates(roverCurrentLocation, maxPointsXandY);
            var newCoordinates = marsRoverCaseStudySolutionService.TakeAction(coordinates, movement);

            if (newCoordinates != null)
                Console.WriteLine(coordinates.X + " " + coordinates.Y + " " + coordinates.direction);
            else
                Console.WriteLine("Rover Robot can not move!");

            //Calling dispose services
            serviceProvider.GetService<IDisposables>().DisposeResources(serviceProvider);
        }
    }
}
