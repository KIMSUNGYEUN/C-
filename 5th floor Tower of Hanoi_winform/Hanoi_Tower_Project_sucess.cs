using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;
namespace HanoiTower
{
  public partial class Form1 : Form
  { 
    public enum Bar
    {
      From = 113,
      Temp = 198,
      To = 283
    }
    int[] Step = {256, 246, 236, 226, 216, 206, 196, 186};    
    private int Board ;
    private int FromCount;
    private int TempCount;
    private int ToCount;
    private bool IsStop = false;
    Images []images;
    string []ImageFiles = 
    {
                      @"Images\BAR8.gif",
                      @"Images\BAR7.gif",
                      @"Images\BAR6.gif",
                      @"Images\BAR5.gif",
                      @"Images\BAR4.gif",
                      @"Images\BAR3.gif",
                      @"Images\BAR2.gif",
                      @"Images\BAR1.gif"
    };
    
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {      
      Board = 8;
      comboBox1.Text = "8";      
      InitBoard();
    }
    private void InitBoard()
    {
      FromCount = 0;
      TempCount = 0;
      ToCount = 0;
      if(images != null) images.Initialize();
      images = new Images[Board];      
      for(int i = 0; i < Board; i++)
      {
        images[i] = new Images(Image.FromFile(ImageFiles[i]), (int)Bar.From, Step[i] );        
        FromCount ++;
      }      
      this.Refresh();      
    }
    
    private void Form1_Paint(object sender, PaintEventArgs e)
    {       
      e.Graphics.DrawImage(Image.FromFile(@"Images\BOARD2.gif"), new Point(0,0));
      for(int i = 0; i < images.Length; i++)
      {
        images[i].DrawImage(e.Graphics);
      }      
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      Board = Convert.ToInt32(comboBox1.Text);
      InitBoard();
    }

    public void Hanoi(int board, Bar from, Bar temp, Bar to)
    {
      if(!IsStop)
      {
        if (board == Board -1)
        {
          MoveBar(board, from, to);
        }
        else
        {
          Hanoi(board + 1, from, to, temp);
          MoveBar(board, from, to);
          Hanoi(board + 1, temp, from, to);
        }
      }      
    }
    
    public void MoveBar(int board, Bar from, Bar to)
    {      
      if(from == Bar.From) FromCount--;
      else if(from == Bar.Temp) TempCount--;
      else if(from == Bar.To) ToCount--;

      if (to == Bar.From) 
      {
        images[board].Y = Step[FromCount];
        FromCount++;        
      }
      else if (to == Bar.Temp) 
      {
        images[board].Y = Step[TempCount];
        TempCount++;
      }
      else if (to == Bar.To) 
      {
        images[board].Y = Step[ToCount];
        ToCount++;
      }
      
      images[board].X = (int)to;      
      textBox1.Text += string.Format("{0} : {1} - > {2}\r\n", board, from, to);
      this.Refresh();
      Thread.Sleep(300);  
    }

    private void button1_Click(object sender, EventArgs e)
    {
      comboBox1.Enabled = false;
      button1.Enabled = false;
      
      InitBoard();

      Hanoi(0, Bar.From, Bar.Temp, Bar.To);
      
      comboBox1.Enabled = true;
      button1.Enabled = true;      
    } 
    private void MoveStart()
    {
      Hanoi(0, Bar.From, Bar.Temp, Bar.To);
    }   
  }
}
