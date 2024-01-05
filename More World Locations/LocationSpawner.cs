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
        public GameObject Ruins1_Prefab;
        public GameObject Ruins2_Prefab;
        public GameObject Ruins3_Prefab;
        public GameObject Ruins4_Prefab;
        public GameObject RuinsArena1_Prefab;
        public GameObject RuinsCastle1_Prefab;
        public GameObject RuinsGarden1_Prefab;
        public GameObject RuinsGate1_Prefab;
        public GameObject RuinsHill1_Prefab;
        public GameObject RuinsTower1_Prefab;
        public GameObject RuinsTower2_Prefab;
        public GameObject RuinsTower3_Prefab;
        public GameObject Shrine1_Prefab;
        public GameObject Tavern1_Prefab;

        public void LoadAssets()
        {
            locationsBundle = AssetUtils.LoadAssetBundleFromResources("mwl_bundle");
            Ruins1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins1");
            Ruins2_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins2");
            Ruins3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins3");
            Ruins4_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins4");
            RuinsArena1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsArena1");
            RuinsCastle1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsCastle1");
            RuinsGarden1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsGarden1");
            RuinsGate1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsGate1");
            RuinsHill1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsHill1");
            RuinsTower1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower1");
            RuinsTower2_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower2");
            RuinsTower3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower3");
            Shrine1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Shrine1");
            Tavern1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Tavern1");

            LogResourceNamesAndCheckErrors();
        }

        public void AddLocations()
        {
            // Ensure all prefabs are loaded
            if (Ruins1_Prefab == null || Ruins2_Prefab == null || Ruins3_Prefab == null ||
                RuinsArena1_Prefab == null || RuinsCastle1_Prefab == null || RuinsGarden1_Prefab == null ||
                RuinsGate1_Prefab == null || RuinsHill1_Prefab == null || RuinsTower1_Prefab == null ||
                RuinsTower2_Prefab == null || RuinsTower3_Prefab == null || Shrine1_Prefab == null ||
                Tavern1_Prefab == null)
            {
                Jotunn.Logger.LogError("One or more location prefabs are not loaded.");
                return;
            }

            #region Ruins1
            List<string> ruins1Loot = new List<string> { "Wood", "Stone" };
            DropTable ruins1DropTable = LootManager.CreateDropTable(ruins1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Ruins1_Prefab, "loot_chest_wood", ruins1DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins1_Prefab, "Ruins1_Spawner1", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region Ruins2
            List<string> ruins2Loot = new List<string> { "Coins", "Flint", "Copper Ore", "Carrot Seeds };
            DropTable ruins2DropTable = LootManager.CreateDropTable(ruins2Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Ruins2_Prefab, "loot_chest_wood", ruins2DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins2_Prefab, fixReference: false, new LocationConfig
                {
                    Biome = Heightmap.Biome.Meadows,
                    Quantity = 100,
                    Priotized = true,
                    ExteriorRadius = 10f,
                    ClearArea = true,
                    RandomRotation = true,
                    // Group = "Ruins",
                    MinDistanceFromSimilar = 1000f,
                    MaxTerrainDelta = 1f,
                    MinAltitude = 0f,
                    MinDistance = 1000f
                }));
            #endregion

            #region Ruins3
            List<string> ruins3Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruins3DropTable = LootManager.CreateDropTable(ruins3Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Ruins3_Prefab, "loot_chest_wood", ruins3DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region Ruins4
            List<string> ruins4Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruins4DropTable = LootManager.CreateDropTable(ruins4Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Ruins4_Prefab, "loot_chest_wood", ruins4DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins4_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsArena1
            List<string> ruinsArena1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsArena1DropTable = LootManager.CreateDropTable(ruinsArena1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsArena1_Prefab, "loot_chest_wood", ruinsArena1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsArena1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsCastle1
            List<string> ruinsCastle1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsCastle1DropTable = LootManager.CreateDropTable(ruinsCastle1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsCastle1_Prefab, "loot_chest_wood", ruinsCastle1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsGarden1
            List<string> ruinsGarden1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsGarden1DropTable = LootManager.CreateDropTable(ruinsGarden1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsGarden1_Prefab, "loot_chest_wood", ruinsGarden1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsGarden1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGarden1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGarden1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsGarden1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsGate1
            List<string> ruinsGate1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsGate1DropTable = LootManager.CreateDropTable(ruinsGate1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsGate1_Prefab, "loot_chest_wood", ruinsGate1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsGate1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsHill1
            List<string> ruinsHill1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsHill1DropTable = LootManager.CreateDropTable(ruinsHill1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsHill1_Prefab, "loot_chest_wood", ruinsHill1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsHill1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsHill1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsHill1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsHill1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsTower1
            List<string> ruinsTower1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsTower1DropTable = LootManager.CreateDropTable(ruinsTower1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsTower1_Prefab, "loot_chest_wood", ruinsTower1DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower1_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower1_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower1_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsTower2
            List<string> ruinsTower2Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsTower2DropTable = LootManager.CreateDropTable(ruinsTower2Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsTower2_Prefab, "loot_chest_wood", ruinsTower2DropTable);
/*            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "Spawner3", "Skeleton");*/
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsTower3
            List<string> ruinsTower3Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable ruinsTower3DropTable = LootManager.CreateDropTable(ruinsTower3Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(RuinsTower3_Prefab, "loot_chest_wood", ruinsTower3DropTable);
            //CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "Spawner1", "Skeleton");
            //CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "Spawner2", "Skeleton");
            //CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region Shrine1
            List<string> shrine1Loot = new List<string> { "Wood", "Stone" }; // Modify as needed
            DropTable shrine1DropTable = LootManager.CreateDropTable(shrine1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Shrine1_Prefab, "loot_chest_wood", shrine1DropTable);
            //CreatureAdder.AddCreatureSpawnerToChild(Shrine1_Prefab, "Spawner1", "Skeleton");
            //CreatureAdder.AddCreatureSpawnerToChild(Shrine1_Prefab, "Spawner2", "Skeleton");
            //CreatureAdder.AddCreatureSpawnerToChild(Shrine1_Prefab, "Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Shrine1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 100,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f
            }));
            #endregion

            #region Tavern1
            List<string> tavern1Loot = new List<string> { "Food", "Drink" }; // Modify as needed
            DropTable tavern1DropTable = LootManager.CreateDropTable(tavern1Loot, 1, 3, 1f);
            LootManager.AddContainerToChild(Tavern1_Prefab, "loot_barrel_alcohol", tavern1DropTable);
            //CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "Spawner1", "Bandit");
            //CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "Spawner2", "Bandit");
            //CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "Spawner3", "Bandit");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Tavern1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 50, // Adjust as per requirement
                Priotized = true,
                ExteriorRadius = 15f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Tavern",
                MinDistanceFromSimilar = 1500f,
                MaxTerrainDelta = 2f,
                MinAltitude = 0f
            }));
            #endregion
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

    }
}
