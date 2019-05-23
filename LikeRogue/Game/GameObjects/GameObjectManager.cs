using System;
using System.Collections.ObjectModel;
using System.Linq;
using LikeRogue.Extensions;

namespace LikeRogue.Game.GameObjects
{
    public class GameObjectManager
    {
        public EventHandler NeedRedraw { get; set; }
        public EventHandler NeedRedrawOne { get; set; }
        public ObservableCollection<GameObject> GameObjects { get; } = new ObservableCollection<GameObject>();

        public GameObjectManager()
        {
            GameObjects.CollectionChanged += (sender, args) =>
            {
                args.NewItems.OfType<GameObject>().ForEach(ni => ni.Moved += (o, eventArgs) =>
                    {
                        NeedRedraw(o, eventArgs);
                    }
                );
                args.NewItems.OfType<GameObject>().ForEach(ni => ni.Updated += (o, eventArgs) =>
                    {
                        NeedRedrawOne(o, args);
                    }
                );
            };
        }
    }
}