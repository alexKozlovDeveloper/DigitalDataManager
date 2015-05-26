using DbController.TableEntityes;
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
using System.Windows.Shapes;

namespace DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for AddNewTag.xaml
    /// </summary>
    public partial class AddNewTag : Window
    {
        private MainWindow _window;
        private DdmFileManager.ServiceReference1.ServiceClient _service;
        private User _user;

        public AddNewTag(MainWindow window, DdmFileManager.ServiceReference1.ServiceClient service, User user)
        {
            InitializeComponent();

            _window = window;
            _service = service;
            _user = user;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _service.AddTag(_user.Id, TextBoxName.Text);
            _window.InitTagsDropdownList();
            this.Hide();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
