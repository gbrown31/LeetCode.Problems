using System.Text;

namespace Stacks;

public class Stacks
{
    public string SimplifyPath(string path)
    {
        Stack<string> pathToReturn = new Stack<string>();
        string[] pathParts = path.Split('/');
        foreach (string segment in pathParts)
        {
            if (!string.IsNullOrEmpty(segment))
            {
                if (segment == "..")
                {
                    if (pathToReturn.Count > 0)
                    {
                        pathToReturn.Pop();
                    }
                }
                else if (segment != ".")
                {
                    pathToReturn.Push(segment);
                }
            }
        }

        string sReturnPath = "";
        while (pathToReturn.Count > 0)
        {
            string pathSegment = pathToReturn.Pop();
            if (string.IsNullOrEmpty(sReturnPath))
            {
                sReturnPath = pathSegment;
            }
            else
            {
                sReturnPath = pathSegment + "/" + sReturnPath;
            }
        }

        return "/" + sReturnPath;
    }

    public string MakeGood(string s)
    {
        // loop over all the characters in the string
        Stack<char> characters = new Stack<char>();
        foreach (char a in s)
        {
            if (characters.Count > 0 && Math.Abs(characters.Peek() - a) == 32)
            {
                characters.Pop();
            }
            else
            {
                characters.Push(a);
            }
        }

        string word = "";
        while (characters.Count > 0)
        {
            word = characters.Pop() + word;
        }

        return word;
    }
}