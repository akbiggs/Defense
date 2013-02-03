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

            Player = new Player(this, Vector2.Zero);
            Player.Left = width / 2 - Player.Size.X / 2;
            Player.Bottom = BaseHeight;
        }

        internal void Update()
        {
            foreach (Alien alien in Aliens)
                alien.Update();
            foreach (Projectile projectile in Projectiles)
                projectile.Update();

            Player.Update();

            Aliens.ApplyBuffers();
            Projectiles.ApplyBuffers();
        }

        internal void Draw(SpriteBatch spr)
        {
            spr.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            DrawFireLine(spr);
            foreach (Alien alien in Aliens)
                alien.Draw(spr);
            foreach (Projectile projectile in Projectiles)
                projectile.Draw(spr);
            
            Player.Draw(spr);

            spr.End();
        }

        private void DrawFireLine(SpriteBatch spr)
        {
            spr.Draw(ResourceManager.GetTexture("Pixel"), new Rectangle(0, (int)Engine.ScreenResolution.Y - BaseHeight - Player.FIRE_OFFSET, (int)Engine.ScreenResolution.X, 2), Color.Red);
        }
    }
}
