namespace practice
{
    using System.Collections.Generic;

    public class StartStop
    {
        public static void Stop(List<Figure> figures, int listIndex)
        {
            foreach (var figure in figures)
            {
                if (listIndex == figure.Id)
                {
                    if (figure.MoveSpeedHorisontal != 0)
                    {
                        figure.TempspeedX = figure.MoveSpeedHorisontal;
                        figure.TempspeedY = figure.MoveSpeedVertical;
                        figure.MoveSpeedHorisontal = 0;
                        figure.MoveSpeedVertical = 0;
                    }
                }
            }
        }

        public static void Start(List<Figure> figures, int listIndex)
        {
            foreach (var figure in figures)
            {
                if (listIndex == figure.Id)
                {
                    if (figure.MoveSpeedHorisontal == 0)
                    {
                        figure.MoveSpeedHorisontal = figure.TempspeedX;
                        figure.MoveSpeedVertical = figure.TempspeedY;
                    }
                }
            }
        }
    }
}
