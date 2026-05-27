using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UmbrellaCore.Interfaces;

namespace UmbrellaCore.Services
{
    public static class PluginLoader
    {
        public static void LoadPlugins(string folder, PluginContext context)
        {
            if (!Directory.Exists(folder))
                return;

            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);

                var pluginTypes = assembly.GetTypes()
                    .Where(t =>
                        typeof(IPlugin).IsAssignableFrom(t)
                        && !t.IsInterface
                        && !t.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    IPlugin plugin =
                        (IPlugin)Activator.CreateInstance(type);

                    plugin.Register(context);
                }
            }
        }
    }
}