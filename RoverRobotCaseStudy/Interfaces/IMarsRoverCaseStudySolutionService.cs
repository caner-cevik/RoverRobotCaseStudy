using RoverRobotCaseStudy.Entities;

namespace RoverRobotCaseStudy.Interfaces
{
    public interface IMarsRoverCaseStudySolutionService
    {
        Coordinates TakeAction(Coordinates coordinates,string movement);
        Coordinates GetCoordinates(string[] roverCurrentLocation, string[] maxPointXandY);

    }
}
