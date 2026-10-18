namespace Laba1_PO
{
    partial class MainForm1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnAddLanguage;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnAddLanguage = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 45);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(560, 100);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Сегодня отличная погода, и я рад этому. Работа идёт хорошо, но есть одна проблема" +
    " с отчётом.";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(12, 155);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(150, 30);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "Анализировать";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnAddLanguage
            // 
            this.btnAddLanguage.Location = new System.Drawing.Point(180, 155);
            this.btnAddLanguage.Name = "btnAddLanguage";
            this.btnAddLanguage.Size = new System.Drawing.Size(200, 30);
            this.btnAddLanguage.TabIndex = 3;
            this.btnAddLanguage.Text = "Добавить LanguageDetector";
            this.btnAddLanguage.Click += new System.EventHandler(this.btnAddLanguage_Click);
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(12, 195);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(560, 199);
            this.lstResults.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Система анализа текста ";
            // 
            // MainForm1
            // 
            this.ClientSize = new System.Drawing.Size(590, 410);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnAddLanguage);
            this.Controls.Add(this.lstResults);
            this.Name = "MainForm1";
            this.Text = "Лабораторная работа №1 ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}