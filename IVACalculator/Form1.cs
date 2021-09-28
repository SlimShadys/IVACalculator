using System;
using System.Drawing;
using System.Windows.Forms;

namespace IVACalculator
{
    public partial class Form1 : Form
    {

        public static System.Net.WebClient wc = new System.Net.WebClient();
        public static byte[] raw;

        public Form1()
        {
            InitializeComponent();
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
                double prezzoArticolo = convert(prezzoTextBox.Text);
                double prezzoFinale = Math.Round((prezzoArticolo + ((prezzoArticolo * 22) / 100) + 2.00) - prezzoArticolo, 2, MidpointRounding.AwayFromZero);
                speseFinaliText.Text = "€ " + prezzoFinale.ToString();
            }
            catch { }

            updateTextPosition();
        }

        public static double convert(String prezzo)
        {
            if (prezzo.Contains("."))
            {
                prezzo = prezzo.Replace(".", ",");
            }
            return (double.Parse(prezzo) / Double.Parse(getCurrency()));
        }

        private static string getCurrency()
        {
            raw = wc.DownloadData("https://free.currencyconverterapi.com/api/v6/convert?apiKey=57313b824a42f841f02c&q=EUR_USD&compact=y");
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
