using System;

namespace UmbrellaCore.Entities
{
    [Serializable]
    public abstract class UmbrellaEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public abstract string GetInfo();

        public override string ToString()
        {
            return GetInfo();
        }
    }
}