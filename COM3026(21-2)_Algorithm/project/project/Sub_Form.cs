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

namespace FinalSubject
{
    public partial class Sub_Form : Form
    {
        List<string> imgList = null;
        public static string confirm_path;
        public static string confirm_name;

        public Sub_Form()
        {
            InitializeComponent();

            string subform_name = confirm_name;

            subform_name = subform_name.Substring(9);
            char sp1 = '.';
            string[] Split_name = subform_name.Split(sp1);

            this.Text = Split_name[0];
            myTextBox1.Text = Split_name[0];

            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            reverse.BackColor = 
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            string[] files = Directory.GetFiles(confirm_path);

            string new_path = confirm_path + "\\head and body";
            string[] head_and_leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\arm";
            string[] arm_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\leg";
            string[] leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\other";
            string[] other_files = Directory.GetFiles(new_path);

            var list = new List<string>();

            list.AddRange(files);
            list.AddRange(head_and_leg_files);
            list.AddRange(arm_files);
            list.AddRange(leg_files);
            list.AddRange(other_files);

            string[] fianl_files = list.ToArray();

            imgList = fianl_files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }

        }

        private void PBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int idx = Convert.ToInt32(pb.Tag.ToString());
            string file = this.imgList[idx].ToString();

            ZoomForm frm = new ZoomForm();
            frm.file = file;

            frm.ShowDialog();
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

            Image img = Image.FromFile(imgList[idx]);
            uiPic_Main.Image = img;
            uiPic_Main.SizeMode = PictureBoxSizeMode.Zoom;
            //uiTxt_ImgFile.Text = this.imgList[idx];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sub_Form_Load(object sender, EventArgs e)
        {
        }

        private void uiPic_Main_Click(object sender, EventArgs e)
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void big_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string new_path = confirm_path + "\\unitedfile";
            string[] files = Directory.GetFiles(new_path);

            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void all_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string[] files = Directory.GetFiles(confirm_path);

            string new_path = confirm_path + "\\head and body";
            string[] head_and_leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\arm";
            string[] arm_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\leg";
            string[] leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\other";
            string[] other_files = Directory.GetFiles(new_path);

            var list = new List<string>();

            list.AddRange(files);
            list.AddRange(head_and_leg_files);
            list.AddRange(arm_files);
            list.AddRange(leg_files);
            list.AddRange(other_files);

            string[] fianl_files = list.ToArray();

            imgList = fianl_files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string[] files = Directory.GetFiles(confirm_path);

            string new_path = confirm_path + "\\head and body";
            string[] head_and_leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\arm";
            string[] arm_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\leg";
            string[] leg_files = Directory.GetFiles(new_path);

            new_path = confirm_path + "\\other";
            string[] other_files = Directory.GetFiles(new_path);

            var list = new List<string>();

            list.AddRange(files);
            list.AddRange(head_and_leg_files);
            list.AddRange(arm_files);
            list.AddRange(leg_files);
            list.AddRange(other_files);

            string[] fianl_files = list.ToArray();

            imgList = fianl_files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            imgList.Reverse();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void headandbody_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string new_path = confirm_path + "\\head and body";
            string[] files = Directory.GetFiles(new_path);

            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void arm_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string new_path = confirm_path + "\\arm";
            string[] files = Directory.GetFiles(new_path);

            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void leg_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);

            this.uiFlp_Thumnail.Controls.Clear();
            string new_path = confirm_path + "\\leg";
            string[] files = Directory.GetFiles(new_path);

            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void other_Click(object sender, EventArgs e)
        {
            big.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            all.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            reverse.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            headandbody.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            leg.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            arm.BackColor = System.Drawing.Color.FromArgb(136, 167, 202);
            other.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);

            this.uiFlp_Thumnail.Controls.Clear();
            string new_path = confirm_path + "\\other";
            string[] files = Directory.GetFiles(new_path);

            imgList = files.Where(x => x.IndexOf(".jpg", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       x.IndexOf(".png", StringComparison.OrdinalIgnoreCase) >= 0)
                           .Select(x => x).ToList();

            for (int i = 0; i < imgList.Count; i++)
            {
                Image img = Image.FromFile(imgList[i]);

                Panel pPanel = new Panel();
                pPanel.BackColor = Color.Black;
                pPanel.Size = new Size(150, 150);
                pPanel.Padding = new System.Windows.Forms.Padding(4);

                PictureBox pBox = new PictureBox();
                pBox.BackColor = Color.DimGray;
                pBox.Dock = DockStyle.Fill;
                pBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (img.Width >= img.Height)
                {
                    double rate = img.Height * 150 / img.Width;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(150, val, null, IntPtr.Zero);
                }
                else
                {
                    double rate = img.Width * 150 / img.Height;
                    int val = Convert.ToInt32(rate);
                    pBox.Image = img.GetThumbnailImage(val, 150, null, IntPtr.Zero);
                }

                pBox.Click += PBox_Click;
                pBox.DoubleClick += PBox_DoubleClick;
                pBox.Tag = i.ToString();
                pPanel.Controls.Add(pBox);

                this.uiFlp_Thumnail.Controls.Add(pPanel);
            }

            if (imgList.Count > 0)
            {
                Panel pnl = this.uiFlp_Thumnail.Controls[0] as Panel;
                PictureBox pb = pnl.Controls[0] as PictureBox;
                //uiTxt_ImgFile.Text = this.imgList[0];
                PBox_Click(pb, null);
            }
        }

        private void Minimized_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void myTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
