﻿using DesktopClient.Pages;
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
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();

            FrameUserInfo.Content = new LoginPage();

            ButtonApllyWorkFolder.Click += ButtonApllyWorkFolder_Click;
        }

        void ButtonApllyWorkFolder_Click(object sender, RoutedEventArgs e)
        {
            ConfigController.WorkFolder = TextBoxWorkFolder.Text;
        }
    }
}
