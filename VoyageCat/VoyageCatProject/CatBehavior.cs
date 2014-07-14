using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Common.Math;

namespace VoyageCatProject
{
    class CatBehavior : Behavior
    {

        [RequiredComponent]
        public Transform2D transformation;
        
        public CatBehavior()
            : base("cat")
        {
            this.transformation = null;

        }

        protected override void Update(TimeSpan gameTime)
        {
            transformation.X += 1;
            transformation.Y += 1;
        }
    }
}
