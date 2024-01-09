using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Extensions;
using Jotunn.Managers;
using Jotunn.Utils;
using PieceManager;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static MoreWorldLocations.LocationSpawner;

namespace MoreWorldLocations
{
    internal class LocationSpawner
    {

        private LootManager LootManager = new LootManager();
        private CreatureAdder CreatureAdder = new CreatureAdder();
        private UnityScriptAdder UnityScriptAdder = new UnityScriptAdder();

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
        public GameObject RuinsTower3_Prefab;
        public GameObject Shrine1_Prefab;
        public GameObject Tavern1_Prefab;
        public GameObject Cave1_Prefab;
        public GameObject RuinsArena2_Prefab;

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
            RuinsTower3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower3");
            Shrine1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Shrine1");
            Tavern1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Tavern1");
            Cave1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Cave1");
            RuinsArena2_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsArena2");

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
                RuinsGate1_Prefab == null || RuinsTower3_Prefab == null || Shrine1_Prefab == null || Tavern1_Prefab == null || Cave1_Prefab == null)
            {
                Jotunn.Logger.LogError("One or more location prefabs are not loaded.");
                return;
            }

            #region Ruins1
            DropTable ruins1DropTable = UnityScriptAdder.CreateDropTable(meadowsLoot1, 2, 3);
            UnityScriptAdder.AddContainerToChild(Ruins1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruins1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(Ruins1_Prefab.gameObject);
            // MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            // MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins1_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.UseUnityShader);
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_small",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                // MinDistance = 0,
                MaxDistance = 500,
                InForest = true,
                ForestTresholdMin = 0,
                ForestTrasholdMax = 1,

            }));
            #endregion

            #region Ruins2
            DropTable ruins2DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            LootManager.AddContainerToChild(Ruins2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruins2DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(Ruins2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner1", "Draugr");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner2", "Draugr");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins2_Prefab, "MWL_Ruins2_Spawner3", "Draugr");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 7.5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 500,
                MaxDistance = 2000,
                InForest = false,
                ForestTresholdMin = 2,
                // ForestTrasholdMax = 1,
                //SnapToWater = false,

            }));
            #endregion

            #region Ruins3
            DropTable ruins3DropTable = LootManager.CreateDropTable(meadowsLoot1, 2, 3);
            LootManager.AddContainerToChild(Ruins3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruins3DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(Ruins3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "MWL_Ruins3_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins3_Prefab, "MWL_Ruins3_Spawner2", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_small",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                //MinDistance = 500,
                MaxDistance = 500,
                InForest = false,
                ForestTresholdMin = 1.5f,
                // ForestTrasholdMax = 1,

            }));
            #endregion

            #region Ruins4
            DropTable ruins4DropTable = LootManager.CreateDropTable(blackforestLoot1, 1, 3);
            LootManager.AddContainerToChild(Ruins4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruins4DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(Ruins4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(Ruins4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(Ruins4_Prefab, "MWL_Ruins4_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Ruins4_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest, // Modify as needed
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 500,
                MaxDistance = 2000,
                InForest = true,
                ForestTresholdMin = 0,
                ForestTrasholdMax = 1,

            }));
            #endregion

            #region RuinsArena1
            DropTable ruinsArena1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            LootManager.AddContainerToChild(RuinsArena1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruinsArena1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsArena1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena1_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena1_Prefab, "MWL_RuinsArena1_Spawner5", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsArena1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 1000,
                MaxDistance = 2000,
                InForest = false,
                //ForestTrasholdMax = 1,
                ForestTresholdMin = 3,
            }));
            #endregion

            #region RuinsCastle1
            DropTable ruinsCastle1DropTable = LootManager.CreateDropTable(blackforestLoot1, 2, 3);
            LootManager.AddContainerToChild(RuinsCastle1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruinsCastle1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCastle1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle1_Prefab, "MWL_RuinsCastle1_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 500,
                MaxDistance = 2000,
                InForest = true,
                ForestTrasholdMax = 1,
                ForestTresholdMin = 0,
            }));
            #endregion

            #region RuinsChurch1
            DropTable ruinsChurch1DropTable = LootManager.CreateDropTable(churchLoot1, 2, 4);
            LootManager.AddContainerToChild(RuinsChurch1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruinsChurch1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsChurch1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsChurch1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsChurch1_Prefab, "MWL_RuinsChurch1_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsChurch1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_church",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 1000,
                MaxDistance = 2000,
                InForest = true,
                ForestTrasholdMax = 1,
                ForestTresholdMin = 0,
            }));
            #endregion

            #region RuinsGarden1
            DropTable ruinsGarden1DropTable = LootManager.CreateDropTable(swampLoot1, 2, 4);
            LootManager.AddContainerToChild(RuinsGarden1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone", ruinsGarden1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsGarden1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsGarden1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsGarden1_Prefab.gameObject.transform.FindDeepChild("Creature").gameObject, MaterialReplacer.ShaderType.CustomCreature);
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsGarden1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Swamp,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_garden",
                MinDistanceFromSimilar = 256,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                //MinDistance = 500,
                MaxDistance = 4000,
            }));
            #endregion

            #region RuinsGate1
            DropTable ruinsGate1DropTable = LootManager.CreateDropTable(blackforestLoot1, 2, 3);
            LootManager.AddContainerToChild(RuinsGate1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone", ruinsGate1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsGate1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            //MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsGate1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsGate1_Prefab, "MWL_RuinsGate1_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsGate1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 50,
                MinDistance = 1000,
                MaxDistance = 2000,
            }));
            #endregion


            #region RuinsTower3
            DropTable ruinsTower3DropTable = LootManager.CreateDropTable(blackforestLoot1, 2, 3);
            LootManager.AddContainerToChild(RuinsTower3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_wood", ruinsTower3DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsTower3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsTower3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower3_Prefab, "MWL_RuinsTower3_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest, // Modify as needed
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 7.5f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 1000,
                MaxDistance = 2000,
            }));
            #endregion

            #region Shrine1
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Shrine1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 50,
                Priotized = true,
                ExteriorRadius = 5f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Ruins",
                MinDistanceFromSimilar = 1000f,
                MaxDistance = 250f,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                InForest = false,
                ForestTresholdMin = 1,
                //ForestTrasholdMax = 1,
            }));
            #endregion

            #region Tavern1
            DropTable tavern1DropTable = LootManager.CreateDropTable(tavernLoot1, 2, 3);
            LootManager.AddContainerToChild(Tavern1_Prefab, "loot_chest_wood", tavern1DropTable);
            MaterialReplacer.RegisterGameObjectForMatSwap(Tavern1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(Tavern1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "MWL_Tavern1_Spawner1", "Greydwarf_Elite");
            CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "MWL_Tavern1_Spawner2", "Greydwarf");
            CreatureAdder.AddCreatureSpawnerToChild(Tavern1_Prefab, "MWL_Tavern1_Spawner3", "Greydwarf");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Tavern1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 50, // Adjust as per requirement
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_tavern",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 1000,
                MaxDistance = 2000,
            }));
            #endregion

            #region Cave1
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(Cave1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest, // Modify as needed
                Quantity = 50, // Adjust as per requirement
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Tavern",
                //MinDistanceFromSimilar = 1500f,
                MinDistance = 500f,
                MaxTerrainDelta = 2f,
                MinAltitude = 0f
            }));
            #endregion

            #region RuinsArena2
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsArena2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest, // Modify as needed
                Quantity = 50, // Adjust as per requirement
                Priotized = true,
                ExteriorRadius = 10f,
                ClearArea = true,
                RandomRotation = true,
                // Group = "Tavern",
                //MinDistanceFromSimilar = 1500f,
                MinDistance = 500f,
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
