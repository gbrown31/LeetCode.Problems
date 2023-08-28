namespace Greedy;

public class GreedyAlgo
{
    public int Maximum69Number (int num)
    {
        string numbers = num.ToString();
        char[] characters = new char[numbers.Length];
        int numberOfChanges = 0;
        for (int i=0; i<numbers.Length;i++)
        {
            if (numbers[i] == '6' && numberOfChanges == 0)
            {
                characters[i] = '9';
                numberOfChanges += 1;
            }
            else
            {
                characters[i] = numbers[i];
            }
        }

        numbers = new string(characters);
        return int.Parse(numbers);
    }
}