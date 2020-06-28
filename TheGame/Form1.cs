using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Form1 : Form
    {
        GameSettings gameSettings;
        FieldButton[,] fieldButtons;
        LogicGame logicGame;

        public Form1()
        {
            InitializeComponent();
        }
        public int CountOfGamer { get; set; }
        public int SizeOfField { get; set; }
        
        public Form1(int countOfGamer, int sizeOfFeild)
        {
            CountOfGamer = countOfGamer;
            SizeOfField = sizeOfFeild;

        }

        int CountOfPlayes = 0;
        int Size = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //gameSettings = GameSettings.Instance();
            //if (ToolStripMenuItem1.Checked)
            //{
            //    GameStart();
            //}
            GameStart();
            
        }

        private (int, int) SelectSizeOfField()
        {
            int countHigh;
            int countWidth;
            
            if (x16ToolStripMenuItem.Checked)
            {
                countHigh = 16;
                countWidth = 16;
            }
            if (x20ToolStripMenuItem.Checked)
            {
                countHigh = 20;
                countWidth = 20;
            }
            else
            {
                countHigh = 8;
                countWidth = 8;
            }
            var result = (countHigh, countWidth);
            return result;
        }



        private void GameStart()
        {

            (int, int) sizeOfField = SelectSizeOfField();
            int sizeOfHigh = sizeOfField.Item1;
            int sizeOfWidth = sizeOfField.Item2;



            fieldButtons = new FieldButton[sizeOfHigh, sizeOfWidth];
            for (int y = 0; y < sizeOfHigh; y++)
            {
                for (int x = 0; x < sizeOfWidth; x++)
                {
                    FieldButton btn = new FieldButton();
                    btn.Location = new Point(x * 40, y * 40 + 40);
                    btn.Size = new Size(40, 40);
                    btn.X = x;
                    btn.Y = y;
                    Controls.Add(btn);
                    btn.MouseUp += new MouseEventHandler(FieldButtonClick);
                    fieldButtons[y, x] = btn;
                }
            }
        } 
        private void FieldButtonClick(object sender, MouseEventArgs e)
        {
            FieldButton currentButton = (FieldButton)sender;
            //MessageBox.Show($"{currentButton.X} {currentButton.Y}");

            (int, int) sizeOfField = SelectSizeOfField();
            int sizeOfHigh = sizeOfField.Item1;
            int sizeOfWidth = sizeOfField.Item2;
            logicGame = new LogicGame(2, sizeOfHigh, sizeOfWidth);
 
            logicGame.CapturingCell(1, currentButton.X, currentButton.Y);


        }

        private void ShowField()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    //fieldButtons[y, x].BackColor
                }
            }
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart();
        }
    }
}
