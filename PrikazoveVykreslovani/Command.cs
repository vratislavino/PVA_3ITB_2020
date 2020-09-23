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

        private Shape shape;
        public Shape Shape => shape;

        //Git Medřický

        public Command() {
            InitializeComponent();
        }

        public void SetShape(Shape s) {
            shape = s;
            label1.Text = s.ToString();
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
    }
}
