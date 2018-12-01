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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace IDE
{

    public partial class MainWindow : Window
    {
        //private string filename;
        //private bool showdialog = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {


           //SaveFileDialog sfd = new SaveFileDialog();
           //sfd.Filter = "Cs(*.cs)| ";
           //if (sfd.ShowDialog() == true)
           //{
           //    TextRange doc = new TextRange(Rtb.Document.ContentStart, Rtb.Document.ContentEnd);
           //    using (FileStream fs = File.Create(sfd.FileName))
           //    {
           //         if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".cs")
           //            doc.Save(fs, DataFormats.Text);
           //        else
           //            doc.Save(fs, DataFormats.Xaml);
           //    }
           //}

            //SaveAs();

          SaveFileDialog sfd = new SaveFileDialog
          {
              FileName = "temp",
              Filter = "Txt (*.txt)|*.txt|All files (*.*)|*.*"
              //Filter = "Cs (*.cs)|"
          };
          if (sfd.ShowDialog() == true)
          {
              var textRange = new TextRange(Rtb.Document.ContentStart, Rtb.Document.ContentEnd);
              string Str = textRange.Text;
              StreamWriter writer = new StreamWriter(sfd.FileName);
              writer.Write(Str);
              writer.Close();
          }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Txt (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == true)
            { 
                TextRange doc = new TextRange(Rtb.Document.ContentStart, Rtb.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";
            process.StartInfo.UseShellExecute = !true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = @"/nologo /out:D:\f.exe D:\hi.txt";
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var rez = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            MessageBox.Show(rez);
        }


        //void SaveAs()
        //{
        //    if (showdialog || filename.Length == 0)
        //    {
        //        SaveFileDialog SFD = new SaveFileDialog
        //        {
        //            FileName = "temp",
        //            Filter = "TXT (*.txt)|*.txt|RTF (*.rtf)|*.rtf"
        //        };
        //
        //        if (SFD.ShowDialog() == true)
        //        {
        //            filename = SFD.FileName;
        //            showdialog = false;
        //        }
        //        else
        //            return;
        //    }
        //    Save(filename);
        //}

        //private void Save(string filename)
        //{
        //    StreamWriter SW = new StreamWriter(filename);
        //    SW.Write(Rtb.);
        //    SW.Close();
        //}

        //private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        //{
        //    Window1 second = new Window1
        //    {
        //        Height = 400,
        //        Width = 400,
        //        Owner = this
        //    };
        //    second.Show();
        //    second.VerticalAlignment = VerticalAlignment.Center;
        //}
    }
}