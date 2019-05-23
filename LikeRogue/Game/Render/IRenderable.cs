using LikeRogue.Game.GameObjects;
using LikeRogue.Game.GameObjects.Model;

namespace LikeRogue.Game.Render
{
    public interface IRenderable
    {
        IModel Model { get; }
    }
}