using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Reflection;
using UnityEngine;

namespace MoreWorldLocations
{
    internal class LocationSpawner
    {

        public AssetBundle locationsBundle;
        public GameObject Ruins_warp_1_Prefab;
        public void LoadAssets()
        {
            locationsBundle = AssetUtils.LoadAssetBundleFromResources("moreworldlocations_bundle");
            Ruins_warp_1_Prefab = locationsBundle?.LoadAsset<GameObject>("Ruins_warp_1");

            LogResourceNamesAndCheckErrors();
        }

        public void LogResourceNamesAndCheckErrors()
        {
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(", ", resourceNames)}");

            CheckAssetBundle(locationsBundle, "Ruins");
        }

        public void CheckAssetBundle(AssetBundle bundle, string bundleName)
        {
            if (bundle == null)
            {
                Jotunn.Logger.LogError($"Failed to load the {bundleName} asset bundle.");
            }
        }

        // Define the vegetation configuration
        LocationConfig Ruin1Config = new LocationConfig
        {
            Biome = Heightmap.Biome.Meadows,
            Quantity = 100,
            Priotized = true,
            ExteriorRadius = 2f,
            ClearArea = true

        };

        public void AddLocations()
        {
            // Ensure all prefabs are loaded
            if (Ruins_warp_1_Prefab == null)
            {
                Jotunn.Logger.LogError("One or more location prefabs are not loaded.");
                return;
            }

            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins_warp_1_Prefab, fixReference: false, Ruin1Config));

        }


    }
}
