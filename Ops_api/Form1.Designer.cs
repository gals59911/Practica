namespace Ops_api
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            button2 = new Button();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            comboBox1 = new ComboBox();
            label11 = new Label();
            textBox8 = new TextBox();
            label12 = new Label();
            textBox9 = new TextBox();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(402, 149);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Write";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = " OPC Server URL:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 144);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(265, 23);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 5;
            label2.Text = "Node Id write:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(304, 149);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 126);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Value:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 193);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(265, 23);
            textBox4.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 175);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 9;
            label4.Text = "Node Id read:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(304, 193);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(66, 23);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 175);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 11;
            label5.Text = "Value:";
            // 
            // button2
            // 
            button2.Location = new Point(402, 193);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Read";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(304, 229);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 13;
            label6.Text = "DataType:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(304, 247);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(66, 23);
            textBox6.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(622, 73);
            label7.Name = "label7";
            label7.Size = new Size(102, 15);
            label7.TabIndex = 15;
            label7.Text = "ModBus Server IP:";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(622, 100);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(265, 23);
            textBox7.TabIndex = 16;
            // 
            // button3
            // 
            button3.Location = new Point(923, 97);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 17;
            button3.Text = "Connect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(923, 143);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 18;
            button4.Text = "Disconnect";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(619, 144);
            label8.Name = "label8";
            label8.Size = new Size(105, 15);
            label8.TabIndex = 19;
            label8.Text = "Status connection:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(730, 144);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 20;
            label9.Text = "No connection";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(622, 193);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 21;
            label10.Text = "Register type:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Coil status", "Holding register " });
            comboBox1.Location = new Point(716, 190);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 23);
            comboBox1.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(622, 229);
            label11.Name = "label11";
            label11.Size = new Size(90, 15);
            label11.TabIndex = 23;
            label11.Text = "Adress register :";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(718, 221);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(622, 258);
            label12.Name = "label12";
            label12.Size = new Size(38, 15);
            label12.TabIndex = 25;
            label12.Text = "Value:";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(716, 255);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 23);
            textBox9.TabIndex = 26;
            // 
            // button5
            // 
            button5.Location = new Point(858, 255);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 27;
            button5.Text = "Write";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 591);
            Controls.Add(button5);
            Controls.Add(textBox9);
            Controls.Add(label12);
            Controls.Add(textBox8);
            Controls.Add(label11);
            Controls.Add(comboBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private Button button2;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private Button button3;
        private Button button4;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox comboBox1;
        private Label label11;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox9;
        private Button button5;
    }
}
