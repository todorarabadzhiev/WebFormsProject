﻿using CampingWebForms.Common;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CampingWebForms
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeViewModel>, IHomeView
    {
        public event EventHandler HomeLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.HomeLoad?.Invoke(sender, e);
                this.ListViewLatestPlaces.DataSource = this.Model.CampingPlaces;
                this.ListViewLatestPlaces.DataBind();
            }
        }

        public string ConvertToImage(object data)
        {
            return Utilities.ConvertToImage((byte[])data);
        }
    }
}