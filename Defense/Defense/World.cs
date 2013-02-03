using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Defense
{
    public class World
    {

        public Player Player;
        public BufferedList<Alien> Aliens = new BufferedList<Alien>();
        public BufferedList<Projectile> Projectiles = new BufferedList<Projectile>(); 

        public float Gravity = 0.75f;
        int width, height;

        public int BaseHeight = 200;

        public World(int width, int height)
        {
            this.width = width;
            this.height = height;

            Player = new Player(this, new Vector2(width/2, 0));
            Player.Bottom = BaseHeight;
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
