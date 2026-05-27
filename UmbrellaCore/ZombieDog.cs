using UmbrellaCore.Entities;

namespace ZombieDogPlugin
{
    public class ZombieDog : UmbrellaEntity
    {
        public int BiteForce { get; set; }

        public override string GetInfo()
        {
            return $"ZombieDog {Name}";
        }
    }
}