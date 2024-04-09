using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class ECSystem<T> where T : Component
    {
        public ECSystem() { }

        private static List<T> components = new List<T>();

        public static List<T> Components { get => components; set => components = value; }

        public static void Register(T component) 
        {
            Components.Add(component);
        }

        public static void Unregister(T component)
        {
            Components.Remove(component);
        }
        public static void Ready()
        {
            foreach (Component component in Components)
            {
                if (component.Owner.GetDestroyed())
                {
                    continue;
                }
                component.Ready();
            }
        }
        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                if (component.Owner.GetDestroyed())
                {
                    components.RemoveAt(i);
                }
                component.Update(gameTime);
            }
        }
    }

    class SpriteSystem : ECSystem<Sprite>
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Sprite component = Components[i];
                if (component.Owner.GetDestroyed())
                {
                    Components.RemoveAt(i);
                }
                component.Draw(spriteBatch);
            }
        }
    }

    class ScriptSystem : ECSystem<Script> { };
    class TransformSystem : ECSystem<Transform> { };
}
