using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Media;

namespace ForestMan
{
    internal class Game
    {
        //定义背景音乐
        public SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgm1);
        //定义画布大小
        public const int GameWidth = 1000;
        public const int GameHeight = 600;
        private fireMan fireMan;
        private iceMan iceMan;
        public System.Timers.Timer Timer { get; set; }
        //定义委托
        public delegate void GameChanged();
        //定义事件
        public event GameChanged gameChanged;
        //为火池的图片切换添加记数器
        public int firePool = 0;
        //Dead1画死亡成灰的判断器
        public bool fireDead1 = false;
        public bool iceDead1 = false;
        //Win1画通关的判断器
        public bool Win1 = false;
        //Dead2是终止游戏的判断器
        public bool Dead2 = false;
        //Win2是中止游戏的判断器
        public bool Win2 = false;
        //成灰动画记数器
        public int mist = 0;
        //胜利之门打开动画计数器
        public  int door = 0;
        /// <summary>
        /// 定义所有的块类集合
        /// </summary>
        public List<Block> Blocks;
        /// <summary>
        /// 定义所有的钻石类集合
        /// </summary>
        public List<Diamond> Diamonds;
        //定义所有池
        public FireBlock fireBlock;
        public IceBlock iceBlock;
        public PoisionBlock poisionBlock;
        //定义胜利之门
        public BulandDarwaza bulandDarwaza;
        //定义操纵杆
        public Pole pole;
        //定义按钮
        public Btn button1;
        public Btn button2;
        //定义电梯1和2
        public Lift lift1;
        public Lift lift2;
        //定义箱子类
        public Box box;
        /// <summary>
        /// 导入块列表
        /// </summary>
        public void InputBlocks()
        {
            Rectangle rectangle = new Rectangle(0,0,973,18);
            Block block;
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(973, 0, 27, 600);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(267,79, 62, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(300, 99, 90, 21);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(300, 120, 130, 55);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(430, 120, 543, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(20, 144, 125, 76);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(20, 225, 490, 25);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(510, 190,205, 55);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(715, 225, 155, 40);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(120, 310, 390, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(390, 330, 973, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(20, 415, 410, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(430, 455, 182, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(727, 455, 120, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(612, 465, 115, 10);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(20, 495, 300, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(20, 580, 463, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(578, 580, 86, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(463, 592, 115, 8);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(664, 592, 115, 8);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(779, 580, 905, 20);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(905, 530, 68, 70);
            block = new Block(rectangle);
            Blocks.Add(block);
            rectangle = new Rectangle(0, 20, 20, 600);
            block = new Block(rectangle);
            Blocks.Add(block);
        }
        /// <summary>
        /// 导入钻石列表
        /// </summary>
        public void InputDiamonds()
        {
            Rectangle rectangle = new Rectangle(500,540,40,30);
            bool type = true;
            Diamond diamond;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);
             rectangle = new Rectangle(163, 266, 40, 30);
             type = true;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);
            rectangle = new Rectangle(269, 42, 40, 30);
            type = true;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);
            rectangle = new Rectangle(585, 84, 40, 30);
            type = false;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);
            rectangle = new Rectangle(708, 540, 40, 30);
            type = false;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);
            rectangle = new Rectangle(580, 290, 40, 30);
            type = false;
            diamond = new Diamond(rectangle, type);
            Diamonds.Add(diamond);

        }
        public Game()
        {
            //开始播放游戏界面的bgm
            bgm.PlayLooping();
            //初始化冰火娃
            fireMan = new fireMan();
            iceMan = new iceMan();
            Timer = new System.Timers.Timer();
            //初始化集合
            Blocks = new List<Block>();
            Diamonds = new List<Diamond>();
            //初始化火水毒类
            fireBlock = new FireBlock();
            iceBlock = new IceBlock();
            poisionBlock = new PoisionBlock();
            //初始化箱子
            box = new Box();
            //初始化操纵杆
            pole = new Pole();
            //初始化按钮
            button1 = new Btn(new Rectangle(766, 216, 54, 10));
            button2 = new Btn(new Rectangle(250, 300, 54, 10));
            //初始化电梯
            lift1 = new Lift(new  Rectangle(20, 330, 100, 15));
            lift2 = new Lift(new Rectangle(870,265,100, 15));   
            //初始化胜利之门
            bulandDarwaza = new BulandDarwaza();
            InputBlocks();
            InputDiamonds();
            Timer.Interval = 50; //获取时间的间隔（以毫秒为单位）
            //指定时钟事件的处理程序
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
            bgm.PlayLooping();
        }
        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="gra"></param>
        /// <param name="size"></param>
        public void Draw(Graphics gra,Size size)
        {
            Image img = new Bitmap(GameWidth, GameHeight);
            Graphics _g = Graphics.FromImage(img);
            Rectangle rec = new Rectangle(new Point(0, 0), new Size(GameWidth, GameHeight));
            _g.DrawImage(Properties.Resources.地图, rec);
            foreach (var Diamond in Diamonds)
            {
                Diamond.Draw(_g);
            }
            DrawPole(_g);
            DrawBtn(_g);
            DrawMan(_g);
            DrawBox(_g);
            DrawLift(_g);
            DrawPool(_g);
            DrawDead(_g);
            DrawWin(_g);
            gra.DrawImage(img, new Rectangle(new Point(0, 0), size));
        }
        /// <summary>
        /// 画冰火娃
        /// </summary>
        /// <param name="g"></param>
        public void DrawMan(Graphics g)
        {   if (Win1 == false)
            {
                if (fireDead1 == false)
                {
                    fireMan.Draw(g);
                }
                if (iceDead1 == false)
                {
                    iceMan.Draw(g);
                }
            }
        }
        /// <summary>
        /// 画电梯
        /// </summary>
        /// <param name="g"></param>
        public void DrawLift(Graphics g)
        {
            lift1.Draw(g,Properties.Resources.电梯);
            lift2.Draw(g, Properties.Resources.电梯2);
            
        }
        //画控制电梯的按钮
        public void DrawBtn(Graphics g)
        {
            button1.Draw(g);
            button2.Draw(g);
        }
        public void DrawPole(Graphics g)
        {
            pole.Draw(g);
        }
        /// <summary>
        /// 画箱子
        /// </summary>
        /// <param name="g"></param>
        public void DrawBox(Graphics g)
        {
            box.Draw(g);
        }
        /// <summary>
        /// 画池水
        /// </summary>
        /// <param name="g"></param>
        public void DrawPool(Graphics g)
        {
                
            
                if (firePool == 2) firePool = 0;
                else firePool = firePool + 1;
                switch (firePool)
                {
                    case 0:
                        g.DrawImage(Properties.Resources.火池1, fireBlock.Rectangle);
                        g.DrawImage(Properties.Resources.水池1, iceBlock.Rectangle);
                        g.DrawImage(Properties.Resources.毒池1, poisionBlock.Rectangle);
                        break;
                    case 1:
                        g.DrawImage(Properties.Resources.火池2, fireBlock.Rectangle);
                        g.DrawImage(Properties.Resources.水池2, iceBlock.Rectangle);
                        g.DrawImage(Properties.Resources.毒池2, poisionBlock.Rectangle);
                        break;
                    case 2:
                        g.DrawImage(Properties.Resources.火池3, fireBlock.Rectangle);
                        g.DrawImage(Properties.Resources.水池3, iceBlock.Rectangle);
                        g.DrawImage(Properties.Resources.毒池3, poisionBlock.Rectangle);
                        break;
                }
            
        }
        /// <summary>
        /// 时钟事件，激发Refresh事件，通知主窗体更新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(gameChanged!=null)
                gameChanged(); 
        }
        /// <summary>
        /// 获取火娃Y速度
        /// </summary>
        /// <returns></returns>
        public int GetFireSpeedY()
        {
            return fireMan.SpeedY;
        }
        /// <summary>
        /// 获取火娃X速度
        /// </summary>
        /// <returns></returns>
        public int GetFireSpeedX()
        {
            return fireMan.SpeedX;
        }
        /// <summary>
        /// 获取冰娃Y速度
        /// </summary>
        /// <returns></returns>
        public int GetIceSpeedY()
        {
            return iceMan.SpeedY;
        }
        /// <summary>
        /// 获取兵娃Y速度
        /// </summary>
        /// <returns></returns>
        public int GetIceSpeedX()
        {
            return iceMan.SpeedX;
        }
        /// <summary>
        /// 获取箱子Y速度
        /// </summary>
        /// <returns></returns>
        public int GetBoxSpeedY()
        {
            return box.SpeedY;
        }
        /// <summary>
        /// 获取箱子X速度
        /// </summary>
        /// <returns></returns>
        public int GetBoxSpeedX()
        {
            return box.SpeedX;
        }
        /// <summary>
        /// 判断冰火娃是否进入墙壁，若不进入，则更新位置
        /// </summary>
        public void ChangePosition()
        {   int FireSpeedY = GetFireSpeedY();
            for (int i = 0; i < Math.Abs(FireSpeedY); i++)
            {
                bool judge1 = true;
                Rectangle nextFireYRec = new Rectangle();
                nextFireYRec = fireMan.NextYRectangle();
                if (nextFireYRec.IntersectsWith(pole.Rectangle))
                    judge1 = false;
                //判断下一个位置是否进入了电梯
                if (nextFireYRec.IntersectsWith(lift1.Rectangle))
                    judge1 = false;
                if (nextFireYRec.IntersectsWith(lift2.Rectangle))
                    judge1 = false;
                //判断下一个位置是否进入了砖块
                if (nextFireYRec.IntersectsWith(box.Rectangle))
                    judge1 = false;
                //判断下一个位置是否进入了墙壁
                foreach (var Block in Blocks)
                {
                    if (nextFireYRec.IntersectsWith(Block.Rectangle))
                    {
                        judge1 = false;
                        break;
                    }
                } 
                //只有下个位置不会进入墙壁和砖块时，才更新位置
                if (judge1)
                    fireMan.MoveY();
                else break;
            }
            int FireSpeedX = GetFireSpeedX();
            for (int i = 0; i < Math.Abs(FireSpeedX); i++)
            {
                bool judge2 = true;
                Rectangle nextFireXRec = new Rectangle();
                nextFireXRec = fireMan.NextXRectangle();
                if (nextFireXRec.IntersectsWith(pole.Rectangle))
                    judge2 = false;
                //判断下一个位置是否进入了电梯
                if (nextFireXRec.IntersectsWith(lift2.Rectangle))
                    judge2 = false;
                if (nextFireXRec.IntersectsWith(lift1.Rectangle))
                    judge2 = false;
                //判断下一个位置是否进入了砖块
                if (nextFireXRec.IntersectsWith(box.Rectangle))
                    judge2 = false;
                //判断下一个位置是否进入了墙壁
                foreach (var Block in Blocks)
                {
                    if (nextFireXRec.IntersectsWith(Block.Rectangle))
                    {
                        judge2 = false;
                        break;
                    }
                }
                //只有下个位置不会进入墙壁和砖块时，才更新位置
                if (judge2)
                    fireMan.MoveX();
                else break;
            }

            int IceSpeedY = GetIceSpeedY();
            for (int i = 0; i < Math.Abs(IceSpeedY); i++)
            {
                bool judge3 = true;
                Rectangle nextIceYRec = new Rectangle();
                nextIceYRec = iceMan.NextYRectangle();
                if (nextIceYRec.IntersectsWith(pole.Rectangle))
                    judge3 = false;
                //判断下一个位置是否进入了电梯
                if (nextIceYRec.IntersectsWith(lift1.Rectangle))
                    judge3 = false;
                if (nextIceYRec.IntersectsWith(lift2.Rectangle))
                    judge3 = false;
                //判断下一个位置是否进入了砖块
                if (nextIceYRec.IntersectsWith(box.Rectangle))
                    judge3 = false;
                foreach (var Block in Blocks)
                {
                    if (nextIceYRec.IntersectsWith(Block.Rectangle))
                    {
                        judge3 = false;
                        break;
                    }
                }
                //只有下个位置不会进入墙壁和砖块时，才更新位置
                if (judge3)
                    iceMan.MoveY();
                else break;
            }
            int IceSpeedX = GetIceSpeedX();
            for (int i = 0; i < Math.Abs(IceSpeedX); i++)
            {
                bool judge4 = true;
                Rectangle nextIceXRec = new Rectangle();
                nextIceXRec = iceMan.NextXRectangle();
                if (nextIceXRec.IntersectsWith(pole.Rectangle))
                    judge4 = false;
                //判断下一个位置是否进入了电梯
                if (nextIceXRec.IntersectsWith(lift1.Rectangle))
                    judge4 = false;
                if (nextIceXRec.IntersectsWith(lift2.Rectangle))
                    judge4 = false;
                //判断下一个位置是否进入了砖块
                if (nextIceXRec.IntersectsWith(box.Rectangle))
                    judge4 = false;
                foreach (var Block in Blocks)
                {
                    if (nextIceXRec.IntersectsWith(Block.Rectangle))
                    {
                        judge4 = false;
                        break;
                    }
                }
                //只有下个位置不会进入墙壁和砖块时，才更新位置
                if (judge4)
                    iceMan.MoveX();
                else break;
            }
        }
        /// <summary>
        /// 改变Box的速度
        /// </summary>
        public void ChangeBoxSpeed()
        {   
            //保证冰娃或火娃与砖块挨着时速度才会改变
            if ((fireMan.Rectangle.X == box.Rectangle.X + box.Rectangle.Width && 
                (fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 > box.Rectangle.Y && 
                fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 < box.Rectangle.Y + box.Rectangle.Height))||
                (iceMan.Rectangle.X == box.Rectangle.X + box.Rectangle.Width &&
                (iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 > box.Rectangle.Y &&
                iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 < box.Rectangle.Y + box.Rectangle.Height)))
                box.ChangeDegreeSpeedX();
            if ((fireMan.Rectangle.X + fireMan.Rectangle.Width == box.Rectangle.X && 
                (fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 > box.Rectangle.Y && 
                fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 < box.Rectangle.Y + box.Rectangle.Height))||
                (iceMan.Rectangle.X + iceMan.Rectangle.Width == box.Rectangle.X &&
                (iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 > box.Rectangle.Y &&
                iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 < box.Rectangle.Y + box.Rectangle.Height)))
                box.ChangeSpeedX();

        }
        /// <summary>
        /// 处理操纵杆的状态改变
        /// </summary>
        public void ChangePoleStatus()
        {
            bool judge1 = (fireMan.Rectangle.X == pole.Rectangle.X + pole.Rectangle.Width);
            bool judge2 = (fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 > pole.Rectangle.Y);
            bool judge3 = (fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 < pole.Rectangle.Y + pole.Rectangle.Height);
            bool judge4 = (judge2 && judge3);
            bool judge5 = (judge1 && judge4);
            bool judge6 = (iceMan.Rectangle.X == pole.Rectangle.X + pole.Rectangle.Width);
            bool judge7 = (iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 > pole.Rectangle.Y);
            bool judge8 = (iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 < pole.Rectangle.Y + pole.Rectangle.Height);
            bool judge9 = (judge7 && judge8);
            bool judge10 = (judge6 && judge9);
            //保证冰娃或火娃与操纵杆挨着时方向才会改变
            switch (pole.Ctrl)
            {
                
                case false:
                if (judge5||judge10) pole.ChangeCtrl();
                    PerfectUp();
                    break;
               case true:
                if (((fireMan.Rectangle.X + fireMan.Rectangle.Width == pole.Rectangle.X) &&
                    (fireMan.Rectangle.Y + fireMan.Rectangle.Height / 2 > pole.Rectangle.Y &&
                    fireMan.Rectangle.Y + fireMan.Rectangle.Height /2  < pole.Rectangle.Y + pole.Rectangle.Height)) ||
                    ((iceMan.Rectangle.X + iceMan.Rectangle.Width == pole.Rectangle.X) &&
                    (iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 > pole.Rectangle.Y &&
                    iceMan.Rectangle.Y + iceMan.Rectangle.Height / 2 < pole.Rectangle.Y + pole.Rectangle.Height)))
                {
                    pole.ChangeDegreeCtrl();
                    
                }
                    PerfectDown();
                    break;
            }

        }
        /// <summary>
        /// 处理电梯1下降
        /// </summary>
        public void PerfectDown()
        {
            lift1.Down();
            if (fireMan.Rectangle.IntersectsWith(lift1.Rectangle)) fireMan.Rectangle = new Rectangle(lift1.Rectangle.X + lift1.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
            if (iceMan.Rectangle.IntersectsWith(lift1.Rectangle)) iceMan.Rectangle = new Rectangle(lift1.Rectangle.X + lift1.Rectangle.Width, fireMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
            foreach (var Block in Blocks)
            {
                if (fireMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    fireMan.Rectangle = new Rectangle(Block.Rectangle.X - fireMan.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
                    break;
                }
            }
            foreach (var Block in Blocks)
            {
                if (iceMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    iceMan.Rectangle = new Rectangle(Block.Rectangle.X - iceMan.Rectangle.Width, iceMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
                    break;
                }
            }
        }
        /// <summary>
        /// 处理电梯1上升
        /// </summary>
        public void PerfectUp()
        {
            lift1.Up();
            if (fireMan.Rectangle.IntersectsWith(lift1.Rectangle)) fireMan.Rectangle = new Rectangle(fireMan.Rectangle.X, lift1.Rectangle.Y - fireMan.Rectangle.Height, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
            if (iceMan.Rectangle.IntersectsWith(lift1.Rectangle)) iceMan.Rectangle = new Rectangle(iceMan.Rectangle.X, lift1.Rectangle.Y - iceMan.Rectangle.Height, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
            foreach (var Block in Blocks)
            {
                if (fireMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    fireMan.Rectangle = new Rectangle(Block.Rectangle.X - fireMan.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
                    break;
                }
            }
            foreach (var Block in Blocks)
            {
                if (iceMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    iceMan.Rectangle = new Rectangle(Block.Rectangle.X - iceMan.Rectangle.Width, iceMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
                    break;
                }
            }
        }
        /// <summary>
        /// 通过按钮控制电梯2
        /// </summary>
        public void ChangeButtonStatus()
        {
            if (button1.Rectangle.IntersectsWith(iceMan.Rectangle) || button1.Rectangle.IntersectsWith(fireMan.Rectangle)|| button2.Rectangle.IntersectsWith(iceMan.Rectangle) || button2.Rectangle.IntersectsWith(fireMan.Rectangle))
            {
                PerfectDown2();
            }
            else
            {
                PerfectUp2();
            }
            if (button2.Rectangle.IntersectsWith(iceMan.Rectangle) || button2.Rectangle.IntersectsWith(fireMan.Rectangle))
            {
                button2.occupy = true;
            }
            else button2.occupy = false;
            if (button1.Rectangle.IntersectsWith(iceMan.Rectangle) || button1.Rectangle.IntersectsWith(fireMan.Rectangle))
            {
                button1.occupy = true;
            }
            else button1.occupy = false;

        }
        /// <summary>
        /// 处理电梯2下降
        /// </summary>
        public void PerfectDown2()
        {
            lift2.Down();
            if (fireMan.Rectangle.IntersectsWith(lift2.Rectangle)) fireMan.Rectangle = new Rectangle(lift2.Rectangle.X + lift2.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
            if (iceMan.Rectangle.IntersectsWith(lift2.Rectangle)) iceMan.Rectangle = new Rectangle(lift2.Rectangle.X + lift2.Rectangle.Width, fireMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
            foreach (var Block in Blocks)
            {
                if (fireMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    fireMan.Rectangle = new Rectangle(Block.Rectangle.X +Block.Rectangle.Width- fireMan.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
                    break;
                }
            }
            foreach (var Block in Blocks)
            {
                if (iceMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    iceMan.Rectangle = new Rectangle(Block.Rectangle.X +Block.Rectangle.Width- iceMan.Rectangle.Width, iceMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
                    break;
                }
            }
        }
        /// <summary>
        /// 处理电梯2上升
        /// </summary>
        public void PerfectUp2()
        {
            lift2.Up();
            if (fireMan.Rectangle.IntersectsWith(lift2.Rectangle)) fireMan.Rectangle = new Rectangle(fireMan.Rectangle.X, lift2.Rectangle.Y - fireMan.Rectangle.Height, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
            if (iceMan.Rectangle.IntersectsWith(lift2.Rectangle)) iceMan.Rectangle = new Rectangle(iceMan.Rectangle.X, lift2.Rectangle.Y - iceMan.Rectangle.Height, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
            foreach (var Block in Blocks)
            {
                if (fireMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    fireMan.Rectangle = new Rectangle(Block.Rectangle.X +Block.Rectangle.Width, fireMan.Rectangle.Y, fireMan.Rectangle.Width, fireMan.Rectangle.Height);
                    break;
                }
            }
            foreach (var Block in Blocks)
            {
                if (iceMan.Rectangle.IntersectsWith(Block.Rectangle))
                {
                    iceMan.Rectangle = new Rectangle(Block.Rectangle.X +Block.Rectangle.Width, iceMan.Rectangle.Y, iceMan.Rectangle.Width, iceMan.Rectangle.Height);
                    break;
                }
            }
        }
        /// <summary>
        /// 改变Box的位置，只有box不撞到墙壁与冰火娃，才执行
        /// </summary>
        public void ChangeBoxPosition()
        {
            int BoxSpeedY = box.SpeedY;
            for (int i = 0; i < BoxSpeedY; i++)
            {
                bool judge1 = true;
                Rectangle nextBoxYRec = new Rectangle();
                nextBoxYRec = box.NextYRectangle();
                if(nextBoxYRec.IntersectsWith(fireMan.Rectangle)|| nextBoxYRec.IntersectsWith(iceMan.Rectangle))
                    judge1 = false;
                foreach (var Block in Blocks)
                {
                    if (nextBoxYRec.IntersectsWith(Block.Rectangle))
                    {
                        judge1 = false;
                        break;
                    }
                }
                //只有下个位置不会进入墙壁时，才更新位置
                if (judge1)
                {
                    box.MoveY();
                }
                else break;
            }
            int BoxSpeedX = box.SpeedX;
            for (int i = 0; i < Math.Abs(BoxSpeedX); i++)
            {
                bool judge2 = true;
                Rectangle nextBoxXRec = new Rectangle();
                nextBoxXRec = box.NextXRectangle();
                if (nextBoxXRec.IntersectsWith(fireMan.Rectangle) || nextBoxXRec.IntersectsWith(iceMan.Rectangle))
                    judge2 = false;
                foreach (var Block in Blocks)
                {
                    if (nextBoxXRec.IntersectsWith(Block.Rectangle))
                    {
                        judge2 = false;
                        break;
                    }
                }
                //只有下个位置不会进入墙壁时，才更新位置
                if (judge2)
                {
                    box.MoveX();
                }
                else break;
            }

        }
        /// <summary>
        /// 刷新冰火娃与箱子的速度
        /// </summary>
        public void SpeedChange()
        {
        fireMan.SpeedYChanged();
        iceMan.SpeedYChanged();
        box.ChangeZeroSpeedX();
        }
        public void keyDown(String key)
        {
            //if (key == "W")
            //    iceCall.Play();
            fireMan.keyDown(key);
            iceMan.keyDown(key);
            
        }
        public void keyUp(String key)
        {
            fireMan.keyUp((String)key);
            iceMan.keyUp(key);
        }
        /// <summary>
        /// 判断是否死亡
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            if (fireMan.Rectangle.IntersectsWith(iceBlock.Rectangle) || fireMan.Rectangle.IntersectsWith(poisionBlock.Rectangle))
            {
                fireDead1 = true;
                
                return true;
            }
            if (iceMan.Rectangle.IntersectsWith(fireBlock.Rectangle) || iceMan.Rectangle.IntersectsWith(poisionBlock.Rectangle))
            {
                iceDead1 = true;
              
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 判断是否获胜
        /// </summary>
        /// <returns></returns>
        public bool IsWin()
        {
            if (fireMan.Rectangle.IntersectsWith(bulandDarwaza.Rectangle1) && iceMan.Rectangle.IntersectsWith(bulandDarwaza.Rectangle2))
            {
                Win1 = true;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 画死亡的动画
        /// </summary>
        /// <param name="g"></param>
        public void DrawDead(Graphics g)
        {   if (IsGameOver())
            {
                if (fireDead1)
                {
                    switch (mist)
                    {
                        case 0: break;
                        case 1: g.DrawImage(Properties.Resources.成灰1, fireMan.Rectangle); break;
                        case 2: g.DrawImage(Properties.Resources.成灰2, fireMan.Rectangle); break;
                        case 3: g.DrawImage(Properties.Resources.成灰3, fireMan.Rectangle); break;
                        case 4: g.DrawImage(Properties.Resources.成灰4, fireMan.Rectangle); break;
                        case 5: g.DrawImage(Properties.Resources.成灰5, fireMan.Rectangle); Dead2 = true; break;
                        default: break;
                    }
                    mist++;
                }
                if (iceDead1)
                {
                    switch (mist)
                    {
                        case 0: break;
                        case 1: g.DrawImage(Properties.Resources.成灰1, iceMan.Rectangle); break;
                        case 2: g.DrawImage(Properties.Resources.成灰2, iceMan.Rectangle); break;
                        case 3: g.DrawImage(Properties.Resources.成灰3, iceMan.Rectangle); break;
                        case 4: g.DrawImage(Properties.Resources.成灰4, iceMan.Rectangle); break;
                        case 5: g.DrawImage(Properties.Resources.成灰5, iceMan.Rectangle); Dead2 = true; break;
                        default: break;
                    }
                    mist++;
                }
            }
        }
        /// <summary>
        /// 画获胜的动画
        /// </summary>
        /// <param name="g"></param>
        public void DrawWin(Graphics g)
        {
                if (IsWin())
                {
                    switch (door)
                    {
                        case 0: break;
                        case 1:
                            {
                                g.DrawImage(Properties.Resources.火娃通关1, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关1, bulandDarwaza.Rectangle2);
                                break;
                            }
                        case 2:
                            {
                                g.DrawImage(Properties.Resources.火娃通关2, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关2, bulandDarwaza.Rectangle2);
                                break;
                            }
                        case 3:
                            {
                                g.DrawImage(Properties.Resources.火娃通关3, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关3, bulandDarwaza.Rectangle2);
                                break;
                            }
                        case 4:
                            {
                                g.DrawImage(Properties.Resources.火娃通关4, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关4, bulandDarwaza.Rectangle2);
                                break;
                            }
                        case 5:
                            {
                                g.DrawImage(Properties.Resources.火娃通关5, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关5, bulandDarwaza.Rectangle2);
                                break;
                            }
                        case 6:
                            {
                                g.DrawImage(Properties.Resources.火娃通关6, bulandDarwaza.Rectangle1);
                                g.DrawImage(Properties.Resources.冰娃通关6, bulandDarwaza.Rectangle2);
                                Win2 = true;
                                break;
                            }
                        default: break;
                    }
                    door++;
                
              
            }
        }
        /// <summary>
        /// 判断吃钻石
        /// </summary>
        public void EatDiamonds()
        {   
            //火娃吃火钻，冰娃吃冰钻
            foreach (var Diamond in Diamonds)
            {
                if(Diamond.Type)
                {
                    if (fireMan.Rectangle.IntersectsWith(Diamond.Rectangle))
                    {
                        Diamond.Eat = true;
                    }
                }
                if (!Diamond.Type)
                {
                    if (iceMan.Rectangle.IntersectsWith(Diamond.Rectangle))
                    {
                        Diamond.Eat = true;
                    }
                }
            }
            
        }
    }
    }

