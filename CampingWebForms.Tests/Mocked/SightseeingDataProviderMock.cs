using Repositories;
using Services.DataProviders;
using System;

namespace CampingWebForms.Tests.Mocked
{
    public class SightseeingDataProviderMock : SightseeingDataProvider
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

        public SightseeingDataProviderMock(ICampingDBRepository repository, Func<IUnitOfWork> unitOfWork) 
            : base(repository, unitOfWork)
        {
        }
    }
}
