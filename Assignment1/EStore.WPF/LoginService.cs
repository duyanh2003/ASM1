﻿using EStore.WPF.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.WPF
{
    public class LoginService
    {
        private readonly IConfiguration _configuration;
        private readonly RepositoryManager _repositoryManager;

        public LoginService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
            _repositoryManager = new RepositoryManager();
        }

        public Staff? Authenticate(string name, string password)
        {
            var adminName = _configuration["Account:Name"];
            var adminPassword = _configuration["Account:Password"];
            var adminRole = int.Parse(_configuration["Account:role"]);

            if (name == adminName && password == adminPassword)
            {
                return new Staff { Name = adminName, Password = adminPassword, Role = adminRole };
            }

            var staff = _repositoryManager.StaffRepository.FindByName(name).FirstOrDefault();

            if (staff != null && staff.Password == password)
            {
                return staff;
            }

            return null;
        }

    }



}
