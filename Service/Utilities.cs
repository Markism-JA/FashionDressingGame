using System.Reflection;

namespace FashionDressingGame;

public static class Utilities
{
    public static Dictionary<int, TKey> CreateSequentialDictionary<TKey, TValue>(Dictionary<TKey, TValue> source)
    {
        var newDictionary = new Dictionary<int, TKey>();
        var values = source.Keys.ToList();
        for (int i = 0; i < values.Count; i++)
        {
            int key = i + 1;
            newDictionary[key] = values[i];
        }
        return newDictionary;
    }


    public static string QueryDictionary(Dictionary<int, string> source, int input)
    {
        return source.ContainsKey(input) ? source[input] : throw new KeyNotFoundException();
    }

    public static bool AskYesNo(string x)
    {
        Console.Write($"\nAdd {x} (y/n): ");
        string input = Console.ReadLine().ToLower();
        return input == "y"? true : false;
    }

    public static string Display(Dictionary<string, Grade> x, string title)
    {
        Console.WriteLine($"\n{title}:");
        Dictionary<int, string> y = CreateSequentialDictionary(x);
        foreach (var elements in y)
        {
            Console.WriteLine($"[{elements.Key}] {elements.Value}");
        }

        Console.Write(": ");
        return QueryDictionary(y, int.Parse(Console.ReadLine()));
    }

    public static string Display(Dictionary<int, string> x, string title)
    {
        Console.WriteLine($"\n{title}:");
        foreach (var elements in x)
        {
            Console.WriteLine($"[{elements.Key}] {elements.Value}");
        }
        
        Console.Write(": ");
        return QueryDictionary(x, int.Parse(Console.ReadLine()));
    }

    public static string Display(string title)
    {
        Console.Write($"\n{title}: ");
        return Console.ReadLine();
    }
    
    public static List<TValue> ConvertDictionaryValuesToList<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
    {
        return new List<TValue>(dictionary.Values);
    }
    
    
}