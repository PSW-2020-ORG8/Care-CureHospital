using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain.ValueObjects
{
    [ComplexType]
    public class AccountInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountInfo() { }

        public bool isUsername(string username)
        {
            return (Username.Equals(username) ? true : false);
        }
    }
}
