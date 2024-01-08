using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Reflection;
using UnityEngine;

namespace MoreWorldLocations
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class MoreWorldLocations : BaseUnityPlugin
    {
        public const string PluginGUID = "com.warp.moreWorldLocations";
        public const string PluginName = "MoreWorldLocations";
        public const string PluginVersion = "1.0.0";

        private LocationSpawner locationSpawner;
        private TextManager textManager;

        public static CustomLocalization Localization = Jotunn.Managers.LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {


            PrefabManager.OnVanillaPrefabsAvailable += OnPrefabsAvailable;

            Jotunn.Logger.LogInfo("MoreWorldLocations has loaded");

            // Apply Harmony patches
            var harmony = new Harmony(PluginGUID);
            //harmony.PatchAll();

            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);

        }

        private void OnPrefabsAvailable()
        {

            locationSpawner = new LocationSpawner();
            locationSpawner.LoadAssets();
            locationSpawner.AddLocations();

            textManager = new TextManager();
            textManager.AddlocalizationsEnglish();
            //textManager.JSONS();


            PrefabManager.OnVanillaPrefabsAvailable -= OnPrefabsAvailable;
        }



    }
}