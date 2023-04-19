﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static bool operator >(Vector2 a, Vector2 b) => (a.x > b.x) && (a.y > b.y);
        public static bool operator <(Vector2 a, Vector2 b) => (a.x < b.x) && (a.y < b.y);
    }
}
