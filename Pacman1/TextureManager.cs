using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman1
{
    public class TextureManager
    {
        public static Texture2D cheeseTex;
        public static Texture2D emptyTex;
        public static Texture2D floortileTex;
        public static Texture2D mouseTex;
        public static Texture2D walltileTex;
        public static Texture2D mouseSmallTex;
        public static Texture2D hammerManSpriteSheetTex;

        public static void LoadTextures(ContentManager content)
        {
            cheeseTex = content.Load<Texture2D>("cheese_02-1");
            emptyTex = content.Load<Texture2D>("empty");
            floortileTex = content.Load<Texture2D>("floortile");
            mouseTex = content.Load<Texture2D>("mouse");
            walltileTex = content.Load<Texture2D>("walltile");
            mouseSmallTex = content.Load<Texture2D>("mouse (1)");
            hammerManSpriteSheetTex = content.Load<Texture2D>("IndianaJones");

        }
    }
}
