namespace WindowsFormsApp9
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.abc_id = new System.Windows.Forms.TextBox();
            this.abc_name = new System.Windows.Forms.TextBox();
            this.abc_department = new System.Windows.Forms.TextBox();
            this.abc_age = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.abc_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(392, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(390, 220);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "DEPARTMENT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "AGE";
            // 
            // abc_id
            // 
            this.abc_id.Location = new System.Drawing.Point(197, 23);
            this.abc_id.Name = "abc_id";
            this.abc_id.Size = new System.Drawing.Size(163, 20);
            this.abc_id.TabIndex = 5;
            // 
            // abc_name
            // 
            this.abc_name.Location = new System.Drawing.Point(197, 56);
            this.abc_name.Name = "abc_name";
            this.abc_name.Size = new System.Drawing.Size(163, 20);
            this.abc_name.TabIndex = 6;
            // 
            // abc_department
            // 
            this.abc_department.Location = new System.Drawing.Point(197, 89);
            this.abc_department.Name = "abc_department";
            this.abc_department.Size = new System.Drawing.Size(163, 20);
            this.abc_department.TabIndex = 7;
            // 
            // abc_age
            // 
            this.abc_age.Location = new System.Drawing.Point(197, 123);
            this.abc_age.Name = "abc_age";
            this.abc_age.Size = new System.Drawing.Size(163, 20);
            this.abc_age.TabIndex = 8;
            // 
            // insert
            // 
            this.insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert.Location = new System.Drawing.Point(392, 268);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(113, 36);
            this.insert.TabIndex = 9;
            this.insert.Text = "INSERT";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(536, 268);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(101, 36);
            this.refresh.TabIndex = 10;
            this.refresh.Text = "REFRESH";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click_1);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(685, 268);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(97, 36);
            this.delete.TabIndex = 11;
            this.delete.Text = "DELETE";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.search.Location = new System.Drawing.Point(116, 357);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(119, 38);
            this.search.TabIndex = 12;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(392, 357);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(113, 38);
            this.message.TabIndex = 13;
            this.message.Text = "MESSAGE";
            this.message.UseVisualStyleBackColor = true;
            this.message.Click += new System.EventHandler(this.message_Click);
            // 
            // update
            // 
            this.update.AccessibleName = "update";
            this.update.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.Location = new System.Drawing.Point(559, 357);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(91, 38);
            this.update.TabIndex = 14;
            this.update.Text = "UPDATE";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // abc_search
            // 
            this.abc_search.Location = new System.Drawing.Point(12, 310);
            this.abc_search.Name = "abc_search";
            this.abc_search.Size = new System.Drawing.Size(327, 20);
            this.abc_search.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 484);
            this.Controls.Add(this.abc_search);
            this.Controls.Add(this.update);
            this.Controls.Add(this.message);
            this.Controls.Add(this.search);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.abc_age);
            this.Controls.Add(this.abc_department);
            this.Controls.Add(this.abc_name);
            this.Controls.Add(this.abc_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "abc_search";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox abc_id;
        private System.Windows.Forms.TextBox abc_name;
        private System.Windows.Forms.TextBox abc_department;
        private System.Windows.Forms.TextBox abc_age;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button message;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox abc_search;
    }
}

