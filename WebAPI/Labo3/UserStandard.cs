using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    public class UserStandard : User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public DateTime Birthdate { get; set; }
        public IList<UserPromoter> FavoritePromoters { get; set; }
        public IList<Success> Success { get; set; }
        public IList<Participation> ParticipatedEvents { get; set; }

    }
}
