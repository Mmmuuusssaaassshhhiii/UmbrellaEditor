using UmbrellaCore.Entities;

namespace UmbrellaCore.Interfaces
{
    public interface IEntityFactory
    {
        string Name { get; }

        UmbrellaEntity Create();
    }
}