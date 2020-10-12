using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrikazoveVykreslovani
{
    public partial class Form1 : Form
    {
        List<Group> groups = new List<Group>();

        List<Group> drawnGroups = new List<Group>();
        Group selectedGroup = null;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void přidatToolStripMenuItem_Click(object sender, EventArgs e) {
            GroupManager gm = new GroupManager();
            gm.FormClosing += GroupManagerClosing;
            gm.ShowDialog();
        }

        private void GroupManagerClosing(object sender, FormClosingEventArgs e) {

            var name = ((GroupManager) sender).GroupName;
            var shapes = ((GroupManager) sender).Shapes;

            if (string.IsNullOrEmpty(name) || shapes.Count == 0) {
                return;
            } else {
                Group g = new Group() { name = name, shapes = shapes };
                groups.Add(g);
                UpdateGroups();
            }
        }

        private void UpdateGroups() {
            foreach(Group g in groups) {
                GroupView gv = new GroupView();
                gv.SetGroup(g);
                gv.GroupClicked += GroupClicked;
                flowLayoutPanel1.Controls.Add(gv);
            }

            canvas1.Refresh();
        }

        private void GroupClicked(Group obj) {

            Group g = new Group(obj);
            drawnGroups.Add(g);
            g.size = new Size(200, 400);
            g.position = new Point(50, 50);
            //g.position = new Point(canvas1.Width / 2 , canvas1.Height/2);
            canvas1.Refresh();
        }

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            drawnGroups.ForEach(x => x.DrawGroup(e.Graphics));
        }

        private void canvas1_MouseDown(object sender, MouseEventArgs e) {

        }

        private void canvas1_MouseUp(object sender, MouseEventArgs e) {

        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e) {
            foreach(Group g in drawnGroups) {
                if (g.ContainsPoint(e.Location)) {
                    selectedGroup = g;
                    g.Selected = true;
                    // problém s posunem při vykreslování shape
                    break;
                }
            }

            canvas1.Refresh();
        }
    }
}
