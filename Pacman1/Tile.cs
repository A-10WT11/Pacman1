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
    public class Tile : GameObject
    {
      
        private bool notWalkable;

        //public bool GetNotWalkable()
        //{
        //    return notWalkable;
        //}

        //public void SetNotWalkable(bool notWalkable)
        //{
        //    this.notWalkable = notWalkable;
        //}

        public bool NotWalkable 
        {
            get 
            {
                return notWalkable;
            }
            //set
            //{
            //    notWalkable = value;
            //}
        }


        public Tile(Vector2 pos, Texture2D tex, bool notWalkable) : base(pos, tex)
        {
          
            this.notWalkable = notWalkable;
        }
    }
}
