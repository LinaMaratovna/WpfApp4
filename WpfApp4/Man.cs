using System;
namespace ManApp.Models
{
    public class Man
    {
        private string _name;
        private int _age;
        private string _gender;
        private double _weight;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым.");
                _name = value;
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Возраст должен быть в диапазоне 0..150.");
                _age = value;
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Пол не может быть пустым.");
                _gender = value;
            }
        }
        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Вес должен быть больше нуля.");
                _weight = value;
            }
        }
        public Man()
        {
            _name = "Неизвестно";
            _age = 0;
            _gender = "Не указан";
            _weight = 1;
        }
        public Man(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }
        public void SetParams(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }
        public void SetParams(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void SetParams(string name)
        {
            Name = name;
        }
        public void SetParams(int age, double weight)
        {
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Пол: {Gender}, Вес: {Weight} кг";
        }
    }
}