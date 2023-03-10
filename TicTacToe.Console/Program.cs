using TicTacToe.Console;
using TicTacToe.Console.Models;

int selectedValue;
Board board = null;
do
{
    selectedValue = MenuHelper.ShowMenu();

    switch (selectedValue)
    {
        case 0:
            {
                board = Board.StartGame();
                board.PrintBoard();
                while (!board.IsGameFinished)
                {
                    
                    Console.WriteLine("Введите координаты для X (пример - 0,1)");

                    int[] values = MakeStep(board);
                    if (board.IsGameFinished)
                    {
                        Console.WriteLine("Нажмите кнопку что-бы продолжить...");
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine("Введите координаты для O (пример - 0,0)");

                    values = MakeStep(board);
                    if (board.IsGameFinished)
                    {
                        Console.WriteLine("Нажмите кнопку что-бы продолжить...");
                        Console.ReadLine();
                        break;
                    }
                    board.PrintBoard();
                    board.FreeCoordinates();
                }
            }
            break;
    }
} while (true);

int[] MakeStep(Board board)
{
    var values = Console.ReadLine()
        .Split(',')
        .Select(x => int.Parse(x))
        .ToArray();

    board.Put(new Coord(values[0], values[1]));
    board.Winner();
    return values;
}