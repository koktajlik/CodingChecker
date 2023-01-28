namespace CodingChecker
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.checkCodingButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.choosePathButton = new System.Windows.Forms.Button();
            this.pathOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(592, 20);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.Text = "Ścieżka do pliku";
            // 
            // checkCodingButton
            // 
            this.checkCodingButton.Location = new System.Drawing.Point(12, 38);
            this.checkCodingButton.Name = "checkCodingButton";
            this.checkCodingButton.Size = new System.Drawing.Size(146, 45);
            this.checkCodingButton.TabIndex = 2;
            this.checkCodingButton.Text = "Sprawdź kodowanie";
            this.checkCodingButton.UseVisualStyleBackColor = true;
            this.checkCodingButton.Click += new System.EventHandler(this.checkCodingButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resultLabel.Location = new System.Drawing.Point(164, 38);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(631, 45);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "...";
            this.resultLabel.Visible = false;
            // 
            // choosePathButton
            // 
            this.choosePathButton.Location = new System.Drawing.Point(610, 11);
            this.choosePathButton.Name = "choosePathButton";
            this.choosePathButton.Size = new System.Drawing.Size(185, 21);
            this.choosePathButton.TabIndex = 4;
            this.choosePathButton.Text = "Wybierz plik";
            this.choosePathButton.UseVisualStyleBackColor = true;
            this.choosePathButton.Click += new System.EventHandler(this.choosePathButton_Click);
            // 
            // pathOpenFileDialog
            // 
            this.pathOpenFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 102);
            this.Controls.Add(this.choosePathButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.checkCodingButton);
            this.Controls.Add(this.pathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.OpenFileDialog pathOpenFileDialog;

        private System.Windows.Forms.Button checkCodingButton;
        private System.Windows.Forms.Label resultLabel;

        private System.Windows.Forms.TextBox pathTextBox;

        private System.Windows.Forms.Button choosePathButton;

        #endregion
    }
}