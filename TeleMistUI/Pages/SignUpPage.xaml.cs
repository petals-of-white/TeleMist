using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeleMistUI.DB;
using TeleMistUI.Models;
using TeleMistUI.Helpers;
using System.IO;

namespace TeleMistUI.Pages
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {

            string role, passwordHash, avatarDir;
            bool res;
            byte [] imageData;
            ByteImageConverter converter;
           
            if (UserID.Text == "")
            {
                Warning.Text = "Ім'я користувача не може бути порожнім";
                //MessageBox.Show("Ім'я користувача не може бути порожнім");
                return;
            }

            if (UserID.Text.Length < 6)
            {
                Warning.Text = "Ім'я користувача мусить містити щонайменше 6 символів";
                return ;
            }


            if (Password.Password == "" || CheckPassword.Password == "")
            {
                Warning.Text = "Пароль не може бути порожнім";
                //MessageBox.Show("Пароль не може бути порожнім");
                return;
            }

            if (Password.Password.Length < 6)
            {
                Warning.Text = "Пароль мусить містити щонайменше 6 символів";
                return;

            }

            if (Password.Password != CheckPassword.Password)
            {
                Warning.Text = "Паролі не збігаються. Будь ласка, перевірте.";
                //MessageBox.Show("Паролі не збігаються. Будь ласка, перевірте.");
                return;
            }


            Database db = (Database) App.Current.TryFindResource("AccessDB");


            if (Doctor.IsChecked == true)
            {
                role = "doctor";
            }
            else
            {
                role = "patient";

            }
            passwordHash = Hasher.MD5Hash(Password.Password);

            converter = new ByteImageConverter();
            avatarDir = Path.GetFullPath(@"..\..\..") + @"\Images\default_avatar.png";

            if (File.Exists(avatarDir))
            {
                imageData = converter.ImageToByte(File.OpenRead(avatarDir));

            }
            else
            {

                MessageBox.Show("Немає такого файлу " + avatarDir);
                return;
            }


            res = db.NonQuery($"INSERT INTO [{role}] ([username], [password], [avatar]) VALUES ('{UserID.Text}', '{passwordHash}', @binary);", binaryParameter: imageData);
            
            if (res)
            {
                MessageBox.Show("Обліковий запис успішно створено");
                NavigationService.GoBack();

            }
                
            else
            {
                Warning.Text = "Неможливо зареєструватися. " +
                    "Найімовірніше, користувач з таким іменем уже існує.";
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }
    }
}
