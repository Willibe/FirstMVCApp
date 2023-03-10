using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;



namespace FirstMVCApp.Repositories
{
    // Repository Pattern! Classes that implement CRUD operations on DB on behalf of the controller
    public class AnnouncementsRepository : IClubDataRepository<AnnouncementModel>
    {
        private readonly ClubDataContext _contex;
        public AnnouncementsRepository(ClubDataContext context)
        {
            _contex = context;
        }

        public DbSet<AnnouncementModel> GetAll()
        {
            return _contex.Announcements;
        }

        public void Add(AnnouncementModel model)
        {
            //Set The ID here
            model.IdAnnouncement = Guid.NewGuid();
            //Add Model in ORM Layer
            _contex.Announcements.Add(model);
            //Commit to DB
            _contex.SaveChanges();
        }

        public AnnouncementModel GetById(Guid guid)
        {
            AnnouncementModel announcement = _contex.Announcements.FirstOrDefault(a => a.IdAnnouncement == guid);
            return announcement;
        }

        public void Update(AnnouncementModel model)
        {
            _contex.Announcements.Update(model);
            _contex.SaveChanges();
        }

        public void Delete(Guid guid)
        { 

            AnnouncementModel announcement = GetById(guid);
            if (announcement != null)
            {
                _contex.Announcements.Remove(announcement);
                _contex.SaveChanges();
            }

        }
    }
}
