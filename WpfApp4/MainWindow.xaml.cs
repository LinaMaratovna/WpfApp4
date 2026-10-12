using System.Windows;
using System.Windows.Controls;
using System;
using ManApp.Models;
namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Man _man = new Man();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Считать данные из полей ввода и вернуть человека,
        /// либо null при ошибке (с показом сообщения).
        /// </summary>
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
        /// <summary>
        /// Демонстрация перегрузки SetParams(string, int, string, double).
        /// </summary>
        private void BtnFullSet_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;
            _man.SetParams(m.Name, m.Age, m.Gender, m.Weight);
            lblResult.Text = "SetParams(имя, возраст, пол, вес):\n" + _man;
        }
        /// <summary>
        /// Демонстрация перегрузки SetParams(string, int).
        /// </summary>
        private void BtnNameAge_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;
            _man.SetParams(m.Name, m.Age);
            lblResult.Text = "SetParams(имя, возраст):\n" + _man;
        }
        /// <summary>
        /// Демонстрация перегрузки SetParams(int, double).
        /// </summary>
        private void BtnAgeWeight_Click(object sender, RoutedEventArgs e)
        {
            Man m = ReadFromForm();
            if (m == null) return;

            _man.SetParams(m.Age, m.Weight);
            lblResult.Text = "SetParams(возраст, вес):\n" + _man;
        }
        /// <summary>
        /// Кнопка "О программе".
        /// </summary>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Практическая работа 4. Задание Создать класс Man (человек), с полями: имя, возраст, пол и вес. Создать \r\n" +
                "необходимые методы и свойства. Создать перегруженные методы SetParams, для \r\n" +
                "установки параметров человека. Разработчик: Афонин Михаил Денисович ИСП-31");
        }
        /// <summary>
        /// Кнопка "Выход".
        /// </summary>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}