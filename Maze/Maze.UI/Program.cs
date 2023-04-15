using Maze.Logic;

try
{
    Console.WriteLine("****** Maze Game ******\n");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    var maze = new MyMaze(30, 100);
    Console.Write(maze);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("\n");
    Console.WriteLine("Presione una tecla para dibujar el camino ...\n");
    Console.ReadKey();

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    var maze2 = new MyMaze(30, 100);
    Console.Write(maze);
    Console.BackgroundColor = ConsoleColor.Black;
}
catch (Exception exception)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(exception.Message);
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    var maze = new MyMaze(30, 100);
    Console.Write(maze);
}

