using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrikazoveVykreslovani
{
    public enum ShapeType
    {
        Rectangle,
        Ellipse,
        Cross,
        Line,
        Triangle,
        Hexagon,
        Arrow
    }

    public abstract class Shape
    {
        protected Pen visualizePen = new Pen(Color.Black, 3) 
        { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash};

        public Point start;
        public Point end;
        public Color color;
        public int lineWidth = 4;
        public bool filled;

        public static Shape CreateShape(string s, Shape origin) {
            var shape = CreateShape(s);
            shape.color = origin.color;
            shape.end = origin.end;
            shape.filled = origin.filled;
            shape.lineWidth = origin.lineWidth;
            shape.start = origin.start;
            return shape;
        }

        public static Shape CreateShape(string s) {
            s = CorrectShapeName(s);
            return (Shape) Activator.CreateInstance(
                Type.GetType("PrikazoveVykreslovani." + s));
        }

        private static string CorrectShapeName(string s) {
            var names = Enum.GetNames(typeof(ShapeType));
            if (names.Contains(s)) {
                return s;
            } else {
                return "Rectangle";
            }
        }

        public abstract void Draw(Graphics g);

        public abstract void Visualize(Graphics g);

        public override string ToString() {
            return GetType().Name + start + " " + end;
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw(Graphics g) {
            if (filled) {
                g.FillRectangle(new SolidBrush(color),
                    start.X, start.Y,
                    end.X - start.X, end.Y - start.Y);
            } else {
                g.DrawRectangle(new Pen(color, lineWidth),
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
            }
        }

        public override void Visualize(Graphics g) {
            g.DrawRectangle(visualizePen,
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
        }
    }

    public class Ellipse : Shape
    {
        public override void Draw(Graphics g) {
            if (filled) {
                g.FillEllipse(new SolidBrush(color),
                    start.X, start.Y,
                    end.X - start.X, end.Y - start.Y);
            } else {
                g.DrawEllipse(new Pen(color, lineWidth),
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
            }
        }
        public override void Visualize(Graphics g) {
            g.DrawEllipse(visualizePen,
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
        }
    }

    public class Cross : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, lineWidth), start, end);
            g.DrawLine(new Pen(color, lineWidth), start.X, end.Y, end.X, start.Y);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(visualizePen, start, end);
            g.DrawLine(visualizePen, start.X, end.Y, end.X, start.Y);
        }
    }

    public class Line : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, lineWidth), start, end);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(visualizePen, start, end);
        }
    }

    public class Triangle : Shape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[3] {
                new Point(start.X, end.Y),
                end,
                new Point((end.X + start.X)/2, start.Y)
            };

            if(filled) {
                g.FillPolygon(new SolidBrush(color), points);
            } else {
                g.DrawPolygon(new Pen(color, lineWidth), points);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] points = new Point[3] {
                new Point(start.X, end.Y),
                end,
                new Point((end.X + start.X)/2, start.Y)
            };
            g.DrawPolygon(visualizePen, points);
        }
    }

    public class Hexagon : Shape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4, end.Y),
                new Point(start.X+(end.X-start.X)/4*3, end.Y),
                new Point(end.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4*3, start.Y),
                new Point(start.X+(end.X-start.X)/4, start.Y)
            };

            if (filled) {
                g.FillPolygon(new SolidBrush(color), points);
            } else {
                g.DrawPolygon(new Pen(color, lineWidth), points);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4, end.Y),
                new Point(start.X+(end.X-start.X)/4*3, end.Y),
                new Point(end.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4*3, start.Y),
                new Point(start.X+(end.X-start.X)/4, start.Y)
            };
            g.DrawPolygon(visualizePen, points);
        }
    }
}
