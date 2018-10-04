namespace practice
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Properties;
    
    [Serializable]
    internal class Triangle : Figure
    {
        private readonly int size;
        private Random gen;

        public Triangle(Point areaSize, int count, int id)
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
            this.size = this.gen.Next(15, 50);
            this.Width = this.size;
            this.Height = this.size;
            double sideAB = Math.Sqrt((this.size * this.size) * 2);
            double halfP = ((sideAB * 2) + (this.size * 2)) / 2;
            double square = Math.Sqrt(halfP * (halfP - sideAB) * (halfP - sideAB) * (halfP - (this.size * 2)));
            this.StartPoint = new Point(this.gen.Next(this.size + 1, areaSize.X - this.size + 1), this.gen.Next(1, areaSize.Y - this.size + 1));
            if (Settings.Default.Language == "ru")
            {
                this.Name = "Треугольник ";
            }
            else if (Settings.Default.Language == "en")
            {
                this.Name = "Triangle ";
            }
        }

        public override void Draw(Graphics graphics)
        {
            Brush myBrushes = new SolidBrush(Color.FromArgb(Red, Green, Blue));
            graphics.FillPolygon(myBrushes, this.Points(), FillMode.Alternate);
        }

        public override void Move(PictureBox drawArea)
        {
            if (StartPoint.X + this.Width >= drawArea.Size.Width || StartPoint.X - this.Width <= 0)
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
