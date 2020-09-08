using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace KurzyCNB
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string kurzy;
            using (var wc = new System.Net.WebClient())
            kurzy = wc.DownloadString("https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.xml");


            using (XmlReader reader = XmlReader.Create(new StringReader(kurzy)))
            {
                while (reader.Read())
                {
                    if (reader.Name == "radek")
                    {
                        if (reader.GetAttribute("kod") == "USD")
                        {
                            textblok.Text = String.Format("Kurz USD dolaru: {0}", reader.GetAttribute("kurz"));
                        }
                    }
                }
            }
        }
    }
}
