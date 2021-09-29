using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace IVACalculator
{
    public partial class Form1 : Form
    {

        private readonly System.Net.WebClient wc = new System.Net.WebClient();
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private static byte[] raw;
        private string title = Properties.Resources.ResourceManager.GetString("insertValue", CultureInfo.CurrentCulture);
        private string caption = Properties.Resources.ResourceManager.GetString("msgCaption", CultureInfo.CurrentCulture);
        private double prezzoArticolo;
        private double prezzoFinale;
        private double currency;
        private static String[] currencyList =
        {
            "CAD",
            "EUR",
            "GBP",
            "USD"
        };
        
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < currencyList.Length; i++)
            {
                currencyComboBox.Items.Add(currencyList[i]);
            }
            Aggiorna();
        }

        private void Aggiorna()
        {
            prezzoTextBox.BackColor = Color.White;
            if (isNotValid(prezzoTextBox.Text))
            {
                speseFinaliText.Text = Properties.Resources.ResourceManager.GetString("insertPrice", currentCulture);
                return;
            }
            try
            {
                prezzoArticolo = convert(prezzoTextBox.Text);

                if (prezzoArticolo == 0.00)
                    return;

                prezzoFinale = Math.Round(prezzoArticolo + (prezzoArticolo * 22 / 100) + 2.00 - prezzoArticolo, 2, MidpointRounding.AwayFromZero);
                speseFinaliText.Text = Properties.Resources.ResourceManager.GetString("euroValue", currentCulture) + prezzoFinale;
            }
            catch { }
            
        }

        private static bool isNotValid(String str)
        {
            return str == "0" || str == "" || Regex.IsMatch(str, ".*?[a-zA-Z].*?");
        }

        private double convert(String prezzo)
        {
            currency = Double.Parse(getCurrency(currencyComboBox.Text));

            if (currency == 0.00)
                return 0.00;

            if (prezzo.Contains("."))
                prezzo = prezzo.Replace(".", ",");

            return double.Parse(prezzo) / Math.Round(currency, 2, MidpointRounding.AwayFromZero);
        }

        private string getCurrency(String webCurrency)
        {
            switch (webCurrency)
            {
                case "CAD":
                    raw = wc.DownloadData(Properties.Resources.ResourceManager.GetString("EURToCAD", currentCulture) ?? string.Empty);
                    break;
                case "EUR":
                    return "1,00";
                case "GBP":
                    raw = wc.DownloadData(Properties.Resources.ResourceManager.GetString("EURToGBP", currentCulture) ?? string.Empty);
                    break;
                case "USD":
                    raw = wc.DownloadData(Properties.Resources.ResourceManager.GetString("EURToUSD", currentCulture) ?? string.Empty);
                    break;
                default:
                    System.Windows.MessageBox.Show(title, caption, MessageBoxButton.OK);
                    return "0,00";
            }
            return System.Text.Encoding.UTF8.GetString(raw).Substring(18, 7).Replace(".", ",");
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
            prezzoTextBox.Text = Properties.Resources.ResourceManager.GetString("easter", currentCulture);
            prezzoTextBox.BackColor = Color.Red;
        }
    }
}
