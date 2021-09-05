using RoverRobotCaseStudy.Enums;

namespace RoverRobotCaseStudy.Entities
{
    public class Coordinates
    {
        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// rover robot's direction
        /// </summary>
        public Directions direction { get; set; }
        /// <summary>
        /// maximum X point
        /// </summary>
        public int maxX { get; set; }

        /// <summary>
        /// maximum Y point
        /// </summary>
        public int maxY { get; set; }

    }
}
