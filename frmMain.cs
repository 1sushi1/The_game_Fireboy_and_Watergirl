using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ForestMan.Game;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices;

namespace ForestMan
{
    public partial class frmMain : Form
    {   private Game game;


        /// <summary>
        /// 窗体初始化，初始化游戏实例，并指定Refresh事件的处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameArea_Load(object sender, EventArgs e)
        {   
            game = new Game();
            game.gameChanged += GameChanged;
        }   
        private void GameChanged()
        {
            if (game != null)
            {
                JudgeGameOver();
                game.ChangePosition();
                game.ChangeBoxSpeed();
                game.ChangePoleStatus();
                game.EatDiamonds();
                game.ChangeButtonStatus();
                game.ChangeBoxPosition();
                game.SpeedChange();
                gameArea.Invalidate();
            }
            
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void gameArea_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics, this.gameArea.Size);
        }
        

        private void gameArea_KeyDown(object sender, KeyEventArgs e)
        {
            game.keyDown(e.KeyCode.ToString());
        }

        private void gameArea_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyUp(e.KeyCode.ToString());
        }
        private void JudgeGameOver()
        {
            if (game != null)
            {  
                //处理输赢
                if (game.Dead2)
                {
                    game.bgm.Stop();
                    game.Timer.Stop();
                        //游戏结束了
                        MessageBox.Show("Game Over!You Died!");
                        //重置游戏
                        game = new Game();
                    game.gameChanged += GameChanged;
                    

                }
                if (game.Win2)
                {
                    game.bgm.Stop();
                    game.Timer.Stop();
                    //游戏结束了
                    MessageBox.Show("Game Over!You Win!");
                    //重置游戏
                    game = new Game();
                    game.gameChanged += GameChanged;
                    
                }
               
            }
        }

        private void newGame_Click(object sender, EventArgs e)
        {   if (game != null)
            {
                game.Timer.Stop();
                game.gameChanged -= GameChanged;
            }
            Thread.Sleep(1000);       
            //重置游戏
            game = new Game();
            game.gameChanged += GameChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
            this.Close();
        }
    }
}
