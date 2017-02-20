using Auth;
using Auth.Helpers;
using Auth.IdentityConfig;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms.Account
{
    [PresenterBinding(typeof(CreateUserPresenter))]
    public partial class Register : MvpPage<CreateUserViewModel>, ICreateUserView
    {
        public event EventHandler<CreateUserClickEventArgs> CreateUserClick;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = this.Email.Text, Email = this.Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                // Add data to CampingUser
                string appUserId = user.Id;
                string firstName = this.TextBoxFirstName.Text;
                string lastName = this.TextBoxLastName.Text;
                string userName = user.UserName;
                CreateUserClickEventArgs args = new CreateUserClickEventArgs(appUserId, firstName, lastName, userName);
                this.CreateUserClick?.Invoke(sender, args);

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}