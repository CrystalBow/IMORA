using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using System.Transactions;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Imora
{
    internal class Character : GameObject
    {
        private Transform transform;
        private Sprite sprite;
        public Character(Texture2D texture, float x, float y, float scale) : base()
        {
            Sprite = new Sprite(texture, new Rectangle(0, 0, 16, 16), Color.White, scale, scale);
            Transform = new Transform(x, y);
            AddComponent(Transform);
            AddComponent(Sprite);
            AddComponent(new SinMover(5.0f, 1.0f));
        }

        internal Transform Transform { get => transform; set => transform = value; }
        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
