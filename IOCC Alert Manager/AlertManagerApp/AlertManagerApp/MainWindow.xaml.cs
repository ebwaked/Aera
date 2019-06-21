
using AlertManagerApp.Models;
using AlertManagerApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AlertManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            Top = 0;
            Left = 0;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.WindowStyle = WindowStyle.ThreeDBorderWindow;

        }
    }
}
