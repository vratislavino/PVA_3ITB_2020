using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrikazoveVykreslovani
{
    public class Group
    {
        public string name;
        public List<Shape> shapes;

        public Point position;
        public Size size;

        public bool Selected { get; set; }

        public Group() {

        }

        public Group(Group origin) {
            this.name = origin.name;
            this.shapes = origin.shapes;
            this.size = origin.size;
            this.position = origin.position;
        }

        public bool ContainsPoint(Point p) {
            return p.X > position.X && p.X < position.X + size.Width &&
                p.Y > position.Y && p.Y < position.Y + size.Height;
        }

        public void DrawGroup(Graphics g) {
            foreach (var shape in shapes) {
                shape.DrawInSize(g, position, size);
            }
            if(Selected) {
                g.DrawRectangle(Pens.Red, position.X, position.Y, size.Width, size.Height);
            }
        }
    }
}
