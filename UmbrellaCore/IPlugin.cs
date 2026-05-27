namespace UmbrellaCore.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }

        void Register(PluginContext context);
    }
}