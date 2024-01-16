using DepartmentDomain.Entity;
using Microsoft.EntityFrameworkCore;


namespace DepartmentReposatory.Reposatory
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DepartmentContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new DepartmentContext();

            table = _context.Set<T>();
        }

        public GenericRepository(DepartmentContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
