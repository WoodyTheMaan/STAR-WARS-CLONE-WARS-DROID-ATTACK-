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
       Rectangle cloneTrooper;
        Texture2D titleScreenImage;
        SoundEffect menuMusic;
        Screen screen;
        MouseState mouseState;
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
           cloneTrooper = new Rectangle(300, 10, 100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            titleScreenImage = Content.Load<Texture2D>("STAR WARS CLONE WARS MENU");
            menuMusic = Content.Load<SoundEffect>("Starwars THEME");
            cloneTrooper = Content.Load<Rectangle>("CLONE TROOPER FOR GAME");
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
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.battleFeild;

            }
            else if (screen == Screen.battleFeild)
            {
                cloneTrooper.X = mouseState.X;
            }
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}