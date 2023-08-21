using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestMan
{
    /// <summary>
    /// 砖块类
    /// </summary>
    internal class Block
    {
        public Rectangle Rectangle { get; set; }
        public Block(Rectangle rec)
        {
            Rectangle = rec;
        }
        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black), Rectangle);
            
        }
    }
    /// <summary>
    /// 建立火池的类
    /// </summary>
    internal class FireBlock
    {
        public Rectangle Rectangle { get; set; }
        public FireBlock()
        {
            Rectangle = new Rectangle(463, 581, 115, 12);
        }
    }
    /// <summary>
    /// 建立水池的类
    /// </summary>
    internal class IceBlock
    {
        public Rectangle Rectangle { get; set; }
        public IceBlock()
        {
            Rectangle = new Rectangle(664, 581, 115, 12);
        }
    }
    /// <summary>
    /// 建立毒池的类
    /// </summary>
    internal class PoisionBlock
    {
        public Rectangle Rectangle { get; set; }
        public PoisionBlock()
        {
            Rectangle = new Rectangle(612, 455, 115, 12);
        }
    }
    /// <summary>
    /// 建立胜利之门类
    /// </summary>
    internal class BulandDarwaza
    {
        public Rectangle Rectangle1 { get; set; }
        public Rectangle Rectangle2 { get; set; }
        public BulandDarwaza()
        {
            Rectangle1 = new Rectangle(810, 60, 70, 60);
            Rectangle2 = new Rectangle(900, 60, 70, 60);
        }
       
        
    }
}
