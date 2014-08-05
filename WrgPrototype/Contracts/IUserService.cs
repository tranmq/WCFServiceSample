using System.ServiceModel;
using System.ServiceModel.Web;

namespace WrgPrototype.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [WebGet(UriTemplate = "/users")]
        [OperationContract]
        Users GetAllUsers();

        [WebInvoke(UriTemplate = "/users", Method = "POST")]
        [OperationContract]
        User AddUser(User user);

        [WebGet(UriTemplate = "/users/{userId}")]
        [OperationContract]
        User GetUser(string userId);

        [WebInvoke(UriTemplate = "/users/{userId}", Method = "DELETE")]
        [OperationContract]
        void DeleteUser(string userId);

        [WebInvoke(UriTemplate = "/users/{userId}", Method = "PUT")]
        [OperationContract]
        User UpdateUser(string userId, User user);
    }
}