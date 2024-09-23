using System;
using GamePublic;

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