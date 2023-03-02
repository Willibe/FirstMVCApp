using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public interface IClubDataRepository<T> where T : class
    {
        public DbSet<T> GetAll();
        public void Add(T model);
        public T GetById(Guid guid);
        public void Update(T model);
        public void Delete(Guid guid);
    }
}
