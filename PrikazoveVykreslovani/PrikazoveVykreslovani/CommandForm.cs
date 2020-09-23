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
    // 14.9.2020 13:41 -> Max Kučera: Žáci jsou věční! 

    // http://oddtgames.cz/tests.php

    public partial class CommandForm : Form
    {
        private Color color;
        List<Shape> otherShapes = new List<Shape>();
        Shape shape;
        public Shape Shape => shape;

        bool isMouseDown = false;

        public CommandForm() {
            InitializeComponent();
            InitializeComboBox();
            color = colorButton.BackColor = Color.Black;
        }

        public void SetOtherShapes(List<Shape> shapes) {
            otherShapes = shapes;
            panel1.Refresh();
        }

        private void InitializeComboBox() {
            comboBox1.Items.AddRange(Enum.GetNames(typeof(ShapeType)));
        }

        private void ColorButton_Click(object sender, EventArgs e) {
            var res = colorDialog1.ShowDialog();
            if(res == DialogResult.OK) {
                color = colorDialog1.Color;
                colorButton.BackColor = color;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e) {
            foreach(var shp in otherShapes) {
                shp.Visualize(e.Graphics);
            }

            if (shape != null) {
                shape.Draw(e.Graphics);
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;
            shape = Shape.CreateShape(comboBox1.Text);
            shape.color = color;
            shape.filled = checkBox1.Checked;
            shape.start = e.Location;
            shape.end = e.Location;
            panel1.Refresh();
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e) {
            if(isMouseDown) {
                shape.end = e.Location;
                panel1.Refresh();
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            if(shape != null) {
                shape.filled = checkBox1.Checked;
                panel1.Refresh();
            }
        }

        private void ColorButton_BackColorChanged(object sender, EventArgs e) {
            if(shape != null) {
                shape.color = colorButton.BackColor;
                panel1.Refresh();
            } 
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e) {
            if(shape != null) {
                shape = Shape.CreateShape(comboBox1.Text, shape);
                panel1.Refresh();
            } 
        }

        private void OkButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
