using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace IVACalculator
{
    public partial class Form1 : Form
    {
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private List<string> statusRow = new List<string>();
        private double currency;
        private double prezzoArticolo;
        private double prezzoFinale;
        private readonly HtmlWeb web = new HtmlWeb();
        private readonly WebClient wc = new WebClient();
        private static byte[] raw;
        private string caption = Properties.Resources.ResourceManager.GetString("msgCaption", CultureInfo.CurrentCulture);
        private string title = Properties.Resources.ResourceManager.GetString("insertValue", CultureInfo.CurrentCulture);
        private static String[] currencyList =
        {
            "CAD",
            "EUR",
            "GBP",
            "USD"
        };
        
        /*
         * Inizializzazione del Form.
         */
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < currencyList.Length; i++)
            {
                currencyComboBox.Items.Add(currencyList[i]);
            }
            Aggiorna();
        }

        /*
         * Main method:
         * - Controlla se il prezzo inserito dall'utente è valido.
         * - Converte il prezzo nella valuta selezionata
         * - Esegue i calcoli per ottenere le spese doganali
         */
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
                {
                    return;
                }

                prezzoFinale = Math.Round(prezzoArticolo + (prezzoArticolo * 22 / 100) + 2.00 - prezzoArticolo, 2,
                    MidpointRounding.AwayFromZero);
                speseFinaliText.Text = Properties.Resources.ResourceManager.GetString("euroValue", currentCulture) +
                                       prezzoFinale;
            }
            catch
            {
            }
        }

        /*
         * Controllo input dell'utente
         */
        private static bool isNotValid(String str)
        {
            return str == "0" || str == "" || Regex.IsMatch(str, ".*?[a-zA-Z].*?");
        }

        /*
         * Converti il prezzo indicato nella textBox dell'articolo
         * nella valuta selezionata.
         */
        private double convert(String prezzo)
        {
            currency = Double.Parse(getCurrency(currencyComboBox.Text));

            if (currency == 0.00)
                return 0.00;

            if (prezzo.Contains("."))
                prezzo = prezzo.Replace(".", ",");

            return double.Parse(prezzo) / Math.Round(currency, 2, MidpointRounding.AwayFromZero);
        }

        /*
         * Metodo per il recupero del tasso di conversione
         * In base alla valuta scelta, facciamo gli opportuni check
         */
        private string getCurrency(String webCurrency)
        {
            // Skip recupero dei dati in base allo stato del Server
            // Inoltre skippiamo quando è selezionato "EUR", poichè
            // riusciamo a fare quel calcolo anche senza connessione.
            if (serverIsDown() && webCurrency != "EUR")
            {
                speseFinaliText.Text = Properties.Resources.ResourceManager.GetString("ServerDownError", currentCulture);
                return "";
            }
            
            // Recupera il tasso di conversione
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

        /*
         * Controlla lo stato del Server
         */
        private bool serverIsDown()
        {

            var doc = web.Load("https://www.currencyconverterapi.com/server-status");
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {   
                foreach (HtmlNode row in table.SelectNodes("tbody"))
                {
                    foreach (HtmlNode cell in row.SelectNodes("tr"))
                    {
                        statusRow.Add(cell.InnerText.Trim());
                    }
                }
            }

            return statusRow[1].Contains("DOWN");
        }

        /*
         * Cattura il pulsante "Calcola", avviando il metodo Aggiorna()
         */
        private void calcolaButton_Click(object sender, EventArgs e)
        {
            Aggiorna();
        }

        /*
         * Cattura il pulsante invio sulla TextBox del prezzo,
         * avviando così, il metodo Aggiorna()
         */
        private void prezzoTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            if (currencyComboBox.Text.Equals(""))
                currencyComboBox.Text = "USD";
            Aggiorna();
        }

        /*
         * Easter egg
         */
        private void articoloText_Click(object sender, EventArgs e)
        {
            prezzoTextBox.Text = Properties.Resources.ResourceManager.GetString("easter", currentCulture);
            prezzoTextBox.BackColor = Color.Red;
        }

        /*
         * Cattura il pulsante TAB, avviando il metodo Aggiorna()
         */
        private void previewKeyDownPrezzoTextBox(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.Tab)
            {
                prezzoTextBoxKeyPress(null, new KeyPressEventArgs(Convert.ToChar(Keys.Enter)));
            }
        }
        
        /*
         * Cattura lo stato di cambiamento sulla ComboBox della valuta,
         * avviando così, il metodo Aggiorna()
         */
        private void selectedIndexChangedCurrencyCB(object sender, EventArgs e)
        {
            Aggiorna();
        }
    }
}
