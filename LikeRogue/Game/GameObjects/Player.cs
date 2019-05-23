using System;
using LikeRogue.Game.GameObjects.Model;

namespace LikeRogue.Game.GameObjects
{
    public class Player : GameObject
    {
        private KeyboardController _controller;

        public Player()
        {
            _controller = new KeyboardController(this); 
        }

        public override IModel Model =>
            new ConsoleModel
            {
                Model = "@",
                Color = FromNum(DateTime.UtcNow.Second),
            };

        public override void Play()
        {
            _controller.BeginPollLoop();
        }

        public override void Pause()
        {
            _controller.StopPollLoop();
        }

        ConsoleColor FromNum (int num)
        {
            if (num <= 10)
            {
                return ConsoleColor.Blue;
            }
            else if (num <= 20)
            {
                return ConsoleColor.Green;
            }
            else if (num <= 30)
            {
                return ConsoleColor.Cyan;
            }
            else if (num <= 40)
            {
                return ConsoleColor.Magenta;
            }
            else if (num <= 50)
            {
                return ConsoleColor.Black;
            }

            return ConsoleColor.DarkRed;
        }
    }
}