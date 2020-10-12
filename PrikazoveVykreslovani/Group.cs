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
        
        public void DrawGroup(Graphics g) {
            foreach (var shape in shapes) {
                shape.Draw(g);
            }
        }
    }
}
