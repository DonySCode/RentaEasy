using RentaEasy.Core.Entities;
using RentaEasy.Core.Interfaces;

namespace RentaEasy.Application.Services
{
    public class PropertyService
    {
        private readonly IPropertiesRepository _repository;

        public PropertyService(IPropertiesRepository repository)
        {
            _repository = repository;
        }

        public Property? GetPropertyById(int id) => _repository.GetPropertyById(id);

        public IEnumerable<Property> GetAllProperties() => _repository.GetAllProperties();

        public void AddProperty(Property property) => _repository.AddProperty(property);

        public void UpdateProperty(Property property) => _repository.UpdateProperty(property);

        public void DeleteProperty(int id) => _repository.DeleteProperty(id);
    }
}
