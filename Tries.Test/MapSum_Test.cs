namespace Tries.Test;

public class MapSum_Test
{
    [Fact]
    public void MapSumTests()
    {
        MapSum sum = new MapSum();

        sum.Insert("apple", 3);
        int sumResult1 = sum.Sum("ap");

        sum.Insert("app", 2);
        int sumResult2 = sum.Sum("ap");

        Assert.Equal(3, sumResult1);
    }
}