﻿using EStore.WPF.Models;
using EStore.WPF.Repositories;
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

namespace EStore.WPF.Pages
{
    /// <summary>
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        public StaffPage(RepositoryManager repo,Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
            SetControl();
        }
        private void SetControl()
        {
            if (_staff.Role == 1)
            {
                btnAdd.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            else if(_staff.Role ==0)
            {
                btnAdd.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }
    }
}
