namespace SimpleSnake.GameObjects
{
    using System;

    public class Field : Point
    {
        private const char wallSymbol = '\u25A0';

        public Field(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.LeftX == 0 || snakeHead.TopY == 0 ||
                   snakeHead.LeftX == this.LeftX - 1 || snakeHead.TopY == this.TopY;
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0); //Top border
            this.SetHorizontalLine(this.TopY); //Bottom border

            this.SetVerticalLine(0); //Left border
            this.SetVerticalLine(this.LeftX - 1); //Right border
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
