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

namespace UIWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Messages.Add(new Tuple<string, string>("远方", "你好！"));
            Messages.Add(new Tuple<string, string>("远方", "今天天气真好呀！"));
        }

        public List<Tuple<string, string>> Messages { get; set; } = new List<Tuple<string, string>>();
        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            SwitchTheme(true);
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            SwitchTheme(false);
        }

        public void SwitchTheme(bool isDark)
        {
            var res = Application.Current.Resources.MergedDictionaries;
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri(isDark ? "./Dark.xaml" : "./Light.xaml", UriKind.Relative);
            res[1] = dictionary;
        }

        private void topBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
