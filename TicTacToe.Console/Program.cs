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

                    MakeStep(board);

                    if (board.IsGameFinished)
                    {
                        Console.WriteLine("Нажмите кнопку что-бы продолжить...");
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine("Введите координаты для O (пример - 0,0)");

                    MakeStep(board);

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

void MakeStep(Board board)
{
    bool isInputCorrect = false;
    while (!isInputCorrect)
    {
        try
        {
            var values = Console.ReadLine()
            .Split(',')
            .Select(x => int.Parse(x))
            .ToArray();

            board.Put(xCord: values[0], yCord: values[1]);
            board.Winner();

            isInputCorrect = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неправильный формат ввода координаты. Попробуй еще раз");
        }
    }
}