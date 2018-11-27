using System;
using System.Collections.Generic;
using System.Linq;
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

namespace IDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected XmlDocument doc = new XmlDocument();
        protected string FilePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string FilePath = @"C:\Users\sddrozd\source\repos\IDE";
                doc.InnerText = "Kappa ";
                doc.Save(FilePath);
                FilePath = $@"C:\Users\sddrozd\source\repos\IDE\{doc.Name}";
            }
            catch(Exception ex)
            {
               MessageBox.Show($"{ex.ToString()}");
            }
        }   

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.LoadXml(System.IO.File.ReadAllText(FilePath));
                XmlElement root = doc.DocumentElement;
                XmlElement Param = doc.CreateElement("PrimaryCalendarPeriods");
                Param.SetAttribute("ID", "ЗначениеID");
                root.AppendChild(Param);
                doc.Save(FilePath);
                XmlNode Node = doc.GetElementById("ЗначениеID");
                Param = doc.CreateElement("ResourceName");
                // добавляем что надо
                Node.AppendChild(Param);
                doc.Save(FilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.ToString()}");
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
