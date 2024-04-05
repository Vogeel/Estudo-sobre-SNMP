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
            viewInScreen = new DataGridView();
            searchBtn = new Button();
            walkRB = new RadioButton();
            getRB = new RadioButton();
            ipText = new TextBox();
            label1 = new Label();
            setRB = new RadioButton();
            panel1 = new Panel();
            panel2 = new Panel();
            v3RB = new RadioButton();
            v2RB = new RadioButton();
            v1RB = new RadioButton();
            valueText = new TextBox();
            valueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)viewInScreen).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            // viewInScreen
            // 
            viewInScreen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewInScreen.Location = new Point(15, 127);
            viewInScreen.Name = "viewInScreen";
            viewInScreen.Size = new Size(985, 311);
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
            walkRB.Location = new Point(6, 15);
            walkRB.Name = "walkRB";
            walkRB.Size = new Size(51, 19);
            walkRB.TabIndex = 10;
            walkRB.TabStop = true;
            walkRB.Text = "Walk";
            walkRB.UseVisualStyleBackColor = true;
            // 
            // getRB
            // 
            getRB.AutoSize = true;
            getRB.Location = new Point(6, 40);
            getRB.Name = "getRB";
            getRB.Size = new Size(43, 19);
            getRB.TabIndex = 11;
            getRB.TabStop = true;
            getRB.Text = "Get";
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
            // setRB
            // 
            setRB.AutoSize = true;
            setRB.Location = new Point(8, 65);
            setRB.Name = "setRB";
            setRB.Size = new Size(41, 19);
            setRB.TabIndex = 14;
            setRB.TabStop = true;
            setRB.Text = "Set";
            setRB.UseVisualStyleBackColor = true;
            setRB.CheckedChanged += setRB_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(walkRB);
            panel1.Controls.Add(setRB);
            panel1.Controls.Add(getRB);
            panel1.Location = new Point(373, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(80, 100);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(v3RB);
            panel2.Controls.Add(v2RB);
            panel2.Controls.Add(v1RB);
            panel2.Location = new Point(459, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(80, 100);
            panel2.TabIndex = 16;
            // 
            // v3RB
            // 
            v3RB.AutoSize = true;
            v3RB.Location = new Point(3, 65);
            v3RB.Name = "v3RB";
            v3RB.Size = new Size(38, 19);
            v3RB.TabIndex = 19;
            v3RB.TabStop = true;
            v3RB.Text = "V3";
            v3RB.UseVisualStyleBackColor = true;
            // 
            // v2RB
            // 
            v2RB.AutoSize = true;
            v2RB.Location = new Point(3, 40);
            v2RB.Name = "v2RB";
            v2RB.Size = new Size(38, 19);
            v2RB.TabIndex = 18;
            v2RB.TabStop = true;
            v2RB.Text = "V2";
            v2RB.UseVisualStyleBackColor = true;
            // 
            // v1RB
            // 
            v1RB.AutoSize = true;
            v1RB.Location = new Point(3, 15);
            v1RB.Name = "v1RB";
            v1RB.Size = new Size(38, 19);
            v1RB.TabIndex = 17;
            v1RB.TabStop = true;
            v1RB.Text = "V1";
            v1RB.UseVisualStyleBackColor = true;
            // 
            // valueText
            // 
            valueText.Location = new Point(155, 98);
            valueText.Name = "valueText";
            valueText.Size = new Size(100, 23);
            valueText.TabIndex = 17;
            valueText.Visible = false;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Location = new Point(155, 82);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(33, 15);
            valueLabel.TabIndex = 18;
            valueLabel.Text = "Valor";
            valueLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 450);
            Controls.Add(valueLabel);
            Controls.Add(valueText);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(ipText);
            Controls.Add(searchBtn);
            Controls.Add(viewInScreen);
            Controls.Add(label2);
            Controls.Add(oidText);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)viewInScreen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox oidText;
        private Label label2;
        private DataGridView viewInScreen;
        private Button searchBtn;
        private RadioButton walkRB;
        private RadioButton getRB;
        private TextBox ipText;
        private Label label1;
        private RadioButton setRB;
        private Panel panel1;
        private Panel panel2;
        private RadioButton v3RB;
        private RadioButton v2RB;
        private RadioButton v1RB;
        private TextBox valueText;
        private Label valueLabel;
    }
}
