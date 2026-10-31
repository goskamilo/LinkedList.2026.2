using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter value: ");
            list.Add(Console.ReadLine()!);
            break;
        case "2":
            Console.WriteLine(list.ToStringForward());
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;
        case "4":
            list.OrderDescending();
            Console.WriteLine("List ordered in descending order.");
            break;
        case "5": 
           Console.WriteLine(list.GetModes());
            break;
        case "6":
            Console.WriteLine(string.Join("\n", list.GetGraph()));
            break;

        case "7":
            Console.WriteLine("Enter value to search: ");
            if(list.Contains(Console.ReadLine()!))
            {
                Console.WriteLine("Exist");
            }
            else
            {
                Console.WriteLine("Not Exist");
            }

            break;

        /*case "4*":
            Console.Write("Enter value: ");
            var itemToRemove = Console.ReadLine()!;
            if (!list.Contains(itemToRemove))
            {
                Console.WriteLine($"Item: ´{itemToRemove}´ not exists in the list.");
                break;
            }
            list.Remove(itemToRemove);
            Console.WriteLine($"Item: ´{itemToRemove}´ removed.");
            break;*/
        case "8":
            var datoEliminado = list.RemoveFirst();
            if (datoEliminado != null && !datoEliminado.Equals(default))
            {
                Console.WriteLine($"Se ha eliminado el primer elemento de la lista: {datoEliminado}");
            }
            else
            {
                Console.WriteLine("La lista está vacía, no hay elementos para eliminar.");
            }
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. TO ADD");
    Console.WriteLine("2. Show Forward list.");
    Console.WriteLine("3. Show Reverse list.");
    Console.WriteLine("4. Order Descending.");
    Console.WriteLine("4. Remove."); 
    Console.WriteLine("5. mode"); // Homework!
    Console.WriteLine("6. Graphis"); // Homework! ask for item to insert and ask for previous item
    Console.WriteLine("7. Exist"); // Homework! order alphabetically
    Console.WriteLine("8. Remove first occurrence.");
    Console.WriteLine("9. Show reverse list.");
    Console.WriteLine("0. Exit.");
    Console.Write("Enter your option? ");
    return Console.ReadLine()!;
}
