using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    abstract class Component
    {
        private GameObject owner; //The gameobject that this component it attatched to
        internal GameObject Owner { get => owner; set => owner = value; }

        public Component() { }

        //This method is called every frame
        public virtual void Update(GameTime gameTime)
        {

        }

        //This method is called once at the start of the game
        public virtual void Ready()
        {

        }

        public virtual void onComponentRemove(Component component)
        {

        }
    }
}
