using System.Text;
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
using ToDoList.Pages;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuthFrame.Navigate(new Auth());
            UpdateButtonColors(AuthFrame.Content);
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var context = new ToDoListContext())
        //    {
        //        context.Database.EnsureCreated();

        //        // Создание нового пользователя
        //        string passwordHash, salt;
        //        PasswordHasher.CreatePasswordHash("password123", out passwordHash, out salt);

        //        var user = new User
        //        {
        //            Username = "JohnDoe",
        //            Email = "john@example.com",
        //            PasswordHash = passwordHash,
        //            Salt = salt
        //        };
        //        context.Users.Add(user);
        //        context.SaveChanges();

        //        // Создание нового проекта
        //        var project = new Project
        //        {
        //            Name = "My First Project",
        //            Description = "This is a test project",
        //            CreatedDate = DateTime.Now,
        //            Owner = user
        //        };
        //        context.Projects.Add(project);
        //        context.SaveChanges();

        //        // Создание новой задачи
        //        var task = new Models.Task
        //        {
        //            Title = "Learn WPF",
        //            Description = "Study WPF basics",
        //            IsCompleted = false,
        //            CreatedDate = DateTime.Now,
        //            DueDate = DateTime.Now.AddDays(7),
        //            Project = project
        //        };
        //        context.Tasks.Add(task);
        //        context.SaveChanges();
        //    }

        //}

        private void AuthFrame_Navigated(object sender, NavigationEventArgs e)
        {
            UpdateButtonColors(e.Content);
        }

        private void UpdateButtonColors(object content)
        {
            if (content is Auth)
            {
                AuthBtn.Background = Brushes.LimeGreen;
                RegBtn.Background = Brushes.LightGray;
            }
            else if (content is Registration)
            {
                RegBtn.Background = Brushes.LimeGreen;
                AuthBtn.Background = Brushes.LightGray;
            }
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            AuthFrame.Navigate(new Registration());
        }

        private void Button_Click_Auth(object sender, RoutedEventArgs e)
        {
            AuthFrame.Navigate(new Auth());
        }
    }
}