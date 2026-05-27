using System.Collections.Generic;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore
{
    public class PluginContext
    {
        public List<IEntityFactory> Factories { get; set; }
            = new List<IEntityFactory>();

        public List<IDataTransformer> Transformers { get; set; }
            = new List<IDataTransformer>();
    }
}