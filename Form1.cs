using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame2468
{
    public partial class FMain : Form
    {
        private int[,] Map;
        private Label[,] Labels;
        private PictureBox[,] Pics;
        private int score;

        public FMain()
        {
            // game over
            InitializeComponent();
            score = 0;
            CreateMap();
            Map = new int[4,4];
            Labels = new Label[4,4];
            Pics = new PictureBox[4,4];
            GenerateRandom();
        }

        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    {

                        for (int x = 0; x < 4; x++)
                        {
                            int block = 0;
                            for (int y = 3; y >= 0; y--)
                            {
                                if (Map[x, y] != 0)
                                {
                                    for (int j = y + 1; j < 4 - block; j++)
                                    {
                                        if (Map[x, j] == 0)
                                        {
                                            (Map[x, j], Map[x, j - 1]) = (Map[x, j - 1], Map[x, j]);
                                            (Pics[x, j], Pics[x, j - 1]) = (Pics[x, j - 1], Pics[x, j]);
                                            (Labels[x, j], Labels[x, j - 1]) = (Labels[x, j - 1], Labels[x, j]);

                                            Pics[x, j].Location = new Point(Pics[x, j].Location.X + 56, Pics[x, j].Location.Y);
                                        }
                                        else
                                        {
                                            int a = Map[x, j];
                                            int b = Map[x, j - 1];

                                            if (a == b)
                                            {
                                                
                                                Map[x, j] = a + b;
                                                Labels[x, j].Text = Map[x, j].ToString();
                                                Pics[x, j].BackColor = GetColors(Map[x, j]);

                                                score += a + b;
                                                ScoreBoard.Text = $"score: {score}";

                                                Map[x, j - 1] = 0;
                                                PlayYard.Controls.Remove(Pics[x, j - 1]);
                                                PlayYard.Controls.Remove(Labels[x, j - 1]);
                                                Pics[x, j - 1] = null;
                                                Labels[x, j - 1] = null;

                                            }

                                            block++;
                                        }

                                    }
                                }
                            }
                        }

                        GenerateRandom();
                        break;
                    }
                case "A":
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            int block = 0;
                            for (int y = 0; y < 4; y++)
                            {
                                if (Map[x, y] != 0)
                                {
                                    for (int j = y - 1; j >= 0+block; j--)
                                    {
                                        if (Map[x, j] == 0)
                                        {
                                            (Map[x, j], Map[x, j + 1]) = (Map[x, j + 1], Map[x, j]);
                                            (Pics[x, j], Pics[x, j + 1]) = (Pics[x, j + 1], Pics[x, j]);
                                            (Labels[x, j], Labels[x, j + 1]) = (Labels[x, j + 1], Labels[x, j]);

                                            Pics[x, j].Location = new Point(Pics[x, j].Location.X - 56, Pics[x, j].Location.Y);
                                        }
                                        else
                                        {
                                            int a = Map[x, j];
                                            int b = Map[x, j + 1];

                                            if (a == b)
                                            {
                                                Map[x, j] = a + b;
                                                Labels[x, j].Text = Map[x, j].ToString();
                                                Pics[x, j].BackColor = GetColors(Map[x, j]);

                                                score += a + b;
                                                ScoreBoard.Text = $"score: {score}";

                                                Map[x, j + 1] = 0;
                                                PlayYard.Controls.Remove(Pics[x, j + 1]);
                                                PlayYard.Controls.Remove(Labels[x, j + 1]);
                                                Pics[x, j + 1] = null;
                                                Labels[x, j + 1] = null;

                                            }
                                            block++;
                                        }
                                    }
                                }
                            }
                        }

                        GenerateRandom();
                        break;
                    }

                case "S":
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            int block = 0;
                            for (int x = 3; x >= 0; x--)
                            {
                                if (Map[x, y] != 0)
                                {
                                    for (int i = x + 1; i < 4-block; i++)
                                    {
                                        if (Map[i, y] == 0)
                                        {
                                            (Map[i, y], Map[i - 1, y]) = (Map[i - 1, y], Map[i, y]);
                                            (Pics[i, y], Pics[i - 1, y]) = (Pics[i - 1, y], Pics[i, y]);
                                            (Labels[i, y], Labels[i - 1, y]) = (Labels[i - 1, y], Labels[i, y]);

                                            Pics[i, y].Location = new Point(Pics[i, y].Location.X, Pics[i, y].Location.Y + 56);
                                        }
                                        else
                                        {
                                            int a = Map[i, y];
                                            int b = Map[i - 1, y];

                                            if (a == b)
                                            {
                                                Map[i, y] = a + b;
                                                Labels[i, y].Text = Map[i, y].ToString();
                                                Pics[i, y].BackColor = GetColors(Map[i, y]);

                                                score += a + b;
                                                ScoreBoard.Text = $"score: {score}";

                                                Map[i - 1, y] = 0;
                                                PlayYard.Controls.Remove(Pics[i - 1, y]);
                                                PlayYard.Controls.Remove(Labels[i - 1, y]);
                                                Pics[i - 1, y] = null;
                                                Labels[i - 1, y] = null;

                                            }
                                            block++;
                                        }
                                    }
                                }
                            }
                        }

                        GenerateRandom();
                        break;
                    }

                case "W":
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            int block = 0;
                            for (int x = 0; x <= 3; x++)
                            {
                                if (Map[x, y] != 0)
                                {
                                    for (int i = x - 1; i >= 0+block; i--)
                                    {
                                        if (Map[i, y] == 0)
                                        {
                                            (Map[i, y], Map[i + 1, y]) = (Map[i + 1, y], Map[i, y]);
                                            (Pics[i, y], Pics[i + 1, y]) = (Pics[i + 1, y], Pics[i, y]);
                                            (Labels[i, y], Labels[i + 1, y]) = (Labels[i + 1, y], Labels[i, y]);

                                            Pics[i, y].Location = new Point(Pics[i, y].Location.X, Pics[i, y].Location.Y - 56);
                                        }
                                        else
                                        {
                                            int a = Map[i, y];
                                            int b = Map[i + 1, y];

                                            if (a == b)
                                            {
                                                Map[i, y] = a + b;
                                                Labels[i, y].Text = Map[i, y].ToString();
                                                Pics[i, y].BackColor = GetColors(Map[i, y]);

                                                score += a + b;
                                                ScoreBoard.Text = $"score: {score}";

                                                Map[i + 1, y] = 0;
                                                PlayYard.Controls.Remove(Pics[i + 1, y]);
                                                PlayYard.Controls.Remove(Labels[i + 1, y]);
                                                Pics[i + 1, y] = null;
                                                Labels[i + 1, y] = null;


                                            }
                                            block++;
                                        }
                                    }
                                }
                            }
                        }

                        GenerateRandom();
                        break;
                    }
            }
        }
        private Color GetColors(int number)
        {
            switch (number)
            {
                case 2:
                    return Color.FromArgb(250, 219, 216);
                case 4:
                    return Color.FromArgb(241, 148, 138);
                case 8:
                    return Color.FromArgb(236, 112, 99);
                case 16:
                    return Color.FromArgb(175, 122, 197);
                case 32:
                    return Color.FromArgb(125, 60, 152);
                case 64:
                    return Color.FromArgb(118, 215, 196);
                case 128:
                    return Color.FromArgb(125, 206, 160);
                case 256:
                    return Color.FromArgb(88, 214, 141);
                case 512:
                    return Color.FromArgb(244, 208, 63);
                case 1024:
                    return Color.FromArgb(243, 156, 18);
                case 2048:
                    return Color.FromArgb(230, 126, 34);
                case 4096:
                    return Color.FromArgb(223, 255, 0);
                case 8192:
                    return Color.FromArgb(222, 49, 99);
                default:
                    return Color.FromArgb(0, 0, 0);
            }
        }
        private void CreateMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox mapBG = new PictureBox
                    {
                        Location = new Point(6 + 56 * i, 6 + 56 * j),
                        Size = new Size(50, 50),
                        BackColor = Color.Silver
                    };
                    PlayYard.Controls.Add(mapBG);
                }
            }

        }
        private bool CheckGameIsOver()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i >= 1)
                        if (Map[i, j] == Map[i - 1, j])
                            return true;
                    if (i <=2 )
                        if (Map[i, j] == Map[i + 1, j])
                            return true;
                    if  (j >= 1)
                        if (Map[i, j] == Map[i, j - 1])
                            return true;
                    if (j <= 2)
                        if (Map[i, j] == Map[i, j + 1])
                            return true;
                }
            }
            return false;
        }
        private bool GetFreePlace(out Tuple<int,int> randomFreePlace)
        {
            List<Tuple<int,int>> FreePlaces = new List<Tuple<int,int>>();
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Map[i, j] == 0)
                        FreePlaces.Add(new Tuple<int,int>(i,j));
                }
            }
            try
            {
                randomFreePlace = FreePlaces[new Random().Next(0, FreePlaces.Count)];
            }
            catch
            {
                randomFreePlace = new Tuple<int, int>(-1, -1);
                return false;
            }
            return FreePlaces.Count != 0;
        }
        private void GenerateRandom()
        {
            Tuple<int, int> randomFreePlace = new Tuple<int, int>(-1, -1);

            if (!GetFreePlace(out randomFreePlace))
            {
                if(!CheckGameIsOver())
                {
                    MessageBox.Show("Game Over");
                    return;
                }
                else
                {
                    return;
                }
                
            }

            int x = randomFreePlace.Item1;
            int y = randomFreePlace.Item2;

            Map[x, y] = 2;
            Pics[x, y] = new PictureBox();

            Labels[x, y] = new Label()
            {
                Text = "2",
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(new FontFamily("Microsoft Sans Serif"), 12),
                Dock = DockStyle.Fill
            };

            Pics[x, y].Controls.Add(Labels[x, y]);
            Pics[x, y].Location = new Point(6 + 56 * y, 6 + 56 * x);
            Pics[x, y].Size = new Size(50, 50);
            Pics[x, y].BackColor = Color.FromArgb(245, 183, 177);

            PlayYard.Controls.Add(Pics[x, y]);
            Pics[x, y].BringToFront();
            
        }
        private void FMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 's':
                    label3.ForeColor = Color.FromArgb(169, 50, 38);
                    break;
                case 'a':
                    label4.ForeColor = Color.FromArgb(169, 50, 38);
                    break;
                case 'd':
                    label2.ForeColor = Color.FromArgb(169, 50, 38);
                    break;
                case 'w':
                    label1.ForeColor = Color.FromArgb(169, 50, 38);
                    break;
            }
        }

        private void FMain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "S":
                    label3.ForeColor = Color.White;
                    break;
                case "A":
                    label4.ForeColor = Color.White;
                    break;
                case "D":
                    label2.ForeColor = Color.White;
                    break;
                case "W":
                    label1.ForeColor = Color.White;
                    break;
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            score = 0;
            Map = new int[4, 4];
            Labels = new Label[4, 4];
            Pics = new PictureBox[4, 4];
            PlayYard.Controls.Clear();
            CreateMap();
            GenerateRandom();
        }
    }
}
