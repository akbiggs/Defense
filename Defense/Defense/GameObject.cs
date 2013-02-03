using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Defense
{
    public class GameObject
    {
        public World World;

        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Size;
        public Color Color;
        
        public List<AnimationSet> Animations;
        public AnimationSet CurAnimation;
        
        public int Health;

        public bool ShouldCollide = false;

        public float Rotation = 0;

        bool gravitable;

        public float Top { get { return Position.Y; } set { Position = new Vector2(Position.X, value); } }
        public float Bottom { get { return Position.Y + Size.Y; } set { Position = new Vector2(Position.X, value - Size.Y); } }
        public float Left { get { return Position.X; } set { Position = new Vector2(value, Position.Y); } }
        public float Right { get { return Position.X + Size.X; } set { Position = new Vector2(value - Size.X, Position.Y); } }
        public Vector2 Center { get { return new Vector2(Left + Size.X / 2, Top + Size.Y / 2); } }

        public GameObject(World world, Vector2 position, Vector2 initialVelocity, Vector2 size, List<AnimationSet> animations,
            String initialAnimation, bool shouldCollide, bool gravitable, int health)
        {
            this.World = world;
            this.Position = position;
            this.Velocity = initialVelocity;
            this.Size = size;
            this.Animations = animations;
            this.CurAnimation = FindAnimationByName(initialAnimation);
            this.ShouldCollide = shouldCollide;
            this.Health = health;
            this.Color = Color.White;
            this.gravitable = gravitable;
        }

        public GameObject(World world, Vector2 position, Vector2 initialVelocity, Vector2 size, Texture2D texture,
            bool shouldCollide, bool gravitable, int health) : this(world, position, initialVelocity, size, new List<AnimationSet> 
            {
                new AnimationSet("_", texture, 1, texture.Width, 1, false, 0)
            }, "_", shouldCollide, gravitable, health)
        {

        }

        public virtual void Update()
        {
            this.Move();
        }

        public virtual void Move()
        {
            if (gravitable)
                this.Velocity.Y += World.Gravity;
            this.Position += Velocity;

            if (Bottom > Engine.ScreenResolution.Y - World.BaseHeight)
            {
                Bottom = Engine.ScreenResolution.Y - World.BaseHeight;
                HitAgainstGround();
            }

            if (Left < 0)
            {
                Left = 0;
                HitAgainstWall();
            }

            if (Right > Engine.ScreenResolution.X)
            {
                Right = Engine.ScreenResolution.X;
                HitAgainstWall();
            }
        }

        public virtual void HitAgainstGround()
        {
            Velocity.Y = 0;
        }

        public virtual void HitAgainstWall()
        {
            Velocity.X = 0;
        }

        public virtual void Damage(int amount)
        {
            Health -= amount;
        }

        public virtual void Draw(SpriteBatch spr)
        {
            spr.Draw(CurAnimation.GetTexture(), new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y),
                CurAnimation.GetFrameRect(), Color, Rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

        /// <summary>
        ///     Changes the animation being played. Doesn't do anything if called with the name of the currently
        ///     playing animation.
        /// </summary>
        /// <param name="name">The name of the new animation.</param>
        /// <exception cref="System.InvalidOperationException">Specified animation doesn't exist.</exception>
        protected virtual void ChangeAnimation(string name)
        {
            if (!CurAnimation.IsCalled(name))
            {
                AnimationSet newAnimation = FindAnimationByName(name);
                if (newAnimation == null)
                    throw new InvalidOperationException("Specified animation doesn't exist.");
                newAnimation.Reset();
                newAnimation.Update();
                CurAnimation = newAnimation;
            }
        }

        private AnimationSet FindAnimationByName(String name)
        {
            return Animations.First((anim) => anim.IsCalled(name));
        }
    }
}
