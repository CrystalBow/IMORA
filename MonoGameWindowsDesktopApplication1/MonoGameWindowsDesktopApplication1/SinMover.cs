using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class SinMover : Component
    {
        private Transform transform;
        private float amplitude;
        private float frequency;
        public float Amplitude { get => amplitude; set => amplitude = value; }
        public float Frequency { get => frequency; set => frequency = value; }

        public SinMover()
        {
            this.amplitude = 1.0f;
        }

        public SinMover(float amplitude, float frequency)
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
        }

        public override void Ready()
        {
            transform = Owner.GetComponent<Transform>();
        }

        public override void Update(GameTime gameTime)
        {
            transform.Translate(MathF.Cos((float)gameTime.TotalGameTime.TotalMilliseconds * 0.001f * 2 * MathF.PI * frequency) * amplitude, MathF.Sin((float)gameTime.TotalGameTime.TotalMilliseconds * 0.001f * 2 * MathF.PI * frequency) * amplitude);
            transform.RotateDegrees(5 * (float) gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
