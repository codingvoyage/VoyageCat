#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
#endregion

namespace VoyageCatProject
{
    class EntityFactory
    {
        public static int unique = 0;
        public static int GetUniqueID()
        {
            unique++;
            return unique;
        }

        // Insert scratch cat
        // From the MIT Scratch Project - http://scratch.mit.edu/
        public static Entity MakeCat(string name, float x, float y)
        {
            Entity scratch = new Entity(name)
                .AddComponent(new Sprite("Content/scratchcat.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D()
                {
                    Origin = new Vector2(0, 1),
                    X = x,
                    Y = y
                })
                .AddComponent(new CatBehavior());
            return scratch;
        }

        public static Entity MakeBullet(string name, float x, float y, 
            Vector2 unitDirection)
        {
            Entity bullet = new Entity(name)
                .AddComponent(new Sprite("Content/bullet.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D()
                {

                    Origin = new Vector2(0, 1),
                    X = x,
                    Y = y
                })
                .AddComponent(new BulletBehavior(name, unitDirection));
            return bullet;
        }

        public static Entity MakeCatDefault(string name)
        {
            return MakeCat(name,
                WaveServices.Platform.ScreenWidth / 2,
                WaveServices.Platform.ScreenHeight);
        }

        public static Entity MakeBulletDefault(string name)
        {
            return MakeBullet(name,
                WaveServices.Platform.ScreenWidth / 2,
                WaveServices.Platform.ScreenHeight,
                new Vector2(0, 0));
        }


    }
}
