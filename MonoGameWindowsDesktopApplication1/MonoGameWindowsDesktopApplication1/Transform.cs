using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class Transform : Component
    {
        private Vector2 position;
        public Vector2 Position { get => position; set => position = value; }

        private float rotation;
        private float Rotation { get => rotation; set => rotation = value; }
        
        public Transform()
        {
            TransformSystem.Register(this);
            this.position = Vector2.Zero;
            this.rotation = 0;
        }
        public Transform(Vector2 position) 
        {
            TransformSystem.Register(this);
            this.position = position;
            this.rotation = 0;
        }
        public Transform(float x, float y)
        {
            TransformSystem.Register(this);
            this.position = new Vector2(x, y);
            this.rotation = 0;
        }
        public Transform(Vector2 position, float rotation)
        {
            TransformSystem.Register(this);
            this.position = position;
            this.rotation = rotation;
        }
        public Transform(float x, float y, float rotation)
        {
            TransformSystem.Register(this);
            this.position = new Vector2(x, y);
            this.rotation = rotation;
        }

        ~Transform()
        {
            TransformSystem.Unregister(this);
        }

        public void Translate(float x, float y) 
        { 
            position.X += x;
            position.Y += y;
        }

        public void Rotate(float radians)
        {
            rotation += radians;
        }
        public void RotateDegrees(float degrees)
        {
            rotation += (degrees * MathF.PI)/180.0f;
        }

        public float GetRotationDegrees()
        {
            return (rotation * 180.0f)/MathF.PI;
        }
        public void SetRotatationDegrees(float degrees)
        {
            rotation = (degrees * MathF.PI) / 180.0f;
        }

        public float GetRotation()
        {
            return rotation;
        }
    }
}
