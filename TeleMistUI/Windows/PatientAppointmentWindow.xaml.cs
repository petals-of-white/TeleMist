﻿using System.Windows;

namespace TeleMistUI
{
    /// <summary>
    /// Interaction logic for PatientAppointmentWindow.xaml
    /// </summary>
    public partial class PatientAppointmentWindow : Window
    {
        public PatientAppointmentWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            //if (this.Resources)
        }
    }
}
