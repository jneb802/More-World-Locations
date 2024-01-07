using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using Jotunn.Managers;

namespace MoreWorldLocations
{
    public class CreatureAdder : MonoBehaviour
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


    }
}
