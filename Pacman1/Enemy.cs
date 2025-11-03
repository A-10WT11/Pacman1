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
    public class Enemy : MovingGameObject
    {

        private Random random;

        public Enemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            random = new Random();
        }

        public override int NextDirectionInput()
        {
            int randomDirection = random.Next(0, 4);
            return randomDirection;
        }
 
    }
}
