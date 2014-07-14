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
        public static const Vector2 UP = new Vector2(0, -1);
        public static const Vector2 DOWN = new Vector2(0, 1);
        public static const Vector2 LEFT = new Vector2(-1, 0);
        public static const Vector2 RIGHT = new Vector2(1, 0);


        [RequiredComponent]
        public Transform2D transformation;
        
        public CatBehavior()
            : base("cat")
        {
            this.transformation = null;

        }

        protected override void Update(TimeSpan gameTime)
        {
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

            //Prepare target coordinate
            Vector2.Normalize(direction);
            int amountMoved = 2;
            float deltaX = direction.X * amountMoved;
            float deltaY = direction.Y * amountMoved;
            float newX = transformation.X + deltaX;
            float newY = transformation.Y + deltaY;

            //Validate coordinate
            if (newX > 0 && newX < WaveServices.Platform.ScreenWidth &&
                newY > 0 && newY < WaveServices.Platform.ScreenHeight)
            {
                transformation.X = newX;
                transformation.Y = newY;
            }
        }
    }
}
