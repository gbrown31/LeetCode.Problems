namespace Heaps.Test;

public class UnitTest1
{
    [Fact]
    public void CheckMedian()
    {
        MedianFinder finder = new MedianFinder();

        finder.AddNum(1);
        finder.AddNum(2);

        Assert.Equal(1.5, finder.FindMedian());
        
        finder.AddNum(3);

        Assert.Equal(2.0, finder.FindMedian());
    }
}