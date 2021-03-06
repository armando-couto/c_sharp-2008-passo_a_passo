﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;

namespace UsingStatement
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        private OpenFileDialog openFileDialog = null;

        public Window1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += openFileDialogFileOk;
        }

        private void openFileClick(object sender, RoutedEventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fullPathname = openFileDialog.FileName;
            FileInfo src = new FileInfo(fullPathname);
            fileName.Text = src.Name;
            source.Clear();

            using (TextReader reader = new StreamReader(fullPathname))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    source.Text += line + "\n";
                }
            }
        }
    }
}
