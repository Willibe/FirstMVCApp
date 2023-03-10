using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVCApp.Tests.RepositoriesTests
{
    [TestClass]
    public class AnnouncementsRepositoryTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ClubDataContext _contextInMemory;

        public AnnouncementsRepositoryTests()
        {
            _contextInMemory = DBContextHelper.GetDatabaseContext();
            _repository = new AnnouncementsRepository(_contextInMemory);
        }


        [TestMethod]
        public void GetAllAnnouncements()
        {
            //Arrange -> create fake announcements
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = new Guid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcement",
                Title = "Event1",
            };
            AnnouncementModel announcement2 = new AnnouncementModel
            {
                IdAnnouncement = new Guid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags2",
                Text = "Announcement2",
                Title = "Event2",
            };

            List<AnnouncementModel> list = new List<AnnouncementModel>();
            list.Add(announcement1);
            list.Add(announcement2);
            _repository.Add(announcement1);
            _repository.Add(announcement2);
            //DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            //DBContextHelper.AddAnnouncement(_contextInMemory, announcement2);
            //Act -> call the method

            List<AnnouncementModel> dbAnnouncements = _repository.GetAll().ToList();
            //Assert -> assert the result
            Assert.AreEqual(list.Count, dbAnnouncements.Count);
            //Assert.AreEqual("Event1", dbAnnouncements[0].Title);
        }

        [TestMethod]
        public void GetAnnouncementsWithoutDataInDB()
        {
            List<AnnouncementModel> dbAnnouncements = _repository.GetAll().ToList();

            Assert.AreEqual(0, dbAnnouncements.Count);

        }

        [TestMethod]
        public void GetAnnouncementById_WhenNotExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            //Act
            var result = _repository.GetById(id);

            //Assert
            Assert.IsNull(result);

        }


        [TestMethod]
        public void GetAnnouncementById()
        {
            //Arrange -> vom crea niste announcements fake
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            Guid id = (Guid)announcement1.IdAnnouncement;

            //Act -> chemam metoda din repository
            var result = _repository.GetById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(announcement1.Title, result.Title);
            Assert.AreEqual(announcement1.Tags, result.Tags);
            Assert.AreEqual(announcement1.ValidFrom, result.ValidFrom);
            Assert.AreEqual(announcement1.ValidTo, result.ValidTo);
            Assert.AreEqual(announcement1.EventDate, result.EventDate);
        }

        [TestMethod]
        public void DeleteAnnouncement_AnnouncementNotExist()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            _repository.Delete(id);
            var result = _repository.GetById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteAnnouncement_AnnouncementExists()
        {
            //Arrange -> vom crea un announcement
            Guid id = Guid.NewGuid();
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = id,
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            //Act
            _repository.Delete(id);
            var result = _repository.GetById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateAnnouncement_AnnouncementExist()
        {
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            announcement.Tags = "tagsUpdated";
            _repository.Update(announcement);

            AnnouncementModel updatedModel = _repository.GetById((Guid)announcement1.IdAnnouncement);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(announcement.Tags, updatedModel.Tags);
        }
    }
}
