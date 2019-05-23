using System.Xml.Linq;

namespace LikeRogue.Math
{
    public class Vector2<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
    }

    public class Vector2i : Vector2<int>
    {
        public static Vector2i operator + (Vector2i lhs, Vector2i rhs)
        {
            return new Vector2i
            {
                X = lhs.X + rhs.X,
                Y = lhs.Y + rhs.Y,
            };
        }
        public static Vector2i operator - (Vector2i lhs, Vector2i rhs)
        {
            return new Vector2i
            {
                X = lhs.X - rhs.X,
                Y = lhs.Y - rhs.Y,
            };
        }

        public bool IsZeroOrPositive()
        {
            return X >= 0 && Y >= 0;
        }
    }
}