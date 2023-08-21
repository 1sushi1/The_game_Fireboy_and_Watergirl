using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{   
    /// <summary>
    /// 钻石类
    /// </summary>
    internal class Diamond
    {
        public bool Type;
        public bool Eat;
        public Rectangle Rectangle { get; set; }
        public Diamond(Rectangle rec, bool type)
        {
            Rectangle = rec;
            Eat = false;
            Type = type;
        }
        public void Draw(Graphics g)
        {
            if (!Eat)
            {
                if (Type)
                {
                    g.DrawImage(Properties.Resources.火钻, Rectangle);
                }
                else
                {
                    g.DrawImage(Properties.Resources.冰钻, Rectangle);
                }
            }
        }
    }
}
