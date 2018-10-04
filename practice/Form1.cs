namespace practice
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using Properties;

    public partial class Form1 : Form
    {
        public List<Figure> Figures;
        public string[] Logdata;
        private Thread movingThread;
        private int rectangleCount = 1;
        private int circleCount = 1;
        private int triangleCount = 1;
        private int figureID = 1;
        private int listIndex;
        private Graphics g;

        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Settings.Default.Language);
            this.InitializeComponent();
            movingTick.Start();
            this.Figures = new List<Figure>();
            this.movingThread = new Thread(this.Moving);
            this.movingThread.Start();
            this.Hit += this.Hits;
        }

        public event EventHandler<MyEvent> Hit;

        protected virtual void OnHit(MyEvent e)
        {
            EventHandler<MyEvent> temp = this.Hit;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        private void Hits(object sender, MyEvent e)
        {
            if (this.Logdata != null)
            {
                e.FirstFigure = this.Logdata[0];
                e.SecondFigure = this.Logdata[1];
                File.AppendAllText(
                    "Boom.log", e.FirstFigure + " " + e.SecondFigure + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + Environment.NewLine);
            }
        }

        private void Localization(List<Figure> figures)
        {
            foreach (var figure in figures)
            {
                if (figure.Name == "Rectangle " || figure.Name == "Прямоугольник ")
                {
                    figure.Name = Settings.Default.Language == "ru" ? "Прямоугольник " : "Rectangle ";

                    this.rectangleCount = figure.Count + 1;

                    figureList.Nodes.Add(figure.Name + figure.Count);
                }

                if (figure.Name == "Circle " || figure.Name == "Круг ")
                {
                    figure.Name = Settings.Default.Language == "ru" ? "Круг " : "Circle ";

                    this.circleCount = figure.Count + 1;

                    figureList.Nodes.Add(figure.Name + figure.Count);
                }

                if (figure.Name == "Triangle " || figure.Name == "Треугольник ")
                {
                    figure.Name = Settings.Default.Language == "ru" ? "Треугольник " : "Triangle ";
                    this.triangleCount = figure.Count + 1;
                    figureList.Nodes.Add(figure.Name + figure.Count);
                }
            }
        }

        private void AreaPaint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (var figure in this.Figures)
            {
                figure.Draw(e.Graphics);
            }
        }

        private void RectangleBtn_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(new Point(drawArea.Size.Width, drawArea.Size.Height), this.rectangleCount++, this.figureID++);
            figureList.Nodes.Add(new TreeNode
            {
                Text = rect.Name + rect.Count, Tag = this.figureID - 1
            });
            this.Figures.Add(rect);
        }

        private void CircleBtn_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle(new Point(drawArea.Size.Width, drawArea.Height), this.circleCount++, this.figureID++);
            figureList.Nodes.Add(new TreeNode
            {
                Text = circle.Name + circle.Count, Tag = this.figureID - 1
            });
            this.Figures.Add(circle);
        }

        private void TriangleBtn_Click(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle(new Point(drawArea.Size.Width, drawArea.Size.Height), this.triangleCount++, this.figureID++);
            figureList.Nodes.Add(new TreeNode
            {
                Text = triangle.Name + triangle.Count, Tag = this.figureID - 1
            });
            this.Figures.Add(triangle);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            drawArea.Refresh();
        }

        private void Moving()
        {
            while (true)
            {
                lock (this.Figures)
                {
                    try
                    {
                        foreach (var figure in this.Figures)
                        {
                            try
                            {
                                figure.Move(this.drawArea);
                                MyEvent myEvent = new MyEvent();
                                this.OnHit(myEvent);
                                Hits hits = new Hits();
                                this.Logdata = hits.Boom(this.Figures, g);
                            }
                            catch (FigureOutTheFieldException)
                            {
                                figure.MoveTo();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        
                    }

                    Thread.Sleep(movingTick.Interval);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.rectangleCount = 1;
            this.circleCount = 1;
            this.triangleCount = 1;
            this.Figures.Clear();
            figureList.Nodes.Clear();
        }

        private void RU_Enable_Click(object sender, EventArgs e)
        {
            Settings.Default.Language = "ru";
            Settings.Default.Save();
            Serialization.Serialization_bin(this.Figures);
            Serialization.Serialization_XML(this.Figures);
            Serialization.Serialization_Json(this.Figures);
            Application.Restart();
        }

        private void En_Enable_Click(object sender, EventArgs e)
        {
            Settings.Default.Language = "en";
            Settings.Default.Save();
            Serialization.Serialization_bin(this.Figures);
            Serialization.Serialization_XML(this.Figures);
            Serialization.Serialization_Json(this.Figures);
            Application.Restart();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.listIndex = Convert.ToInt32(figureList.SelectedNode.Tag);
                foreach (var figure in this.Figures)
                {
                    if (Convert.ToInt32(figureList.SelectedNode.Tag) == figure.Id)
                    {
                        StartStop.Stop(this.Figures, this.listIndex);
                    }
                }
            }
            catch (Exception)
            {
                if (Settings.Default.Language == "ru")
                {
                    MessageBox.Show("Вы не выбрали фигуру!", "Ошибка");
                }
                else
                {
                    MessageBox.Show("You have not selected figure!", "Error");
                }
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.listIndex = Convert.ToInt32(figureList.SelectedNode.Tag);
                foreach (var figure in this.Figures)
                {
                    if (Convert.ToInt32(figureList.SelectedNode.Tag) == figure.Id)
                    {
                        StartStop.Start(this.Figures, this.listIndex);
                    }
                }
            }
            catch (Exception)
            {
                if (Settings.Default.Language == "ru")
                {
                    MessageBox.Show("Вы не выбрали фигуру!", "Ошибка");
                }
                else
                {
                    MessageBox.Show("You have not selected figure!", "Error");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.movingThread.Abort();
            Serialization.Serialization_bin(this.Figures);
            Serialization.Serialization_XML(this.Figures);
            Serialization.Serialization_Json(this.Figures);
        }

        private void DelLastBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int figureIndex = Convert.ToInt32(figureList.Nodes.Count);
                string item = figureList.Nodes[figureIndex - 1].Text;
                if (item.Contains("Rectangle") || item.Contains("Прямоугольник"))
                {
                    this.rectangleCount--;
                }

                if (item.Contains("Circle") || item.Contains("Круг"))
                {
                    this.circleCount--;
                }

                if (item.Contains("Triangle") || item.Contains("Треугольник"))
                {
                    this.triangleCount--;
                }

                this.Figures.RemoveAt(figureIndex - 1);
                figureList.Nodes.RemoveAt(figureIndex - 1);
                drawArea.Refresh();
            }
            catch (Exception)
            {
                if (Settings.Default.Language == "ru")
                {
                    MessageBox.Show("Список пуст!", "Ошибка");
                }
                else
                {
                    MessageBox.Show("No item for deleting!", "Error");
                }
            }
        }

        private void LoadFromBinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            figureList.Nodes.Clear();
            this.Figures = Deserialization.Deserialization_bin();
            this.Localization(this.Figures);
        }

        private void LoadFromXMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            figureList.Nodes.Clear();
            this.Figures = Deserialization.Deserialization_XML();
            this.Localization(this.Figures);
        }

        private void LoadFromJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureList.Nodes.Clear();
            this.Figures = Deserialization.Deserialization_Json();
            this.Localization(this.Figures);
        }
    }
}
