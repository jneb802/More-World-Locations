using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using PieceManager;
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
        public GameObject RuinsChurch1_Prefab;
        public GameObject RuinsGarden1_Prefab;
        public GameObject RuinsGate1_Prefab;
        public GameObject RuinsHill1_Prefab;
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
            RuinsChurch1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsChurch1");
            RuinsGarden1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsGarden1");
            RuinsGate1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsGate1");
            RuinsHill1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsHill1");
            RuinsTower2_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower2");
            RuinsTower3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower3");
            Shrine1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Shrine1");
            Tavern1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Tavern1");

            LogResourceNamesAndCheckErrors();
        }


        #region LootLists
        List<string> meadowsLoot1 = new List<string> { "Coins", "Flint", "Feathers", "LeatherScraps", "DeerHide" };
        List<string> meadowsLoot2 = new List<string> { "FineWood", "Bronze", "CopperOre", "Coins" };
        List<string> shrineEikLoot1 = new List<string> { "Acorn", "Ruby", "Coins" };
        List<string> tavernLoot1 = new List<string> { "Honey", "DeerStew", "QueensJam", "MinceMeatSauce" };
        List<string> churchLoot1 = new List<string> { "FineWood", "AmberPearl", "SilverNecklace", "Bronze" };
        List<string> blackforestLoot1 = new List<string> { "ArrowBronze", "CopperOre", "Amber", "Ruby", "AmberPearl", "Coins", "BoneFragments" };
        List<string> swampLoot1 = new List<string> { "Amber", "AmberPearl", "Ruby", "Chain", "ElderBark", "IronScrap", "WitheredBone" };

        #endregion

        public void AddLocations()
        {
            // Ensure all prefabs are loaded
            if (Ruins1_Prefab == null || Ruins2_Prefab == null || Ruins3_Prefab == null ||
                RuinsArena1_Prefab == null || RuinsCastle1_Prefab == null || RuinsChurch1_Prefab == null || RuinsGarden1_Prefab == null ||
                RuinsGate1_Prefab == null || RuinsHill1_Prefab == null || RuinsTower2_Prefab == null || 
                RuinsTower3_Prefab == null || Shrine1_Prefab == null || Tavern1_Prefab == null)
            {
                Jotunn.Logger.LogError("One or more location prefabs are not loaded.");
                return;
            }

            #region Ruins1
            DropTable ruins1DropTable = LootManager.CreateDropTable(meadowsLoot1, 1, 3);
            LootManager.AddContainerToChild(Ruins1_Prefab, "loot_chest_wood", ruins1DropTable);
            //MaterialReplacer.RegisterGameObjectForMatSwap(Ruins1_Prefab.gameObject);
            //MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins1_Prefab.gameObject, MaterialReplacer.ShaderType.UseUnityShader); 
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins1_Prefab, fixReference: true, new LocationConfig
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
            DropTable ruins2DropTable = LootManager.CreateDropTable(meadowsLoot2, 1, 3);
            LootManager.AddContainerToChild(Ruins2_Prefab, "loot_chest_wood", ruins2DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner1", "Draugr");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner2", "Draugr");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner3", "Draugr");
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
            DropTable ruins3DropTable = LootManager.CreateDropTable(meadowsLoot1, 1, 3);
            LootManager.AddContainerToChild(Ruins3_Prefab, "loot_chest_wood", ruins3DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "MWL_Ruins3_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "MWL_Ruins3_Spawner2", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 1,
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
            DropTable ruins4DropTable = LootManager.CreateDropTable(blackforestLoot1, 1, 3);
            LootManager.AddContainerToChild(Ruins4_Prefab, "loot_chest_wood", ruins4DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins4_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest, // Modify as needed
                Quantity = 1,
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
            DropTable ruinsArena1DropTable = LootManager.CreateDropTable(meadowsLoot2, 1, 3);
            LootManager.AddContainerToChild(RuinsArena1_Prefab, "loot_chest_wood", ruinsArena1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsArena1_Prefab.gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena1_Prefab.gameObject, MaterialReplacer.ShaderType.UseUnityShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner5", "Skeleton");
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
            DropTable ruinsCastle1DropTable = LootManager.CreateDropTable(blackforestLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsCastle1_Prefab, "loot_chest_wood", ruinsCastle1DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 1,
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

            #region RuinsChurch1
            DropTable ruinsChurch1DropTable = LootManager.CreateDropTable(churchLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsCastle1_Prefab, "loot_chest_wood", ruinsChurch1DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsChurch1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 1,
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
            DropTable ruinsGarden1DropTable = LootManager.CreateDropTable(swampLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsGarden1_Prefab, "loot_chest_stone", ruinsGarden1DropTable);
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsGarden1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Swamp, // Modify as needed
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
            DropTable ruinsGate1DropTable = LootManager.CreateDropTable(blackforestLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsGate1_Prefab, "loot_chest_stone", ruinsGate1DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner3", "Skeleton");
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
            DropTable ruinsHill1DropTable = LootManager.CreateDropTable(shrineEikLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsHill1_Prefab, "loot_chest_wood", ruinsHill1DropTable);
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

            #region RuinsTower2
            DropTable ruinsTower2DropTable = LootManager.CreateDropTable(swampLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsTower2_Prefab, "loot_chest_wood", ruinsTower2DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "MWL_RuinsTower2_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "MWL_RuinsTower2_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower2_Prefab, "MWL_RuinsTower2_Spawner3", "Skeleton");
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
            DropTable ruinsTower3DropTable = LootManager.CreateDropTable(blackforestLoot1, 1, 3);
            LootManager.AddContainerToChild(RuinsTower3_Prefab, "loot_chest_wood", ruinsTower3DropTable);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner3", "Skeleton");
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
            DropTable tavern1DropTable = LootManager.CreateDropTable(tavernLoot1, 1, 3);
            LootManager.AddContainerToChild(Tavern1_Prefab, "loot_chest_wood", tavern1DropTable);
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
