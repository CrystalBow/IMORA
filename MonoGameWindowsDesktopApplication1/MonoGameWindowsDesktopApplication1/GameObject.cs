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
        private int _id;
        private bool _destroyed;
        private List<Component> _components;

        public GameObject(int id)
        {
            this._id = id;
            _destroyed = false;
            _components = new List<Component>();
        }

        //Returns the id of a gameobject
        public int GetId()
        {
            return _id;
        }
        
        //Add a component to a gameobject
        public void AddComponent(Component component)
        {
            if (component == null)
            {
                return;
            }
            component.Owner = this;
            _components.Add(component);
        }

        //Returns a specific component reference if it exists
        public T GetComponent<T>() where T : Component 
        { 
            foreach (Component component in _components) 
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
            foreach (Component component in _components)
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
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i].GetType() == typeof(T))
                {
                    _components.RemoveAt(i);
                    return true;
                }
            }
            foreach (Component component in _components)
            {
                component.OnComponentRemove(component);
            }
            return false;
        }

        //Returns the list of components
        public List<Component> GetComponents() 
        {
            return _components;
        }

        //Marks an object to be destroyed
        public void Destroy()
        {
            _destroyed = true;
        }

        //Returns whether or not the object is destroyed
        public bool GetDestroyed()
        {
            return _destroyed;
        }

        public void Ready()
        {
            foreach (Component component in _components)
            {
                component.Ready();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
