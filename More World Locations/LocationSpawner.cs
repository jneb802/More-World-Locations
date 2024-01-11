﻿using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Extensions;
using Jotunn.Managers;
using Jotunn.Utils;
using PieceManager;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using SimpleJson;
using static MoreWorldLocations.LocationSpawner;


namespace MoreWorldLocations
{
    internal class LocationSpawner
    {

        private LootManager LootManager = new LootManager();
        private CreatureAdder CreatureAdder = new CreatureAdder();
        private UnityScriptAdder UnityScriptAdder = new UnityScriptAdder();

        public AssetBundle locationsBundle;
        public AssetBundle locationsBundle2;
        public GameObject Ruins1_Prefab;
        public GameObject Ruins2_Prefab;
        public GameObject Ruins3_Prefab;
        public GameObject Ruins4_Prefab;
        public GameObject RuinsArena1_Prefab;
        public GameObject RuinsCastle1_Prefab;
        public GameObject RuinsChurch1_Prefab;
        public GameObject RuinsGarden1_Prefab;
        public GameObject RuinsTower3_Prefab;
        public GameObject Shrine1_Prefab;
        public GameObject Tavern1_Prefab;
        public GameObject RuinsCathedral1_Prefab;
        public GameObject Cave2_Prefab
        public GameObject RuinsArena2_Prefab;
        public GameObject RuinsArena3_Prefab;
        public GameObject RuinsCastle2_Prefab;
        public GameObject RuinsCastle3_Prefab;
        public GameObject RuinsCastle4_Prefab;
        public GameObject RuinsTower6_Prefab;
        public GameObject RuinsTower8_Prefab;
        public GameObject WoodHideout1_Prefab;
        public GameObject WoodTower1_Prefab;
        public GameObject WoodTower2_Prefab;

        public void LoadAssets()
        {
            locationsBundle = AssetUtils.LoadAssetBundleFromResources("mwl_bundle");
            locationsBundle2 = AssetUtils.LoadAssetBundleFromResources("mwl_bundle2");
            Ruins1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins1");
            Ruins2_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins2");
            Ruins3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins3");
            Ruins4_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Ruins4");
            RuinsArena1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsArena1");
            RuinsCastle1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsCastle1");
            RuinsChurch1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsChurch1");
            RuinsGarden1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsGarden1");
            RuinsTower3_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_RuinsTower3");
            Shrine1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Shrine1");
            Tavern1_Prefab = locationsBundle?.LoadAsset<GameObject>("MWL_Tavern1");
            RuinsCathedral1_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsCathedral1");
            Cave2_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_Cave2");
            RuinsArena2_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsArena2");
            RuinsArena3_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsArena3");
            RuinsCastle2_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsCastle2");
            RuinsCastle3_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsCastle3");
            RuinsCastle4_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsCastle4");
            RuinsTower6_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsTower6");
            RuinsTower8_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_RuinsTower8");
            WoodHideout1_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_WoodHideout1");
            WoodTower1_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_WoodTower1");
            WoodTower2_Prefab = locationsBundle2?.LoadAsset<GameObject>("MWL_WoodTower2");

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
                RuinsGate1_Prefab == null || RuinsTower3_Prefab == null || Shrine1_Prefab == null || Tavern1_Prefab == null)
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
                MinDistanceFromSimilar = 512,
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
                MinDistanceFromSimilar = 512,
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
                //Group = "Ruins_tavern",
                MinDistanceFromSimilar = 512,
                MaxTerrainDelta = 1f,
                MinAltitude = 0f,
                MinDistance = 1000,
                MaxDistance = 2000,
            }));
            #endregion

            #region Cathedral1
            DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            LootManager.AddContainerToChild(RuinsCathedral1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            LootManager.AddContainerToChild(RuinsCathedral1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCathedral1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCathedral1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCathedral1_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner6", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCathedral1_Prefab, "MWL_Cathedral1_Spawner7", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCathedral1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 30,
                ClearArea = true,
                RandomRotation = false,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MaxTerrainDelta = 1f,
                MinAltitude = 8,
                MinDistance = 1500,
                MaxDistance = 3000,
            }));
            #endregion

            #region Cave2
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsCave2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsCave2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCave2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCave2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCave2_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            //CreatureAdder.AddCreatureSpawnerToChild(RuinsCave2_Prefab, "MWL_Cathedral1_Spawner1", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCave2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows, // Modify as needed
                Quantity = 10, // Adjust as per requirement
                Priotized = true,
                ExteriorRadius = 18,
                ClearArea = true,
                RandomRotation = false,
                Group = "Environment_medium",
                MinDistanceFromSimilar = 256,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 500,
                MaxDistance = 2000,
            }));
            #endregion

            #region RuinsArena2
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner6", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner7", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner8", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner9", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena2_Prefab, "MWL_Cathedral1_Spawner10", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsArena2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Plains,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 20f,
                ClearArea = true,
                RandomRotation = false,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MaxTerrainDelta = 1f,
                MinAltitude = 0,
                MinDistance = 2500,
                MaxDistance = 4000,
            }));
            #endregion

            #region RuinsArena3
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsArena3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsArena3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena3_Prefab, "MWL_Cathedral1_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena3_Prefab, "MWL_Cathedral1_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena3_Prefab, "MWL_Cathedral1_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsArena3_Prefab, "MWL_Cathedral1_Spawner4", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsArena3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 25,
                Priotized = true,
                ExteriorRadius = 15,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_small",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 500,
                MaxDistance = 2000,
            }));
            #endregion

            #region RuinsCastle2
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsCastle2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsCastle2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCastle2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner6", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner7", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner8", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner9", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle2_Prefab, "MWL_RuinsCastle2_Spawner10", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.Plains,
                BiomeArea = Heightmap.BiomeArea.Median,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 35,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 3500,
                MaxDistance = 6000,
            }));
            #endregion

            #region RuinsCastle3
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCastle3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle3_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle3_Prefab.gameObject.transform.FindDeepChild("Creature").gameObject, MaterialReplacer.ShaderType.CustomCreature);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle3_Prefab, "MWL_RuinsCastle3_Spawner5", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle3_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 20,
                SlopeRotation = true,
                ClearArea = true,
                RandomRotation = false,
                SnapToWater = true,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 1500,
                MaxDistance = 3000,
            }));
            #endregion

            #region RuinsCastle4
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsCastle4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsCastle4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsCastle4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle4_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsCastle4_Prefab.gameObject.transform.FindDeepChild("Creature").gameObject, MaterialReplacer.ShaderType.CustomCreature);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle4_Prefab, "MWL_RuinsCastle4_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle4_Prefab, "MWL_RuinsCastle4_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle4_Prefab, "MWL_RuinsCastle4_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle4_Prefab, "MWL_RuinsCastle4_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsCastle4_Prefab, "MWL_RuinsCastle4_Spawner6", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsCastle4_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 30,
                ClearArea = true,
                RandomRotation = true,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MaxTerrainDelta = 1,
                MinAltitude = -5,
                MaxAltitude = 0,
                MinDistance = 2500,
                MaxDistance = 4000,
            }));
            #endregion

            #region RuinsTower6
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsTower6_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsTower6_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsTower6_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner5", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner6", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner7", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner8", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner9", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower6_Prefab, "MWL_RuinsTower6_Spawner10", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower6_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Edge,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 15,
                ClearArea = true,
                RandomRotation = true,
                SnapToWater = true,
                Group = "Ruins_large",
                MinDistanceFromSimilar = 1028,
                MinAltitude = -5,
                MaxAltitude = -1,
                MinDistance = 1500,
                MaxDistance = 3000,
            }));
            #endregion

            #region RuinsTower8
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(RuinsTower8_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsTower8_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(RuinsTower8_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower8_Prefab, "MWL_RuinsTower8_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower8_Prefab, "MWL_RuinsTower8_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(RuinsTower8_Prefab, "MWL_RuinsTower8_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(RuinsTower8_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Edge,
                Quantity = 10,
                Priotized = true,
                ExteriorRadius = 12,
                ClearArea = true,
                RandomRotation = true,
                SnapToWater = true,
                Group = "Ruins_medium",
                MinDistanceFromSimilar = 256,
                MaxTerrainDelta = 1,
                MinAltitude = -5,
                MaxAltitude = -1,
                MinDistance = 500,
                MaxDistance = 2000,
            }));
            #endregion

            #region WoodHideout1
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(WoodHideout1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(WoodHideout1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(WoodHideout1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodHideout1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodHideout1_Prefab.gameObject.transform.FindDeepChild("Vegetation").gameObject, MaterialReplacer.ShaderType.VegetationShader);
            CreatureAdder.AddCreatureSpawnerToChild(WoodHideout1_Prefab, "MWL_WoodHideout1_Prefab_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodHideout1_Prefab, "MWL_WoodHideout1_Prefab_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodHideout1_Prefab, "MWL_WoodHideout1_Prefab_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodHideout1_Prefab, "MWL_WoodHideout1_Prefab_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodHideout1_Prefab, "MWL_WoodHideout1_Prefab_Spawner5", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(WoodHideout1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Median,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 20,
                ClearArea = true,
                RandomRotation = true,
                Group = "Environment_medium",
                MinDistanceFromSimilar = 256,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 500,
                MaxDistance = 2000,
            }));
            #endregion

            #region WoodTower1
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(WoodTower1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodTower1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower1_Prefab, "MWL_WoodTower1_Prefab_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower1_Prefab, "MWL_WoodTower1_Prefab_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower1_Prefab, "MWL_WoodTower1_Prefab_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower1_Prefab, "MWL_WoodTower1_Prefab_Spawner4", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower1_Prefab, "MWL_WoodTower1_Prefab_Spawner5", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(WoodTower1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Edge,
                Quantity = 10,
                Priotized = true,
                ExteriorRadius = 8,
                ClearArea = true,
                RandomRotation = true,
                Group = "Wood_small",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 5,
                MinAltitude = 0,
                MinDistance = 500,
                MaxDistance = 2000,
            }));
            #endregion

            #region WoodTower2
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(RuinsArena2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(WoodTower2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodTower2_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower2_Prefab, "MWL_WoodTower2_Prefab_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower2_Prefab, "MWL_WoodTower2_Prefab_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodTower2_Prefab, "MWL_WoodTower2_Prefab_Spawner3", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(WoodTower2_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Edge,
                Quantity = 10,
                Priotized = true,
                ExteriorRadius = 8,
                ClearArea = true,
                RandomRotation = true,
                Group = "Wood_small",
                MinDistanceFromSimilar = 128,
                MaxTerrainDelta = 5,
                MinAltitude = 0,
                MinDistance = 1500,
                MaxDistance = 3000,
            }));
            #endregion

            #region WoodVillage1
            //DropTable tavern1DropTable = LootManager.CreateDropTable(meadowsLoot2, 2, 3);
            //LootManager.AddContainerToChild(WoodVillage1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone1", meadowsLoot2);
            //LootManager.AddContainerToChild(WoodVillage1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, "loot_chest_stone2", meadowsLoot2);
            MaterialReplacer.RegisterGameObjectForMatSwap(WoodVillage1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodVillage1_Prefab.gameObject.transform.FindDeepChild("Blueprint").gameObject, MaterialReplacer.ShaderType.PieceShader);
            MaterialReplacer.RegisterGameObjectForShaderSwap(WoodVillage1_Prefab.gameObject.transform.FindDeepChild("Creature").gameObject, MaterialReplacer.ShaderType.CustomCreature);
            CreatureAdder.AddCreatureSpawnerToChild(WoodVillage1_Prefab, "MWL_WoodTower2_Prefab_Spawner1", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodVillage1_Prefab, "MWL_WoodTower2_Prefab_Spawner2", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodVillage1_Prefab, "MWL_WoodTower2_Prefab_Spawner3", "Skeleton");
            CreatureAdder.AddCreatureSpawnerToChild(WoodVillage1_Prefab, "MWL_WoodTower2_Prefab_Spawner4", "Skeleton");
            ZoneManager.Instance.AddCustomLocation(new CustomLocation(WoodVillage1_Prefab, fixReference: false, new LocationConfig
            {
                Biome = Heightmap.Biome.BlackForest,
                BiomeArea = Heightmap.BiomeArea.Edge,
                Quantity = 5,
                Priotized = true,
                ExteriorRadius = 19,
                ClearArea = true,
                RandomRotation = true,
                Group = "Wood_medium",
                MinDistanceFromSimilar = 256,
                MaxTerrainDelta = 1,
                MinAltitude = 0,
                MinDistance = 2500,
                MaxDistance = 4000,
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
