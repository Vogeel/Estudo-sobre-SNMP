namespace SnmpSearchForm
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
            oidText = new TextBox();
            label2 = new Label();
            SearchIpBtn = new Button();
            label3 = new Label();
            viewInScreen = new DataGridView();
            searchBtn = new Button();
            walkRB = new RadioButton();
            getRB = new RadioButton();
            ipText = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)viewInScreen).BeginInit();
            SuspendLayout();
            // 
            // oidText
            // 
            oidText.Location = new Point(155, 56);
            oidText.Name = "oidText";
            oidText.Size = new Size(100, 23);
            oidText.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 38);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 3;
            label2.Text = "OID";
            // 
            // SearchIpBtn
            // 
            SearchIpBtn.Location = new Point(585, 56);
            SearchIpBtn.Name = "SearchIpBtn";
            SearchIpBtn.Size = new Size(75, 23);
            SearchIpBtn.TabIndex = 4;
            SearchIpBtn.Text = "Pesquisar";
            SearchIpBtn.UseVisualStyleBackColor = true;
            SearchIpBtn.Click += SearchIpBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(585, 38);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 5;
            label3.Text = "Pesquisar IPs na rede";
            // 
            // viewInScreen
            // 
            viewInScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewInScreen.Location = new Point(15, 127);
            viewInScreen.Name = "viewInScreen";
            viewInScreen.Size = new Size(773, 311);
            viewInScreen.TabIndex = 7;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(273, 56);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "Pesquisar";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // walkRB
            // 
            walkRB.AutoSize = true;
            walkRB.Location = new Point(389, 27);
            walkRB.Name = "walkRB";
            walkRB.Size = new Size(147, 19);
            walkRB.TabIndex = 10;
            walkRB.TabStop = true;
            walkRB.Text = "Walk com ponto inicial";
            walkRB.UseVisualStyleBackColor = true;
            // 
            // getRB
            // 
            getRB.AutoSize = true;
            getRB.Location = new Point(389, 52);
            getRB.Name = "getRB";
            getRB.Size = new Size(92, 19);
            getRB.TabIndex = 11;
            getRB.TabStop = true;
            getRB.Text = "Get com Oid";
            getRB.UseVisualStyleBackColor = true;
            // 
            // ipText
            // 
            ipText.Location = new Point(28, 57);
            ipText.Name = "ipText";
            ipText.Size = new Size(100, 23);
            ipText.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 38);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 13;
            label1.Text = "IP";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(ipText);
            Controls.Add(getRB);
            Controls.Add(walkRB);
            Controls.Add(searchBtn);
            Controls.Add(viewInScreen);
            Controls.Add(label3);
            Controls.Add(SearchIpBtn);
            Controls.Add(label2);
            Controls.Add(oidText);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)viewInScreen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox oidText;
        private Label label2;
        private Button SearchIpBtn;
        private Label label3;
        private DataGridView viewInScreen;
        private Button searchBtn;
        private RadioButton walkRB;
        private RadioButton getRB;
        private TextBox ipText;
        private Label label1;
    }
}
