using RentaEasy.Core.Entities;

namespace RentaEasy.Core.Interfaces
{
    public interface IPropertiesRepository
    {
        IEnumerable<Property> GetAllProperties();

        Property? GetPropertyById(int id);
        void AddProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(int id);
    }
}
