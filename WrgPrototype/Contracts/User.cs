using System.Runtime.Serialization;
using System.Xml.Linq;

namespace WrgPrototype.Contracts
{
    [DataContract(Name = "user", Namespace = "")]
    public class User
    {
        [DataMember( Name ="id", Order = 1)]
        public string UserId;
        
        [DataMember( Name = "firstname", Order = 2)]
        public string FirstName;
        
        [DataMember( Name = "lastname", Order = 3)]
        public string LastName;
        
        [DataMember( Name = "email", Order = 4)]
        public string Email;

        [DataMember(Name = "notes")]
        public XElement Notes;
    }
}