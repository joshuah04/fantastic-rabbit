using Microsoft.Xna.Framework;
using Sprint0.Constants;
using Sprint0.Interfaces.Player;

namespace Sprint0
{
    public class Camera
    {
        /* SpriteBatch Begin will need the transformation matrix */
        private float originalY = 220;

        private int leftX;
        private int rightX;
        public Matrix TransformMatrix { get; private set; }
        public Vector2 CameraPosition { get; private set; }

        public Camera()
        {
            /* Start at original coordinates of the screen and ground */
            CameraPosition = new Vector2(0, originalY);
        }

        public void SetBounds(int leftBound, int rightBound)
        {
            this.leftX = leftBound;
            this.rightX = rightBound;
        }

        public void Update(IPlayer player)
        {
            int halfOfScreen = Game1.Width / 2;

            /* Normally, want the camera to be offset by screen dimensions in order to be centered on the player */
            Matrix offsetCenterMatrix = Matrix.CreateTranslation(halfOfScreen, Game1.Height, 0);
            CameraPosition = new Vector2(player.CurrentPosition.X, originalY - CameraConstants.GROUND_OFFSET);

            /* Clamps the camera at the bounds of the level */
            if (CameraPosition.X <= leftX)
            {
                CameraPosition = new Vector2(leftX, originalY);
                offsetCenterMatrix = Matrix.CreateTranslation(halfOfScreen, Game1.Height + CameraConstants.BOTTOM_MATRIX_OFFSET, 0);
            }

            if (CameraPosition.X >= rightX)
            {
                CameraPosition = new Vector2(rightX, originalY);
                offsetCenterMatrix = Matrix.CreateTranslation(halfOfScreen, Game1.Height + CameraConstants.BOTTOM_MATRIX_OFFSET, 0);
            }

            /* Create final translation based on camera from player */
            Matrix playerPositionMatrix = Matrix.CreateTranslation(-(CameraPosition.X), -(CameraPosition.Y), 0);
            /* Create a zoom scale */
            Matrix zoomMatrix = Matrix.CreateScale(2, 2, 0);

            TransformMatrix = playerPositionMatrix * zoomMatrix * offsetCenterMatrix;
        }
    }
}