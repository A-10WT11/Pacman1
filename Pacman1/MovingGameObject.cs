using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman1
{
    public abstract class MovingGameObject : GameObject
    {

        protected Rectangle rec;

        protected Vector2 direction;
        protected float speed;

        protected bool moving;
        protected Vector2 destination;


        public Rectangle Rec
        {
            get
            {
                return rec;
            }
            //set
            //{
            //    notWalkable = value;
            //}
        }

        public MovingGameObject(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            rec = new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize);
            //tex = TextureManager.mouseTex;
            direction = new Vector2(0, 0);
            speed = 200;
            moving = false;
            destination = Vector2.Zero;
        }

        public abstract int NextDirectionInput();
       

        public virtual void Update(GameTime gameTime)
        {


            if (!moving)
            {
                if (NextDirectionInput() == 0)
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (NextDirectionInput() == 1)
                {
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (NextDirectionInput() == 2)
                {
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (NextDirectionInput() == 3)
                {
                    ChangeDirection(new Vector2(0, 1));
                }
            }
            else
            {
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                rec.X = (int)pos.X;
                rec.Y = (int)pos.Y;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * Game1.tileSize;

            if (!Game1.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
        }
    }
}
