using MySalesWebMvc.Data;
using MySalesWebMvc.Models;

namespace MySalesWebMvc.Services
{
    public class SellerService
    {
        private readonly MySalesWebMvcContext _context;

        public SellerService(MySalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
