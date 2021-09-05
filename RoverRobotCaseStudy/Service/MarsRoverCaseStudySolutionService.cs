using RoverRobotCaseStudy.Entities;
using RoverRobotCaseStudy.Enums;
using RoverRobotCaseStudy.Interfaces;
using RoverRobotCaseStudy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RoverRobotCaseStudy.Service
{
    public class MarsRoverCaseStudySolutionService : IMarsRoverCaseStudySolutionService
    {
        /// <summary>
        /// Rover robot taking action
        /// </summary>
        public Coordinates TakeAction(Coordinates coordinates, string movement)
        {

            //Using reflection library so that we can get all IPerform implementation types and create instance of them
            var takeActions = new List<IPerform>();
            foreach (Type type in Assembly.GetAssembly(typeof(IPerform)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && typeof(IPerform).IsAssignableFrom(myType)))
            {
                takeActions.Add((IPerform)Activator.CreateInstance(type));
            }

            // Calling Perform method according to movement or rotation command sended to rover robot
            movement.ToList().ForEach(y =>
            {
                if (coordinates != null)
                {
                    var movementOfRoverRobot = takeActions.SingleOrDefault(x => x.Movement == y);
                    var newCoordinates = movementOfRoverRobot.Perform(coordinates);
                    coordinates = newCoordinates;
                }
            });

            return coordinates;
        }

        /// <summary>
        /// Get coordinates
        /// </summary>
        public Coordinates GetCoordinates(string[] roverCurrentLocation, string[] maxPointXandY)
        {
            var maxPointLists = maxPointXandY.Select(x => int.Parse(x)).ToList();

            var coordinates = new Coordinates()
            {
                X = Convert.ToInt32(roverCurrentLocation[0]),
                Y = Convert.ToInt32(roverCurrentLocation[1]),
                direction = roverCurrentLocation[2].TryConvertToEnum<Directions>(),
                maxX = Convert.ToInt32(maxPointXandY[0]),
                maxY = Convert.ToInt32(maxPointXandY[1]),
            };

            return coordinates;

        }

    }
}
