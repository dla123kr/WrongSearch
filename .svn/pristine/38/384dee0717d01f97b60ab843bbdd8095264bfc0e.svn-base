using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WrongSearch_Client
{
    public partial class RegistForm : Form
    {
        // RegistForm에서 사용되는 전역변수를 관리합니다.
        #region 변수 모음

        private TcpClient clientSocket = null;

        public Point mouse_point;

        #endregion

        // Form의 켜짐에 관련된 함수를 관리합니다.
        #region Form Load

        // TcpClient와 RegistForm을 연결합니다.
        public RegistForm(TcpClient cs)
        {
            InitializeComponent();

            clientSocket = cs;
        }

        #endregion

        // 회원가입에 대한 예외처리를 한 후, SendRegist함수를 부릅니다.
        #region 회원가입 시도

        // 회원가입 처리합니다.
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (tbClassNumber.Text == "" || tbPassword.Text == "" || tbPassConf.Text == "" ||
                tbName.Text == "" || (!rbMan.Checked && !rbWoman.Checked) || tbPhone.Text == "")
            {
                MessageBox.Show("모든 칸을 채워주시기 바랍니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbClassNumber.Text.Length != 8)
            {
                MessageBox.Show("학번이 올바르지 않습니다. (8자리)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPassword.Text != tbPassConf.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendRegist();
        }

        #endregion

        // 클라이언트에서 서버로 회원가입과 관련된 버퍼를 전송합니다.
        #region SendRegist

        // 서버에 회원정보를 버퍼로 보냅니다.
        private void SendRegist()
        {
            string gender = null;
            if(rbMan.Checked)
                gender = "남";
            else if(rbWoman.Checked)
                gender = "여";

            NetworkStream ns = clientSocket.GetStream();

            // msg: regist√학번√비밀번호√이름√성별√연락처√
            string msg = "regist√" + tbClassNumber.Text + "√" + tbPassword.Text + "√" +
                tbName.Text + "√" + gender + "√" + tbPhone.Text + "√";
            byte[] buf = Encoding.UTF8.GetBytes(msg);

            ns.Write(buf, 0, buf.Length);
            ns.Flush();
        }

        delegate void SendRegistDelegate();
        private void _SendRegist2()
        {
            this.Close();
        }
        public void SendRegist2(string msg)
        {
            if (msg == "fail")
            {
                MessageBox.Show("이미 가입된 학번입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (msg == "pass")
            {
                MessageBox.Show(tbName.Text + "님 가입을 환영합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Invoke(new SendRegistDelegate(_SendRegist2));
            }
        }

        #endregion

        // tbClassNumber, tbPhoneNumber을 예외처리합니다.
        #region KeyPress_OnlyNumber

        // 학번칸에 숫자만 입력받게 합니다.
        private void tbClassNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        // 연락처칸에 숫자만 입력받게 합니다.
        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnMenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_point = new Point(e.X, e.Y);
        }

        private void pnMenuBar_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mouse_point.X - e.X), this.Top - (mouse_point.Y - e.Y));
            }
        }
    }
}
