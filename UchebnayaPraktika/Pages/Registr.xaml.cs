﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using UchebnayaPraktika.Components;

namespace UchebnayaPraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void AuthBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            string surname = SurnameTb.Text.Trim();
            string name = NameTb.Text.Trim();
            string patronymic = PatronymicTb.Text.Trim();
            if (login.Length > 0 && (password.Length >= 6 && PasswordTb.Password.Any(char.IsUpper) && PasswordTb.Password.Any(char.IsNumber) && (PasswordTb.Password.Contains('!') || PasswordTb.Password.Contains('@') || PasswordTb.Password.Contains('#') || PasswordTb.Password.Contains('%'))))
            {
                try
                {
                    User user = new User()
                    {
                        Login = login,
                        Password = password,
                        RoleId = 1,
                        Surname = surname,
                        Name = name,
                        Patronymic = patronymic
                    };
                    DbConnect.db.User.Add(user);
                    DbConnect.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CleanBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";
            PasswordTb.Password = "";
        }
    }
}
