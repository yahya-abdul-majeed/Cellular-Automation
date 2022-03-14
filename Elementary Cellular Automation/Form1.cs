using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elementary_Cellular_Automation
{
    public partial class Form1 : Form
    {
        public Grid World { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.World = new Grid(new Size(20, 20));
            this.World.SetDimensions(new Rectangle(0, 0, this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int r = 0; r < this.World.Size.Height; r++)
            {
                for (int c = 0; c < this.World.Size.Width; c++)
                {
                    this.World.Cells[c, r].Hover = this.World.Cells[c, r].Bounds.Contains(e.X, e.Y);
                }
            }
            this.pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int r = 0; r < this.World.Size.Height; r++)
            {
                for (int c = 0; c < this.World.Size.Width; c++)
                {
                    if (this.World.Cells[c, r].Bounds.Contains(e.X, e.Y))
                    {
                        this.World.Cells[c, r].RotateState();
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //int num = 1;
            for (int r = 0; r < this.World.Size.Height; r++)
            {
                for (int c = 0; c < this.World.Size.Width; c++)
                {
                    if (this.World.Cells[c, r].State == Cell.CellState.Active)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, this.World.Cells[c, r].Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, this.World.Cells[c, r].Bounds);
                    }

                    if (!this.World.Cells[c, r].Hover)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, this.World.Cells[c, r].Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Red, this.World.Cells[c, r].Bounds);

                    }
                    //e.Graphics.DrawString(num.ToString(), new Font(this.Font, FontStyle.Bold), Brushes.Black, this.World.Cells[c, r].Bounds);
                    //num++;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            char[] bits = toBinarr((int)(ruleText.Value));

            for (int r = 1; r < this.World.Size.Height; r++)
            {
                for (int c = 1; c < this.World.Size.Width - 1; c++)
                {
                    if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Inactive &&
                        this.World.Cells[c, r - 1].State == Cell.CellState.Inactive &&
                        this.World.Cells[c + 1, r - 1].State == Cell.CellState.Inactive)
                    {
                        if (bits[7] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Inactive &&
                              this.World.Cells[c, r - 1].State == Cell.CellState.Inactive &&
                              this.World.Cells[c + 1, r - 1].State == Cell.CellState.Active)
                    {
                        if (bits[6] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Inactive &&
                            this.World.Cells[c, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c + 1, r - 1].State == Cell.CellState.Inactive)
                    {
                        if (bits[5] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Inactive &&
                            this.World.Cells[c, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c + 1, r - 1].State == Cell.CellState.Active)
                    {
                        if (bits[4] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c, r - 1].State == Cell.CellState.Inactive &&
                            this.World.Cells[c + 1, r - 1].State == Cell.CellState.Inactive)
                    {
                        if (bits[3] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c, r - 1].State == Cell.CellState.Inactive &&
                            this.World.Cells[c + 1, r - 1].State == Cell.CellState.Active)
                    {
                        if (bits[2] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else if (this.World.Cells[c - 1, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c, r - 1].State == Cell.CellState.Active &&
                            this.World.Cells[c + 1, r - 1].State == Cell.CellState.Inactive)
                    {
                        if (bits[1] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }
                    else
                    {
                        if (bits[0] == '0')
                            this.World.Cells[c, r].State = Cell.CellState.Inactive;
                        else
                            this.World.Cells[c, r].State = Cell.CellState.Active;
                    }

                    this.pictureBox1.Invalidate();
                }
            }
        }
        private char[] toBinarr(int num)
        {
            string number = num.ToString();
            int fromBase = 10;
            int toBase = 2;

            string result = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
            textBox1.Text = result;
            char[] bits = new char[8];
            for (int i = 0; i < 8; i++)
            {
                bits[i] = '0';
            }
            int index = 8 - result.Length;
            int j = 0;
            for (int i = index; i < 8; i++)
            {
                bits[i] = result[j];
                j++;
            }
            return bits;
        }
    }
    public struct Cell
    {
        public bool Hover { get; set; }
        public enum CellState { Inactive, Active }
        public CellState State { get; set; }
        public int Column { get; private set; }
        public int Row { get; private set; }
        public Rectangle Bounds { get; private set; }

        public Cell(int column, int row, CellState state = CellState.Inactive)
        {
            this.Column = column;
            this.Row = row;
            this.Hover = false;
            this.State = Cell.CellState.Inactive;
            this.Bounds = new Rectangle();

        }
        public void SetDimensions(Rectangle bounds)
        {
            this.Bounds = bounds;
        }
        public void RotateState()
        {
            if (this.State == CellState.Active)
                this.State = CellState.Inactive;
            else
                this.State = CellState.Active;
        }

    }

    public struct Grid
    {
        public Cell[,] Cells { get; private set; }
        public Size Size { get; private set; }
        public Rectangle Bounds { get; private set; }

        public Grid(Size gridSize)
        {
            this.Size = gridSize;
            this.Cells = new Cell[this.Size.Width, this.Size.Height];
            this.Bounds = new Rectangle();

            for (int r = 0; r < this.Size.Height; r++)
            {
                for (int c = 0; c < this.Size.Width; c++)
                {
                    this.Cells[c, r] = new Cell(c, r);
                }
            }
        }

        public void SetDimensions(Rectangle bounds)
        {
            Size size;

            this.Bounds = bounds;
            size = new Size((int)(((float)bounds.Width) / ((float)this.Size.Width)), (int)(((float)bounds.Height) / ((float)this.Size.Height)));

            for (int r = 0; r < this.Size.Height; r++)
            {
                for (int c = 0; c < this.Size.Width; c++)
                {
                    this.Cells[c, r].SetDimensions(new Rectangle(bounds.Left + (size.Width * c), bounds.Top + (size.Height * r), size.Width, size.Height));
                }
            }


        }
    }
}
