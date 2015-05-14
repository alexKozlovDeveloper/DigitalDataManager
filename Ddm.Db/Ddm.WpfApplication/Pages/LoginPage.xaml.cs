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

namespace Ddm.WpfApplication.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            var currentUser = ConfigController.CurrentUser;

            if (currentUser == null)
            {
                GridLogout.Visibility = Visibility.Visible;
                GridLogin.Visibility = Visibility.Hidden;
                GridRegistration.Visibility = Visibility.Hidden;
            }
            else
            {
                GridLogin.Visibility = Visibility.Visible;
                LabelLoginText.Content = currentUser.Login;
            }

            ButtonCompleteRegistrate.Click += ButtonCompleteRegistrate_Click;
            ButtonLogout.Click += ButtonLogout_Click;
            ButtonRegistration.Click += ButtonRegistration_Click;
            ButtonLogin.Click += ButtonLogin_Click;
            ButtonSendCode.Click += ButtonSendCode_Click;
        }

        void ButtonSendCode_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            GridLogout.Visibility = Visibility.Hidden;
            GridLogin.Visibility = Visibility.Visible;
        }

        void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            GridLogout.Visibility = Visibility.Hidden;
            GridRegistration.Visibility = Visibility.Visible;
        }

        void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            GridLogin.Visibility = Visibility.Hidden;
            GridLogout.Visibility = Visibility.Visible;
        }

        void ButtonCompleteRegistrate_Click(object sender, RoutedEventArgs e)
        {
            GridRegistration.Visibility = Visibility.Hidden;
            GridLogin.Visibility = Visibility.Visible;
        }
    }
}
