using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Defense
{
    public class World
    {

        public Player Player;
        public List<Alien> Aliens = new List<Alien>();

        public float Gravity = 0.75f;
        int width, height;

        public int BaseHeight = 200;

        public World(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        internal void Update()
        {
            foreach (Alien alien in Aliens)
                alien.Update();
        }

        internal void Draw(SpriteBatch spr)
        {
        }
    }
}
