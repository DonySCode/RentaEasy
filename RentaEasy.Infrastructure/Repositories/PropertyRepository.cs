using System.Collections.Generic;
using System.Linq;
using RentaEasy.Core.Entities;
using RentaEasy.Core.Interfaces;
using RentaEasy.Infrastructure.Data;

namespace RentaEasy.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RentaEasyDbContext _context;

        public PropertyRepository(RentaEasyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAllProperties() => _context.Properties.ToList();

        public void AddProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }
    }
}
