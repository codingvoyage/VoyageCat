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

            // Insert scratch cat

            // From the MIT Scratch Project - http://scratch.mit.edu/

            var scratch = new Entity("Cat")
                .AddComponent(new Sprite("Content/scratchcat.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D()
                {
                    Origin = new Vector2(0, 1),
                    X = WaveServices.Platform.ScreenWidth / 2,
                    Y = WaveServices.Platform.ScreenHeight
                })
                .AddComponent(new CatBehavior());

            EntityManager.Add(scratch);

            var bullet = new Entity("Bullet")
                .AddComponent(new Sprite("Content/bullet.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D() {

                    Origin = new Vector2(0, 1),
                    X = WaveServices.Platform.ScreenWidth / 2,
                    Y = WaveServices.Platform.ScreenHeight
                });

            EntityManager.Add(bullet);


            
        }

        
    }
}
