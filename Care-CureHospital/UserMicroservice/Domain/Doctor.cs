using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain
{
    public class Doctor : User
    {
        public int SpecialitationId { get; set; }
        public virtual Specialitation Specialitation { get; set; }

        public Doctor()
        {
        }

    }
}
