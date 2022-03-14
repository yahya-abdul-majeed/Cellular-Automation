using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;


namespace Two_dimensional_cellular_automation
{
    public partial class Form1 : Form
    {
        public Grid World { get; set; }

        public Form1()
        {
            
            InitializeComponent();
            this.World = new Grid(new Size(50,50));
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
                        //if (this.World.Cells[c, r].State == Cell.CellState.Active)
                        //    LiveCells.Add(this.World.Cells[c, r]);
                        //else
                        //    LiveCells.Remove(LiveCells.SingleOrDefault(g => g.State == Cell.CellState.Inactive));

                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawString();
            //int num = 1;
            for (int r = 0; r <this.World.Size.Height; r++)
            {
                for (int c = 0; c <this.World.Size.Width; c++)
                {
                    if (this.World.Cells[c, r].State == Cell.CellState.Active)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue,this.World.Cells[c, r].Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White,this.World.Cells[c, r].Bounds);
                    }

                    if (this.World.Cells[c, r].Hover)
                    {
                        e.Graphics.DrawRectangle(Pens.Black,this.World.Cells[c, r].Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Red,this.World.Cells[c, r].Bounds);

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
            timer1.Enabled = !timer1.Enabled;
            
        }
        
        private int CalNeighbors(Cell cell)
        {
            int neigbors = 0;
            for(int n= cell.Row -1; n <= cell.Row + 1; n++)
            {
                for(int m= cell.Column - 1; m <= cell.Column + 1; m++)
                {
                    if (this.World.Cells[m,n].State == Cell.CellState.Active)
                        neigbors++;
                }
            }
            return neigbors-1;
        }
        //private char[] toBinarr(int num)
        //{
        //    string number = num.ToString();
        //    int fromBase = 10;
        //    int toBase = 2;

        //    string result = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
        //    textBox1.Text = result;
        //    char[] bits = new char[8];
        //    for (int i = 0; i < 8; i++)
        //    {
        //        bits[i] = '0';
        //    }
        //    int index = 8 - result.Length;
        //    int j = 0;
        //    for (int i = index; i < 8; i++)
        //    {
        //        bits[i] = result[j];
        //        j++;
        //    }
        //    return bits;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            Grid placeholder = new Grid();
            placeholder.Size = this.World.Size;
            placeholder.Bounds = this.World.Bounds;
            placeholder.Cells = new Cell[World.Size.Width, World.Size.Height];
            for (int r = 0; r < this.World.Size.Height; r++)
            {
                for (int c = 0; c < this.World.Size.Width; c++)
                {
                    placeholder.Cells[c, r] = this.World.Cells[c, r];
                }
            }

            for (int r = 1; r < this.World.Size.Height - 1; r++)
            {
                for (int c = 1; c < this.World.Size.Width - 1; c++)
                {
                    if (this.World.Cells[c, r].State == Cell.CellState.Active)
                    {
                        int n = CalNeighbors(this.World.Cells[c, r]);
                        if (n == 2 || n == 3)
                            placeholder.Cells[c, r].State = Cell.CellState.Active;
                        else
                            placeholder.Cells[c, r].State = Cell.CellState.Inactive;
                    }
                    else
                    {
                        int n = CalNeighbors(this.World.Cells[c, r]);
                        n++;
                        if (n == 3)
                            placeholder.Cells[c, r].State = Cell.CellState.Active;
                    }

                }
            }
            World = placeholder;
            this.pictureBox1.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void DrawString()
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            string drawString = "Any live cell with two or three live neighbors lives on to the next generation\n"+
                                "Any empty cell with exactly three live neighbors becomes a live cell in the next generation.\n"+
                                "All other cells are empty in the next generation.";
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 10.0F;
            float y = 550.0F;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
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
        public Cell[,] Cells { get; set; }
        public Size Size { get; set; }
        public Rectangle Bounds { get; set; }
  
        public Grid(Size gridSize)
        {
            this.Size = gridSize;
            this.Cells = new Cell[this.Size.Width, this.Size.Height];
            this.Bounds = new Rectangle() ;

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
