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
    public class MousePlayer : MovingGameObject
    {
        

        public MousePlayer(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
           
        }

        public override int NextDirectionInput()
        {
            if (KeyMouseReader.KeyPressed(Keys.Up))
            {
                return 0;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Left))
            {
                return 1;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Right))
            {
                return 2;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Down))
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }

        public override void Update(GameTime gameTime) 
        {
            KeyMouseReader.Update();

            base.Update(gameTime);
            
        }

    }
}
