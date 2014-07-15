using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Common.Math;

namespace VoyageCatProject
{
    class BulletBehavior : Behavior
    {
        public Vector2 unitDirection;
        public static float velocity = 2;

        [RequiredComponent]
        Transform2D transformation;

        public BulletBehavior(string name, Vector2 unitDirection)
            : base(name)
        {
            this.unitDirection = unitDirection;
        }

        protected override void Update(TimeSpan gameTime)
        {
            //Go forward in the direction of the unit vector.
            transformation.X += velocity * unitDirection.X;
            transformation.Y += velocity * unitDirection.Y;

            //Delete if out of bounds.
            if (transformation.X < 0 || 
                transformation.X > WaveServices.Platform.ScreenWidth ||
                transformation.Y < 0 ||
                transformation.Y > WaveServices.Platform.ScreenHeight)
            {
                EntityManager.Remove(this.Owner);
            }


        }




    }
}
