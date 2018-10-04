namespace practice
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Properties;
    [Serializable]
    class Rectangle : Figure
    {
        private Random gen;

        public Rectangle(Point areaSize, int count, int id)
        {
            this.Id = id;
            if (this.MoveSpeedHorisontal == 0)
            {
                this.MoveSpeedHorisontal++;
            }

            if (this.MoveSpeedVertical == 0)
            {
                this.MoveSpeedVertical++;
            }

            this.TempspeedX = this.MoveSpeedHorisontal;
            this.TempspeedY = this.MoveSpeedVertical;
            this.Count = count;
            this.gen = new Random();

            this.StartPoint = new Point(this.gen.Next(1, areaSize.X - Height - 5), this.gen.Next(1, areaSize.Y - Height - 5));
            if (Settings.Default.Language == "ru")
            {
                this.Name = "Прямоугольник ";
            }
            else if (Settings.Default.Language == "en")
            {
                this.Name = "Rectangle ";
            }
        }

        public override void Draw(Graphics graphics)
        {
            Brush myBrushes = new SolidBrush(Color.FromArgb(Red, Green, Blue));
            graphics.FillRectangle(myBrushes, StartPoint.X, StartPoint.Y, this.Width, this.Height);
        }

        public override void Move(PictureBox drawArea)
        {
            if (StartPoint.X + this.Width >= drawArea.Size.Width || StartPoint.X <= 0)
            {
                this.MoveSpeedHorisontal = -this.MoveSpeedHorisontal;
            }

            if (StartPoint.Y + this.Height >= drawArea.Size.Height || StartPoint.Y <= 0)
            {
                this.MoveSpeedVertical = -this.MoveSpeedVertical;
            }

            this.StartPoint = new Point(StartPoint.X + MoveSpeedHorisontal, StartPoint.Y + MoveSpeedVertical);

            if ((StartPoint.X + this.Width > drawArea.Size.Width + 5 || StartPoint.X < -5) ||
        (StartPoint.Y + this.Height > drawArea.Size.Height + 5 || StartPoint.Y < -5))
            {
                throw new FigureOutTheFieldException("error");
            }
        }
    }
}
