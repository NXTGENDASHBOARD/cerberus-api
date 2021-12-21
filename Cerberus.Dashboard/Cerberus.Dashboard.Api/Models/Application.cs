﻿using Cerberus.Dashboard.Api.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cerberus.Dashboard.Api.Models
{
    public class Application : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string ApplicationDate { get; set; }
        public bool IsDisable { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
     }
}
