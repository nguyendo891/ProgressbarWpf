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
using System.Windows.Shapes;

namespace Progressbar
{
    /// <summary>
    /// Interaction logic for Progressbar.xaml
    /// </summary>
    public partial class Progressbar : Window
    {
        public Progressbar()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int percentage)
        {
            // When progress is reported, update the progress bar control.
            pbLoad.Value = percentage;

            // When progress reaches 100%, close the progress bar window.
            if (percentage == 100)
            {
                Close();
            }
        }
    }
}