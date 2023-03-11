namespace TicTacToe.Api.Models.Errors.Exceptions
{
    public class PositionIsNotNullException : Exception
    {
        public PositionIsNotNullException(int xCord,int yCord) 
            : base($"Координата с позицией x - {xCord} и y - {yCord} занята")
        {
        }
    }
}
