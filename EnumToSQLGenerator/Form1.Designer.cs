namespace EnumToSQLGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxAssemblyLocation = new System.Windows.Forms.TextBox();
            this.btnLoadAssembly = new System.Windows.Forms.Button();
            this.checkedListBoxDiscoveredEnums = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxSQL = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUUID = new System.Windows.Forms.RadioButton();
            this.radioButtonInteger = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Assembly";
            // 
            // txtboxAssemblyLocation
            // 
            this.txtboxAssemblyLocation.Location = new System.Drawing.Point(113, 19);
            this.txtboxAssemblyLocation.Name = "txtboxAssemblyLocation";
            this.txtboxAssemblyLocation.Size = new System.Drawing.Size(563, 20);
            this.txtboxAssemblyLocation.TabIndex = 1;
            // 
            // btnLoadAssembly
            // 
            this.btnLoadAssembly.Location = new System.Drawing.Point(694, 17);
            this.btnLoadAssembly.Name = "btnLoadAssembly";
            this.btnLoadAssembly.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAssembly.TabIndex = 2;
            this.btnLoadAssembly.Text = "Browse";
            this.btnLoadAssembly.UseVisualStyleBackColor = true;
            this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
            // 
            // checkedListBoxDiscoveredEnums
            // 
            this.checkedListBoxDiscoveredEnums.FormattingEnabled = true;
            this.checkedListBoxDiscoveredEnums.Location = new System.Drawing.Point(22, 115);
            this.checkedListBoxDiscoveredEnums.Name = "checkedListBoxDiscoveredEnums";
            this.checkedListBoxDiscoveredEnums.Size = new System.Drawing.Size(307, 394);
            this.checkedListBoxDiscoveredEnums.TabIndex = 4;
            this.checkedListBoxDiscoveredEnums.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDiscoveredEnums_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Discovered Enums";
            // 
            // richTextBoxSQL
            // 
            this.richTextBoxSQL.Location = new System.Drawing.Point(349, 110);
            this.richTextBoxSQL.Name = "richTextBoxSQL";
            this.richTextBoxSQL.Size = new System.Drawing.Size(419, 398);
            this.richTextBoxSQL.TabIndex = 6;
            this.richTextBoxSQL.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TSQL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Copy TSQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(694, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save Script";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUUID);
            this.groupBox1.Controls.Add(this.radioButtonInteger);
            this.groupBox1.Location = new System.Drawing.Point(401, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 44);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID Specification Type";
            // 
            // radioButtonUUID
            // 
            this.radioButtonUUID.AutoSize = true;
            this.radioButtonUUID.Location = new System.Drawing.Point(88, 18);
            this.radioButtonUUID.Name = "radioButtonUUID";
            this.radioButtonUUID.Size = new System.Drawing.Size(52, 17);
            this.radioButtonUUID.TabIndex = 1;
            this.radioButtonUUID.TabStop = true;
            this.radioButtonUUID.Text = "UUID";
            this.radioButtonUUID.UseVisualStyleBackColor = true;
            // 
            // radioButtonInteger
            // 
            this.radioButtonInteger.AutoSize = true;
            this.radioButtonInteger.Location = new System.Drawing.Point(7, 18);
            this.radioButtonInteger.Name = "radioButtonInteger";
            this.radioButtonInteger.Size = new System.Drawing.Size(57, 17);
            this.radioButtonInteger.TabIndex = 0;
            this.radioButtonInteger.TabStop = true;
            this.radioButtonInteger.Text = "integer";
            this.radioButtonInteger.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxSQL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxDiscoveredEnums);
            this.Controls.Add(this.btnLoadAssembly);
            this.Controls.Add(this.txtboxAssemblyLocation);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Enum To SQL Genetaor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxAssemblyLocation;
        private System.Windows.Forms.Button btnLoadAssembly;
        private System.Windows.Forms.CheckedListBox checkedListBoxDiscoveredEnums;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxSQL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUUID;
        private System.Windows.Forms.RadioButton radioButtonInteger;
    }
}

