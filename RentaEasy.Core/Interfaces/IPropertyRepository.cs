using RentaEasy.Core.Entities;

namespace RentaEasy.Core.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();
        void AddProperty(Property property);
    }
}
