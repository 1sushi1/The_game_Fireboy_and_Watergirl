using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{   
    /// <summary>
    /// 控制杆类
    /// </summary>
    internal class Pole
    { 
        public bool Ctrl; 
        public Rectangle Rectangle { get; set; }
        public Pole()
        {
            Rectangle = new Rectangle(235,385,28,45);
            Ctrl = false;
        }
        public void Draw(Graphics g)
        {
            if (Ctrl)
                g.DrawImage(Properties.Resources.操作杆左向, Rectangle);
            if (!Ctrl)
                g.DrawImage(Properties.Resources.操作杆右向, Rectangle);
        }
        public void ChangeCtrl()
        {
            Ctrl = true;
            Rectangle = new Rectangle(210, 385, 28, 43);
        }
        public void ChangeDegreeCtrl()
        {
            Ctrl = false;
            Rectangle = new Rectangle(235, 385, 28, 45);
        }
    }
}
