using RoverRobotCaseStudy.Entities;

namespace RoverRobotCaseStudy.Interfaces
{
    public interface IPerform
    {
        /// <summary>
        /// performing rover robot rotation/movement
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>        
        Coordinates Perform(Coordinates coordinates);
        char Movement
        {
            get;
        }
    }
}
