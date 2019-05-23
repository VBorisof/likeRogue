using System;
using LikeRogue.Game;
using LikeRogue.Game.Render;

namespace LikeRogue
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game.LikeRogue(
                renderer: new ConsoleGameObjectRenderer()
            )
            .Run();
        }
    }
}