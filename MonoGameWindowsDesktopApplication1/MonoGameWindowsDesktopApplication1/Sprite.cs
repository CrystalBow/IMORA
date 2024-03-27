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
        private Rectangle source;
        private SpriteEffects _effects;
        private bool flipH;
        

        private bool hasTransform;
        private Transform transform;

        public Vector2 Scale { get => scale; set => scale = value; }
        public Color Modulate { get => modulate; set => modulate = value; }
        public bool Visible { get => visible; set => visible = value; }

        public bool FlipH
        {
            get => flipH;
            set
            {
                flipH = FlipH;
                if (FlipH)
                {
                    _effects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    _effects = SpriteEffects.None;
                }
            }
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source)
        {
            this.texture = texture;
            this.scale = Vector2.One;
            this.spriteBatch = spriteBatch;
            this.modulate = Color.White;
            this.Visible = true;
            this.source = source;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, float scaleX, float scaleY)
        {
            this.texture = texture;
            this.scale = new Vector2(scaleX, scaleY);
            this.spriteBatch = spriteBatch;
            this.modulate = Color.White;
            this.Visible = true;
            this.source = source;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture,Rectangle source, Color modulate, float scaleX, float scaleY)
        {
            this.texture = texture;
            this.scale = new Vector2(scaleX, scaleY);
            this.spriteBatch = spriteBatch;
            this.modulate = modulate;
            this.Visible = true;
            this.source = source;
        }

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, Color modulate)
        {
            this.texture = texture;
            this.scale = Vector2.One;
            this.spriteBatch = spriteBatch;
            this.modulate = modulate;
            this.Visible = true;
            this.source = source;
        }

        public override void Ready()
        {
            hasTransform = Owner.HasComponent<Transform>();
            if (hasTransform)
            {
                transform = Owner.GetComponent<Transform>();
            }
        }

        public override void OnComponentRemove(Component component)
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
                spriteBatch.Draw(texture, transform.Position,source, modulate, transform.GetRotationDegrees(), 8 * Vector2.One, scale, _effects, 1);
                return;
            }
            spriteBatch.Draw(texture, new Rectangle(0, 0, 16 * (int)scale.X, 16 * (int)scale.Y), modulate);
        }
    }
}
