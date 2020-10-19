using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PrikazoveVykreslovani
{
    public partial class Form1 : Form
    {
        List<Group> groups = new List<Group>();

        List<Group> drawnGroups = new List<Group>();
        Group selectedGroup = null;

        Operation operation = Operation.None;
        bool loadDefault = true;

        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            if(loadDefault) {
                LoadFile(@"C:\Users\vrati\Documents\groups2.json");
            }
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

            flowLayoutPanel1.Controls.Clear();

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
            g.size = new Size(400, 400);
            g.position = new Point(50, 50);
            //g.position = new Point(canvas1.Width / 2 , canvas1.Height/2);
            canvas1.Refresh();
        }

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            drawnGroups.ForEach(x => x.DrawGroup(e.Graphics));
        }

        private void canvas1_MouseDown(object sender, MouseEventArgs e) {
            if(selectedGroup != null) {
                operation = selectedGroup.GetOperation(e.Location);
            }
        }

        private void canvas1_MouseUp(object sender, MouseEventArgs e) {
            operation = Operation.None;
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e) {

            Group tempSelected = null;

            foreach (Group g in drawnGroups) {
                if (g.ContainsPoint(e.Location)) {
                    tempSelected = g;
                    break;
                }
            }

            if(tempSelected == null) {
                if(selectedGroup != null) {
                    selectedGroup.Selected = false;
                }
            } else {
                if(selectedGroup != null) {
                    selectedGroup.Selected = false;
                }
                selectedGroup = tempSelected;
                tempSelected.Selected = true;
            }

            if(selectedGroup != null && operation != Operation.None) {
                if(operation == Operation.Replace) {
                    selectedGroup.GroupReplace(e.Location);
                } else {
                    Point p = selectedGroup.position;
                    Size s = new Size(e.X - p.X, e.Y - p.Y);
                    selectedGroup.GroupResize(s);
                }

            }

            canvas1.Refresh();
        }

        private void Canvas1_MouseLeave(object sender, EventArgs e) {
            operation = Operation.None;
        }

        private void uložitToolStripMenuItem_Click(object sender, EventArgs e) {

            /*
            Group g = new Group() {
                name = "TestGroup",
                position = new Point(50, 50),
                size = new Size(100, 100),
                shapes = new List<Shape>() {
                    new Rectangle() { color=Color.Red, end = new Point(15,15), start = new Point(0,0), filled = true},
                    new Rectangle() { color=Color.Red, end = new Point(15,15), start = new Point(0,0), filled = true},
                    new Ellipse() { color=Color.Red, end = new Point(15,15), start = new Point(0,0), filled = true},
                    new Ellipse() { color=Color.Red, end = new Point(15,15), start = new Point(0,0), filled = true},
                    new Rectangle() { color=Color.Red, end = new Point(15,15), start = new Point(0,0), filled = true},
                }
            };*/

            string vystup = JsonConvert.SerializeObject(groups);
            Console.WriteLine(vystup);
            SaveFileDialog fd = new SaveFileDialog();
            fd.AddExtension = true;
            fd.DefaultExt = ".json";
            fd.Filter = "JSON soubory (*.json)|*.json";
            DialogResult dr = fd.ShowDialog();
            if(dr == DialogResult.OK) {

                Console.WriteLine(fd.FileName);
                var stream = File.Create(fd.FileName);
                byte[] arr = Encoding.ASCII.GetBytes(vystup);
                stream.Write(arr, 0, arr.Length);
                stream.Close();
            }
        }

        private void načístToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "JSON soubory (*.json)|*.json";
            DialogResult dr = od.ShowDialog();
            if(dr == DialogResult.OK) {
                LoadFile(od.FileName);   
            }
        }

        private void LoadFile(string fileName) {
            Console.WriteLine("Načítá se " + fileName);
            string text = File.ReadAllText(fileName);
            //                            generická metoda
            List<Group> nactene = JsonConvert.DeserializeObject<List<Group>>(text);

            foreach (var group in nactene) {
                for (int i = 0; i < group.shapes.Count; i++) {
                    group.shapes[i] = Shape.CreateShape(group.shapes[i].ClassName, group.shapes[i]);
                }
            }

            groups = nactene;
            UpdateGroups();
        }

    }
    public enum Operation
    {
        None,
        Replace,
        Resize
    }
}
