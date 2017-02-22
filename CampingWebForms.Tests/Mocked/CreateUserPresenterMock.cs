using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class CreateUserPresenterMock : CreateUserPresenter
    {
        public ICampingUserDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public CreateUserPresenterMock(ICreateUserView view, ICampingUserDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
