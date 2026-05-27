using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class SecurityFactory : IEntityFactory
    {
        public string Name => "Security";

        public UmbrellaEntity Create()
        {
            return new SecurityUnit();
        }
    }
}