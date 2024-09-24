using System;
using Game;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        using (FNAGame game = FNAGame.Instance)
        {
            game.Run();
        }
    }
}