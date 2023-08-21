using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{   /// <summary>
/// box类的物理性质也和冰火娃一样，本身有着向下的速度
/// </summary>
    internal class Box
    {
        
        public Rectangle Rectangle { get; set; }
        public int SpeedX;
        public int SpeedY;
        public int Height=30;
        public int Width=30;
        public Box()
        {
            Rectangle = new Rectangle(520,160,Width,Height);
            SpeedX = 0;
            SpeedY = 20;
        }
        public void Draw(Graphics g)
        {

            g.DrawImage(Properties.Resources.箱子, Rectangle);
        }
        /// <summary>
        /// 处理box的重力问题
        /// </summary>
        /// <returns></returns>
        public Rectangle NextYRectangle()
        {
                Rectangle rect = new Rectangle(Rectangle.X, Rectangle.Y + 1, Width, Height);
                return rect;
        }
        /// <summary>
        /// 获取box水平移动后的下一个位置
        /// </summary>
        /// <returns></returns>
        public Rectangle NextXRectangle()
        {
            if (SpeedX > 0)
            {
                Rectangle rect = new Rectangle(Rectangle.X + 1, Rectangle.Y, Width, Height);
                return rect;
            }
            if (SpeedX < 0)
            {
                Rectangle rect = new Rectangle(Rectangle.X - 1, Rectangle.Y, Width, Height);
                return rect;
            }
            else
            {
                Rectangle rect = new Rectangle(Rectangle.X , Rectangle.Y, Width, Height);
                return rect;
            }
        }
        /// <summary>
        /// 改变box的Y坐标
        /// </summary>
        public void MoveY()
        {
            
                Rectangle = new Rectangle(Rectangle.X-2, Rectangle.Y + 1, Width, Height);
        }
        /// <summary>
        /// 改变box的X坐标
        /// </summary>
        public void MoveX()
        {

            if (SpeedX > 0)
            {
                Rectangle = new Rectangle(Rectangle.X+1, Rectangle.Y , Width, Height);
            }
            if (SpeedX < 0)
            {
                Rectangle = new Rectangle(Rectangle.X-1, Rectangle.Y , Width, Height);
            }
        }
        /// <summary>
        /// 改变box的水平速度
        /// </summary>
        public void ChangeSpeedX()
        {
            SpeedX = 5;
        }
        public void ChangeDegreeSpeedX()
        {
            SpeedX = -5;
        }
        public void ChangeZeroSpeedX()
        {
            SpeedX = 0;
        }
    }
}
