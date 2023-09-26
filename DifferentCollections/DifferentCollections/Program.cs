using System.Linq;

namespace DifferentCollections;
class Program
{
    private static void Main(string[] args)
    {
        List<object> mixedList = new List<object> { "Random text", 123, "More random things", '!', "Smth", 56, '%', 0, "String", '^', 143.3f, '#', 76.4f };
        //List<string> Strings = new List<string>();
        List<string> text = mixedList.OfType<string>().ToList();
        List<int> ints = mixedList.OfType<int>().ToList();
        List<float> floats = mixedList.OfType<float>().ToList();
        List<char> symbols = mixedList.OfType<char>().Where(c => !char.IsLetterOrDigit(c)).ToList();


        string joinedMixed = string.Join(" ; ", mixedList);
        Console.WriteLine(joinedMixed);

        int countText = 0;
        int countInts = 0;
        int countFloats = 0;
        int countSymbols = 0;
        int sumInts = 0;
        float sumFloats = 0;

        ints.Sort();
        floats.Sort();

        Console.WriteLine('\n');
        Console.WriteLine("Strings:");
        string joinedText = string.Join<string>(" ; ", text);
        Console.WriteLine(joinedText);
        countText = text.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Ints:");

        var joinedInt = string.Join<int>(" ; ", ints);
        Console.WriteLine(joinedInt);
        foreach (int i in ints) sumInts += i;
        countInts = ints.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Floats:");

        string joinedFloat = string.Join(" ; ", floats);
        Console.WriteLine(joinedFloat);
        foreach (float i in floats) sumFloats += i;
        countFloats = floats.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Symbols:");

        string joinedSymbols = string.Join<char>(" ; ", symbols);
        Console.WriteLine(joinedSymbols);
        countSymbols = symbols.Count();

        Console.WriteLine('\n');

        Console.WriteLine($"Count of strings: {countText}");
        Console.WriteLine($"Count of ints: {countInts} \t sum is: {sumInts}");
        Console.WriteLine($"Count of floats: {countFloats} \t sum is: {sumFloats:0.00}");
        Console.WriteLine($"Count of symbols: {countSymbols}");
    }
}