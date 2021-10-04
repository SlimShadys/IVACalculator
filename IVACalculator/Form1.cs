using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IVACalculator
{
    public partial class Form1 : Form
    {
        private double currency;
        private double prezzoArticolo;
        private double prezzoFinale;
        private readonly CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private readonly WebClient wc = new WebClient();
        private static string AUD = "";
        private static string CAD = "";
        private static string GBP = "";
        private static string USD = "";
        private const string EUR = "1.00";
        private const string tokenKey = "OWI0ODJlZTVjNGZiNGE1MWY5N2QzOTVkMjk5MzkzZjE=";
        private string caption = Properties.Resources.ResourceManager.GetString("msgCaption", CultureInfo.CurrentCulture);
        private string title = Properties.Resources.ResourceManager.GetString("insertValue", CultureInfo.CurrentCulture);
        private readonly static string[] currencyList =
        {
            "AUD",
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
            getCurrency();
            foreach (var t in currencyList)
            {
                currencyComboBox.Items.Add(t);
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

            return Math.Round(double.Parse(prezzo) / currency, 2, MidpointRounding.AwayFromZero);
        }

        /*
         * Fetch delle ultime valute tramite l'API di Fixer.io
         */
        private void getCurrency()
        {
            var success = false;
            var data = Convert.FromBase64String(tokenKey);
            dynamic jsonDe = JsonConvert.DeserializeObject(wc.DownloadString(
                "http://data.fixer.io/api/latest?access_key="+ Encoding.UTF8.GetString(data) + "&symbols=USD,AUD,CAD,GBP&format=1"));
            
            if (jsonDe != null)
                success = jsonDe.success;
            
            if (!success)
            {
                speseFinaliText.Text = Properties.Resources.ResourceManager.GetString("ServerDownError", currentCulture);
                return;
            }
            
            USD = jsonDe.rates.USD;
            AUD = jsonDe.rates.AUD;
            CAD = jsonDe.rates.CAD;
            GBP = jsonDe.rates.GBP;
        }
        
        /*
         * Metodo per il recupero del tasso di conversione
         * In base alla valuta scelta, facciamo gli opportuni check
         */
        private string getCurrency(String webCurrency)
        {
            switch (webCurrency)
            {
                case "AUD":
                    return AUD.Replace(".", ",");
                case "CAD":
                    return CAD.Replace(".", ",");
                case "EUR":
                    return EUR.Replace(".", ",");
                case "GBP":
                    return GBP.Replace(".", ",");
                case "USD":
                    return USD.Replace(".", ",");
                default:
                    System.Windows.MessageBox.Show(title, caption, MessageBoxButton.OK);
                    return "0,00";
            }
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
