﻿using System;
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
using UchebnayaPraktika.Components;

namespace UchebnayaPraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для log.xaml
    /// </summary>
    public partial class log : Page
    {
        public log()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();

            if (login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Navigation.AuthUser = DbConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (Navigation.AuthUser == null)
                {
                    Navigation.AuthUser = DbConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                    MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
              
            }
        }

        private void RegistrBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Registr());
        }
    }
}
