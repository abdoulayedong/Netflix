using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using NetflixApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IAuthenticationService))]
namespace NetflixApp.Droid.DependencyServices
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsSignIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }
        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var tokenResult = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
                return tokenResult.Token;
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                ex.PrintStackTrace();
                return "Not Exist";
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                ex.PrintStackTrace();
                return "Not Exist";
            }
            catch (FirebaseException ex)
            {
                ex.PrintStackTrace();
                return "Not Exist";
            }

        }


        public async Task<string> SignupWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var tokenResult = await newUser.User.GetIdToken(false).AsAsync<GetTokenResult>();
                return tokenResult.Token;
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                ex.PrintStackTrace();
                return "Not Exist";
            }
           catch (FirebaseAuthUserCollisionException ex)
            {
                ex.PrintStackTrace();
                return "Exist";
            }
        }
    }
}