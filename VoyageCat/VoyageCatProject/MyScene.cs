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

            //Insert your code here
            var scratch = new Entity("Cat")
                .AddComponent(new Sprite("Content/Cat.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D() {
                    Origin = new Vector2(0.5f, 1),
                    X = WaveServices.Platform.ScreenWidth / 2,
                    Y = WaveServices.Platform.ScreenHeight
                });

            EntityManager.Add(scratch);
            
        }
    }
}
