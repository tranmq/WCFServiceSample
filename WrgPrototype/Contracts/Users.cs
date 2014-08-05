using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WrgPrototype.Contracts
{
    [CollectionDataContract(Name = "users", Namespace = "")]
    public class Users : List<User>
    {
    }
}