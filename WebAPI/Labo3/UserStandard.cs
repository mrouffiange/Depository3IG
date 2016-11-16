﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labo3
{
    //[DataContract(IsReference = true)]
    [DataContract]
    public class UserStandard : User
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public DateTime Birthdate { get; set; }
        public IList<UserPromoter> FavoritePromoters { get; set; }
        public IList<Success> Success { get; set; }
        public IList<Participation> ParticipatedEvents { get; set; }

    }
}
