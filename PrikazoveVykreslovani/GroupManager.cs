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
    public partial class GroupManager : Form
    {
        List<Shape> shapes = new List<Shape>();

        public GroupManager() {
            InitializeComponent();
            UpdateCommands();
        }

        private void AddButton_Click(object sender, EventArgs e) {
            CommandForm cmd = new CommandForm();
            cmd.SetOtherShapes(shapes);
            cmd.FormClosing += OnCommandClosing;
            cmd.ShowDialog();
        }

        private void OnCommandClosing(object sender, FormClosingEventArgs e) {
            var shp = ((CommandForm) sender).Shape;
            if (shp != null) {
                shapes.Add(shp);
                panel1.Refresh();
            }

            UpdateCommands();
        }

        private void UpdateCommands() {
            flowLayoutPanel1.Controls.Clear();
            foreach (var shp in shapes) {
                Command c = new Command();
                c.SetShape(shp);
                c.PosunNiz += OnPosunNiz;
                c.PosunVys += OnPosunVys;
                c.Smazat += OnSmazat;
                flowLayoutPanel1.Controls.Add(c);
            }
            flowLayoutPanel1.Refresh();
        }

        private void OnPosunNiz(Command c) {
            int index = shapes.IndexOf(c.Shape);
            if (index - 1 >=  0) {
                shapes.RemoveAt(index);
                index--;
                shapes.Insert(index, c.Shape);
            }
            UpdateCommands();
            panel1.Refresh();
        }

        private void OnPosunVys(Command c) {
            // TODO: Opravit!
            int index = shapes.IndexOf(c.Shape);

            if (index + 1 < shapes.Count) {
                shapes.RemoveAt(index);
                shapes.Insert(index, c.Shape);
            }
            UpdateCommands();
            panel1.Refresh();
        }

        private void OnSmazat(Command c) {
            shapes.Remove(c.Shape);
            UpdateCommands();
            panel1.Refresh();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e) {
            shapes.ForEach(shp => shp.Draw(e.Graphics));
        }
    }
}
