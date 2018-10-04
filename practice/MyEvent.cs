namespace practice
{
    using System;
    using System.Drawing;

    public class MyEvent : EventArgs
    {
        public string FirstFigure { get; set; }

        public string SecondFigure { get; set; }
    }
}
