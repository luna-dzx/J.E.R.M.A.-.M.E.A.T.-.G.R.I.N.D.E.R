using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MeatGrinder
{
    public class Cursor
    {
        private Texture2D _texture2D;
        private Vector2 offset;


        public Cursor(ContentManager content, string filepath, float offsetX = 0.5f, float offsetY = 0.5f)
        {
            _texture2D = content.Load<Texture2D>(filepath);
            offset = new Vector2(offsetX * _texture2D.Width, offsetY * _texture2D.Height);
        }

        public Vector2 GetOffset() => offset;
        public Texture2D GetTexture() => _texture2D;


    }
}