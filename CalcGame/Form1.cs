using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        // 定数
        private const int BulletNum = 25;

        // メンバ変数
        private int bullet = 0;
        private List<string> targetList = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "u" };
        private int targetPos = 0;

        private void Init()
        {
            InvadeTimer.Stop();
            InvadeTimer.Interval = 2000;

            bullet = 0;

            InitTarget();

            InvaderTbox.Text = "";
        }

        private void InitTarget()
        {
            targetPos = 0;
            targetTbox.Text = targetList[targetPos];
        }

        private void NextTarget()
        {
            targetPos++;
            if (targetList.Count == targetPos)
            {
                targetPos = 0;
            }
            targetTbox.Text = targetList[targetPos];
        }

        private void InvadeTimer_Tick(object sender, EventArgs e)
        {
            var retVal = CInvader.Instance.Invade();
            var showStr = string.Join("", retVal.invader);
            InvaderTbox.Text = showStr;

            if (0 == retVal.ret)
            {
                InvadeTimer.Stop();
            }
            else
            {
                CSound.Instance.Play(ESoundFile.INVADE);
            }
        }

        private void targetBtn_Click(object sender, EventArgs e)
        {
            NextTarget();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Init();
            bullet = BulletNum;

            CInvader.Instance.Init();

            InvadeTimer.Start();

            CSound.Instance.Play(ESoundFile.START);
        }

        private void shootBtn_Click(object sender, EventArgs e)
        {
            bullet--;
            var target = targetList[targetPos];

            var retVal = CInvader.Instance.Shoot(target);
            if (0 == retVal.ret)
            {
                // 攻撃失敗
                CSound.Instance.Play(ESoundFile.STRAY);
            }
            else if (1 == retVal.ret)
            {
                // 攻撃成功
                CSound.Instance.Play(ESoundFile.SHOOT);
            }
            else
            {
                // ステージクリア
                var showStr = string.Join("", retVal.invader);
                InvaderTbox.Text = showStr;

                return;
            }

            if (0 == bullet)
            {
                // 弾切れ
                var scoreStr = CInvader.Instance.Score.ToString();
                InvaderTbox.Text = scoreStr;

                // ゲーム停止
                InvadeTimer.Stop();
            }
            else
            {
                // ステージ続行
                var showStr = string.Join("", retVal.invader);
                InvaderTbox.Text = showStr;
            }

            return;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            var a = 0;
            a++;
        }
    }
}
