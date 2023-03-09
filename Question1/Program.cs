// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

Console.WriteLine("Arrays vs LinkedList");
Console.WriteLine();
Console.WriteLine("Arrays");
//An array is a collection of elements of a similar data type.
//Array elements can be accessed randomly using the array index.

//Array declaration and its storaged values.
int[] myNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//Printing array through foreach loop
foreach(int number in myNumbers)
{
    Console.Write($"{number} ");
}

Console.WriteLine();
Console.WriteLine("\nLinkedList");
//Random accessing is not possible in linked lists. The elements will have to be accessed sequentially.
//Linked List is an ordered collection of elements of the same type in which each element is connected to the next using pointers.

LinkedList<int> myLinkedList = new LinkedList<int>();
//Using AddLast to add values at the end of our LinkedList.
myLinkedList.AddLast(20);
myLinkedList.AddLast(30);
myLinkedList.AddLast(40);

//Printing our linked list.
foreach(var list in myLinkedList) 
{
    Console.Write($"{list} ");
}

Console.WriteLine();
Console.WriteLine("\nLinkedList updated");
//Using AddFirst to add values at the beggining of our LinkedList.
myLinkedList.AddFirst(50);
myLinkedList.AddLast(60);
myLinkedList.AddLast(70);
//Printing our linked list with new values added.
foreach (var list in myLinkedList)
{
    Console.Write($"{list} ");
}

Console.WriteLine("\n");
Console.WriteLine("Stack vs Queue");
Console.WriteLine();

//A stack is referred to as a last-in, first-out (LIFO).
Console.WriteLine("Generating our Stack");
Stack<string> myNames = new Stack<string>();
//The primary operations to manipulate a stack are push and pop.
//Operation push adds a new node to the top of the stack.
myNames.Push("Johan");
myNames.Push("Chritine");
myNames.Push("Leidy");
//Printing values stored in our stack
foreach (var name in myNames)
{
    Console.Write($"{name} ");
}
Console.WriteLine();
//Operation pop removes a node from the top of the stack and returns the data item from the popped node.
Console.WriteLine("\nUsing pop for deleting the first element in our stack");
myNames.Pop();
foreach (var name in myNames)
{
    Console.Write($"{name} ");
}

Console.WriteLine();
Console.WriteLine("\nUsing clear for removing all element in our stack");
//Clear help us to delete all elements in our stack
myNames.Clear();
//Printing an empty stack
foreach (var name in myNames)
{
    Console.Write($"{name} ");
}



Console.WriteLine();
//A queue is a first-in, first-out (FIFO)data structure.
Console.WriteLine("Creating our Queue");
Queue<double> price = new Queue<double>();
//The insert and remove operations are known as enqueue and dequeue.
//Using Enqueue to add values into our Queue
price.Enqueue(89.6);
price.Enqueue(80.5);
price.Enqueue(79.689);
price.Enqueue(105.11);
//Printing our queue
foreach (var list in price)
{
   Console.WriteLine($"{list} ");
}
Console.WriteLine();
Console.WriteLine("Using dequeue for removing the first item in our Queue");
//Deleting our first element of the queue
price.Dequeue();
foreach (var list in price)
{
    Console.WriteLine($"{list} ");
}


Console.WriteLine();
//Allows you to use constraints to restrict client code to specify certain types while instantiating generic types.
Console.WriteLine("Type Constraint");

ShowPerson<string>("Johan", 20, "Male");

static void ShowPerson<T>(T name, int age, T gender) 
{
    Console.WriteLine($"Name: {name} \nAge: {age} \nGender: {gender}");
}
Console.ReadKey();


