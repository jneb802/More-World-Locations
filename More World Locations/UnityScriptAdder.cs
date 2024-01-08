using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static DropTable;
using Jotunn.Extensions;

namespace MoreWorldLocations
{
    internal class UnityScriptAdder
    {

        public GameObject GetCreaturePrefab(string prefabName)
        {
            GameObject creaturePrefab = PrefabManager.Cache.GetPrefab<GameObject>(prefabName);
            if (creaturePrefab != null)
            {
                return creaturePrefab;
            }
            else
            {
                Debug.LogWarning($"MoreWorldLocations: Prefab not found for name: {prefabName}");
                return null;
            }
        }

        public void AddCreatureSpawnerToChild(GameObject parentGameObject, string childName, string creaturePrefab)
        {
            // Find the child GameObject by name
            Transform childTransform = parentGameObject.transform.Find(childName);

            // Check if the child was found
            if (childTransform != null)
            {
                // Add the Container component to the child GameObject
                CreatureSpawner creatureSpawner = childTransform.gameObject.AddComponent<CreatureSpawner>();

                // Configure the Container properties
                creatureSpawner.m_creaturePrefab = GetCreaturePrefab(creaturePrefab);
                creatureSpawner.m_maxLevel = 3;
                creatureSpawner.m_minLevel = 1;
                creatureSpawner.m_levelupChance = 10;
                creatureSpawner.m_triggerDistance = 60f;
                creatureSpawner.m_spawnAtDay = true;
                creatureSpawner.m_spawnAtNight = true;
                creatureSpawner.m_spawnInterval = 5;
                creatureSpawner.m_setPatrolSpawnPoint = true;
                creatureSpawner.m_maxGroupSpawned = 1;
                creatureSpawner.m_spawnerWeight = 1f;
            }
            else
            {
                Debug.LogError("MoreWorldLocations: Child GameObject (" + childName + ") not found in parent GameObject (" + parentGameObject + ")");
            }
        }

        // Method to create a DropTable with specified parameters
        public DropTable CreateDropTable(List<string> itemNames, int dropMin, int dropMax)
        {
            DropTable newDropTable = new DropTable
            {
                m_dropMin = dropMin,
                m_dropMax = dropMax,
                m_dropChance = 1.0f
            };

            foreach (var itemName in itemNames)
            {
                // Use Jotunn's PrefabManager to get the prefab for the item
                GameObject itemPrefab = PrefabManager.Cache.GetPrefab<GameObject>(itemName);

                if (itemPrefab != null)
                {
                    DropData dropData = new DropData
                    {
                        m_item = itemPrefab,
                        m_stackMin = 1,
                        m_stackMax = 3,
                        m_weight = 1.0f,   // Assuming equal weight for all items
                        m_dontScale = false
                    };

                    newDropTable.m_drops.Add(dropData);
                }
                else
                {
                    Debug.LogWarning($"MoreWorldLocations: Prefab for {itemName} not found.");
                }
            }

            return newDropTable;
        }

        public void AddContainerToChild(GameObject parentGameObject, string childName, DropTable dropTable)
        {
            // Find the child GameObject by name
            Transform childTransform = parentGameObject.transform.Find(childName);

            // Check if the child was found
            if (childTransform != null)
            {
                // Add the Container component to the child GameObject
                Container container = childTransform.gameObject.AddComponent<Container>();

                // Configure the Container properties
                container.m_defaultItems = dropTable;
                container.m_name = "Chest";
                container.m_width = 4;
                container.m_height = 2;

            }
            else
            {
                Debug.LogError("MoreWorldLocations: Child GameObject (" + childName + ") not found in parent GameObject (" + parentGameObject + ")");
            }
        }

        private void AddDestructibleToChild(GameObject prefab, string destroyedEffect, string destroyedSound)
        {
            var destructible = prefab.GetComponent<Destructible>() ?? prefab.AddComponent<Destructible>();

            // Set up destroyed and hit effects
            GameObject destroyedEffectPrefab = PrefabManager.Cache.GetPrefab<GameObject>("vfx_RockDestroyed");
            GameObject destroyedSoundPrefab = PrefabManager.Cache.GetPrefab<GameObject>("sfx_rock_destroyed");
            GameObject hitEffectPrefab = PrefabManager.Cache.GetPrefab<GameObject>("vfx_RockHit");
            GameObject hitSoundPrefab = PrefabManager.Cache.GetPrefab<GameObject>("sfx_rock_hit");

            destructible.m_destroyedEffect.m_effectPrefabs = new EffectList.EffectData[]
            {
                new EffectList.EffectData { m_prefab = destroyedEffectPrefab },
                new EffectList.EffectData { m_prefab = destroyedSoundPrefab }
            };

            destructible.m_hitEffect.m_effectPrefabs = new EffectList.EffectData[]
            {
                new EffectList.EffectData { m_prefab = hitEffectPrefab },
                new EffectList.EffectData { m_prefab = hitSoundPrefab }
            };
        }


    }
}
