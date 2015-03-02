using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
public sealed class ReverseComparer<T> : IComparer<T>
{
    private readonly IComparer<T> original;

    public ReverseComparer(IComparer<T> original)
    {
        // TODO: Validation
        this.original = original;
    }

    public int Compare(T left, T right)
    {
        return original.Compare(right, left);
    }
}
class RelevanceIndex
{
    static char[] punctuationMarks = new char[] { ',', '.', '(', ')', ';', '-', '!', '?', ' ' };
    static void Main()
    {
        //INPUT
        string key = Console.ReadLine().ToLower();
        string pattern = string.Format(@"\b{0}\b", key);
        var paragraphs = new SortedDictionary<int, List<string>>(new ReverseComparer<int>(Comparer<int>.Default));

        int numberOfParagraphs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfParagraphs; i++)
        {
            string para = string.Join(" ", Console.ReadLine()
                .Split(punctuationMarks, StringSplitOptions.RemoveEmptyEntries));

            para = Regex.Replace(para, pattern, key.ToUpper(), RegexOptions.IgnoreCase);

            int occurrences = Regex.Matches(para, pattern, RegexOptions.IgnoreCase).Count;
            if (!paragraphs.ContainsKey(occurrences))
            {
                paragraphs.Add(occurrences, new List<string>());
                paragraphs[occurrences].Add(para);

            }
            else
            {
                paragraphs[occurrences].Add(para);
            }
        }

        var allParagraphs = paragraphs.SelectMany(x => x.Value);
        //OUTPUT
        foreach (var para in allParagraphs)
        {
            Console.WriteLine(para);
        }
    }
}