using UmbrellaCore;
using UmbrellaCore.Interfaces;

namespace ZombieDogPlugin
{
    public class ZombieDogPlugin : IPlugin
    {
        public string Name => "Zombie Dog Plugin";

        public void Register(PluginContext context)
        {
            context.Factories.Add(
                new ZombieDogFactory());
        }
    }
}