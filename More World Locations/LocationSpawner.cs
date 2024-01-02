using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static DropTable;

namespace MoreWorldLocations
{
    internal class LocationSpawner
    {

        private LootManager LootManager = new LootManager();
        private CreatureAdder CreatureAdder = new CreatureAdder();

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
            ExteriorRadius = 10f,
            ClearArea = true,
            RandomRotation = true,
            Group = "Ruins",
            MinDistanceFromSimilar = 1000f,
            MaxTerrainDelta = 1f,
            MinAltitude = 0f
        };

        public void AddLocations()
        {
            // Ensure all prefabs are loaded
            if (Ruins_warp_1_Prefab == null)
            {
                Jotunn.Logger.LogError("One or more location prefabs are not loaded.");
                return;
            }

            List<string> ruins1Loot = new List<string> { "Wood", "Stone" }; // Example items

            DropTable ruins1DropTable = LootManager.CreateDropTable(ruins1Loot, 1, 3, 1f);

            LootManager.AddContainerToChild(Ruins_warp_1_Prefab, "loot_chest_wood", ruins1DropTable);

            GameObject skeletonPrefab = PrefabManager.Cache.GetPrefab<GameObject>("Skeleton");

            CreatureAdder.AddCreatureSpawnerToChild(Ruins_warp_1_Prefab, "Ruins1_Spawner1", skeletonPrefab);

            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins_warp_1_Prefab, fixReference: false, Ruin1Config));

        }


    }
}
