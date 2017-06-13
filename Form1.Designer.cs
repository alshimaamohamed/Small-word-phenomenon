namespace Small_World_Phenomenon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Line_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chain_Movies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get_Quary ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line_Number,
            this.actor1,
            this.degree,
            this.rel,
            this.chain,
            this.Chain_Movies});
            this.dataGridView1.Location = new System.Drawing.Point(28, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(966, 374);
            this.dataGridView1.TabIndex = 1;
            // 
            // Line_Number
            // 
            this.Line_Number.HeaderText = "#Line";
            this.Line_Number.Name = "Line_Number";
            this.Line_Number.Width = 50;
            // 
            // actor1
            // 
            this.actor1.HeaderText = "Actor1";
            this.actor1.Name = "actor1";
            // 
            // degree
            // 
            this.degree.HeaderText = "Actor2";
            this.degree.Name = "degree";
            // 
            // rel
            // 
            this.rel.HeaderText = "Degree";
            this.rel.Name = "rel";
            // 
            // chain
            // 
            this.chain.HeaderText = "Relation_Strength";
            this.chain.Name = "chain";
            // 
            // Chain_Movies
            // 
            this.Chain_Movies.HeaderText = "Chain_Movies";
            this.Chain_Movies.Name = "Chain_Movies";
            this.Chain_Movies.Width = 500;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1077, 456);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn actor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn rel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chain_Movies;


    }
}

