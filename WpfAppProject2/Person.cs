using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppProject2
{
    public class Person : Data
    {
        public void SaveDataToLog()
        {
            FileStream fileStream = new FileStream(base.FilePath, FileMode.OpenOrCreate);

            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(Template);
                streamWriter.WriteLine(base.PictureFilePath);
                streamWriter.WriteLine(" " + base.FullName);
                streamWriter.WriteLine(" " + base.Birthday);
                streamWriter.WriteLine(" " + base.Address);
                streamWriter.WriteLine(" " + base.Phone);
                streamWriter.WriteLine(" " + base.Mail);
                streamWriter.WriteLine(" " + base.Aim);
                streamWriter.WriteLine(" " + base.Experience);
                streamWriter.WriteLine(" " + base.Age);
                streamWriter.WriteLine(" " + base.AboutMe);
                streamWriter.WriteLine(" " + base.Achievement);
                streamWriter.WriteLine(" " + base.Activity);
                streamWriter.WriteLine(" " + base.Biography);
                streamWriter.WriteLine(" " + base.Citizenship);
                streamWriter.WriteLine(" " + base.Education);
                streamWriter.WriteLine(" " + base.Language);
                streamWriter.WriteLine(" " + base.Recommendation);
                streamWriter.WriteLine(" " + base.Relocation);
                streamWriter.WriteLine(" " + base.Salary);
                streamWriter.WriteLine(" " + base.Skill);
                streamWriter.WriteLine(" " + base.Position);
                streamWriter.WriteLine(" " + base.Course);
            }
        }

        public void ReceiveDataFromLog()
        {
            string[] items;
            string[] separator = { "\r\n" };
            FileStream fileStream = new FileStream(base.FilePath, FileMode.OpenOrCreate);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                items = streamReader.ReadToEnd().Split(separator, StringSplitOptions.None);
            }

            for (int i = 1; i < items.Length; i++)
            {
                base.PersonalData.Add(items[i].Trim());
            }
        }
    }
}