namespace Graphs.Test;

public class CountComponents_Test
{
    [Fact]
    public void CountComponentsTest()
    {
        CountComponents components = new CountComponents();

        int result = components.CountComponents2(5, new int[][] {new int[] {0, 1}, new int[] {1, 2}, new int[] {3, 4}});

        Assert.NotNull(result);
    }
    [Fact]
    public void CountComponentsTest2()
    {
        CountComponents components = new CountComponents();

        int result = components.CountComponents2(5, new int[][] {new int[] {0, 1}, new int[] {0, 2}, new int[] {1, 2}});

        Assert.NotNull(result);
    }

    [Fact]
    public void findHouses()
    {
        FindingHouses houses = new FindingHouses();
        
        int result = houses.ShortestDistance(new int[][] {new int[] {1,0,2,0,1},new int[] {0,0,0,0,0}, new int[] {0,0,1,0,0} });

        Assert.Equal(7, result);
    }
}