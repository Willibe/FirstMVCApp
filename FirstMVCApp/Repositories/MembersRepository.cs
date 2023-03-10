using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository : IClubDataRepository<MemberModel>
    {
        private readonly ClubDataContext _context;

        public MembersRepository(ClubDataContext context)
        {
            _context = context;
        }

        public void Add(MemberModel model)
        {
            model.IdMember = Guid.NewGuid();
            _context.Members.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            MemberModel model= GetById(guid);
            _context.Members.Remove(model);
            _context.SaveChanges();
        }

        public DbSet<MemberModel> GetAll()
        {
            
            return _context.Members;
        }

        public MemberModel GetById(Guid guid)
        {
            MemberModel model = _context.Members.FirstOrDefault(m => m.IdMember == guid);
            return model;
        }

        public void Update(MemberModel model)
        {
            _context.Members.Update(model);
            _context.SaveChanges();
        }

        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid memberId)
        {
            MemberCodeSnippetsViewModel MCmodel = new MemberCodeSnippetsViewModel();
            MemberModel memberModel = GetById(memberId);
            if (memberModel != null)
            {
                MCmodel.Name = memberModel.Name;
                MCmodel.Position = memberModel.Position;
                MCmodel.Title = memberModel.Title;
                IQueryable<CodeSnippetModel> memberCodeSnippets = _context.CodeSnippets.Where(c => c.IdMember == memberId);

                foreach (var codeSnippet in memberCodeSnippets)
                {
                    MCmodel.CodeSnippets.Add(codeSnippet);
                }

            }
            return MCmodel;
        }
    }
}
