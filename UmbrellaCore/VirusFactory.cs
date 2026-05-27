using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Factories
{
    public class VirusFactory : IEntityFactory
    {
        public string Name => "Virus";

        public UmbrellaEntity Create()
        {
            return new VirusSample();
        }
    }
}