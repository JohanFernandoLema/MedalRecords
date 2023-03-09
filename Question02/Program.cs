// See https://aka.ms/new-console-template for more information
using System.Text;

public static class StringBuilderExtensions
{
    public static void Main(string[] args)
    {
        //We create the StringBuilder variable with the respective message that we want to print.
        StringBuilder sb = new StringBuilder("This is to test whether the extension method count can return a right answer or not");

        //We print the message with the method to count the number of words.
        Console.WriteLine($"Number of words in {sb} is {sb.WordsCount()}");

        Console.ReadKey();
    }
    //We need to extend the class, to do that we use the "this" keyword.
    public static int WordsCount(this StringBuilder sb)
    {
        //We use the split method to separate our string message.
        return sb.ToString().Split(' ').Length;
    }
    
}
