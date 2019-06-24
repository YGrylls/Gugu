using Gugu.Model;

namespace Gugu.Services
{
    public interface IGuguUserService
    {
        User CheckUser(string username, string password);
        bool AddUser(string username, string password);


    }
}
