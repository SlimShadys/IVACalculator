using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace IVACalculator
{
    public partial class Form1 : Form
    {

        public static System.Net.WebClient wc = new System.Net.WebClient();
        public static byte[] raw;
        private string title = "Inserire una valuta!";
        private string caption = "ATTENZIONE";
        private double prezzoArticolo;
        private double prezzoFinale;
        private double currency;

        public Form1()
        {
            InitializeComponent();
            this.currencyComboBox.Items.Add("USD");
            this.currencyComboBox.Items.Add("EUR");
            this.currencyComboBox.Items.Add("CAD");
            Aggiorna();
        }

        private void Aggiorna()
        {
            prezzoTextBox.BackColor = Color.White;
            if (prezzoTextBox.Text == "0" || prezzoTextBox.Text == "")
            {
                speseFinaliText.Text = "Inserisci un prezzo!";
                updateTextPosition();
                return;
            }
            try
            {
                prezzoArticolo = convert(prezzoTextBox.Text);

                if (prezzoArticolo == 0.00)
                    return;

                prezzoFinale = Math.Round(prezzoArticolo + (prezzoArticolo * 22 / 100) + 2.00 - prezzoArticolo, 2, MidpointRounding.AwayFromZero);
                speseFinaliText.Text = "€ " + prezzoFinale.ToString();
            }
            catch { }

            updateTextPosition();
        }

        public double convert(String prezzo)
        {
            currency = Math.Round(Double.Parse(getCurrency(this.currencyComboBox.Text.ToString())), 2, MidpointRounding.AwayFromZero);

            if (currency == 0.00)
                return 0.00;

            if (prezzo.Contains("."))
                prezzo = prezzo.Replace(".", ",");

            return double.Parse(prezzo) / currency;
        }

        private string getCurrency(String currency)
        {
            switch (currency)
            {
                case "USD":
                    raw = wc.DownloadData("https://free.currencyconverterapi.com/api/v6/convert?apiKey=57313b824a42f841f02c&q=EUR_USD&compact=y");
                    break;
                case "CAD":
                    raw = wc.DownloadData("https://free.currencyconverterapi.com/api/v6/convert?apiKey=57313b824a42f841f02c&q=EUR_CAD&compact=y");
                    break;
                case "EUR":
                    return "1,00";
                default:
                    MessageBoxResult result = System.Windows.MessageBox.Show(title, caption, MessageBoxButton.OK);
                    return "0,00";
            }
            return System.Text.Encoding.UTF8.GetString(raw).Substring(18, 7).Replace(".", ",");
        }

        private void updateTextPosition()
        {
            speseFinaliText.Left = (this.Width - speseFinaliText.Size.Width) / 2;
        }

        private void calcolaButton_Click(object sender, EventArgs e)
        {
            Aggiorna();
        }

        private void prezzoTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Aggiorna();
            }
        }

        private void articoloText_Click(object sender, EventArgs e)
        {
            prezzoTextBox.Text = "dolito :P";
            prezzoTextBox.BackColor = Color.Red;
        }
    }
}
