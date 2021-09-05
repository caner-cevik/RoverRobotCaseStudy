using RoverRobotCaseStudy.Entities;
using RoverRobotCaseStudy.Enums;
using RoverRobotCaseStudy.Interfaces;
using System;
using System.Collections.Generic;

namespace RoverRobotCaseStudy.Controls
{
    public class MoveLeft : IPerform
    {
        /// <summary>
        /// it is for rover's left rotation. If sended rotation command is 'L', then MoveLeft class instance's Perform method is called.
        /// </summary>
        public char Movement => 'L';

        /// <summary>
        /// Performing rover robot rotation
        /// </summary>
        public Coordinates Perform(Coordinates coordinates)
        {
            var Mapping = new Dictionary<Directions, Func<Coordinates, Coordinates>>
            {
                 { Directions.N, (x) =>  {x.direction = Directions.W; return x; }  },
                 { Directions.E, (x) =>  {x.direction = Directions.N; return x; }  },
                 { Directions.S, (x) =>  {x.direction = Directions.E; return x; }  },
                 { Directions.W, (x) =>  {x.direction = Directions.S; return x; }  }
            };

            return Mapping[coordinates.direction](coordinates);
        }
    }
}
