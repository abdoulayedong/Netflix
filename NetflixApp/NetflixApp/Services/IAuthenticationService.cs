using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginWithEmailAndPassword(string email, string password);
        Task<string> SignupWithEmailAndPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();
    }
}
