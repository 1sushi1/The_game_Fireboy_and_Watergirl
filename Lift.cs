using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{   /// <summary>
/// 电梯类
/// </summary>
    internal class Lift
    {
        int count = 25;
        public Rectangle Rectangle { get; set; }
        public Lift(Rectangle rec)
        {
            Rectangle = rec;
        }
        public void Draw(Graphics g,Bitmap bitmap)
        {
            g.DrawImage(bitmap, Rectangle);
        }
        /// <summary>
        /// 电梯上升
        /// </summary>
        public void Up()
        {
            if (count < 25)
            { Rectangle = new Rectangle(Rectangle.X, Rectangle.Y - 2, Rectangle.Width, Rectangle.Height);
                count++;
            }
        }
        /// <summary>
        /// 电梯下降
        /// </summary>
        public void Down()
        {
            if (count > 0)
            {
                Rectangle = new Rectangle(Rectangle.X, Rectangle.Y + 2, Rectangle.Width, Rectangle.Height);
                count--;
            }
        }
    }
}
