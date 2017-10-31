namespace Dekart.LazyNet
{
    partial class DrawingControl : System.Windows.Forms.UserControl
    {

        //UserControl overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components = null;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.VScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.HScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.DrawingBoard1 = new DrawingBoard();
            this.SuspendLayout();
            // 
            // VScrollBar1
            // 
            this.VScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VScrollBar1.Enabled = false;
            this.VScrollBar1.LargeChange = 20;
            this.VScrollBar1.Location = new System.Drawing.Point(548, 0);
            this.VScrollBar1.Name = "VScrollBar1";
            this.VScrollBar1.Size = new System.Drawing.Size(17, 332);
            this.VScrollBar1.TabIndex = 1;
            this.VScrollBar1.ValueChanged += new System.EventHandler(this.ScrollBarValueChanged);
            // 
            // HScrollBar1
            // 
            this.HScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HScrollBar1.Enabled = false;
            this.HScrollBar1.LargeChange = 20;
            this.HScrollBar1.Location = new System.Drawing.Point(0, 332);
            this.HScrollBar1.Name = "HScrollBar1";
            this.HScrollBar1.Size = new System.Drawing.Size(549, 17);
            this.HScrollBar1.TabIndex = 2;
            this.HScrollBar1.ValueChanged += new System.EventHandler(this.ScrollBarValueChanged);
            // 
            // DrawingBoard1
            // 
            this.DrawingBoard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingBoard1.Image = null;
            this.DrawingBoard1.InitialImage = null;
            this.DrawingBoard1.Location = new System.Drawing.Point(0, 0);
            this.DrawingBoard1.Name = "DrawingBoard1";
            this.DrawingBoard1.Origin = new System.Drawing.Point(0, 0);
            this.DrawingBoard1.PanButton = System.Windows.Forms.MouseButtons.Left;
            this.DrawingBoard1.PanMode = true;
            this.DrawingBoard1.Size = new System.Drawing.Size(549, 333);
            this.DrawingBoard1.StretchImageToFit = false;
            this.DrawingBoard1.TabIndex = 0;
            this.DrawingBoard1.ZoomFactor = 1D;
            this.DrawingBoard1.ZoomOnMouseWheel = true;
            this.DrawingBoard1.SetScrollPositions += new DrawingBoard.SetScrollPositionsEventHandler(this.DrawingBoard1SetScrollPositions);
            this.DrawingBoard1.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingBoard1Paint);
            this.DrawingBoard1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard1MouseDown);
            this.DrawingBoard1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard1MouseMove);
            // 
            // DrawingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HScrollBar1);
            this.Controls.Add(this.VScrollBar1);
            this.Controls.Add(this.DrawingBoard1);
            this.Name = "DrawingControl";
            this.Size = new System.Drawing.Size(566, 350);
            this.ResumeLayout(false);

        }

        internal DrawingBoard DrawingBoard1;
        internal System.Windows.Forms.VScrollBar VScrollBar1;

        internal System.Windows.Forms.HScrollBar HScrollBar1;

    }
}