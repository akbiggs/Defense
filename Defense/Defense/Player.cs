using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Defense
{
    public class Player : GameObject
    {
        public static int FIRE_OFFSET = 100;

        const int SIZE_X = 48;
        const int SIZE_Y = 48;

        const int HEALTH = 3;

        const float MOVE_SPEED_X = 10f;
        const float FIRE_SPEED = 10f;

        public Vector2 NextPos = Vector2.Zero;
        public bool ShouldMove
        {
            get { return NextPos != Vector2.Zero; }
        }

        public Player(World world, Vector2 position)
            : base(world, position, Vector2.Zero, new Vector2(SIZE_X, SIZE_Y), ResourceManager.GetTexture("Pixel"), true, HEALTH)
        {

        }

        public override void Update()
        {
            if (Input.ScreenTapped)
            {
                if (Input.TapPosition.Y < Top - FIRE_OFFSET)
                {
                    FireAt(Input.TapPosition);
                }
                else
                    MoveTo(new Vector2(Input.TapPosition.X, Top));
            }

            if (ShouldMove)
            {
                Position = Position.PushTowards(NextPos, new Vector2(MOVE_SPEED_X, 0));
                // are we done moving?
                if (Position == NextPos)
                    NextPos = Vector2.Zero;
            }

            base.Update();
        }

        private void MoveTo(Vector2 vector2)
        {
            NextPos = vector2;
        }

        private void FireAt(Vector2 location)
        {
            Vector2 fireOrigin = new Vector2(Top, Center.X);
            Vector2 direction = Vector2.Normalize(location - fireOrigin);
            World.Projectiles.BufferAdd(new Projectile(World, fireOrigin, direction, direction * FIRE_SPEED));
        }

        public override void HitAgainstGround()
        {
            base.HitAgainstGround();
        }

        public override void HitAgainstWall()
        {
            base.HitAgainstWall();
        }

        public override void Draw(SpriteBatch spr)
        {
            base.Draw(spr);
        }
    }
}
