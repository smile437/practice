namespace practice
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class Hits
    {
        private string[] logdata = new string[5];

        public string[] Boom(List<Figure> figures, Graphics graphics)
        {
            for (int i = 0; i < figures.Count - 1; i++)
            {
                for (int j = i + 1; j < figures.Count; j++)
                {
                    RectangleF[] points = this.IntersectsPoints(figures[i], figures[j], graphics);
                    if (points.Length > 0)
                    {
                        int speedTempX;
                        int speedTempY;
                        Random myRandom = new Random();
                        speedTempX = figures[i].MoveSpeedHorisontal;
                        speedTempY = figures[i].MoveSpeedVertical;
                        figures[i].MoveSpeedHorisontal = figures[j].MoveSpeedHorisontal;
                        figures[i].MoveSpeedVertical = figures[j].MoveSpeedVertical;
                        figures[j].MoveSpeedHorisontal = speedTempX;
                        figures[j].MoveSpeedVertical = speedTempY;
                        figures[i].Red = myRandom.Next(255);
                        figures[i].Green = myRandom.Next(255);
                        figures[i].Blue = myRandom.Next(255);
                        figures[j].Red = myRandom.Next(255);
                        figures[j].Green = myRandom.Next(255);
                        figures[j].Blue = myRandom.Next(255);
                        if (figures[i].Name == figures[j].Name)
                        {
                            this.logdata[0] = figures[i].Name + figures[i].Count + " with ";
                            this.logdata[1] = figures[j].Name + figures[j].Count + " in ";
                            return this.logdata;
                        }
                    }
                }
            }

            return null;
        }

        public RectangleF[] IntersectsPoints(Figure figure1, Figure figure2, Graphics graphics)
        {
            GraphicsPath graphicsPathFirstFigure = new GraphicsPath();
            this.FigurePath(figure1, graphicsPathFirstFigure);
            GraphicsPath graphicsPathSecondFigure = new GraphicsPath();
            this.FigurePath(figure2, graphicsPathSecondFigure);
            Region reg = new Region(graphicsPathFirstFigure);
            reg.Intersect(graphicsPathSecondFigure);
            RectangleF[] points = reg.GetRegionScans(new Matrix());
            return points;
        }

        public void FigurePath(Figure figure, GraphicsPath graphicsPath)
        {
            if (figure is Rectangle)
            {
                graphicsPath.AddRectangle(new System.Drawing.Rectangle(figure.StartPoint.X, figure.StartPoint.Y, figure.Width, figure.Height));
            }

            if (figure is Circle)
            {
                graphicsPath.AddEllipse(figure.StartPoint.X, figure.StartPoint.Y, figure.Width, figure.Height);
            }

            if (figure is Triangle)
            {
                graphicsPath.AddPolygon(figure.Points());
            }
        }
    }
}

/*System.Drawing.Rectangle figure1 = new System.Drawing.Rectangle(
                        figures[i].StartPoint.X, figures[i].StartPoint.Y, figures[i].Width, figures[i].Height);
                    System.Drawing.Rectangle figure2 = new System.Drawing.Rectangle(
                        figures[j].StartPoint.X, figures[j].StartPoint.Y, figures[j].Width, figures[j].Height);

                    if (figure1.IntersectsWith(figure2) || figure2.IntersectsWith(figure1))
                    {
                        int speedTempX;
                        int speedTempY;
                        Random myRandom = new Random();
                        speedTempX = figures[i].MoveSpeedHorisontal;
                        speedTempY = figures[i].MoveSpeedVertical;
                        figures[i].MoveSpeedHorisontal = figures[j].MoveSpeedHorisontal;
                        figures[i].MoveSpeedVertical = figures[j].MoveSpeedVertical;
                        figures[j].MoveSpeedHorisontal = speedTempX;
                        figures[j].MoveSpeedVertical = speedTempY;
                        figures[i].Red = myRandom.Next(255);
                        figures[i].Green = myRandom.Next(255);
                        figures[i].Blue = myRandom.Next(255);
                        figures[j].Red = myRandom.Next(255);
                        figures[j].Green = myRandom.Next(255);
                        figures[j].Blue = myRandom.Next(255);
                        if (figures[i].GetType() == figures[j].GetType())
                        {
                            this.logdata[0] = figures[i].Name + figures[i].Count + " with ";
                            this.logdata[1] = figures[j].Name + figures[j].Count + " in ";
                            return this.logdata;
                        }
                    }*/