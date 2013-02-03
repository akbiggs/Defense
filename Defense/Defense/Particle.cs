using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Defense
{
    public class Particle
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public int Life;
        int lifeCounter = 0;
        public Vector2 Size;
        public Color Color;

        public Particle(Vector2 position, Vector2 speed, int life, Color color, Vector2 size)
        {
            this.Position = position;
            this.Velocity = speed;
            this.Life = life;
            this.Size = size;
            this.Color = color;
        }

        public virtual void Update()
        {
            Position += Velocity;

        }

        public virtual void Draw(SpriteBatch spr)
        {
            spr.Draw(ResourceManager.GetTexture("Pixel"), new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color);
        }
    }
}
