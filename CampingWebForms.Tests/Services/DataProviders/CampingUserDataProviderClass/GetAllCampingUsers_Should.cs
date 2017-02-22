﻿using NUnit.Framework;
using Repositories;
using Services.DataProviders;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CampingWebForms.Tests.Services.DataProviders.CampingUserDataProviderClass
{
    [TestFixture]
    public class GetAllCampingUsers_Should
    {
        private Guid id_01 = Guid.NewGuid();
        private Guid id_02 = Guid.NewGuid();
        private Guid id_03 = Guid.NewGuid();

        private string userName_01 = "Name_01";
        private string userName_02 = "Name_02";
        private string userName_03 = "Name_03";

        [Test]
        public void CallExactlyOnceCampingUserRepositoryMethodGetAll()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);

            // Act
            provider.GetAllCampingUsers();

            // Assert
            Mock.Assert(() => repository.GetCampingUserRepository()
                .GetAll(), Occurs.Once());
        }

        [Test]
        public void ReturnsNull_WhenThereArentAnyCampingUsersInTheDB()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            IEnumerable<CampingDB.Models.CampingUser> dbUsers = null;
            Mock.Arrange(() => repository.GetCampingUserRepository()
                .GetAll()).Returns(dbUsers);

            // Act
            var users = provider.GetAllCampingUsers();

            // Assert
            Assert.IsNull(users);
        }

        [Test]
        public void ReturnsAllCampingUsers_WhenCampingUsersExistInTheDB()
        {
            // Arrange
            ICampingDBRepository repository = Mock.Create<ICampingDBRepository>();
            Func<IUnitOfWork> unitOfWork = Mock.Create<Func<IUnitOfWork>>();
            var provider = new CampingUserDataProvider(repository, unitOfWork);
            IEnumerable<CampingDB.Models.CampingUser> dbUsers = this.GetDbCampingUsers();

            Mock.Arrange(() => repository.GetCampingUserRepository()
                .GetAll()).Returns(dbUsers);

            IEnumerable<ICampingUser> expectedUsers = this.GetCampingUsers();

            // Act
            var users = provider.GetAllCampingUsers();

            // Assert
            Assert.AreEqual(expectedUsers.Count(), users.Count());
            foreach (var doublePlace in expectedUsers.Zip(users, Tuple.Create))
            {
                Assert.AreEqual(doublePlace.Item1.Id, doublePlace.Item2.Id);
            }
        }

        private IEnumerable<ICampingUser> GetCampingUsers()
        {
            IEnumerable<ICampingUser> users = new List<ICampingUser>()
            {
                new CampingUser()
                {
                    Id = this.id_01,
                    UserName = this.userName_01
                },
                new CampingUser()
                {
                    Id = this.id_02,
                    UserName = this.userName_02
                },
                new CampingUser()
                {
                    Id = this.id_03,
                    UserName = this.userName_03
                }
            };

            return users;
        }

        private IEnumerable<CampingDB.Models.CampingUser> GetDbCampingUsers()
        {
            IEnumerable<CampingDB.Models.CampingUser> dbUsers =
                new List<CampingDB.Models.CampingUser>()
            {
                new CampingDB.Models.CampingUser()
                {
                    Id = this.id_01,
                    UserName = this.userName_01
                },
                new CampingDB.Models.CampingUser()
                {
                    Id = this.id_02,
                    UserName = this.userName_02
                },
                new CampingDB.Models.CampingUser()
                {
                    Id = this.id_03,
                    UserName = this.userName_03
                }
            };

            return dbUsers;
        }
    }
}
