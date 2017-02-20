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
        public event EventHandler MyCampingPlacesInsertItem;
        public event EventHandler<IdEventArgs> MyCampingPlacesDeleteItem;
        public event EventHandler<IdEventArgs> MyCampingPlacesUpdateItem;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<ICampingPlace> ListViewMyPlaces_GetData()
        {
            string userName = HttpContext.Current.User.Identity.Name;
            NameEventArgs args = new NameEventArgs(userName);
            this.MyCampingPlacesGetData?.Invoke(this, args);

            var myCampingPlaces = this.Model.MyCampingPlaces;

            return myCampingPlaces;
        }

        public void ListViewMyPlaces_InsertItem()
        {
            var item = new CampingPlace();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMyPlaces_DeleteItem(int id)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMyPlaces_UpdateItem(int id)
        {
            CampingPlace item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }
    }
}