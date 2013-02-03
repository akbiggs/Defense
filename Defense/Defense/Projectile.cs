using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Defense
{
    public class Projectile : GameObject
    {
        const int SIZE_X = 10;
        const int SIZE_Y = 30;
        public Vector2 Direction;

        public Projectile(World world, Vector2 position, Vector2 direction, Vector2 speed)
            : base(world, position, speed, new Vector2(SIZE_X, SIZE_Y), ResourceManager.GetTexture("Pixel"), true, false, 1)
        {

        }

        public override void HitAgainstGround()
        {
            base.HitAgainstGround();
            World.Projectiles.BufferRemove(this);
        }

        public override void HitAgainstWall()
        {
            base.HitAgainstWall();
            World.Projectiles.BufferRemove(this);
        }
    }
}
