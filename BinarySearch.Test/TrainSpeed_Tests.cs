namespace BinarySearch.Test;

public class TrainSpeed_Tests
{
    [Fact]
    public void FindIFDestinationCanBeReached()
    {
        TrainSpeed trains = new TrainSpeed();

        var result = trains.MinSpeedOnTime(new int[] {1, 3, 2}, 2.7);

        Assert.Equal(3, result);
    }
}