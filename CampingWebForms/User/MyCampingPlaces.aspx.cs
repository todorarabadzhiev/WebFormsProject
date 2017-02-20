using MVP.Models;
using MVP.Models.EventModels;
using MVP.Presenters;
using MVP.Views;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms.User
{
    [PresenterBinding(typeof(MyCampingPlacesPresenter))]
    public partial class MyCampingPlaces : MvpPage<MyCampingPlacesViewModel>, IMyCampingPlacesView
    {
        public event EventHandler<NameEventArgs> MyCampingPlacesGetData;
        public event EventHandler<IdEventArgs> MyCampingPlacesDeleteItem;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ICampingPlace> ListViewMyPlaces_GetData()
        {
            string userName = HttpContext.Current.User.Identity.Name;
            NameEventArgs args = new NameEventArgs(userName);
            this.MyCampingPlacesGetData?.Invoke(this, args);

            var myCampingPlaces = this.Model.MyCampingPlaces.AsQueryable();

            return myCampingPlaces;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMyPlaces_DeleteItem(Guid id)
        {
            IdEventArgs args = new IdEventArgs(id);
            this.MyCampingPlacesDeleteItem?.Invoke(this, args);
        }
    }
}