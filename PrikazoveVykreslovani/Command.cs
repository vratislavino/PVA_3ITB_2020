using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrikazoveVykreslovani
{
    public partial class Command : UserControl
    {
        public event Action<Command> PosunVys;
        public event Action<Command> PosunNiz;
        public event Action<Command> Smazat;

        public event Action<Command> DragStart;
        public event Action<Command> DragEnded;
        public event Action<Command> MovedDragged;

        private Shape shape;
        public Shape Shape => shape;

        private Font yoinkedFont = new System.Drawing.Font("Microsoft Sans Serif", 12.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
        private string shapeText ="";
        //Git Medřický
        // můj nový řádek

        public Command() {
            InitializeComponent();
            ControlExtension.Draggable(this, true);
        }

        public void SetShape(Shape s) {
            shape = s;
            pictureBox1.BackColor = s.color;
            shapeText = s.ToString();
        } 

        private void PosunoutVýšToolStripMenuItem_Click(object sender, EventArgs e) {
            PosunVys?.Invoke(this);
            contextMenuStrip1.Close();
        }

        private void PosunoutNížToolStripMenuItem_Click(object sender, EventArgs e) {
            PosunNiz?.Invoke(this);
            contextMenuStrip1.Close();
        }

        private void SmazatToolStripMenuItem_Click(object sender, EventArgs e) {
            Smazat?.Invoke(this);
            contextMenuStrip1.Close();
        }

        private void Command_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(this, e.Location);
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(this, e.Location);
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }

        private void Command_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawString(shapeText, yoinkedFont, Brushes.Black, new Point(50, 8));
        }

        private void Command_MouseDown(object sender, MouseEventArgs e) {
            DragStart?.Invoke(this);
        }

        private void Command_MouseUp(object sender, MouseEventArgs e) {
            DragEnded?.Invoke(this);
        }

        private void Command_MouseMove(object sender, MouseEventArgs e) {
            MovedDragged?.Invoke(this);
        }
    }
}
