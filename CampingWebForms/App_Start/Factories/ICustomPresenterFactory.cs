using System;
using WebFormsMvp;

namespace CampingWebForms.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
