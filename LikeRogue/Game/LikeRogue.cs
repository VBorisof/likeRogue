using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LikeRogue.Game.GameObjects;
using LikeRogue.Game.Render;
using LikeRogue.Math;

namespace LikeRogue.Game
{
    public class LikeRogue
    {
        private bool _running = false;
        private IGameObjectRenderer _renderer;
        private GameObjectManager _gameObjectManager = new GameObjectManager();
        
        public LikeRogue(IGameObjectRenderer renderer)
        {
            _renderer = renderer;
        }
        
        
        public void Run()
        {
            _gameObjectManager.NeedRedraw += (_, __) =>
            {
                _renderer.Clear();
                _renderer.Render(_gameObjectManager.GameObjects);
            };
            
            _gameObjectManager.NeedRedrawOne += (_, __) =>
            {
                _renderer.Render(_ as GameObject);
            };
            
            var gameObjects = new List<GameObject>
            {
                new GameObject
                {
                    Position = new Vector2i
                    {
                        X = 0,
                        Y = 0
                    }
                },
                new GameObject
                {
                    Position = new Vector2i
                    {
                        X = 10,
                        Y = 5
                    }
                },
                new Player
                {
                    Position = new Vector2i
                    {
                        X = 10,
                        Y = 10
                    }
                },
            };
            gameObjects.ForEach(go =>
            {
                _gameObjectManager.GameObjects.Add(go);
                go.Play();
            });
            _renderer.Clear();
            _renderer.Render(gameObjects);

            _running = true;
            while (_running)
            {
                
            }
        }
    }
}