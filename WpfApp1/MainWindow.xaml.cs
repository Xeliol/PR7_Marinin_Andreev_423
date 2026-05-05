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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void xor_button_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text.Length == 0 ||
                key.Text.Length == 0)
            {
                MessageBox.Show("Не введён текст или ключ");
                return;
            }
            try
            {
                output.Text = XOR.XorEncrypt(input.Text, key.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка шифрования");
            }
        }

        private void unxor_button_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text.Length == 0 ||
                key.Text.Length == 0)
            {
                MessageBox.Show("Не введён текст или ключ");
                return;
            }
            try
            {
                output.Text = XOR.XorDecrypt(input.Text, key.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка расшифрования");
            }
        }

        private void xor_button_bin_Click(object sender, RoutedEventArgs e)
        {
            if (input_bin.Text.Length == 0 ||
                key_bin.Text.Length == 0)
            {
                MessageBox.Show("Не введён текст или ключ");
                return;
            }

            try
            {
                byte[] data = Convert.FromBase64String(input_bin.Text);
                byte[] key = Encoding.UTF8.GetBytes(key_bin.Text);

                byte[] encrypted = XOR.XorEncrypt(data, key);
                output_bin.Text = Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка шифрования");
            }
        }

        private void unxor_button_bin_Click(object sender, RoutedEventArgs e)
        {
            if (input_bin.Text.Length == 0 ||
                key_bin.Text.Length == 0)
            {
                MessageBox.Show("Не введён текст или ключ");
                return;
            }

            try
            {
                byte[] data = Convert.FromBase64String(input_bin.Text);
                byte[] key = Encoding.UTF8.GetBytes(key_bin.Text);

                byte[] encrypted = XOR.XorEncrypt(data, key);
                output_bin.Text = Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка шифрования");
            }
        }
    }
}
