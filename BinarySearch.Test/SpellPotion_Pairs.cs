namespace BinarySearch.Test;

public class SpellPotion_Pairs
{
    [Theory]
    [InlineData(new object[] {new int[] {5, 1, 3}, new int[] {1, 2, 3, 4, 5}, 7, new int[] {4, 0, 3}})]
    [InlineData(new object[] {new int[] {3, 1, 2}, new int[] {8, 5, 8}, 16, new int[] {2, 0, 2}})]
    public void FindSpellPotionPairs(int[] spells, int[] potions, long success, int[] expectedAnswers)
    {
        BinarySearch_SuccessfulPairs spellPotions = new BinarySearch_SuccessfulPairs();

        int[] result = spellPotions.SuccessfulPairs(spells, potions, success);

        for (int i = 0; i < expectedAnswers.Length; i++)
        {
            Assert.Equal(expectedAnswers[i], result[i]);
        }
    }
}