using System.Collections.Generic;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore
{
    public static class FactoryRegistry
    {
        public static List<IEntityFactory> Factories { get; }
            = new List<IEntityFactory>();
    }
}