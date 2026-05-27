using FriendPlugin;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Adapters
{
    public class FriendPluginAdapter : IDataTransformer
    {
        private readonly IFriendPlugin plugin;

        public FriendPluginAdapter(IFriendPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string Name => "Friend Adapter";

        public string TransformBeforeSave(string data)
        {
            return plugin.Process(data);
        }

        public string TransformAfterLoad(string data)
        {
            return data;
        }
    }
}