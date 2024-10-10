using System.ComponentModel.DataAnnotations.Schema;

namespace Theme_34_6_Practice
{
    [Table("Students_data")]
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    MessageBox.Show("Возраст должен быть положительным");
                }
                else
                {
                    _age = value;
                }
               
            }
        }
        public Student()
        {
        }
        public Student(string? firstName, string? lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public string Display()
        {
            string line = $"{FirstName} {LastName} {Age}";
            return line;
        }
    }
}
