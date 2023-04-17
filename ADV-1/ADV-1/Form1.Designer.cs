namespace ADV_1
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
            InputBox = new TextBox();
            outputBox = new ListBox();
            doButton = new Button();
            SuspendLayout();
            // 
            // InputBox
            // 
            InputBox.Location = new Point(316, 93);
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(186, 23);
            InputBox.TabIndex = 0;
            InputBox.TextChanged += InputBox_TextChanged;
            // 
            // outputBox
            // 
            outputBox.FormattingEnabled = true;
            outputBox.ItemHeight = 15;
            outputBox.Location = new Point(316, 122);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(186, 169);
            outputBox.TabIndex = 11;
            // 
            // doButton
            // 
            doButton.Location = new Point(508, 92);
            doButton.Name = "doButton";
            doButton.Size = new Size(75, 23);
            doButton.TabIndex = 12;
            doButton.Text = "Do";
            doButton.UseVisualStyleBackColor = true;
            doButton.Click += doButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(doButton);
            Controls.Add(outputBox);
            Controls.Add(InputBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputBox;
        private TextBox outputBox0;
        private TextBox outputBox1;
        private TextBox outputBox2;
        private TextBox outputBox3;
        private TextBox outputBox4;
        private TextBox outputBox5;
        private TextBox outputBox6;
        private TextBox outputBox7;
        private TextBox outputBox8;
        private TextBox outputBox9;
        private ListBox outputBox;
        private Button doButton;
    }
}