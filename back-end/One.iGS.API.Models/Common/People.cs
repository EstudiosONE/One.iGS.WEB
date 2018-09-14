using System;
using System.Collections.Generic;

namespace One.iGS.API.Models.Common
{
    public class People
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Nationality { get; set; }
        public string TypeOfIdentityDocument { get; set; }
        public string IdentityDocument { get; set; }
        public List<PeopleContact> Contacts { get; set; }
        public List<PeopleAddress> Addresses { get; set; }
    }
}