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
    public class Cheese : GameObject
    {
       

        private Rectangle rec;
        private bool isEaten;

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

        public Cheese(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
           

            this.rec = new Rectangle((int)pos.X, (int)pos.Y, Game1.tileSize, Game1.tileSize);
            this.isEaten = false;
        }

        public void ChangeIsEaten()
        {
            isEaten = true;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(tex, pos, Color.White);
            if (!isEaten)
            {
                spriteBatch.Draw(tex, rec, Color.White);
            }
            
        }

    }
}
