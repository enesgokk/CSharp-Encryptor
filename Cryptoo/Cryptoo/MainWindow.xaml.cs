using System;
using System.IO;
using System.Windows;
namespace Cryptoo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            //Loaded += MainWindow_Loaded;
        }

        /* private void MainWindow_Loaded(object sender, RoutedEventArgs e)
         {
             Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
             Nullable<bool> result = openFileDlg.ShowDialog();

             if (result!=null)
             {
                 string metin = openFileDlg.FileName;

                 string[] parca = metin.Split('\\');

                 textOku.Text =parca[parca.Length-1]+" => "+System.IO
                                                                  .File
                                                                  .ReadAllText(openFileDlg.FileName);

                 return;

             }*/




        private string sifrele(string icerik)
        {
            string sifrelenmisi = "";
            foreach (char harf in icerik)
            {
                sifrelenmisi += Convert.ToChar(harf + 2);
            }
            return sifrelenmisi;
        }


        private string sifreCoz(string sifreliIcerik)
        {
            string cozulmusIcerik = "";
            foreach (char harf in sifreliIcerik)
            {
                cozulmusIcerik += Convert.ToChar(harf - 2);
            }
            return cozulmusIcerik;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = saveFileDialog.ShowDialog();

            saveFileDialog.Filter = "Metin Dosyası (*.txt)|*.txt";
            //saveFileDialog.ShowDialog();
            string yol = saveFileDialog.FileName;
            if (yol == "")
            {
                saveFileDialog.Reset();
            }
            else
            {
                File.CreateText(yol).Close();
                string icerik = textbox1.Text;
                string yeniIcerik = sifrele(icerik);
                File.WriteAllText(yol, yeniIcerik);
                MessageBox.Show("Kayıt İşlemi Gerçekleştirildi");
                textbox1.Clear();
            }
            
           

        }


        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.ShowDialog();

            string yol = openFileDialog.FileName;
            if (yol == "")
            {

                openFileDialog.Reset();
            }
            else
            {
                string sifreliIcerik = File.ReadAllText(yol);
                string yeniIcerik = sifreCoz(sifreliIcerik);
                textbox1.Text = yeniIcerik;
            }
        }
    }
    }

