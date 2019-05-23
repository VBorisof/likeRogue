using System;
using System.Threading;
using LikeRogue.Game.GameObjects;
using LikeRogue.Math;

namespace LikeRogue.Game
{
    public class KeyboardController
    {
        private Thread _pollThread;
        private GameObject _subject;

        public KeyboardController(GameObject subject)
        {
            _subject = subject;
            _pollThread = new Thread(() =>
            {
                while (true)
                {
                    Process(Console.ReadKey(intercept: true));
                }
            });
        }

        public void BeginPollLoop()
        {
            if (!_pollThread.IsAlive)
            {
                _pollThread.Start();
            }
        }

        public void StopPollLoop()
        {
            if (_pollThread.IsAlive)
            {
                _pollThread.Abort();
            }
        }
        
        public void Process(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.W:
                    _subject.Move(new Vector2i{ Y = -1 });
                    break;
                case ConsoleKey.A:
                    _subject.Move(new Vector2i{ X = -1 });
                    break;
                case ConsoleKey.S:
                    _subject.Move(new Vector2i{ Y = 1 });
                    break;
                case ConsoleKey.D:
                    _subject.Move(new Vector2i{ X = 1 });
                    break;
            }
        }
    }
}