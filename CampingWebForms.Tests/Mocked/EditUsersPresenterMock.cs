using MVP.Presenters;
using MVP.Views;
using Services.DataProviders;

namespace CampingWebForms.Tests.Mocked
{
    public class EditUsersPresenterMock : EditUsersPresenter
    {
        public ICampingUserDataProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public EditUsersPresenterMock(IEditUsersView view, ICampingUserDataProvider provider) 
            : base(view, provider)
        {
        }
    }
}
