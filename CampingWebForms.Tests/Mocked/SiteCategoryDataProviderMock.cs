using Repositories;
using Services.DataProviders;
using System;

namespace CampingWebForms.Tests.Mocked
{
    public class SiteCategoryDataProviderMock : SiteCategoryDataProvider
    {
        public ICampingDBRepository Repository
        {
            get
            {
                return this.repository;
            }
        }

        public Func<IUnitOfWork> UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public SiteCategoryDataProviderMock(ICampingDBRepository repository, Func<IUnitOfWork> unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}
