﻿using MVP.Models.EventModels;
using MVP.Views;
using Services.DataProviders;
using WebFormsMvp;

namespace MVP.Presenters
{
    public class CampingPlaceDetailsPresenter : Presenter<ICampingPlaceDetailsView>
    {
        private readonly ICampingPlaceDataProvider provider;
        public CampingPlaceDetailsPresenter(ICampingPlaceDetailsView view, ICampingPlaceDataProvider provider)
            : base(view)
        {
            this.provider = provider;

            this.View.CampingPlaceDetailsLoad += this.View_CampingPlaceDetailsLoad;
        }

        private void View_CampingPlaceDetailsLoad(object sender, IdEventArgs e)
        {
            this.View.Model.CampingPlaceDetails = this.provider.GetCampingPlaceById(e.Id);
        }
    }
}
