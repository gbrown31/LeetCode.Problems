using System.Text;

namespace Backtracking;

public class LetterCombinationsOfPhoneKey
{
    private List<string> answer;
    private readonly Dictionary<char, string> letters = new Dictionary<char, string>()
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "xwyz"},
    };

    private string PhoneDigits;
        

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
        {
            return new List<string>();
        }
        PhoneDigits = digits;
        answer = new List<string>();
        backtrack(0, new StringBuilder());
        return answer;
    }

    private void backtrack(int index, StringBuilder sb)
    {
        if (index == PhoneDigits.Length)
        {
            answer.Add(sb.ToString());
            return;
        }

        string possibleLetters = letters[PhoneDigits[index]];
        foreach (char letter in possibleLetters)
        {
            sb.Append(letter);
            backtrack(index + 1, sb);
            sb.Remove(sb.Length - 1, 1);
        }
    }
}