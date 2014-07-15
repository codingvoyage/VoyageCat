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
using System.Diagnostics;

namespace VoyageCatProject
{
    class CatBehavior : Behavior
    {
        public static Vector2 UP = new Vector2(0, -1);
        public static Vector2 DOWN = new Vector2(0, 1);
        public static Vector2 LEFT = new Vector2(-1, 0);
        public static Vector2 RIGHT = new Vector2(1, 0);

        [RequiredComponent]
        public Transform2D transformation;

        private class SimpleGun
        {
            public int firingDelay;
            public int currentDelay;
            public SimpleGun(int firingDelay)
            {
                this.firingDelay = firingDelay;
                currentDelay = firingDelay;
            }
            public bool CanFire()
            {
                return currentDelay >= firingDelay;              
            }
            public void Fire()
            {
                currentDelay = 0;
            }
            public void Update(TimeSpan gameTime)
            {
                Debug.Print(gameTime.Milliseconds + "");

                currentDelay += gameTime.Milliseconds;
                if (currentDelay > 2147482647) currentDelay = firingDelay;
            }

        }


        private SimpleGun gun;

        public CatBehavior()
            : base("cat")
        {
            this.transformation = null;
            gun = new SimpleGun(800);
        }

        protected override void Update(TimeSpan gameTime)
        {
            //Update gun
            gun.Update(gameTime);

            //Prepare for input
            Vector2 direction = new Vector2(0, 0);

            //Process input.
            var keyboard = WaveServices.Input.KeyboardState;
            if (keyboard.Right == ButtonState.Pressed)
            {
                direction += RIGHT;
            }
            if (keyboard.Left == ButtonState.Pressed)
            {
                direction += LEFT;
            }
            if (keyboard.Up == ButtonState.Pressed)
            {
                direction += UP;
            }
            if (keyboard.Down == ButtonState.Pressed)
            {
                direction += DOWN;
            }
            if (keyboard.Space == ButtonState.Pressed)
            {
                if (gun.CanFire())
                {
                    gun.Fire();
                    EntityManager.Add(
                        EntityFactory.MakeBullet(
                        "bullet" + EntityFactory.GetUniqueID(),
                        transformation.X,
                        transformation.Y,
                        UP)
                    );
                }
            }

            //Prepare target coordinate
            Vector2.Normalize(direction);
            int amountMoved = 2;
            float deltaX = direction.X * amountMoved;
            float deltaY = direction.Y * amountMoved;
            float newX = transformation.X + deltaX;
            float newY = transformation.Y + deltaY;

            //Validate coordinate
            if (newX > 0 && 
                newX < WaveServices.Platform.ScreenWidth &&
                newY > 0 && 
                newY < WaveServices.Platform.ScreenHeight)
            {
                transformation.X = newX;
                transformation.Y = newY;
            }


        }
    }
}
