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
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.posunoutVýšToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posunoutNížToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smazatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rectangle (20,20,100,100) Green";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posunoutVýšToolStripMenuItem,
            this.posunoutNížToolStripMenuItem,
            this.smazatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 104);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // posunoutVýšToolStripMenuItem
            // 
            this.posunoutVýšToolStripMenuItem.Name = "posunoutVýšToolStripMenuItem";
            this.posunoutVýšToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.posunoutVýšToolStripMenuItem.Text = "Posunout výš";
            this.posunoutVýšToolStripMenuItem.Click += new System.EventHandler(this.PosunoutVýšToolStripMenuItem_Click);
            // 
            // posunoutNížToolStripMenuItem
            // 
            this.posunoutNížToolStripMenuItem.Name = "posunoutNížToolStripMenuItem";
            this.posunoutNížToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.posunoutNížToolStripMenuItem.Text = "Posunout níž";
            this.posunoutNížToolStripMenuItem.Click += new System.EventHandler(this.PosunoutNížToolStripMenuItem_Click);
            // 
            // smazatToolStripMenuItem
            // 
            this.smazatToolStripMenuItem.Name = "smazatToolStripMenuItem";
            this.smazatToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.smazatToolStripMenuItem.Text = "Smazat";
            this.smazatToolStripMenuItem.Click += new System.EventHandler(this.SmazatToolStripMenuItem_Click);
            // 
            // Command
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Name = "Command";
            this.Size = new System.Drawing.Size(500, 50);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Command_MouseClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem posunoutVýšToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posunoutNížToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smazatToolStripMenuItem;
    }
}
