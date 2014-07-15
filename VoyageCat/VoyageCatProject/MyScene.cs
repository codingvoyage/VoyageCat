#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
#endregion

namespace VoyageCatProject {
    public class MyScene : Scene {
        protected override void CreateScene() {
            RenderManager.BackgroundColor = Color.CornflowerBlue;

            var scratch = EntityFactory.MakeCatDefault("Cat");
            EntityManager.Add(scratch);

            var bullet = EntityFactory.MakeBulletDefault("Bullet");
            EntityManager.Add(bullet);

            
        }

        
    }
}
