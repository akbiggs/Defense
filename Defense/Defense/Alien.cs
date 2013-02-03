using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Defense
{
    public class Alien : GameObject
    {
        const int SIZE_X = 30;
        const int SIZE_Y = 30;

        const int BASE_HEALTH = 2;

        public Alien(World world, Vector2 position, Vector2 initialSpeed)
            : base(world, position, initialSpeed, new Vector2(SIZE_X, SIZE_Y), ResourceManager.GetTexture("Pixel"), true, BASE_HEALTH)
        {

        } 

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spr)
        {
            base.Draw(spr);
        }
    }
}
