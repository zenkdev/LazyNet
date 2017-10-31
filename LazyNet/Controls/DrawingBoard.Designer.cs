namespace Dekart.LazyNet
{
    partial class DrawingBoard
    {

        //UserControl1 overrides dispose to clean up the component list.
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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            //DrawingBoard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DrawingBoard";
            this.Size = new System.Drawing.Size(189, 165);
            this.ResumeLayout(false);

        }
    }
}
