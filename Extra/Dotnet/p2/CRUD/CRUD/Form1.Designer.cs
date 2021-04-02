namespace CRUD
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
            this.components = new System.ComponentModel.Container();
            this.userInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.netClassDataSet = new CRUD.NetClassDataSet();
            this.userInfoTableAdapter = new CRUD.NetClassDataSetTableAdapters.UserInfoTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netClassDataSet1 = new CRUD.NetClassDataSet1();
            this.netClassDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.addressBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userInfoBindingSource
            // 
            this.userInfoBindingSource.DataMember = "UserInfo";
            this.userInfoBindingSource.DataSource = this.netClassDataSet;
            // 
            // netClassDataSet
            // 
            this.netClassDataSet.DataSetName = "NetClassDataSet";
            this.netClassDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userInfoTableAdapter
            // 
            this.userInfoTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(485, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(524, 223);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // netClassDataSet1
            // 
            this.netClassDataSet1.DataSetName = "NetClassDataSet1";
            this.netClassDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // netClassDataSet1BindingSource
            // 
            this.netClassDataSet1BindingSource.DataSource = this.netClassDataSet1;
            this.netClassDataSet1BindingSource.Position = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 42);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(84, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Enter your name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(164, 42);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(153, 20);
            this.nameBox.TabIndex = 2;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(27, 90);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(95, 13);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Enter your address";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(164, 90);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(153, 20);
            this.addressBox.TabIndex = 4;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(30, 153);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(76, 13);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "Enter your emil";
           
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(164, 145);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(153, 20);
            this.emailBox.TabIndex = 6;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(34, 193);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(88, 13);
            this.phoneLabel.TabIndex = 7;
            this.phoneLabel.Text = "Enter your phone";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(164, 190);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(153, 20);
            this.phoneBox.TabIndex = 8;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(164, 227);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 450);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netClassDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NetClassDataSet netClassDataSet;
        private System.Windows.Forms.BindingSource userInfoBindingSource;
        private NetClassDataSetTableAdapters.UserInfoTableAdapter userInfoTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private NetClassDataSet1 netClassDataSet1;
        private System.Windows.Forms.BindingSource netClassDataSet1BindingSource;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Button submitButton;
    }
}

