using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ForestMan
{
    /// <summary>
    /// 人类
    /// </summary>
    internal class Man
    {
        public Bitmap leftPicture;
        public Bitmap rightPicture;
        public Bitmap standPicture;
        public Bitmap leftPicture2;
        public Bitmap rightPicture2;
        public Bitmap jumpPicture;
        public Bitmap fallPicture;
        public Bitmap leftJumpPicture;
        public Bitmap rightJumpPicture;
        public Bitmap leftFallPicture;
        public Bitmap rightFallPicture;

        public string leftKey;
        public string rightKey;
        public string upKey;

        public int manWidth = 40;
        public int manHeight = 50;
        public bool picture;
        //定义速度
        public int SpeedX;
        public int SpeedY;
        //定义加速度
        public Rectangle Rectangle { get; set; }
        public Man()
        {   
            SpeedX = 0;
            SpeedY = 20;
            picture = false;

        }
       


        
        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {   
            if(SpeedX==0&&SpeedY==20)
                g.DrawImage(standPicture, Rectangle);
            else if(SpeedX == 0 && SpeedY>=0&&SpeedY<20)
                g.DrawImage(fallPicture, Rectangle);
            else if (SpeedX == 0 && SpeedY <0)
                g.DrawImage(jumpPicture, Rectangle);
            else if(SpeedX < 0 && SpeedY == 20 && picture == false)
            {
                picture = !picture;
                g.DrawImage(leftPicture, Rectangle);
                
            }
            else if(SpeedX < 0 && SpeedY == 20 && picture == true)
            {
                picture = !picture;
                g.DrawImage(leftPicture2, Rectangle);
                
            }
            else if (SpeedX > 0 && SpeedY == 20&&picture == false)
            {
                picture = !picture;
                g.DrawImage(rightPicture, Rectangle);
               
            }
            else if (SpeedX > 0 && SpeedY == 20 && picture == true)
            {
                picture = !picture;
                g.DrawImage(rightPicture2, Rectangle);
                
            }
            else if (SpeedX < 0 && SpeedY >= 0 && SpeedY < 20)
                g.DrawImage(leftFallPicture, Rectangle);
            else if (SpeedX > 0 && SpeedY >= 0 && SpeedY < 20)
                g.DrawImage(rightFallPicture, Rectangle);
            else if (SpeedX > 0 && SpeedY <0)
                g.DrawImage(rightJumpPicture, Rectangle);
            else if (SpeedX < 0 && SpeedY < 0)
                g.DrawImage(leftJumpPicture, Rectangle);
            
        }

        /// <summary>
        /// 获取Y动了的位置
        /// </summary>
        /// <returns></returns>
        public Rectangle NextYRectangle()
        {
            if (SpeedY > 0)
            {
                Rectangle rect = new Rectangle(Rectangle.X, Rectangle.Y + 1, manWidth, manHeight);
                return rect;
            }
            else
            {
                Rectangle rect = new Rectangle(Rectangle.X, Rectangle.Y - 1, manWidth, manHeight);
                return rect;
            }
        }
        /// <summary>
        /// 判断X动了的位置
        /// </summary>
        /// <returns></returns>
        public Rectangle NextXRectangle()
        {
            if (SpeedX > 0)
            {
                Rectangle rect = new Rectangle(Rectangle.X+1, Rectangle.Y , manWidth, manHeight);
                return rect;
            }
            if (SpeedX < 0)
            {
                Rectangle rect = new Rectangle(Rectangle.X - 1, Rectangle.Y, manWidth, manHeight);
                return rect;
            }
            else return Rectangle;
        }
        /// <summary>
        /// 处理按键
        /// </summary>
        /// <param name="key"></param>
        public void keyDown(String key)
        {
            int newX = Rectangle.X;
            if (key == leftKey)
            {
                SpeedX = -10;
            }
            if (key == rightKey)
            {
                SpeedX = 10;
            }
            if (key == upKey)
            {   if (SpeedY == 20)
                {
                    SpeedY = -20;
                }
            }
        }
        /// <summary>
        /// 当松开键盘时，X轴速度就归零
        /// </summary>
        /// <param name="key"></param>
        public void keyUp(String key)
        {
            if(key == leftKey||key == rightKey)
            {
                SpeedX = 0;
            }
        }
        /// <summary>
        /// 改变娃的Y的位置
        /// </summary>
        public void MoveY()
        { if (SpeedY > 0)
            {
                Rectangle = new Rectangle(Rectangle.X, Rectangle.Y + 1, manWidth, manHeight);
            }
            else
            {
                Rectangle = new Rectangle(Rectangle.X, Rectangle.Y - 1, manWidth, manHeight);
            }
        }
        /// <summary>
        /// 改变娃的X的位置
        /// </summary>
        public void MoveX()
        {
            if (SpeedX > 0)
            {
                Rectangle = new Rectangle(Rectangle.X+1, Rectangle.Y , manWidth, manHeight);
            }
            if(SpeedX < 0)
            {
                Rectangle = new Rectangle(Rectangle.X-1, Rectangle.Y , manWidth, manHeight);
            }
        }
         /// <summary>
         /// 若speedY被改变，则递加直到回到他的初始值
         /// </summary>
         public void SpeedYChanged()
        {
            if (SpeedY < 20)
                SpeedY += 2;
        }
    }



    /// <summary>
    /// 火人类
    /// </summary>
    internal class fireMan : Man
    {
        public fireMan()
        {
            Rectangle = new Rectangle(100, 530, manWidth, manHeight);
            leftPicture = new Bitmap(Properties.Resources.火娃左跑);
            rightPicture = new Bitmap(Properties.Resources.火娃右跑);
            leftPicture2 = new Bitmap(Properties.Resources.火娃左跑2);
            rightPicture2 = new Bitmap(Properties.Resources.火娃右跑2);
            standPicture = new Bitmap(Properties.Resources.火娃站立);
            jumpPicture = new Bitmap(Properties.Resources.火娃上升);
            fallPicture = new Bitmap(Properties.Resources.火娃下落);
            leftJumpPicture = new Bitmap(Properties.Resources.火娃左上升);
            leftFallPicture = new Bitmap(Properties.Resources.火娃左下降);
            rightJumpPicture = new Bitmap(Properties.Resources.火娃右上升);
            rightFallPicture = new Bitmap(Properties.Resources.火娃右下降);
            leftKey = "Left";
            rightKey = "Right";
            upKey = "Up";
        }
    }
    /// <summary>
    /// 冰人类
    /// </summary>
    internal class iceMan : Man
    {
        public iceMan()
        {
            Rectangle = new Rectangle(50, 530, manWidth, manHeight);
            leftPicture = new Bitmap(Properties.Resources.冰娃左跑1);
            rightPicture = new Bitmap(Properties.Resources.冰娃右跑1);
            leftPicture2 = new Bitmap(Properties.Resources.冰娃左跑2);
            rightPicture2 = new Bitmap(Properties.Resources.冰娃右跑2);
            standPicture = new Bitmap(Properties.Resources.冰娃站立);
            jumpPicture = new Bitmap(Properties.Resources.冰娃上升);
            fallPicture = new Bitmap(Properties.Resources.冰娃下降);
            leftJumpPicture = new Bitmap(Properties.Resources.冰娃左上升);
            leftFallPicture = new Bitmap(Properties.Resources.冰娃左下降);
            rightJumpPicture = new Bitmap(Properties.Resources.冰娃右上升);
            rightFallPicture = new Bitmap(Properties.Resources.冰娃右下降);
            leftKey = "A";
            rightKey = "D";
            upKey = "W";
        }
    }
}


