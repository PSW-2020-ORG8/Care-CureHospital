using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Domain.Enum;
using UserMicroservice.Domain.ValueObjects;
using UserMicroservice.Repository;

namespace UserMicroservice.Domain
{
    public class User : Person, IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public AccountInfo AccountInfo { get; set; }
        [NotMapped]
        public string Token { get; set; }

        public User()
        {
        }


        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public bool CheckUser(string username)
        {
            return AccountInfo.isUsername(username);
        }

        public bool HasJMBG(string jmbg)
        {
            return PersonalInfo.HasJMBG(jmbg);
        }
    }
}