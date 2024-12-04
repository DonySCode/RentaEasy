using System.Collections.Generic;
using System.Linq;
using RentaEasy.Core.Entities;
using RentaEasy.Core.Interfaces;
using RentaEasy.Infrastructure.Data;

namespace RentaEasy.Infrastructure.Repositories
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly RentaEasyDbContext _context;

        public PropertiesRepository(RentaEasyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAllProperties() => _context.Properties.ToList();

        public Property? GetPropertyById(int id) => _context.Properties.FirstOrDefault(p => p.Id == id);

        public void AddProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        public void UpdateProperty(Property property)
        {
            _context.Properties.Update(property);
            _context.SaveChanges();
        }

        public void DeleteProperty(Property property) => _context.Properties.Remove(property);
    }
}
