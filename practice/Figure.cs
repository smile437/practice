namespace practice
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Windows.Forms;

    [Serializable]
    [DataContract]
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Circle))]
    [KnownType(typeof(Triangle))]
    public abstract class Figure
    {
        public static Random RandomGen = new Random();
        [DataMember] public int MoveSpeedHorisontal = RandomGen.Next(-3, 3);
        [DataMember] public int MoveSpeedVertical = RandomGen.Next(-3, 3);
        [DataMember] public int Width = RandomGen.Next(30, 75);
        [DataMember] public int Height = RandomGen.Next(30, 75);
        [DataMember] public int TempspeedX;
        [DataMember] public int TempspeedY;
        [DataMember] public int Red = RandomGen.Next(255);
        [DataMember] public int Green = RandomGen.Next(224);
        [DataMember] public int Blue = RandomGen.Next(209);

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Point StartPoint { get; set; }

        public abstract void Draw(Graphics graphics);

        public abstract void Move(PictureBox drawArea);

        public void MoveTo()
        {
            this.StartPoint = new Point(this.StartPoint.X + this.MoveSpeedHorisontal, this.StartPoint.Y + this.MoveSpeedVertical);
        }

        public Point[] Points()
        {
            Point[] points = new Point[]
            {
                new Point(this.StartPoint.X, this.StartPoint.Y), 
                new Point(this.StartPoint.X - this.Width, this.StartPoint.Y + this.Height),
                new Point(this.StartPoint.X + this.Width, this.StartPoint.Y + this.Height)
            };
            return points;
        }
    }
}