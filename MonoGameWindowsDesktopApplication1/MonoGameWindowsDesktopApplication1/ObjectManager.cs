using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class ObjectManager
    {
        public enum Types
        {
            empty,
            character
        };
        private static int currentId = 0;
        private List<GameObject> objects = new List<GameObject>();
        public List<GameObject> Objects { get { return objects; } }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject gameObject = objects[i]; 
                if (gameObject == null)
                {
                    continue;
                }
                if (gameObject.GetDestroyed())
                {
                    objects.Remove(gameObject);
                }
            }

            SpriteSystem.Update(gameTime);
            TransformSystem.Update(gameTime);
            ScriptSystem.Update(gameTime);
        }

        public void AddEntity(GameObject gameObject)
        {
            objects.Add(gameObject);
            gameObject.Id = currentId;
            currentId++;
        }
        
        public GameObject GetGameObject(int id)
        {
            return objects[id];
        }

        public void Ready()
        {
            SpriteSystem.Ready();
            TransformSystem.Ready();
            ScriptSystem.Ready();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteSystem.Draw(spriteBatch);
        }
    }
}
