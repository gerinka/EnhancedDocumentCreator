using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edc.Domain.Models;

namespace Edc.WebClient.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool CanBeMentor { get; set; }
        public int Id { get; set; }
    }

    public class PersonsViewModel
    {
        public IList<PersonViewModel> AllUsers { get; set; } 
    }
}