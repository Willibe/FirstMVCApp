using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVCApp.Tests.Helpers
{
    public class DBContextHelper
    {
        public static ClubDataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ClubDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var databaseContext = new ClubDataContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        public static AnnouncementModel AddAnnouncement(ClubDataContext context, AnnouncementModel announcement)
        {

            context.Add(announcement);
            context.SaveChanges();
            context.Entry(announcement).State = EntityState.Detached;
            return announcement;
        }
    }
}
