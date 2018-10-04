using System.Data;

namespace practice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.figureList = new System.Windows.Forms.TreeView();
            this.drawArea = new System.Windows.Forms.PictureBox();
            this.triangleBtn = new System.Windows.Forms.Button();
            this.rectangleBtn = new System.Windows.Forms.Button();
            this.circleBtn = new System.Windows.Forms.Button();
            this.movingTick = new System.Windows.Forms.Timer(this.components);
            this.clearBtn = new System.Windows.Forms.Button();
            this.RU_Enable = new System.Windows.Forms.Button();
            this.En_Enable = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.delLastBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFromBinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromXMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // figureList
            // 
            resources.ApplyResources(this.figureList, "figureList");
            this.figureList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.figureList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.figureList.Name = "figureList";
            // 
            // drawArea
            // 
            resources.ApplyResources(this.drawArea, "drawArea");
            this.drawArea.BackColor = System.Drawing.Color.Transparent;
            this.drawArea.Name = "drawArea";
            this.drawArea.TabStop = false;
            this.drawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.AreaPaint);
            // 
            // triangleBtn
            // 
            resources.ApplyResources(this.triangleBtn, "triangleBtn");
            this.triangleBtn.Name = "triangleBtn";
            this.triangleBtn.UseVisualStyleBackColor = true;
            this.triangleBtn.Click += new System.EventHandler(this.TriangleBtn_Click);
            // 
            // rectangleBtn
            // 
            resources.ApplyResources(this.rectangleBtn, "rectangleBtn");
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.UseMnemonic = false;
            this.rectangleBtn.UseVisualStyleBackColor = true;
            this.rectangleBtn.Click += new System.EventHandler(this.RectangleBtn_Click);
            // 
            // circleBtn
            // 
            resources.ApplyResources(this.circleBtn, "circleBtn");
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.UseVisualStyleBackColor = true;
            this.circleBtn.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // movingTick
            // 
            this.movingTick.Enabled = true;
            this.movingTick.Interval = 10;
            this.movingTick.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // clearBtn
            // 
            resources.ApplyResources(this.clearBtn, "clearBtn");
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // RU_Enable
            // 
            resources.ApplyResources(this.RU_Enable, "RU_Enable");
            this.RU_Enable.Name = "RU_Enable";
            this.RU_Enable.UseVisualStyleBackColor = true;
            this.RU_Enable.Click += new System.EventHandler(this.RU_Enable_Click);
            // 
            // En_Enable
            // 
            resources.ApplyResources(this.En_Enable, "En_Enable");
            this.En_Enable.Name = "En_Enable";
            this.En_Enable.UseVisualStyleBackColor = true;
            this.En_Enable.Click += new System.EventHandler(this.En_Enable_Click);
            // 
            // stopBtn
            // 
            resources.ApplyResources(this.stopBtn, "stopBtn");
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // startBtn
            // 
            resources.ApplyResources(this.startBtn, "startBtn");
            this.startBtn.Name = "startBtn";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // delLastBtn
            // 
            resources.ApplyResources(this.delLastBtn, "delLastBtn");
            this.delLastBtn.Name = "delLastBtn";
            this.delLastBtn.UseVisualStyleBackColor = true;
            this.delLastBtn.Click += new System.EventHandler(this.DelLastBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromBinToolStripMenuItem1,
            this.loadFromXMLToolStripMenuItem1,
            this.loadFromJsonToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // loadFromBinToolStripMenuItem1
            // 
            this.loadFromBinToolStripMenuItem1.Name = "loadFromBinToolStripMenuItem1";
            resources.ApplyResources(this.loadFromBinToolStripMenuItem1, "loadFromBinToolStripMenuItem1");
            this.loadFromBinToolStripMenuItem1.Click += new System.EventHandler(this.LoadFromBinToolStripMenuItem1_Click);
            // 
            // loadFromXMLToolStripMenuItem1
            // 
            this.loadFromXMLToolStripMenuItem1.Name = "loadFromXMLToolStripMenuItem1";
            resources.ApplyResources(this.loadFromXMLToolStripMenuItem1, "loadFromXMLToolStripMenuItem1");
            this.loadFromXMLToolStripMenuItem1.Click += new System.EventHandler(this.LoadFromXMLToolStripMenuItem1_Click);
            // 
            // loadFromJsonToolStripMenuItem
            // 
            this.loadFromJsonToolStripMenuItem.Name = "loadFromJsonToolStripMenuItem";
            resources.ApplyResources(this.loadFromJsonToolStripMenuItem, "loadFromJsonToolStripMenuItem");
            this.loadFromJsonToolStripMenuItem.Click += new System.EventHandler(this.LoadFromJsonToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.delLastBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.En_Enable);
            this.Controls.Add(this.RU_Enable);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.circleBtn);
            this.Controls.Add(this.rectangleBtn);
            this.Controls.Add(this.triangleBtn);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.figureList);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView figureList;
        private System.Windows.Forms.PictureBox drawArea;
        private System.Windows.Forms.Button triangleBtn;
        private System.Windows.Forms.Button rectangleBtn;
        private System.Windows.Forms.Button circleBtn;
        private System.Windows.Forms.Timer movingTick;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button RU_Enable;
        private System.Windows.Forms.Button En_Enable;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button delLastBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFromBinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFromXMLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFromJsonToolStripMenuItem;
    }
}
