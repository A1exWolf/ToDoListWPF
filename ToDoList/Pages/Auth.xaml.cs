using Microsoft.EntityFrameworkCore;
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
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            LoginFunc();
        }

        public User LoginFunc()
        {
            using (var context = new ToDoListContext())
            {
                context.Database.EnsureCreated();

                var user = context.Users.SingleOrDefault(x => x.Username == Login.Text.Trim());

                // Проверяем, существует ли пользователь
                if (user == null)
                    return null;

                // Проверяем пароль
                if (!PasswordHasher.VerifyPasswordHash(Password.Password.Trim(), user.PasswordHash, user.Salt))
                    return null;
                MessageBox.Show("Аутентификация успешна");
                // Аутентификация успешна
                return user;
            }
        }
    }
}
