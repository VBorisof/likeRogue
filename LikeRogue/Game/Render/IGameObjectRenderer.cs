using System.Collections.Generic;
using LikeRogue.Game.GameObjects;

namespace LikeRogue.Game.Render
{
    public interface IGameObjectRenderer
    {
        void Render(GameObject gameObject);
        void Render(IEnumerable<GameObject> gameObjects);
        void Clear();
    }
}