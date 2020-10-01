namespace PrikazoveVykreslovani
{
    partial class Command
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.posunoutVýšToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posunoutNížToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smazatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posunoutVýšToolStripMenuItem,
            this.posunoutNížToolStripMenuItem,
            this.smazatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // posunoutVýšToolStripMenuItem
            // 
            this.posunoutVýšToolStripMenuItem.Name = "posunoutVýšToolStripMenuItem";
            this.posunoutVýšToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.posunoutVýšToolStripMenuItem.Text = "Posunout výš";
            this.posunoutVýšToolStripMenuItem.Click += new System.EventHandler(this.PosunoutVýšToolStripMenuItem_Click);
            // 
            // posunoutNížToolStripMenuItem
            // 
            this.posunoutNížToolStripMenuItem.Name = "posunoutNížToolStripMenuItem";
            this.posunoutNížToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.posunoutNížToolStripMenuItem.Text = "Posunout níž";
            this.posunoutNížToolStripMenuItem.Click += new System.EventHandler(this.PosunoutNížToolStripMenuItem_Click);
            // 
            // smazatToolStripMenuItem
            // 
            this.smazatToolStripMenuItem.Name = "smazatToolStripMenuItem";
            this.smazatToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.smazatToolStripMenuItem.Text = "Smazat";
            this.smazatToolStripMenuItem.Click += new System.EventHandler(this.SmazatToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Command
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Name = "Command";
            this.Size = new System.Drawing.Size(498, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Command_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Command_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Command_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Command_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem posunoutVýšToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posunoutNížToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smazatToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
