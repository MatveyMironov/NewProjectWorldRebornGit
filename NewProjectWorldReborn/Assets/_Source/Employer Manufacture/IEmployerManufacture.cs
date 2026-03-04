using EmployerSystem;
using ManufactureSystem;

namespace EmployerManufactureSystem
{
    public interface IEmployerManufacture
    {
        IEmployer Employer { get; }
        IManufacture Manufacture { get; }
    }
}