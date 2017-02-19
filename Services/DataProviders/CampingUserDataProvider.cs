using Repositories;
using Services.Models;
using System;

namespace Services.DataProviders
{
    public class CampingUserDataProvider : ICampingUserDataProvider
    {
        private readonly ICampingDBRepository repository;
        private readonly Func<IUnitOfWork> unitOfWork;

        public CampingUserDataProvider(ICampingDBRepository repository, Func<IUnitOfWork> unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("CampingDBRepository");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void AddCampingUser(string appUserId, string firstName,
            string lastName, string userName)
        {
            IGenericRepository<CampingDB.Models.CampingUser> capmingUserRepository =
                this.repository.GetCampingUserRepository();
            ICampingUser newCampingUser = new CampingUser();
            newCampingUser.ApplicationUserId = appUserId;
            newCampingUser.FirstName = firstName;
            newCampingUser.LastName = lastName;
            newCampingUser.UserName = userName;

            using (var uw = this.unitOfWork())
            {
                CampingDB.Models.CampingUser dbCampingUser = ConvertFromUser(newCampingUser);
                capmingUserRepository.Add(dbCampingUser);
                uw.Commit();
            }
        }

        private CampingDB.Models.CampingUser ConvertFromUser(ICampingUser campUser)
        {
            CampingDB.Models.CampingUser user = new CampingDB.Models.CampingUser();
            user.ApplicationUserId = campUser.ApplicationUserId;
            user.FirstName = campUser.FirstName;
            user.LastName = campUser.LastName;
            user.UserName = campUser.UserName;
            user.RegisteredOn = DateTime.Now;

            return user;
        }
    }
}
