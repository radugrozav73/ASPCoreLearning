using static Rover.Rover;

Console.SetCursorPosition(0, 0);
Console.Write("Please enter the number of columns and rows(bigger than 3): ");
int size;
while (true)
{
    size = int.Parse(Console.ReadLine());

    if (size < 3)
    {
        Console.WriteLine("Please enter a size bigger than 3");
    }
    else
    {
        break;
    }
}
Rover.Rover rover = new Rover.Rover(size);

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape) break;
    Console.Clear();
    rover.Move(key);
}