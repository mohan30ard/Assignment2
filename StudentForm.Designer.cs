namespace Assignment2
{
    partial class StudentForm
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
            this.Operations = new System.Windows.Forms.GroupBox();
            this.delete = new System.Windows.Forms.RadioButton();
            this.update = new System.Windows.Forms.RadioButton();
            this.addnew = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.performbtn = new System.Windows.Forms.Button();
            this.scoreCount = new System.Windows.Forms.TextBox();
            this.average = new System.Windows.Forms.TextBox();
            this.score = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Operations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Operations
            // 
            this.Operations.Controls.Add(this.exit);
            this.Operations.Controls.Add(this.delete);
            this.Operations.Controls.Add(this.update);
            this.Operations.Controls.Add(this.addnew);
            this.Operations.Location = new System.Drawing.Point(1448, 39);
            this.Operations.Name = "Operations";
            this.Operations.Size = new System.Drawing.Size(276, 322);
            this.Operations.TabIndex = 2;
            this.Operations.TabStop = false;
            this.Operations.Text = "Operations";
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(20, 176);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(138, 41);
            this.delete.TabIndex = 8;
            this.delete.TabStop = true;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.Location = new System.Drawing.Point(20, 115);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(151, 41);
            this.update.TabIndex = 7;
            this.update.TabStop = true;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            // 
            // addnew
            // 
            this.addnew.AutoSize = true;
            this.addnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnew.Location = new System.Drawing.Point(20, 52);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(179, 41);
            this.addnew.TabIndex = 6;
            this.addnew.TabStop = true;
            this.addnew.Text = "Add New";
            this.addnew.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1519, 698);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "Average";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1487, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Score Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1487, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Score Total";
            // 
            // performbtn
            // 
            this.performbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performbtn.Location = new System.Drawing.Point(1483, 394);
            this.performbtn.Name = "performbtn";
            this.performbtn.Size = new System.Drawing.Size(185, 68);
            this.performbtn.TabIndex = 12;
            this.performbtn.Text = "Perform";
            this.performbtn.UseVisualStyleBackColor = true;
            this.performbtn.Click += new System.EventHandler(this.performbtn_Click);
            // 
            // scoreCount
            // 
            this.scoreCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreCount.Enabled = false;
            this.scoreCount.Location = new System.Drawing.Point(1515, 633);
            this.scoreCount.Multiline = true;
            this.scoreCount.Name = "scoreCount";
            this.scoreCount.ReadOnly = true;
            this.scoreCount.Size = new System.Drawing.Size(139, 47);
            this.scoreCount.TabIndex = 11;
            // 
            // average
            // 
            this.average.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.average.Enabled = false;
            this.average.Location = new System.Drawing.Point(1515, 747);
            this.average.Multiline = true;
            this.average.Name = "average";
            this.average.ReadOnly = true;
            this.average.Size = new System.Drawing.Size(139, 47);
            this.average.TabIndex = 10;
            // 
            // score
            // 
            this.score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score.Enabled = false;
            this.score.Location = new System.Drawing.Point(1515, 529);
            this.score.Multiline = true;
            this.score.Name = "score";
            this.score.ReadOnly = true;
            this.score.Size = new System.Drawing.Size(139, 47);
            this.score.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1397, 726);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1483, 813);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 68);
            this.button2.TabIndex = 18;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(20, 239);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(100, 41);
            this.exit.TabIndex = 9;
            this.exit.TabStop = true;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(403, 37);
            this.label4.TabIndex = 19;
            this.label4.Text = "Students Data In Grid View";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1758, 940);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.performbtn);
            this.Controls.Add(this.scoreCount);
            this.Controls.Add(this.average);
            this.Controls.Add(this.score);
            this.Controls.Add(this.Operations);
            this.Name = "StudentForm";
            this.Text = "Student Form";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.Operations.ResumeLayout(false);
            this.Operations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox Operations;
        private System.Windows.Forms.RadioButton delete;
        private System.Windows.Forms.RadioButton update;
        private System.Windows.Forms.RadioButton addnew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button performbtn;
        private System.Windows.Forms.TextBox scoreCount;
        private System.Windows.Forms.TextBox average;
        private System.Windows.Forms.TextBox score;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton exit;
        private System.Windows.Forms.Label label4;
    }
}

