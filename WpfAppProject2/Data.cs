using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppProject2
{
    public abstract class Data
    {
        private List<string> personalData = new List<string>();
        private string filePath = Path.Combine(Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "log")).FullName, "log.txt");
        private string template;
        private string fullName;
        private string address;
        private string mail;
        private string phone;
        private string aim;
        private string experience;
        private string activity;
        private string achievement;
        private string biography;
        private string education;
        private string recommendation;
        private string age;
        private string language;
        private string skill;
        private string aboutMe;
        private string salary;
        private string birthday;
        private string citizenship;
        private string relocation;
        private string pictureFilePath;
        private string position;
        private string course;
        
        public List<string> PersonalData { get => personalData; set => personalData = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string Template { get => template; set => template = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Aim { get => aim; set => aim = value; }
        public string Experience { get => experience; set => experience = value; }
        public string Activity { get => activity; set => activity = value; }
        public string Achievement { get => achievement; set => achievement = value; }
        public string Biography { get => biography; set => biography = value; }
        public string Education { get => education; set => education = value; }
        public string Recommendation { get => recommendation; set => recommendation = value; }
        public string Age { get => age; set => age = value; }
        public string Language { get => language; set => language = value; }
        public string Skill { get => skill; set => skill = value; }
        public string AboutMe { get => aboutMe; set => aboutMe = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string Relocation { get => relocation; set => relocation = value; }
        public string PictureFilePath { get => pictureFilePath; set => pictureFilePath = value; }
        public string Position { get => position; set => position = value; }
        public string Course { get => course; set => course = value; }
    }
}