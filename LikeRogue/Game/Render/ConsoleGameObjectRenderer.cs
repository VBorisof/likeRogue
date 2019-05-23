using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using LikeRogue.Extensions;
using LikeRogue.Game.GameObjects;
using LikeRogue.Game.GameObjects.Model;

namespace LikeRogue.Game.Render
{
    public class ConsoleGameObjectRenderer : IGameObjectRenderer
    {
        private string _screen;
        
        public ConsoleGameObjectRenderer()
        {
            _screen = string.Join("",
                // Generate the screen
                Enumerable.Repeat(
                    // Generate a line
                    string.Join("", Enumerable.Repeat(".", Console.WindowWidth)), 
                    Console.WindowHeight
                )
            );
        }
        
        
        public void Render(GameObject gameObject)
        {
            if (!gameObject.Position.IsZeroOrPositive()) return;
            Console.SetCursorPosition(gameObject.Position.X, gameObject.Position.Y);
            
            var consoleModel = gameObject.Model as ConsoleModel;
            ConsoleEx.Write(consoleModel.Model, consoleModel.Color);
            
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
        }

        public void Render(IEnumerable<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                if (!gameObject.Position.IsZeroOrPositive()) continue;
                Console.SetCursorPosition(gameObject.Position.X, gameObject.Position.Y);
                
                var consoleModel = gameObject.Model as ConsoleModel;
                ConsoleEx.Write(consoleModel.Model, consoleModel.Color);
            }
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
        }

        public void Clear()
        {
            Console.SetCursorPosition(0,0);
            ConsoleEx.Write(_screen, ConsoleColor.DarkGray);
        }
    }
}