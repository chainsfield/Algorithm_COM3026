using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace FinalSubject
{
    public partial class Main_Form : Form
    {
        List<string> imgList = null;
        public Main_Form()
        {
            InitializeComponent();

            this.Text = "GFE MAIN MENU";

            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile("SEOUL_NAMSAN.ttf");
            Font font1 = new Font(privateFonts.Families[0], 14f);

            string[] files = Directory.GetFiles(@"C:\GFE");
            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0
                                    || x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)

                              .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);
                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(230, 420);
                pPanel.BorderStyle = BorderStyle.None;
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.White;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 270 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(230, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 230 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 270, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);
                MyTextBox tBox = new MyTextBox();
                tBox.Size = new Size(230, 45);
                tBox.Multiline = true;
                tBox.BackColor = Color.Gray;
                tBox.Dock = DockStyle.Bottom;
                string tmp = this.imgList[i];
                tmp = tmp.Substring(9);
                char sp1 = '.';
                char sp2 = ' ';
                string[] spstring1 = tmp.Split(sp1);
                string[] spstring2 = spstring1[0].Split(sp2);

                string new_code_name;
                new_code_name = spstring2[1].PadRight(32, ' ');

                int length = spstring2[1].Length + 1;
                tmp = spstring1[0].Substring(length);

                tBox.Text = new_code_name + tmp;


                tBox.BorderStyle = BorderStyle.None;
                tBox.Font = font1;
                
                tBox.BackColor = Color.Black;
                tBox.ForeColor = Color.White;
                tBox.AutoSize = false;
                tBox.Enabled = false;
                tBox.Tag = i.ToString();
                pPanel.Controls.Add(tBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);

            }

            /*
            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0]; 텍스트 저장
                PBox_Click(pb, null);
            }
            */
        }

        private void PBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.uiFlp_Thumnail.Controls.Count; i++)
            {
                if (this.uiFlp_Thumnail.Controls[i] is Panel)
                {
                    Panel pnl = this.uiFlp_Thumnail.Controls[i] as Panel;
                    pnl.BackColor = Color.Black;
                }
            }

            PictureBox pb = sender as PictureBox;
            pb.Parent.BackColor = Color.Red;

            int idx = Convert.ToInt32(pb.Tag.ToString());


            string confirm_path = this.imgList[idx];
            Sub_Form.confirm_name = this.imgList[idx];

            confirm_path = confirm_path.Substring(0, 9);
            Sub_Form.confirm_path = confirm_path;

            Point parentPoint = this.Location;
            Form new_form = new Sub_Form();

            new_form.Owner = this;

            new_form.StartPosition = FormStartPosition.Manual;  // 폼의 위치가 Location 의 속성에 의해서 결정
            new_form.Location = new Point(parentPoint.X + 735, parentPoint.Y);
            new_form.Show();

            /*
            Image img = Image.FromFile(imgList[idx]);
            uiPic_Main.Image = img;
            uiPic_Main.SizeMode = PictureBoxSizeMode.StretchImage;
            uiTxt_ImgFile.Text = this.imgList[idx];
            */

        }


        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        Point point;
        bool isMove;

        private void pn_mousedown(object sender, MouseEventArgs e)
        {
            isMove = true;
            point = new Point(e.X, e.Y);
        }

        private void pn_mousemove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }

        private void pn_mouseup(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile("SEOUL_NAMSAN.ttf");
            Font font1 = new Font(privateFonts.Families[0], 14f);

            this.uiFlp_Thumnail.Controls.Clear();
            string filter = "*" + textBox1.Text + "*";
            string[] files = Directory.GetFiles(@"C:\GFE", filter);
            files.Reverse();
            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0
                                    || x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)

                              .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);
                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(230, 420);
                pPanel.BorderStyle = BorderStyle.None;
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.White;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 270 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(230, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 230 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 270, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);
                MyTextBox tBox = new MyTextBox();
                tBox.Size = new Size(230, 45);
                tBox.Multiline = true;
                tBox.BackColor = Color.Gray;
                tBox.Dock = DockStyle.Bottom;
                string tmp = this.imgList[i];
                tmp = tmp.Substring(9);
                char sp1 = '.';
                char sp2 = ' ';
                string[] spstring1 = tmp.Split(sp1);
                string[] spstring2 = spstring1[0].Split(sp2);

                string new_code_name;
                new_code_name = spstring2[1].PadRight(32, ' ');

                int length = spstring2[1].Length + 1;
                tmp = spstring1[0].Substring(length);

                tBox.Text = new_code_name + tmp;


                tBox.BorderStyle = BorderStyle.None;
                tBox.Font = font1;

                tBox.BackColor = Color.Black;
                tBox.ForeColor = Color.White;
                tBox.AutoSize = false;
                tBox.Enabled = false;
                tBox.Tag = i.ToString();
                pPanel.Controls.Add(tBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);

            }

            if (imgList.Count == 1)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0]; 텍스트 저장
                PBox_Click(pb, null);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("제작\n 김륜엽 박규남\n 신동수 양병헌\n\n이미지 출처\n http://dalong.net/ \n\nⓒ 2021. 2 Trillion all rights reserved.\nCC BY-NC-SA 4.0", "프로그램 정보");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
