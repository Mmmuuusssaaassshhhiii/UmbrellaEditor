using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class ScientistFactory : IEntityFactory
    {
        public string Name => "Scientist";

        public UmbrellaEntity Create()
        {
            return new Scientist();
        }
    }
}