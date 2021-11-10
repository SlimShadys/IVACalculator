
namespace IVACalculator
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.prezzoTextBox = new System.Windows.Forms.TextBox();
            this.articoloText = new System.Windows.Forms.Label();
            this.speseText = new System.Windows.Forms.Label();
            this.speseFinaliText = new System.Windows.Forms.Label();
            this.calcolaButton = new System.Windows.Forms.Button();
            this.versionText = new System.Windows.Forms.Label();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.valutaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // prezzoTextBox
            // 
            this.prezzoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.prezzoTextBox.Location = new System.Drawing.Point(89, 18);
            this.prezzoTextBox.Name = "prezzoTextBox";
            this.prezzoTextBox.Size = new System.Drawing.Size(165, 20);
            this.prezzoTextBox.TabIndex = 0;
            this.prezzoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prezzoTextBoxKeyPress);
            this.prezzoTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.previewKeyDownPrezzoTextBox);
            // 
            // articoloText
            // 
            this.articoloText.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.articoloText.AutoSize = true;
            this.articoloText.Location = new System.Drawing.Point(3, 21);
            this.articoloText.Name = "articoloText";
            this.articoloText.Size = new System.Drawing.Size(80, 13);
            this.articoloText.TabIndex = 1;
            this.articoloText.Text = "Prezzo Articolo:";
            this.articoloText.Click += new System.EventHandler(this.articoloText_Click);
            // 
            // speseText
            // 
            this.speseText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speseText.AutoSize = true;
            this.speseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.speseText.Location = new System.Drawing.Point(0, 8);
            this.speseText.Name = "speseText";
            this.speseText.Size = new System.Drawing.Size(83, 13);
            this.speseText.TabIndex = 2;
            this.speseText.Text = "Spese doganali:";
            // 
            // speseFinaliText
            // 
            this.speseFinaliText.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speseFinaliText.AutoSize = true;
            this.speseFinaliText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.speseFinaliText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.speseFinaliText.Location = new System.Drawing.Point(85, 8);
            this.speseFinaliText.Name = "speseFinaliText";
            this.speseFinaliText.Size = new System.Drawing.Size(22, 13);
            this.speseFinaliText.TabIndex = 3;
            this.speseFinaliText.Text = "0,0";
            this.speseFinaliText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calcolaButton
            // 
            this.calcolaButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcolaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.calcolaButton.Location = new System.Drawing.Point(291, 140);
            this.calcolaButton.Name = "calcolaButton";
            this.calcolaButton.Size = new System.Drawing.Size(98, 23);
            this.calcolaButton.TabIndex = 4;
            this.calcolaButton.Text = "Calcola";
            this.calcolaButton.UseVisualStyleBackColor = true;
            this.calcolaButton.Click += new System.EventHandler(this.calcolaButton_Click);
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.versionText.Location = new System.Drawing.Point(11, 150);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(97, 13);
            this.versionText.TabIndex = 5;
            this.versionText.Text = "SlimShadys, v1.2.1";
            this.versionText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(89, 44);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(47, 21);
            this.currencyComboBox.TabIndex = 6;
            this.currencyComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChangedCurrencyCB);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.valutaLabel);
            this.panel1.Controls.Add(this.articoloText);
            this.panel1.Controls.Add(this.prezzoTextBox);
            this.panel1.Controls.Add(this.currencyComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 82);
            this.panel1.TabIndex = 7;
            // 
            // valutaLabel
            // 
            this.valutaLabel.Location = new System.Drawing.Point(3, 47);
            this.valutaLabel.Name = "valutaLabel";
            this.valutaLabel.Size = new System.Drawing.Size(76, 18);
            this.valutaLabel.TabIndex = 7;
            this.valutaLabel.Text = "Valuta:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Informazioni";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.speseText);
            this.panel2.Controls.Add(this.speseFinaliText);
            this.panel2.Location = new System.Drawing.Point(12, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 30);
            this.panel2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(401, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.calcolaButton);
            this.Controls.Add(this.versionText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IVACalculator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Label valutaLabel;

        private System.Windows.Forms.Panel panel1;

        #endregion

        private System.Windows.Forms.TextBox prezzoTextBox;
        private System.Windows.Forms.Label articoloText;
        private System.Windows.Forms.Label speseText;
        private System.Windows.Forms.Label speseFinaliText;
        private System.Windows.Forms.Button calcolaButton;
        private System.Windows.Forms.Label versionText;
        private System.Windows.Forms.ComboBox currencyComboBox;
    }
}

