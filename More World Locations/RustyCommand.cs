using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging; // Make sure this is the correct namespace for BepInEx Logger if you're using it.
using HarmonyLib;
using UnityEngine; // Add this line to use Debug
using PieceManager;

namespace MoreWorldLocations
{
    public class RustyCommand
    {
        [HarmonyPatch(typeof(Terminal), nameof(Terminal.InitTerminal))]

        static class terminalInitPatch
        {
            private static void PostFix() => CreateSearchCommand();
        }

        private static void CreateSearchCommand()
        {
            Terminal.ConsoleCommand SearchMaterials = new Terminal.ConsoleCommand("search_cached_materials", "",
                (Terminal.ConsoleEventFailable)(
                    args =>
                    {
                        if (args.Length < 2) return false;
                        Debug.LogWarning("Material search results: ");
                        foreach (var kvp in MaterialReplacer.OriginalMaterials)
                        {
                            if (kvp.Key.Contains(args[1]) || kvp.Key.StartsWith(args[1]) || kvp.Key.EndsWith(args[1]))
                            {
                                Debug.LogWarning($"{kvp.Key} = {kvp.Value.name}");
                            }
                        }
                        return true;
                    }));
        }
    }
}
