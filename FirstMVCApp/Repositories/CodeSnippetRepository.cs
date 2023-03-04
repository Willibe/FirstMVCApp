using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetRepository : IClubDataRepository<CodeSnippetModel>
    {
        private readonly ClubDataContext _context;

        public CodeSnippetRepository(ClubDataContext context)
        {
            _context = context;
        }

        public void Add(CodeSnippetModel model)
        {
            model.IdCodeSnippet = Guid.NewGuid();
            _context.Entry(model).State = EntityState.Added; // Same as _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            CodeSnippetModel model = GetById(guid);
            _context.CodeSnippets.Remove(model);
            _context.SaveChanges();
        }

        public DbSet<CodeSnippetModel> GetAll()
        {
            return _context.CodeSnippets;
        }

        public CodeSnippetModel GetById(Guid guid)
        {
            CodeSnippetModel model = _context.CodeSnippets.FirstOrDefault(c => c.IdCodeSnippet == guid);
            return model;
        }

        public void Update(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }
    }
}
