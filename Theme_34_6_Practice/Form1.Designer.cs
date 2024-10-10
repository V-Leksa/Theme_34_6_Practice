namespace Theme_34_6_Practice
{
    partial class StudentF
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
            NameTB = new TextBox();
            LastNameTB = new TextBox();
            AgeTB = new TextBox();
            AddBt = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ShowLB = new ListBox();
            ShowBt = new Button();
            label4 = new Label();
            NameSurnameTb = new TextBox();
            label5 = new Label();
            NameRB = new RadioButton();
            SurnameRB = new RadioButton();
            FindBt = new Button();
            RedactionBt = new Button();
            RemoveBt = new Button();
            SaveBt = new Button();
            SuspendLayout();
            // 
            // NameTB
            // 
            NameTB.Location = new Point(21, 32);
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(158, 23);
            NameTB.TabIndex = 0;
            // 
            // LastNameTB
            // 
            LastNameTB.Location = new Point(21, 89);
            LastNameTB.Name = "LastNameTB";
            LastNameTB.Size = new Size(158, 23);
            LastNameTB.TabIndex = 1;
            // 
            // AgeTB
            // 
            AgeTB.Location = new Point(21, 150);
            AgeTB.Name = "AgeTB";
            AgeTB.Size = new Size(158, 23);
            AgeTB.TabIndex = 2;
            // 
            // AddBt
            // 
            AddBt.Location = new Point(21, 191);
            AddBt.Name = "AddBt";
            AddBt.Size = new Size(158, 62);
            AddBt.TabIndex = 3;
            AddBt.Text = "Добавить";
            AddBt.UseVisualStyleBackColor = true;
            AddBt.Click += AddBt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 4;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 71);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 132);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 6;
            label3.Text = "Возраст";
            // 
            // ShowLB
            // 
            ShowLB.FormattingEnabled = true;
            ShowLB.ItemHeight = 15;
            ShowLB.Location = new Point(212, 47);
            ShowLB.Name = "ShowLB";
            ShowLB.Size = new Size(421, 439);
            ShowLB.TabIndex = 7;
            ShowLB.SelectedIndexChanged += ShowLB_SelectedIndexChanged;
            // 
            // ShowBt
            // 
            ShowBt.Location = new Point(323, 7);
            ShowBt.Name = "ShowBt";
            ShowBt.Size = new Size(134, 34);
            ShowBt.TabIndex = 8;
            ShowBt.Text = "Вывести";
            ShowBt.UseVisualStyleBackColor = true;
            ShowBt.Click += ShowBt_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 9);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 9;
            label4.Text = "Список студентов";
            // 
            // NameSurnameTb
            // 
            NameSurnameTb.Location = new Point(653, 32);
            NameSurnameTb.Name = "NameSurnameTb";
            NameSurnameTb.Size = new Size(180, 23);
            NameSurnameTb.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(653, 9);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 12;
            label5.Text = "Имя/Фамилия";
            // 
            // NameRB
            // 
            NameRB.AutoSize = true;
            NameRB.Location = new Point(653, 71);
            NameRB.Name = "NameRB";
            NameRB.Size = new Size(49, 19);
            NameRB.TabIndex = 14;
            NameRB.TabStop = true;
            NameRB.Text = "Имя";
            NameRB.UseVisualStyleBackColor = true;
            // 
            // SurnameRB
            // 
            SurnameRB.AutoSize = true;
            SurnameRB.Location = new Point(653, 96);
            SurnameRB.Name = "SurnameRB";
            SurnameRB.Size = new Size(76, 19);
            SurnameRB.TabIndex = 15;
            SurnameRB.TabStop = true;
            SurnameRB.Text = "Фамилия";
            SurnameRB.UseVisualStyleBackColor = true;
            // 
            // FindBt
            // 
            FindBt.Location = new Point(653, 129);
            FindBt.Name = "FindBt";
            FindBt.Size = new Size(145, 62);
            FindBt.TabIndex = 16;
            FindBt.Text = "Поиск";
            FindBt.UseVisualStyleBackColor = true;
            FindBt.Click += FindBt_Click;
            // 
            // RedactionBt
            // 
            RedactionBt.Location = new Point(21, 276);
            RedactionBt.Name = "RedactionBt";
            RedactionBt.Size = new Size(158, 67);
            RedactionBt.TabIndex = 17;
            RedactionBt.Text = "Редактировать данные";
            RedactionBt.UseVisualStyleBackColor = true;
            RedactionBt.Click += RedactionBt_Click;
            // 
            // RemoveBt
            // 
            RemoveBt.Location = new Point(21, 367);
            RemoveBt.Name = "RemoveBt";
            RemoveBt.Size = new Size(158, 67);
            RemoveBt.TabIndex = 18;
            RemoveBt.Text = "Удалить студента";
            RemoveBt.UseVisualStyleBackColor = true;
            RemoveBt.Click += RemoveBt_Click;
            // 
            // SaveBt
            // 
            SaveBt.Location = new Point(654, 211);
            SaveBt.Name = "SaveBt";
            SaveBt.Size = new Size(144, 75);
            SaveBt.TabIndex = 19;
            SaveBt.Text = "Резервное копирование";
            SaveBt.UseVisualStyleBackColor = true;
            SaveBt.Click += SaveBt_Click;
            // 
            // StudentF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 487);
            Controls.Add(SaveBt);
            Controls.Add(RemoveBt);
            Controls.Add(RedactionBt);
            Controls.Add(FindBt);
            Controls.Add(SurnameRB);
            Controls.Add(NameRB);
            Controls.Add(label5);
            Controls.Add(NameSurnameTb);
            Controls.Add(label4);
            Controls.Add(ShowBt);
            Controls.Add(ShowLB);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddBt);
            Controls.Add(AgeTB);
            Controls.Add(LastNameTB);
            Controls.Add(NameTB);
            Name = "StudentF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Click += StudentF_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTB;
        private TextBox LastNameTB;
        private TextBox AgeTB;
        private Button AddBt;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox ShowLB;
        private Button ShowBt;
        private Label label4;
        private TextBox NameSurnameTb;
        private Label label5;
        private RadioButton NameRB;
        private RadioButton SurnameRB;
        private Button FindBt;
        private Button RedactionBt;
        private Button RemoveBt;
        private Button SaveBt;
    }
}