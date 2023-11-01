using System.Linq;

namespace DifferentCollections;
class Program
{
    private static void Main(string[] args)
    {
<<<<<<< HEAD
        List<object> mixedList = new List<object> {"Random text", 123, "More random things", '!', "Smth", 56, '%', 0, "String", '^' , 143.3f, '#', 76.4f};
=======
        List<object> mixedList = new List<object> { "Random text", 123, "More random things", '!', "Smth", 56, '%', 0, "String", '^', 143.3f, '#', 76.4f };
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        //List<string> Strings = new List<string>();
        List<string> text = mixedList.OfType<string>().ToList();
        List<int> ints = mixedList.OfType<int>().ToList();
        List<float> floats = mixedList.OfType<float>().ToList();
        List<char> symbols = mixedList.OfType<char>().Where(c => !char.IsLetterOrDigit(c)).ToList();

<<<<<<< HEAD
        string joinedMixed = string.Join(" ; ", mixedList);
        Console.WriteLine(joinedMixed);
        
=======

        string joinedMixed = string.Join(" ; ", mixedList);
        Console.WriteLine(joinedMixed);

>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
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
<<<<<<< HEAD
        string joinedText = string.Join(" ; ", text);
=======
        string joinedText = string.Join<string>(" ; ", text);
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        Console.WriteLine(joinedText);
        countText = text.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Ints:");

<<<<<<< HEAD
        var joinedInt = string.Join(" ; ", ints);
        Console.WriteLine(joinedInt);
=======
        var joinedInt = string.Join<int>(" ; ", ints);
        Console.WriteLine(joinedInt);
        foreach (int i in ints) sumInts += i;
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        countInts = ints.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Floats:");
<<<<<<< HEAD
        string joinedFloat = string.Join(" ; ", floats);
        Console.WriteLine(joinedFloat);
        countFloats = floats.Count();
        
        Console.WriteLine('\n');
        Console.WriteLine("Symbols:");
        string joinedSymbols = string.Join(" ; ", symbols);
=======

        string joinedFloat = string.Join(" ; ", floats);
        Console.WriteLine(joinedFloat);
        foreach (float i in floats) sumFloats += i;
        countFloats = floats.Count();

        Console.WriteLine('\n');
        Console.WriteLine("Symbols:");

        string joinedSymbols = string.Join<char>(" ; ", symbols);
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        Console.WriteLine(joinedSymbols);
        countSymbols = symbols.Count();

        Console.WriteLine('\n');

        Console.WriteLine($"Count of strings: {countText}");
<<<<<<< HEAD
        Console.WriteLine($"Count of ints: {countInts} \t sum is: {ints.Sum()}");
        Console.WriteLine($"Count of floats: {countFloats} \t sum is: {floats.Sum():0.00}");
=======
        Console.WriteLine($"Count of ints: {countInts} \t sum is: {sumInts}");
        Console.WriteLine($"Count of floats: {countFloats} \t sum is: {sumFloats:0.00}");
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        Console.WriteLine($"Count of symbols: {countSymbols}");
    }
}