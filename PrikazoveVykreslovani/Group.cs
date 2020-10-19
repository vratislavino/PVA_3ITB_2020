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

        private int arrowSize = 15;
        private static Pen arrowPen = new Pen(Color.Blue, 3);

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
            return p.X > position.X - arrowSize && p.X < position.X + size.Width + arrowSize &&
                p.Y > position.Y - arrowSize && p.Y < position.Y + size.Height+ arrowSize;
        }

        public void DrawGroup(Graphics g) {
            foreach (var shape in shapes) {
                shape.DrawInSize(g, position, size);
            }
            if (Selected) {
                g.DrawRectangle(Pens.Red, position.X, position.Y, size.Width, size.Height);
                DrawArrows(g);
            }
        }

        private void DrawArrows(Graphics g) {
            // šipky nahoře
            g.DrawLine(arrowPen, position.X - arrowSize, position.Y, position.X + arrowSize, position.Y);
            g.DrawLine(arrowPen, position.X, position.Y - arrowSize, position.X, position.Y + arrowSize);

            // šipky dole
            g.DrawLine(arrowPen,
                position.X + size.Width,
                position.Y + size.Height,
                position.X + size.Width + arrowSize,
                position.Y + size.Height
                );
            g.DrawLine(arrowPen,
                 position.X + size.Width,
                 position.Y + size.Height,
                 position.X + size.Width,
                 position.Y + size.Height + arrowSize
                 );
        }

        public Operation GetOperation(Point mouse) {

            if (mouse.Distance(position) < arrowSize) {
                return Operation.Replace;
            }

            if(mouse.Distance(new Point(position.X + size.Width, position.Y + size.Height)) < arrowSize) {
                return Operation.Resize;
            }


            return Operation.None;
        }

        public void GroupReplace(Point p) {
            position = p;
        }

        public void GroupResize(Size s) {
            size = s;
        }
    }
}
