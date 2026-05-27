using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class ExperimentFactory : IEntityFactory
    {
        public string Name => "Experiment";

        public UmbrellaEntity Create()
        {
            return new Experiment();
        }
    }
}