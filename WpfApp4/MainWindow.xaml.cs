using System.Windows;
using System.Windows.Controls;
using System;
using ManApp.Models;
namespace WpfApp4
{
    // Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        private Man _man = new Man();
        public MainWindow()
        {
            InitializeComponent();
        }
        // Считать данные из полей ввода и вернуть человека,
        // либо null при ошибке (с показом сообщения).
        private Man ReadFromForm()
        {
            try
            {
                if (!int.TryParse(txtAge.Text, out int age))
                    throw new FormatException("Некорректный возраст.");
                if (!double.TryParse(txtWeight.Text, out double weight))
                    throw new FormatException("Некорректный вес.");
                string gender = ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString();
                return new Man(txtName.Text, age, gender, weight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
        // Демонстрация перегрузки SetParams(string, int, string, double).
        private void BtnFullSet_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;
            _man.SetParams(m.Name, m.Age, m.Gender, m.Weight);
            lblResult.Text = "SetParams(имя, возраст, пол, вес):\n" + _man;
        }
        // Демонстрация перегрузки SetParams(string, int).
        private void BtnNameAge_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;
            _man.SetParams(m.Name, m.Age);
            lblResult.Text = "SetParams(имя, возраст):\n" + _man;
        }
        // Демонстрация перегрузки SetParams(int, double).
        private void BtnAgeWeight_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;

            _man.SetParams(m.Age, m.Weight);
            lblResult.Text = "SetParams(возраст, вес):\n" + _man;
        }
        // Кнопка "О программе".
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Практическая работа 4. Задание Создать класс Man (человек), с полями: имя, возраст, пол и вес. Создать \r\n" +
                "необходимые методы и свойства. Создать перегруженные методы SetParams, для \r\n" +
                "установки параметров человека. Разработчик: Мухутдинова Алина Маратовна ИСП-31");
        }
        // Кнопка "Выход".
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}