using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyExtension;

namespace VisualHanoiTower
{
    public partial class MainForm : Form
    {
        int gap_time = 20;
        int su, skip, cnt_move;
        StreamReader sr = null;
        Timer timer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int a = 0; a < 12; a++)
            {
                cboDisk.Items.Add(a);
            }
            cboTime.Items.Add(16);
            cboTime.Items.Add(12);
            cboTime.Items.Add(8);
            cboTime.Items.Add(4);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { picHanoi01, picHanoi02, picHanoi03, picHanoi04, picHanoi05, picHanoi06, picHanoi07, picHanoi08, picHanoi09, picHanoi10, picHanoi11, picHanoi12};
            int su = (int)cboDisk.SelectedItem;

            for (int a = 0; a < su; a++)            //설정된 탑의 구성
            {
                pictureBoxes[a].Top = 100 + (12 - su) * 22 + a * 22;
                pictureBoxes[a].Left = 35 + 215;    //pole 사이의 거리 215
            }

            for (int a = su; a < 12; a++)           //탑의 남아있는 부분
            {
                pictureBoxes[a].Top = 100 + a * 22;
                pictureBoxes[a].Left = 35;
            }

            txtDiskPole1.Text = su.ToString();      //초기 상태에서 각 pole의 디스크 개수
            txtDiskPole2.Text = "0";                //
            txtDiskPole3.Text = "0";                //

            if (su > 0)
            {
                txtSituation.Text = su.ToString() + "층 탑을 이동할 준비가 되었습니다.";
                cmdMove.Enabled = true;
            } else
            {
                txtSituation.Text = "옮겨야 할 탑이 없습니다.";
                cmdMove.Enabled = false;

            }
            cmdMove.Focus();
        }

        private void MoveDisk()
        {
            PictureBox[] pictureBoxes = { picHanoi01, picHanoi02, picHanoi03, picHanoi04, picHanoi05, picHanoi06, picHanoi07, picHanoi08, picHanoi09, picHanoi10, picHanoi11, picHanoi12 };
            TextBox[] textBoxes = { txtDiskPole1, txtDiskPole2, txtDiskPole3 };
            char[] pole = { 'A', 'B', 'C' };
            object[] str = sr.ReadLine().Split(new char[] { '\t' });

            int disk = Convert.ToInt32(str[0]);         //파일에 기록된 6개의 항목
            int polefrom = Convert.ToInt32(str[1]);
            int poleto = Convert.ToInt32(str[2]);
            int su1 = Convert.ToInt32(str[3]);
            int su2 = Convert.ToInt32(str[4]);
            int su3 = Convert.ToInt32(str[5]);

            int tmp = Convert.ToInt32(textBoxes[poleto].Text);      //poleto의 이전 디스크 개수

            pictureBoxes[disk - 1].Top = 342 - tmp * 22;            //옮겨진 디스크의 Y 위치
            pictureBoxes[disk - 1].Left = 250 + poleto * 215;       //옮겨진 디스크의 X 위치

            txtDiskPole1.Text = su1.ToString();     //이동 후 각 pole의 디스크 개수
            txtDiskPole2.Text = su2.ToString();     //
            txtDiskPole3.Text = su3.ToString();     //

            txtSituation.Text = "< " + cnt_move + "/" + (su - 1) + " >  Part ( " + disk + " )  :  " +
                pole[polefrom] + "   ========>   " + pole[poleto];
        }

        private void cmdMove_Click(object sender, EventArgs e)
        {
            cmdMove.Enabled = false;
            cboDisk.Focus();
            sr = new StreamReader(new FileStream("Hanoi.txt", FileMode.Open));

            int stair = (int)cboDisk.SelectedItem;      //층수
            su = 2.Power(stair);                        //(이동할 횟수 + 1)
            skip = su - stair;                          //(스킵할 수 + 1)

            for (int st = 1; st < skip; st++)           //이전 층 자료는 스킵하고
                sr.ReadLine();

            gap_time = 100 * (int)cboTime.SelectedItem;
            timer = new System.Windows.Forms.Timer();   //타이머 설정==============
            timer.Interval = gap_time; // 1초
            timer.Tick += new EventHandler(timer_Tick);

            cnt_move = 1;                               //이동 시작
            timer.Start();
        }

        // 매 1초마다 Tick 이벤트 핸들러 실행
        void timer_Tick(object sender, EventArgs e)
        {
            MoveDisk();
            if (++cnt_move >= su)
            {
                timer.Stop();
                sr.Close();
                txtSituation.Text = "총 " + (su - 1) + " 회의 이동으로 탑을 옮겼습니다.";
                cboDisk.Focus();
            }
            else if (cnt_move >= su / 2)
                timer.Interval = gap_time / 2;
        }
    }
}

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int a = 1; a < exponent; a++)
                result *= myInt;

            return result;
        }
    }
}
