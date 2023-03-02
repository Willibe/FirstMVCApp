using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipTypesRepository : IClubDataRepository<MembershipTypeModel>
    {
        private readonly ClubDataContext _context;

        public MembershipTypesRepository(ClubDataContext context)
        {
            _context = context;
        }

        public void Add(MembershipTypeModel model)
        {
            model.IdMembershipType = Guid.NewGuid();
            _context.MembershipTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            MembershipTypeModel membershipTypeModel = GetById(guid);
            _context.MembershipTypes.Remove(membershipTypeModel);
            _context.SaveChanges();
        }

        public DbSet<MembershipTypeModel> GetAll()
        {

            return _context.MembershipTypes;
        }

        public MembershipTypeModel GetById(Guid guid)
        {
            var membershipType = _context.MembershipTypes.FirstOrDefault(m => m.IdMembershipType == guid);
            return membershipType;
        }

        public void Update(MembershipTypeModel model)
        {
            _context.MembershipTypes.Update(model);
            _context.SaveChanges();
        }
    }
}
