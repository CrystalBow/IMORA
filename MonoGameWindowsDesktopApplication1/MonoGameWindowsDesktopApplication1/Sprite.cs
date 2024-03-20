using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;

namespace Imora
{
    internal class Sprite : Component
    {
        private Texture2D texture;
        private Vector2 scale;
        private bool visible;
        private SpriteBatch spriteBatch;
        private Color modulate;

        private bool hasTransform;
        private Transform transform;

        public Vector2 Scale { get => scale; set => scale = value; }
        public Color Modulate { get => modulate; set => modulate = value; }
        public bool Visible { get => visible; set => visible = value; }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture)
        {
            this.texture = texture;
            this.scale = Vector2.One;
            this.spriteBatch = spriteBatch;
            this.modulate = Color.White;
            this.Visible = true;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, float scaleX, float scaleY)
        {
            this.texture = texture;
            this.scale = new Vector2(scaleX, scaleY);
            this.spriteBatch = spriteBatch;
            this.modulate = Color.White;
            this.Visible = true;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Color modulate, float scaleX, float scaleY)
        {
            this.texture = texture;
            this.scale = new Vector2(scaleX, scaleY);
            this.spriteBatch = spriteBatch;
            this.modulate = modulate;
            this.Visible = true;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Color modulate)
        {
            this.texture = texture;
            this.scale = Vector2.One;
            this.spriteBatch = spriteBatch;
            this.modulate = modulate;
            this.Visible = true;
        }

        public override void Ready()
        {
            hasTransform = Owner.HasComponent<Transform>();
            if (hasTransform)
            {
                transform = Owner.GetComponent<Transform>();
            }
        }

        public override void onComponentRemove(Component component)
        {
            if (component.GetType() != typeof(Transform)) 
            {
                return;
            }
            hasTransform = false;
            transform = null;
        }

        public void Draw()
        {
            if (!Visible)
            {
                return;
            }
            if (hasTransform) 
            {
                spriteBatch.Draw(texture, new Rectangle((int)transform.Position.X, (int)transform.Position.Y, 16 * (int)scale.X, 16 * (int)scale.Y), modulate);
                return;
            }
            spriteBatch.Draw(texture, new Rectangle(0, 0, 16 * (int)scale.X, 16 * (int)scale.Y), modulate);
        }
    }
}
