using System;
using LikeRogue.Game.GameObjects.Model;
using LikeRogue.Game.Render;
using LikeRogue.Math;

namespace LikeRogue.Game.GameObjects
{
    public class GameObject : IRenderable
    {
        public Vector2i Position { get; set; }
        public EventHandler Moved { get; set; }
        public EventHandler Updated { get; set; }
        
        public virtual IModel Model =>
            new ConsoleModel
            {
                Color = ConsoleColor.White,
                Model = "#"
            };

        public void Move(Vector2i velocity)
        {
            Position += velocity;
            OnMove();
        }

        public void CastSpell(Spell spell)
        {
            
        }
        
        public virtual void Play() { }
        
        public virtual void Pause() { }


        public void OnMove()
        {
            Moved(this, null);
        }
        
        public void OnUpdate()
        {
            Updated(this, null);
        }
    }
}