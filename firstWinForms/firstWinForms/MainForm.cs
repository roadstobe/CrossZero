using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstWinForms
{
    public partial class MainForm : Form
    {
        static int move = 0;
        static bool isStop = false;
        static bool[] check = new bool[9];
        static int[] checkMove = new int[9];
        static int WinX;
        static int WinO;
        static int Draw;
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                check[i] = false;
            }
            if (move % 2 == 0)
                buttonMove.Image = Image.FromFile(@"x.bmp");
            else
                buttonMove.Image = Image.FromFile(@"o.bmp");
            buttonX.Text = WinX.ToString();
            buttonO.Text = WinO.ToString();
            buttonDraw.Text = Draw.ToString();
        }
        private bool CheckWin(int[] tmp)
        {
            int countO = 0;
            int countX = 0;
            for (int i = 0; i < 9; i++)
            {
                if (tmp[i] == 1)
                    countO++;
                else if (tmp[i] == 2)
                    countX++;
               
                if(countO == 3)
                {
                    MessageBox.Show("Win X", "~ Win ~");
                    WinX++;
                    buttonX.Text = WinX.ToString();
                    return true;
                }
                else if(countX == 3)
                {
                    WinO++;
                    buttonO.Text = WinO.ToString();
                    MessageBox.Show("Win 0", "~ Win ~");
                    return true;
                }
                if (i == 2 || i == 5 || i == 8)
                {
                    countX = 0;
                    countO = 0;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = i; j < 9; j+=3)
                {
                    if (tmp[j] == 1)
                        countO++;
                    else if (tmp[j] == 2)
                        countX++;

                    if (countO == 3)
                    {
                        MessageBox.Show("Win X", "~ Win ~");
                        WinX++;
                        buttonX.Text = WinX.ToString();
                        return true;
                    }
                    else if (countX == 3)
                    {
                        MessageBox.Show("Win 0", "~ Win ~");
                        WinO++;
                        buttonO.Text = WinO.ToString();
                        return true;
                    }
                    
                }
                countO = 0;
                countX = 0;
            }
            if ((tmp[0] == 1 && tmp[4] == 1 && tmp[8] == 1) || (tmp[2] == 1 && tmp[4] == 1 && tmp[6] == 1))
            {
                WinX++;
                MessageBox.Show("Win X", "~ Win ~");
                buttonX.Text = WinX.ToString();
                return true;
            }
            if ((tmp[0] == 2 && tmp[4] == 2 && tmp[8] == 2) || (tmp[2] == 2 && tmp[4] == 2 && tmp[6] == 2))
            {
                MessageBox.Show("Win 0", "~ Win ~");
                WinO++;
                buttonO.Text = WinO.ToString();
                return true;
            }
            return false;
        }
        private bool isDraw(int move)
        {
           if(move == 9)
            {
                MessageBox.Show("This is Draw", "Draw");
                Draw++;
                buttonDraw.Text = Draw.ToString();
                return true;
            }
            return false;
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want close?","???Close???", MessageBoxButtons.YesNo) == DialogResult.No)
            e.Cancel = true;
        }

        private void But1(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[0] == false)
                {
                    if (move % 2 == 0)
                    {
                        button1.Image = Image.FromFile(@"x.bmp");
                        checkMove[0] = 1;
                    }
                    else
                    {
                        button1.Image = Image.FromFile(@"o.bmp");
                        checkMove[0] = 2;
                    }
                    check[0] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But2(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[1] == false)
                {
                    if (move % 2 == 0)
                    {
                        button2.Image = Image.FromFile(@"x.bmp");
                        checkMove[1] = 1;
                    }
                    else
                    {
                        button2.Image = Image.FromFile(@"o.bmp");
                        checkMove[1] = 2;
                    }
                    check[1] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But3(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[2] == false)
                {
                    if (move % 2 == 0)
                    {
                        button3.Image = Image.FromFile(@"x.bmp");
                        checkMove[2] = 1;
                    }
                    else
                    {
                        button3.Image = Image.FromFile(@"o.bmp");
                        checkMove[2] = 2;
                    }
                    check[2] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But4(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[3] == false)
                {
                    if (move % 2 == 0)
                    {
                        button4.Image = Image.FromFile(@"x.bmp");
                        checkMove[3] = 1;
                    }
                    else
                    {
                        button4.Image = Image.FromFile(@"o.bmp");
                        checkMove[3] = 2;
                    }
                    check[3] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But5(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[4] == false)
                {
                    if (move % 2 == 0)
                    {
                        button5.Image = Image.FromFile(@"x.bmp");
                        checkMove[4] = 1;
                    }
                    else
                    {
                        button5.Image = Image.FromFile(@"o.bmp");
                        checkMove[4] = 2;
                    }
                    check[4] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"temp: {move}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But6(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[5] == false)
                {
                    if (move % 2 == 0)
                    {
                        button6.Image = Image.FromFile(@"x.bmp");
                        checkMove[5] = 1;
                    }
                    else
                    {
                        button6.Image = Image.FromFile(@"o.bmp");
                        checkMove[5] = 2;
                    }
                    check[5] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But7(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[6] == false)
                {
                    if (move % 2 == 0)
                    {
                        button7.Image = Image.FromFile(@"x.bmp");
                        checkMove[6] = 1;
                    }
                    else
                    {
                        button7.Image = Image.FromFile(@"o.bmp");
                        checkMove[6] = 2;
                    }
                    check[6] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"temp: {move}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But8(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[7] == false)
                {
                    if (move % 2 == 0)
                    {
                        button8.Image = Image.FromFile(@"x.bmp");
                        checkMove[7] = 1;
                    }
                    else
                    {
                        button8.Image = Image.FromFile(@"o.bmp");
                        checkMove[7] = 2;
                    }
                    check[7] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void But9(object sender, EventArgs e)
        {
            if (isStop == true)
            {
                MessageBox.Show("Game end", $"stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Restart(buttonRestart, EventArgs.Empty);
            }
            else
            {
                if (check[8] == false)
                {
                    if (move % 2 == 0)
                    {
                        button9.Image = Image.FromFile(@"x.bmp");
                        checkMove[8] = 1;
                    }
                    else
                    {
                        button9.Image = Image.FromFile(@"o.bmp");
                        checkMove[8] = 2;
                    }
                    check[8] = true;
                    move++;
                }
                else
                    MessageBox.Show("This box engage", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (CheckWin(checkMove) == true)
                {
                    isStop = true;
                    MessageBox.Show("You win", $"!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isDraw(move) == true)
                {
                    isStop = true;
                    this.Restart(buttonRestart, EventArgs.Empty);
                }
                Button10_Click(buttonMove, EventArgs.Empty);
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want restart game?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (int i = 0; i < 9; i++)
                {
                    check[i] = false;
                    checkMove[i] = 0;
                }
                move = 0;
                button1.Image = Image.FromFile(@"Empty.bmp");
                button2.Image = Image.FromFile(@"Empty.bmp");
                button3.Image = Image.FromFile(@"Empty.bmp");
                button4.Image = Image.FromFile(@"Empty.bmp");
                button5.Image = Image.FromFile(@"Empty.bmp");
                button6.Image = Image.FromFile(@"Empty.bmp");
                button7.Image = Image.FromFile(@"Empty.bmp");
                button8.Image = Image.FromFile(@"Empty.bmp");
                button9.Image = Image.FromFile(@"Empty.bmp");
                isStop = false;
            }
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            if (move % 2 == 0)
                buttonMove.Image = Image.FromFile(@"x.bmp");
            else
                buttonMove.Image = Image.FromFile(@"o.bmp");
        }
    }
}
