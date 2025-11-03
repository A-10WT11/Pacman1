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
    public abstract class GameObject
    {
        protected Vector2 pos;
        protected Texture2D tex;

        public GameObject(Vector2 pos, Texture2D tex)
        {
            this.pos = pos;
            this.tex = tex;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
            //spriteBatch.Draw(tex, pos, Color.White);
        }
    }
}
