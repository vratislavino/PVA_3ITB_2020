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
    public partial class GroupView : UserControl
    {
        public Group group;
        public event Action<Group> GroupClicked;

        public GroupView() {
            InitializeComponent();
        }

        public void SetGroup(Group g) {
            this.group = g;
            this.label1.Text = g.name;

            if (group.shapes.Count > 0)
                command1.SetShape(group.shapes[0]);
            else
                command1.Visible = false;

            if (group.shapes.Count > 1)
                command2.SetShape(group.shapes[1]);
            else
                command2.Visible = false;

            if (group.shapes.Count > 2)
                command3.SetShape(group.shapes[2]);
            else
                command3.Visible = false;

            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            GroupClicked?.Invoke(group);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            if(group != null) {
                group.position = new Point(0,0);
                group.size = new Size(pictureBox1.Width, pictureBox1.Height);
                group.DrawGroup(e.Graphics);
            }
        }
    }
}
