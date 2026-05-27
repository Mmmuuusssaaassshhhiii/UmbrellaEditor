using UmbrellaCore.Entities;
using UmbrellaCore.Interfaces;

namespace ZombieDogPlugin
{
    public class ZombieDogFactory : IEntityFactory
    {
        public string Name => "ZombieDog";

        public UmbrellaEntity Create()
        {
            return new ZombieDog();
        }
    }
}