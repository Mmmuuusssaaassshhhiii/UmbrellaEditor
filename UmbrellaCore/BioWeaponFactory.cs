using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class BioWeaponFactory : IEntityFactory
    {
        public string Name => "BioWeapon";

        public UmbrellaEntity Create()
        {
            return new BioWeapon();
        }
    }
}