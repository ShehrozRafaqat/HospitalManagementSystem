
namespace HMS
{
    partial class Login_Page
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
            this.label1 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lgn = new System.Windows.Forms.Button();
            this.reg = new System.Windows.Forms.Button();
            this.Admin_op = new System.Windows.Forms.RadioButton();
            this.patientOp = new System.Windows.Forms.RadioButton();
            this.doctorOp = new System.Windows.Forms.RadioButton();
            this.staffOp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(228, 97);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(305, 20);
            this.user.TabIndex = 1;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(228, 216);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(305, 20);
            this.pwd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lgn
            // 
            this.lgn.Location = new System.Drawing.Point(228, 313);
            this.lgn.Name = "lgn";
            this.lgn.Size = new System.Drawing.Size(130, 35);
            this.lgn.TabIndex = 5;
            this.lgn.Text = "Login";
            this.lgn.UseVisualStyleBackColor = true;
            this.lgn.Click += new System.EventHandler(this.lgn_Click);
            // 
            // reg
            // 
            this.reg.Location = new System.Drawing.Point(413, 313);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(120, 35);
            this.reg.TabIndex = 6;
            this.reg.Text = "Register";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // Admin_op
            // 
            this.Admin_op.AutoSize = true;
            this.Admin_op.Location = new System.Drawing.Point(599, 97);
            this.Admin_op.Name = "Admin_op";
            this.Admin_op.Size = new System.Drawing.Size(54, 17);
            this.Admin_op.TabIndex = 7;
            this.Admin_op.TabStop = true;
            this.Admin_op.Text = "Admin";
            this.Admin_op.UseVisualStyleBackColor = true;
            this.Admin_op.CheckedChanged += new System.EventHandler(this.Admin_op_CheckedChanged);
            // 
            // patientOp
            // 
            this.patientOp.AutoSize = true;
            this.patientOp.Location = new System.Drawing.Point(675, 97);
            this.patientOp.Name = "patientOp";
            this.patientOp.Size = new System.Drawing.Size(58, 17);
            this.patientOp.TabIndex = 8;
            this.patientOp.TabStop = true;
            this.patientOp.Text = "Patient";
            this.patientOp.UseVisualStyleBackColor = true;
            // 
            // doctorOp
            // 
            this.doctorOp.AutoSize = true;
            this.doctorOp.Location = new System.Drawing.Point(599, 167);
            this.doctorOp.Name = "doctorOp";
            this.doctorOp.Size = new System.Drawing.Size(57, 17);
            this.doctorOp.TabIndex = 9;
            this.doctorOp.TabStop = true;
            this.doctorOp.Text = "Doctor";
            this.doctorOp.UseVisualStyleBackColor = true;
            // 
            // staffOp
            // 
            this.staffOp.AutoSize = true;
            this.staffOp.Location = new System.Drawing.Point(686, 167);
            this.staffOp.Name = "staffOp";
            this.staffOp.Size = new System.Drawing.Size(47, 17);
            this.staffOp.TabIndex = 10;
            this.staffOp.TabStop = true;
            this.staffOp.Text = "Staff";
            this.staffOp.UseVisualStyleBackColor = true;
            // 
            // Login_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.staffOp);
            this.Controls.Add(this.doctorOp);
            this.Controls.Add(this.patientOp);
            this.Controls.Add(this.Admin_op);
            this.Controls.Add(this.reg);
            this.Controls.Add(this.lgn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Name = "Login_Page";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Page_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button lgn;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.RadioButton Admin_op;
        private System.Windows.Forms.RadioButton patientOp;
        private System.Windows.Forms.RadioButton doctorOp;
        private System.Windows.Forms.RadioButton staffOp;
    }
}

