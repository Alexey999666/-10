using System;
using System.Collections.Generic;
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

namespace практос_10
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Вводим переменную для динамического массива создающегося по средствам обобщенной коллекции List<>
        /// </summary>
        private List<int> numbers;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// подсчитываем количество 5 и -5 в массиве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputArray = tbArrayManually.Text;
                numbers = inputArray.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(num => int.Parse(num.Trim()))
                    .ToList();
                if (numbers.All(num => num >= -10 && num <= 10))
                {
                    int countFive = numbers.Count(n => n == 5);
                    int countMinusFive = numbers.Count(n => n == -5);

                    /// Обновляем текстовые блоки с результатами
                    tblCountFive.Text = countFive.ToString();
                    tblCountMinusFive.Text = countMinusFive.ToString();

                    /// Обновляем текстовый блок с массивом
                    tblArrayAuto.Text = string.Join(", ", numbers);
                }
                else
                {
                    MessageBox.Show("Значения должны быть в интервале от -10 до 10","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(tbArrayManually.Text))
            {
                Random random = new Random();
                numbers = new List<int>();/// Создаем пустой динамический массив

                for (int i = 0; i < 100; i++) /// например, 100 случайных чисел
                {
                    numbers.Add(random.Next(-10, 11)); /// заполняем массив значениями
                }

                /// Подсчитываем количество значений 5 и -5
                int countFive = numbers.Count(n => n == 5);
                int countMinusFive = numbers.Count(n => n == -5);

                /// Обновляем текстовые блоки с результатами
                tblCountFive.Text = countFive.ToString();
                tblCountMinusFive.Text = countMinusFive.ToString();

                /// Обновляем текстовый блок с массивом
                tblArrayAuto.Text = string.Join(", ", numbers);
            }
           
        }

        
        /// <summary>
        /// Закрываем приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
        /// <summary>
        /// Информация о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дан массив в диапазоне [-10;10] найти количество значений равных 5 и -5. ", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Информация о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show("Андрианов Алексей Вариант 14", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Очищает TextBlock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tblArrayAuto.Text = "";
            tblCountFive.Text = "";
            tblCountMinusFive.Text = "";
            tbArrayManually.Clear();
        }
    }
}
