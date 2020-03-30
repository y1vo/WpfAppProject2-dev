using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppProject2
{
    /// <summary>
    /// Логика взаимодействия для WindowT1.xaml
    /// </summary>
    public partial class WindowT1 : Window
    {
        public Person person = new Person();
        private string template = "1";
        private string pictureFilePath;

        public WindowT1()
        {
            InitializeComponent();

            if (File.Exists(person.FilePath)) { ReceiveData(); }
            else { return; }
        }

        private void SendData()
        {
            person.Template = template;
            person.PictureFilePath = pictureFilePath;
            person.FullName = this.fullname.Text;
            person.Birthday = this.birthday.Text;
            person.Address = this.address.Text;
            person.Phone = this.phone.Text;
            person.Mail = this.mail.Text;
            person.Aim = this.aim.Text;
            person.Experience = this.experience.Text;
        }

        private void ReceiveData()
        {
            person.ReceiveDataFromLog();

            if (!string.IsNullOrWhiteSpace(person.PersonalData[0]))
            {
                pictureFilePath = person.PersonalData[0];
                img1.Source = new BitmapImage(new Uri(pictureFilePath));
            }
            if (!string.IsNullOrEmpty(person.PersonalData[1])) fullname.Text = person.PersonalData[1];
            if (!string.IsNullOrEmpty(person.PersonalData[2])) this.birthday.Text = person.PersonalData[2];
            if (!string.IsNullOrEmpty(person.PersonalData[3])) this.address.Text = person.PersonalData[3];
            if (!string.IsNullOrEmpty(person.PersonalData[4])) this.phone.Text = person.PersonalData[4];
            if (!string.IsNullOrEmpty(person.PersonalData[5])) this.mail.Text = person.PersonalData[5];
            if (!string.IsNullOrEmpty(person.PersonalData[6])) this.aim.Text = person.PersonalData[6];
            if (!string.IsNullOrEmpty(person.PersonalData[7])) this.experience.Text = person.PersonalData[7];
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Хотите сохранить свой результат?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (boxResult == MessageBoxResult.Yes)
            {
                SendData();
                person.SaveDataToLog();
            }
            this.Close();
            Environment.Exit(0);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(person.FilePath);
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            SendData();
            person.SaveDataToLog();
            WindowSaveInFormat window = new WindowSaveInFormat();
            window.Owner = this;
            window.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void BtnAddPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.BMP; *.JPG; *.PNG; *.JPEG)|*.BMP; *.JPG; *.PNG; *.JPEG)| All files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                pictureFilePath = openFile.FileName;
                img1.Source = new BitmapImage(new Uri(pictureFilePath));
            }
        }
    }
}