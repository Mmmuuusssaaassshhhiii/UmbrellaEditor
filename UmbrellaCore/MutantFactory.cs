using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class MutantFactory : IEntityFactory
    {
        public string Name => "Mutant";

        public UmbrellaEntity Create()
        {
            return new Mutant();
        }
    }
}