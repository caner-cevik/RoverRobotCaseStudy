using RoverRobotCaseStudy.Entities;
using RoverRobotCaseStudy.Enums;
using RoverRobotCaseStudy.Interfaces;
using System;
using System.Collections.Generic;

namespace RoverRobotCaseStudy.Controls
{
    public class MoveForward : IPerform
    {
        /// <summary>
        /// it is for rover's movement. If sended movement command is 'M', then MoveForward class instance's Perform method is called.
        /// </summary>
        public char Movement => 'M';

        /// <summary>
        /// Performing movement
        /// </summary>
        public Coordinates Perform(Coordinates coordinates)
        {

            var Mapping = new Dictionary<Directions, Func<Coordinates, Coordinates>>
            {
                 { Directions.N, (x) =>  DirectionNorth(x)  },
                 { Directions.E, (x) =>  DirectionEast(x)  },
                 { Directions.S, (x) =>  DirectionSouth(x) },
                 { Directions.W, (x) =>  DirectionWest(x)  }
            };

            return Mapping[coordinates.direction](coordinates);
        }

        private Coordinates DirectionNorth(Coordinates coordinates)
        {
            if (coordinates.Y >= coordinates.maxY)
                coordinates = null;
            else
                coordinates.Y += 1;

            return coordinates;
        }
        private Coordinates DirectionEast(Coordinates coordinates)
        {
            if (coordinates.X >= coordinates.maxX)
                coordinates = null;
            else
                coordinates.X += 1;

            return coordinates;
        }
        private Coordinates DirectionSouth(Coordinates coordinates)
        {
            if (coordinates.Y != 0)
                coordinates.Y -= 1;
            else
                coordinates = null;

            return coordinates;
        }
        private Coordinates DirectionWest(Coordinates coordinates)
        {
            if (coordinates.X != 0)
                coordinates.X -= 1;
            else
                coordinates = null;

            return coordinates;
        }

    }

  
}
