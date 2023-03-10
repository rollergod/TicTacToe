namespace TicTacToe.Console
{
    public static class MenuHelper
    {
        public static int ShowMenu()
        {
            int selectedValue;

            System.Console.Clear();
            System.Console.WriteLine("Привет!");
            System.Console.WriteLine();
            System.Console.Write(
                "Сделайте выбор: \n\n" +
                "[0] Начать игру \n");
            System.Console.WriteLine("-------------------------------");

            var value = System.Console.ReadLine();

            if (!int.TryParse(value, out selectedValue))
            {
                selectedValue = 999;
                System.Console.WriteLine("упс... попробуй еще раз :)");
            }

            return selectedValue;
        }

    }
}
