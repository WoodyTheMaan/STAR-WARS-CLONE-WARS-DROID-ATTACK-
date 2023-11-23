using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace STAR_WARS_CLONE_WARS_DROID_ATTACK_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle cloneTrooperRect, blastShotRect;
        Texture2D titleScreenImage, cloneTrooper, b1BattleDroid, b1BattleDroidBroken, blastShot;
        SoundEffectInstance menuMusic, mainTheme;
        Screen screen;
        MouseState mouseState;
        Vector2 cloneTrooperSpeed, blastShotSpeed;
        bool blast;
        int grow;
        enum Screen
        {
            Intro,
            battleFeild
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            cloneTrooperRect = new Rectangle(-200, -300, -70, 50);
            cloneTrooperSpeed = new Vector2(1, 1);
            blastShotRect = new Rectangle(200,75,200,20);
            blastShotSpeed = new Vector2(2, 1);
            grow = 1;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            titleScreenImage = Content.Load<Texture2D>("STAR WARS CLONE WARS MENU");
            menuMusic = Content.Load<SoundEffect>("Starwars THEME").CreateInstance();
            b1BattleDroid = Content.Load<Texture2D>("B1_Battle_Droid");
            b1BattleDroidBroken = Content.Load<Texture2D>("Deddrodmanman");
            blastShot = Content.Load<Texture2D>("Blast1");
            cloneTrooper = Content.Load<Texture2D>("CLONE TROOPER FOR GAME");
            mainTheme = Content.Load<SoundEffect>("MainTheme").CreateInstance();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();


            if (screen == Screen.Intro)
            {
                menuMusic.Play();
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.battleFeild;

            }
            else if (screen == Screen.battleFeild)
            {
                menuMusic.Pause();
                mainTheme.Play();
                cloneTrooperRect.X += (int)cloneTrooperSpeed.X;
                cloneTrooperRect.Y += (int)cloneTrooperSpeed.Y;
                cloneTrooperRect.Width += grow;
                cloneTrooperRect.Height += grow;
                if (cloneTrooperRect.X == 100)
                {
                    cloneTrooperSpeed.X = 0;
                    cloneTrooperSpeed.Y = 0;
                    grow = 0;
                    blast = true;
                }
                if (blast)
                {
                    blastShotRect.X += (int)blastShotSpeed.X;
                    blastShotRect.Y += (int)blastShotSpeed.Y;
                    if(blastShotRect.X == 500)
                    {
                        blastShotSpeed.X = 0;
                        blastShotSpeed.Y = 0;
                        blast = false;
                        b1BattleDroid = b1BattleDroidBroken;
                        
                    }

                }

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(titleScreenImage, new Rectangle(0, 0, 800, 600), Color.White);
            }
            else if (screen == Screen.battleFeild)
            {
                _spriteBatch.Draw(cloneTrooper, cloneTrooperRect, Color.White);
                _spriteBatch.Draw(b1BattleDroid, new Rectangle(560, 120, 200, 380), Color.White);
                if (blast)
                    _spriteBatch.Draw(blastShot, blastShotRect, Color.White);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}