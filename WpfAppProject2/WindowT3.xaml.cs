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
using System.Windows.Shapes;

namespace WpfAppProject2
{
    /// <summary>
    /// Логика взаимодействия для WindowT3.xaml
    /// </summary>
    public partial class WindowT3 : Window
    {
        public Person person = new Person();
        private string template = "3";
        private string pictureFilePath;
        public WindowT3()
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
            person.Position = this.position.Text;
            person.Address = this.address.Text;
            person.Age = this.age.Text;
            person.Experience = this.experience.Text;
            person.Education = this.education.Text;
            person.Course = this.course.Text;
            person.Phone = this.phone.Text;
            person.Mail = this.mail.Text;
            person.Language = this.language.Text;
            person.Skill = this.skill.Text;
            person.AboutMe = this.aboutMe.Text;
        }

        private void ReceiveData()
        {
            person.ReceiveDataFromLog();

            if (!string.IsNullOrWhiteSpace(person.PersonalData[0]))
            {
                pictureFilePath = person.PersonalData[0];
                img1.Source = new BitmapImage(new Uri(pictureFilePath));
            }
            if (!string.IsNullOrEmpty(person.PersonalData[1])) this.fullname.Text = person.PersonalData[1];
            if (!string.IsNullOrEmpty(person.PersonalData[3])) this.address.Text = person.PersonalData[3];
            if (!string.IsNullOrEmpty(person.PersonalData[4])) this.phone.Text = person.PersonalData[4];
            if (!string.IsNullOrEmpty(person.PersonalData[5])) this.mail.Text = person.PersonalData[5];
            if (!string.IsNullOrEmpty(person.PersonalData[7])) this.experience.Text = person.PersonalData[7];
            if (!string.IsNullOrEmpty(person.PersonalData[8])) this.age.Text = person.PersonalData[8];
            if (!string.IsNullOrEmpty(person.PersonalData[9])) this.aboutMe.Text = person.PersonalData[9];
            if (!string.IsNullOrEmpty(person.PersonalData[14])) this.education.Text = person.PersonalData[14];
            if (!string.IsNullOrEmpty(person.PersonalData[15])) this.language.Text = person.PersonalData[15];
            if (!string.IsNullOrEmpty(person.PersonalData[19])) this.skill.Text = person.PersonalData[19];
            if (!string.IsNullOrEmpty(person.PersonalData[20])) this.position.Text = person.PersonalData[20];
            if (!string.IsNullOrEmpty(person.PersonalData[21])) this.course.Text = person.PersonalData[21];
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
