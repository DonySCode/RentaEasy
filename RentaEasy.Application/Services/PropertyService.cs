using RentaEasy.Core.Entities;
using RentaEasy.Core.Interfaces;

namespace RentaEasy.Application.Services
{
    public class PropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Property> GetAllProperties() => _repository.GetAllProperties();

        public void AddProperty(Property property) => _repository.AddProperty(property);
    }
}
