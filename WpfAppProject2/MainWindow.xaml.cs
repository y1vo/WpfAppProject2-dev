using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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

namespace WpfAppProject2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person person = new Person();
        private WindowT1 windowT1 = new WindowT1();
        private WindowT2 windowT2 = new WindowT2();
        private WindowT3 windowT3 = new WindowT3();
        private WindowT4 windowT4 = new WindowT4();
        private WindowT5 windowT5 = new WindowT5();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(person.FilePath))
            {
                ReceiveData();
            }

            else { return; }
        }

        private void ReceiveData()
        {
            string log = File.ReadAllText(person.FilePath);

            if (log.StartsWith("1")) { windowT1.Show(); }
            else if (log.StartsWith("2")) { windowT2.Show(); }
            else if (log.StartsWith("3")) { windowT3.Show(); }
            else if (log.StartsWith("4")) { windowT4.Show(); }
            else if (log.StartsWith("5")) { windowT5.Show(); }

            this.Visibility = Visibility.Hidden;
        }

        private void BtnT1_Click(object sender, RoutedEventArgs e)
        {
            windowT1.Owner = this;
            windowT1.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnT2_Click(object sender, RoutedEventArgs e)
        {
            windowT2.Owner = this;
            windowT2.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnT3_Click(object sender, RoutedEventArgs e)
        {
            windowT3.Owner = this;
            windowT3.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnT4_Click(object sender, RoutedEventArgs e)
        {
            windowT4.Owner = this;
            windowT4.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnT5_Click(object sender, RoutedEventArgs e)
        {
            windowT5.Owner = this;
            windowT5.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            if (File.Exists(person.FilePath))
            {
                File.Delete(person.FilePath);
            }

            Environment.Exit(0);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            //здесь будет открываться последнее окно
            /*
            Window1 window = new Window1();
            window.Show();
            */
        }
    }
}