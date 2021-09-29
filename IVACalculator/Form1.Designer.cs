
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
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
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
            this.SuspendLayout();
            // 
            // prezzoTextBox
            // 
            this.prezzoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prezzoTextBox.Location = new System.Drawing.Point(98, 44);
            this.prezzoTextBox.Name = "prezzoTextBox";
            this.prezzoTextBox.Size = new System.Drawing.Size(57, 20);
            this.prezzoTextBox.TabIndex = 0;
            this.prezzoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prezzoTextBoxKeyPress);
            // 
            // articoloText
            // 
            this.articoloText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.articoloText.AutoSize = true;
            this.articoloText.Location = new System.Drawing.Point(110, 18);
            this.articoloText.Name = "articoloText";
            this.articoloText.Size = new System.Drawing.Size(77, 13);
            this.articoloText.TabIndex = 1;
            this.articoloText.Text = "Prezzo Articolo";
            this.articoloText.Click += new System.EventHandler(this.articoloText_Click);
            // 
            // speseText
            // 
            this.speseText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speseText.AutoSize = true;
            this.speseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speseText.Location = new System.Drawing.Point(104, 133);
            this.speseText.Name = "speseText";
            this.speseText.Size = new System.Drawing.Size(83, 13);
            this.speseText.TabIndex = 2;
            this.speseText.Text = "Spese doganali:";
            // 
            // speseFinaliText
            // 
            this.speseFinaliText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speseFinaliText.AutoSize = true;
            this.speseFinaliText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speseFinaliText.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.speseFinaliText.Location = new System.Drawing.Point(133, 155);
            this.speseFinaliText.Name = "speseFinaliText";
            this.speseFinaliText.Size = new System.Drawing.Size(22, 13);
            this.speseFinaliText.TabIndex = 3;
            this.speseFinaliText.Text = "0,0";
            this.speseFinaliText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calcolaButton
            // 
            this.calcolaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcolaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcolaButton.Location = new System.Drawing.Point(98, 86);
            this.calcolaButton.Name = "calcolaButton";
            this.calcolaButton.Size = new System.Drawing.Size(101, 23);
            this.calcolaButton.TabIndex = 4;
            this.calcolaButton.Text = "Calcola";
            this.calcolaButton.UseVisualStyleBackColor = true;
            this.calcolaButton.Click += new System.EventHandler(this.calcolaButton_Click);
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionText.Location = new System.Drawing.Point(254, 196);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(28, 13);
            this.versionText.TabIndex = 5;
            this.versionText.Text = "v0.2";
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(161, 43);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(47, 21);
            this.currencyComboBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 218);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.calcolaButton);
            this.Controls.Add(this.speseFinaliText);
            this.Controls.Add(this.speseText);
            this.Controls.Add(this.articoloText);
            this.Controls.Add(this.prezzoTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "IVACalculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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

