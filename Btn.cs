using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{   /// <summary>
/// 定义冰火娃踩的机关类
/// </summary>
    internal class Btn
    {
        public bool occupy;
        public Rectangle Rectangle { get; set; }
        public Btn(Rectangle rec)
        {
            Rectangle = rec;
            occupy = false;
        }
        public void Draw(Graphics g)
        {
            if(!occupy)
            {
                g.DrawImage(Properties.Resources.按钮,Rectangle);
            }
        }
    }
}
