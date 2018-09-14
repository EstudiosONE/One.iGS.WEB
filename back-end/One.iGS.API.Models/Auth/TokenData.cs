using System.Collections.Generic;

namespace One.iGS.API.Models.Auth
{
    public class TokenData
    {
        public string EntityId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Rights { get; set; }

        public TokenData()
        {
            Rights = new List<string>();
        }
    }
}