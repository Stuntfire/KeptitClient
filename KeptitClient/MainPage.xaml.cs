﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KeptitClient.View;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KeptitClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Mainframe.Navigate(typeof(Greenkeeper));
        }
       

        private void GreenKeeperButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(Greenkeeper));
        }

        private void AdminSeTimerButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(Admin));
        }

        private void AdminDoneTasksButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(Admindonetasks));
        }

        private void AdminAreasButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(AdminAreas));
        }

        private void AdminAnsatteButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(AdminAnsatte));
        }

        private void AdminwhetherButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(Adminwhether));
        }
        



    }
}
