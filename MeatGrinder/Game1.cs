using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MeatGrinder
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "Jerma Extermination Revolution Millitary Assault Meat Explosion Arctic Torment Glory Reloaded Insanity Nuclear Dracula Extreme 2.0 Reloaded [The Sequal]";
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            IsMouseVisible = false;
            
            
            base.Initialize();
        }
        
        
        Vector2 cursorPosition = Vector2.Zero;
        int activeCursor;
        private List<Cursor> ratCursors;


        private void AddRats(string[] names, float offsetX = 0.5f, float offsetY = 0.5f)
        {
            string rat = "Rat Cursor/blackrat_";
            foreach (var name in names) { ratCursors.Add( new Cursor(Content, rat+name, offsetX,offsetY) ); }
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            ratCursors = new List<Cursor>();

            AddRats(new [] {"alt"}, 0.5f, 0f);
            AddRats(new [] {"write"}, 0f,0f);
            AddRats(new [] {"help"}, 0.2f,0.2f);
            AddRats(new [] {"no"}, 0.25f,0.6f);
            AddRats(new [] {"link","norm"}, 0f,0.6f);
            AddRats(new [] {"diag1","diag2","horz","move","precise","text","vert"});



            activeCursor = 0;
            
            

        }


        private bool clickBuffer;
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            cursorPosition = Mouse.GetState().Position.ToVector2();

            
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!clickBuffer) if (activeCursor++ >= ratCursors.Count-1) activeCursor = 0;
                clickBuffer = true;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                if (!clickBuffer) if (activeCursor-- <= 0) activeCursor = ratCursors.Count - 1;
                clickBuffer = true;
            }
            
            
            if (Mouse.GetState().LeftButton != ButtonState.Pressed && Mouse.GetState().RightButton != ButtonState.Pressed) clickBuffer = false;
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap);

            
            //new Vector2(blackrat_alt.Width / 2f, 0f)
            _spriteBatch.Draw(ratCursors[activeCursor].GetTexture(),
                cursorPosition - ratCursors[activeCursor].GetOffset(), Color.White);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}