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
            CodeSnippetModel codeSnippetModel = GetById(guid);
            _context.CodeSnippets.Remove(codeSnippetModel);
            _context.SaveChanges();
        }

        public DbSet<CodeSnippetModel> GetAll()
        {
            return _context.CodeSnippets;
        }

        public CodeSnippetModel GetById(Guid guid)
        {
            CodeSnippetModel codeSnippetModel = _context.CodeSnippets.FirstOrDefault(c => c.IdCodeSnippet == guid);
            return codeSnippetModel;
        }

        public void Update(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }
    }
}
