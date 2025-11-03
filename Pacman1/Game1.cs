using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Pacman1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize = 50;

        public MousePlayer player;
        private Cheese cheese;
        private Enemy enemy;

        Tile tile;

        private List<MovingGameObject> allMovingGameObjectsObjects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);

            allMovingGameObjectsObjects = new List<MovingGameObject>();

            CreateLevel(@"maze.txt");

            // TODO: use this.Content to load your game content here
        }

        public List<string> ReadFromFile(string maze)
        {
            StreamReader sr = new StreamReader(maze);
            
            List<string> result = new List<string>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                result.Add(line);
            }
            sr.Close();
            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> level = ReadFromFile(fileName);

            tileArray = new Tile[level[0].Length, level.Count];

            for (int i = 0; i < level.Count; i++)
            {
                for (int j = 0; j < level[0].Length; j++)
                {
                    if (level[i][j] == 'w')
                    {
                        tile = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.walltileTex, true);
                        tileArray[j, i] = tile;
                        //allObjects.Add(tile);
                    }
                    else
                    {
                        tile = new Tile(new Vector2(j * tileSize, i * tileSize), TextureManager.floortileTex, false);
                        tileArray[j, i] = tile;
                        //allObjects.Add(tile);
                    }


                    if (level[i][j] == 'p')
                    {
                        player = new MousePlayer(new Vector2(j * tileSize, i * tileSize), TextureManager.mouseSmallTex);
                        allMovingGameObjectsObjects.Add(player);
                    }
                    else if (level[i][j] == 'e')
                    {
                        enemy = new Enemy(new Vector2(j * tileSize, i * tileSize), TextureManager.emptyTex);
                        allMovingGameObjectsObjects.Add(enemy);
                    }
                    else if (level[i][j] == 'c')
                    {
                        cheese = new Cheese(new Vector2(j * tileSize, i * tileSize), TextureManager.cheeseTex);
                        //allObjects.Add(cheese);
                    }
                }
            }
        }

        public static bool GetTileAtPosition(Vector2 pos)
        {
            //return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].notWalkable;
            //return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].GetNotWalkable();
            return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].NotWalkable;
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //player.Update(gameTime);
            //enemy.Update(gameTime);

            foreach (MovingGameObject mgo in allMovingGameObjectsObjects)
            {
                mgo.Update(gameTime);
            }

            if (player.Rec.Intersects(cheese.Rec))
            {
                cheese.ChangeIsEaten();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //foreach (GameObject gameObject in allObjects) 
            //{
            //    gameObject.Draw(spriteBatch);
            //}


            foreach (Tile tile in tileArray)
            {
                tile.Draw(spriteBatch);
            }

            cheese.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
