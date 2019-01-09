using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8QuanHau
{
    public class QLBanCo
    {
        private int loai, loai2;
        private Panel banco;
        private TextBox playerName;
        private PictureBox playerMark;
        private int currentPlayer;
        private List<List<Button>> matrix;

        public bool a;
        public int solan;
        public int n = 0;

        //private Image hinhconco = Image.FromFile(Application.StartupPath + "\\resources\\Hau1.png");
        private Image hinhconco1 = Image.FromFile(Application.StartupPath + "\\resources\\Hau1.png");
        private Image hinhconco2 = Image.FromFile(Application.StartupPath + "\\resources\\Hau2.png");

        public Panel Banco
        {
            get { return banco; }
            set { banco = value; }

        }


        private List<Player> player;

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }

        }
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }

        }
        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }

        }
        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }

        }
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }

        }

        private event EventHandler playerMarked;
        public event EventHandler Playermarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        public int chedogame;
        public QLBanCo(Panel banco, TextBox playername, PictureBox mark, int chedogame)
        {
            this.Banco = banco;
            this.PlayerName = playername;
            this.PlayerMark = mark;
            this.Player = new List<Player>()
            {
                new Player("Player1", Image.FromFile(Application.StartupPath + "\\resources\\Hau1.png")),
                new Player("Player2", Image.FromFile(Application.StartupPath + "\\resources\\Hau2.png"))
            };
            loai = 0;
            this.chedogame = chedogame;
        }

        public QLBanCo(Panel banco)
        {
            this.Banco = banco;
            loai = 1;
        }
        public void VeBanCo()
        {
            Banco.Enabled = true;
            Banco.Controls.Clear();
           
            
            if (loai == 0)
            {
                n = 0;
                CurrentPlayer = 0;
                ChangePlayer();
            }
            else
            {
                a = true;
                solan = 0;
            }


            Matrix = new List<List<Button>>();

            Button oldbutton = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < 8; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldbutton.Location.X + oldbutton.Width, oldbutton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };

                    btn.Click += Btn_Click;
                    Banco.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldbutton = btn;
                    if (i + j == 1 || i + j == 3 || i + j == 5 || i + j == 7 || i + j == 9 || i + j == 11 || i + j == 11 || i + j == 13 || i + j == 15)
                        btn.BackColor = Color.Green;
                }
                oldbutton.Location = new Point(0, oldbutton.Location.Y + Cons.CHESS_HEIGHT);
                oldbutton.Width = 0;
                oldbutton.Height = 0;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            if(chedogame == 0)
            {
                Mark(btn);
                ChangePlayer();
            }
            else
            {
                btn.BackgroundImage = Player[0].Mark;
            }

            

            if (playerMarked != null)
                playerMarked(this, new EventArgs());

            if(chedogame == 0)
            {
                if (isEndGame(btn))
                {
                    EndGame();
                }
            }
            else
            {
                if (isEndGame(btn))
                {
                    EndGame();
                }
                else
                {
                    n++;
                    if (n == 4)
                    {
                        EndGame();
                    }
                    else
                    {
                        MayDanh();
                    }
                }
            }


        }

        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());

        }

        private bool isEndGame(Button btn)
        {

            return isEndNgang(btn) || isEndDoc(btn) || isEndCheoChinh(btn) || isEndCheoPhu(btn);
        }

        private Point GetChessPoint(Button btn)
        {

            int vertical = Convert.ToInt32(btn.Tag);//cot doc
            int horizontal = Matrix[vertical].IndexOf(btn);//hang ngang
            Point point = new Point(horizontal, vertical);
            return point;
        }
        private bool isEndNgang(Button btn)
        {
            Point point = GetChessPoint(btn);
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage != null)
                {
                    count++;
                }

            }
            return count == 2;
        }
        private bool isEndDoc(Button btn)
        {
            Point point = GetChessPoint(btn);
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Matrix[i][point.X].BackgroundImage != null)
                {
                    count++;
                }

            }
            return count == 2;
        }
        private bool isEndCheoChinh(Button btn)
        {

            Point point = GetChessPoint(btn);
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage != null)
                {
                    count++;
                }
            }
            int countcc = 0;
            for (int j = 0; j < 8; j++)
            {
                if (point.X + j > 7 || point.Y + j > 7)
                    break;
                if (Matrix[point.Y + j][point.X + j].BackgroundImage != null)
                {
                    countcc++;
                }

            }
            return count == 2 || countcc == 2;
        }
        private bool isEndCheoPhu(Button btn)
        {
            {

                Point point = GetChessPoint(btn);
                int count = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (point.X + i > 7 || point.Y - i < 0)
                        break;
                    if (Matrix[point.Y - i][point.X + i].BackgroundImage != null)
                    {
                        count++;
                    }

                }
                int countcc = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (point.X - j < 0 || point.Y + j > 7)
                        break;
                    if (Matrix[point.Y + j][point.X - j].BackgroundImage != null)
                    {
                        countcc++;
                    }

                }
                return count == 2 || countcc == 2;
            }
        }


        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }

        public bool IsSafe(List<List<Button>> matrix,int row ,int col)
        {
            
            int i, j;
            for(i = 0; i< col; i++)
            {
                if(matrix[row][i].BackgroundImage != null)
                {
                    return false;
                }
            }

            for( i = row, j= col; i>=0 && j >= 0; i--,j--)
            {
                if(matrix[i][j].BackgroundImage != null)
                {
                    return false;
                }
            }

            for (i = row, j = col; j >= 0 && i < 8; i++, j--)
            {
                if (matrix[i][j].BackgroundImage != null)
                {
                    return false;
                }
            }

            return true;
        }

        private bool Ngang(int row)
        {
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                if (matrix[row][i].BackgroundImage != null)
                {
                    count++;
                }
            }
            return count == 2;
        }

        private bool Doc(int col)
        {
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                if (matrix[i][col].BackgroundImage != null)
                    count++;
            }
            return count == 2;
        }

        private bool CheoChinh(int row, int col)
        {
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                if (col - i < 0 || row - i < 0)
                    break;
                if (matrix[row - i][col - i].BackgroundImage != null)
                {
                    count++;
                }

            }
            int countcc = 1;
            for (int j = 0; j < 8; j++)
            {
                if (col + j > 7 || row + j > 7)
                    break;
                if (matrix[row + j][col + j].BackgroundImage != null)
                {
                    countcc++;
                }

            }
            return count == 2 || countcc == 2;
        }

        private bool CheoPhu(int row, int col)
        {
            int count = 1;
            for (int i = 0; i < 8; i++)
            {
                if (col + i > 7 || row - i < 0)
                    break;
                if (matrix[row - i][col + i].BackgroundImage != null)
                {
                    count++;
                }

            }
            int countcc = 1;
            for (int j = 0; j < 8; j++)
            {
                if (col - j < 0 || row + j > 7)
                    break;
                if (matrix[row + j][col - j].BackgroundImage != null)
                {
                    countcc++;
                }

            }
            return count == 2 || countcc == 2;

        }

        private bool Check(int row, int col)
        {
            return Doc(col) || Ngang(row) || CheoChinh(row, col) || CheoPhu(row, col);
        }

        public bool solveNQUtil(List<List<Button>> matrix, int col)
        {
            if (col >= 8)
                return true;

            Random rdm = new Random();
            int row = rdm.Next(0, 7);

            if(loai2 == 1)
            {
                loai2 = 2;
                if (IsSafe(matrix, row, col))
                {
                    matrix[row][col].BackgroundImage = hinhconco1;

                    if (solveNQUtil(matrix, col + 1))
                    {
                        return true;
                    }
                    matrix[row][col].BackgroundImage = null;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (IsSafe(matrix, i, col))
                    {
                        matrix[i][col].BackgroundImage = hinhconco1;

                        if (solveNQUtil(matrix, col + 1))
                        {
                            return true;
                        }
                        matrix[i][col].BackgroundImage = null;
                    }
                }
            }
            return false; 
        }
        public void solveNQ()
        {
            loai2 = 1;
            solveNQUtil(matrix, 0);
        }


        private bool KiemTra()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!Check(i, j))
                        return true;
                }
            }
            return false;
        }

        public void solveNQ2()
        {
            Random rdm = new Random();
            int row, col;

            if (!KiemTra())
            {
                a = false;
            }
            else
            {
                do
                {

                    row = rdm.Next(0, 8);
                    col = rdm.Next(0, 8);

                } while (Check(row, col));

                if (solan % 2 == 0)
                    Matrix[row][col].BackgroundImage = hinhconco1;
                else
                    Matrix[row][col].BackgroundImage = hinhconco2;
                solan++;
            }

        }

        private void MayDanh()
        {
            int row, col;
            do
            {
                Random rdm = new Random();
                row = rdm.Next(0, 8);
                col = rdm.Next(0, 8);
            } while (Check(row, col));
            Matrix[row][col].BackgroundImage = Player[1].Mark;
        }



    }
}
