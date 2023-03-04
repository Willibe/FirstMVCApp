using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository : IClubDataRepository<MembershipModel>
    {
        private readonly ClubDataContext _context;

        public MembershipsRepository(ClubDataContext context)
        {
            _context = context;
        }


        public void Add(MembershipModel model)
        {
            model.IdMembership = Guid.NewGuid();
            _context.Memberships.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            MembershipModel model = GetById(guid);
            _context.Memberships.Remove(model);
            _context.SaveChanges();
        }

        public DbSet<MembershipModel> GetAll()
        {
            return _context.Memberships;
        }

        public MembershipModel GetById(Guid guid)
        {
            MembershipModel model = _context.Memberships.FirstOrDefault(m => m.IdMembership == guid);

            return model;
        }

        public void Update(MembershipModel model)
        {
            _context.Memberships.Update(model);
            _context.SaveChanges();
        }
    }
}
