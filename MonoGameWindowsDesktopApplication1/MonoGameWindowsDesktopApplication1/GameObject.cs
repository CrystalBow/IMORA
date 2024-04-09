using Microsoft.Xna.Framework;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class GameObject
    {
        private int id;
        private bool destroyed;
        private List<Component> components;

        public int Id { get => id; set => id = value; }

        public GameObject()
        {
            this.Id = Id;
            destroyed = false;
            components = new List<Component>();
        }
        
        //Add a component to a gameobject
        public void AddComponent(Component component)
        {
            if (component == null)
            {
                return;
            }
            component.Owner = this;
            components.Add(component);
        }

        //Returns a specific component reference if it exists
        public T GetComponent<T>() where T : Component 
        { 
            foreach (Component component in components) 
            { 
                if (component.GetType() == typeof(T))
                {
                    return (T)component;
                }
            }
            return null;
        }

        //Returns true if a specific component exists and false otherwise
        public bool HasComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    return true;
                }
            }
            return false;
        }

        //Delete a specific component if it exists, returns false if unsuccessful
        public bool DeleteComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                {
                    components.RemoveAt(i);
                    return true;
                }
            }
            foreach (Component component in components)
            {
                component.OnComponentRemove(component);
            }
            return false;
        }

        //Returns the list of components
        public List<Component> GetComponents() 
        {
            return components;
        }

        //Marks an object to be destroyed
        public void Destroy()
        {
            destroyed = true;
        }

        //Returns whether or not the object is destroyed
        public bool GetDestroyed()
        {
            return destroyed;
        }

        public void Ready()
        {
            foreach (Component component in components)
            {
                component.Ready();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}
