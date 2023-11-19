
namespace FinalSubject
{
    partial class Sub_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sub_Form));
            this.uiFlp_Thumnail = new System.Windows.Forms.FlowLayoutPanel();
            this.uiPic_Main = new System.Windows.Forms.PictureBox();
            this.reverse = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Minimized_Button = new System.Windows.Forms.Button();
            this.big = new System.Windows.Forms.Button();
            this.other = new System.Windows.Forms.Button();
            this.leg = new System.Windows.Forms.Button();
            this.arm = new System.Windows.Forms.Button();
            this.headandbody = new System.Windows.Forms.Button();
            this.all = new System.Windows.Forms.Button();
            this.myTextBox1 = new FinalSubject.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiPic_Main)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiFlp_Thumnail
            // 
            this.uiFlp_Thumnail.AutoScroll = true;
            this.uiFlp_Thumnail.BackColor = System.Drawing.Color.DimGray;
            this.uiFlp_Thumnail.Location = new System.Drawing.Point(677, 88);
            this.uiFlp_Thumnail.Name = "uiFlp_Thumnail";
            this.uiFlp_Thumnail.Size = new System.Drawing.Size(191, 700);
            this.uiFlp_Thumnail.TabIndex = 2;
            // 
            // uiPic_Main
            // 
            this.uiPic_Main.BackColor = System.Drawing.Color.DimGray;
            this.uiPic_Main.Location = new System.Drawing.Point(5, 129);
            this.uiPic_Main.Name = "uiPic_Main";
            this.uiPic_Main.Size = new System.Drawing.Size(666, 659);
            this.uiPic_Main.TabIndex = 3;
            this.uiPic_Main.TabStop = false;
            this.uiPic_Main.Click += new System.EventHandler(this.uiPic_Main_Click);
            // 
            // reverse
            // 
            this.reverse.FlatAppearance.BorderSize = 0;
            this.reverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reverse.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.reverse.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.reverse.Location = new System.Drawing.Point(198, 42);
            this.reverse.Name = "reverse";
            this.reverse.Size = new System.Drawing.Size(100, 40);
            this.reverse.TabIndex = 4;
            this.reverse.Text = "분해";
            this.reverse.UseVisualStyleBackColor = true;
            this.reverse.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(167)))), ((int)(((byte)(202)))));
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(843, 2);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(34, 23);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "X";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(167)))), ((int)(((byte)(202)))));
            this.panel1.Controls.Add(this.close_button);
            this.panel1.Controls.Add(this.Minimized_Button);
            this.panel1.Controls.Add(this.big);
            this.panel1.Controls.Add(this.other);
            this.panel1.Controls.Add(this.leg);
            this.panel1.Controls.Add(this.arm);
            this.panel1.Controls.Add(this.headandbody);
            this.panel1.Controls.Add(this.all);
            this.panel1.Controls.Add(this.reverse);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 82);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_mousedown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_mousemove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_mouseup);
            // 
            // Minimized_Button
            // 
            this.Minimized_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.Minimized_Button.FlatAppearance.BorderSize = 0;
            this.Minimized_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimized_Button.Font = new System.Drawing.Font("굴림", 15F);
            this.Minimized_Button.ForeColor = System.Drawing.Color.White;
            this.Minimized_Button.Location = new System.Drawing.Point(808, 1);
            this.Minimized_Button.Name = "Minimized_Button";
            this.Minimized_Button.Size = new System.Drawing.Size(34, 23);
            this.Minimized_Button.TabIndex = 11;
            this.Minimized_Button.Text = "-";
            this.Minimized_Button.UseVisualStyleBackColor = false;
            this.Minimized_Button.Click += new System.EventHandler(this.Minimized_Button_Click);
            // 
            // big
            // 
            this.big.FlatAppearance.BorderSize = 0;
            this.big.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.big.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.big.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.big.Location = new System.Drawing.Point(101, 42);
            this.big.Name = "big";
            this.big.Size = new System.Drawing.Size(100, 40);
            this.big.TabIndex = 10;
            this.big.Text = "원본";
            this.big.UseVisualStyleBackColor = true;
            this.big.Click += new System.EventHandler(this.big_Click);
            // 
            // other
            // 
            this.other.FlatAppearance.BorderSize = 0;
            this.other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.other.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.other.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.other.Location = new System.Drawing.Point(583, 42);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(100, 40);
            this.other.TabIndex = 9;
            this.other.Text = "무장";
            this.other.UseVisualStyleBackColor = true;
            this.other.Click += new System.EventHandler(this.other_Click);
            // 
            // leg
            // 
            this.leg.FlatAppearance.BorderSize = 0;
            this.leg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leg.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.leg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.leg.Location = new System.Drawing.Point(487, 42);
            this.leg.Name = "leg";
            this.leg.Size = new System.Drawing.Size(100, 40);
            this.leg.TabIndex = 8;
            this.leg.Text = "다리";
            this.leg.UseVisualStyleBackColor = true;
            this.leg.Click += new System.EventHandler(this.leg_Click);
            // 
            // arm
            // 
            this.arm.FlatAppearance.BorderSize = 0;
            this.arm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arm.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.arm.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.arm.Location = new System.Drawing.Point(390, 42);
            this.arm.Name = "arm";
            this.arm.Size = new System.Drawing.Size(100, 40);
            this.arm.TabIndex = 7;
            this.arm.Text = "팔";
            this.arm.UseVisualStyleBackColor = true;
            this.arm.Click += new System.EventHandler(this.arm_Click);
            // 
            // headandbody
            // 
            this.headandbody.FlatAppearance.BorderSize = 0;
            this.headandbody.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.headandbody.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.headandbody.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headandbody.Location = new System.Drawing.Point(294, 42);
            this.headandbody.Name = "headandbody";
            this.headandbody.Size = new System.Drawing.Size(100, 40);
            this.headandbody.TabIndex = 6;
            this.headandbody.Text = "머리 몸통";
            this.headandbody.UseVisualStyleBackColor = true;
            this.headandbody.Click += new System.EventHandler(this.headandbody_Click);
            // 
            // all
            // 
            this.all.FlatAppearance.BorderSize = 0;
            this.all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.all.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.all.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.all.Location = new System.Drawing.Point(1, 42);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(100, 40);
            this.all.TabIndex = 5;
            this.all.Text = "전체";
            this.all.UseVisualStyleBackColor = true;
            this.all.Click += new System.EventHandler(this.all_Click);
            // 
            // myTextBox1
            // 
            this.myTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(167)))), ((int)(((byte)(202)))));
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myTextBox1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.myTextBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.myTextBox1.Location = new System.Drawing.Point(5, 88);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.ReadOnly = true;
            this.myTextBox1.Size = new System.Drawing.Size(666, 35);
            this.myTextBox1.TabIndex = 12;
            this.myTextBox1.Text = "간다무";
            this.myTextBox1.UseWaitCursor = true;
            this.myTextBox1.TextChanged += new System.EventHandler(this.myTextBox1_TextChanged);
            // 
            // Sub_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(880, 800);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.uiPic_Main);
            this.Controls.Add(this.uiFlp_Thumnail);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sub_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Sub_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPic_Main)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uiFlp_Thumnail;
        private System.Windows.Forms.PictureBox uiPic_Main;
        private System.Windows.Forms.Button reverse;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button other;
        private System.Windows.Forms.Button leg;
        private System.Windows.Forms.Button arm;
        private System.Windows.Forms.Button headandbody;
        private System.Windows.Forms.Button all;
        private System.Windows.Forms.Button big;
        private System.Windows.Forms.Button Minimized_Button;
        private MyTextBox myTextBox1;
    }
}