using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using Jotunn.Managers;

namespace MoreWorldLocations
{
    public class CreatureAdder : MonoBehaviour
    {

        public void AddCreatureSpawnerToChild(GameObject parentGameObject, string childName, GameObject creaturePrefab)
        {
            // Find the child GameObject by name
            Transform childTransform = parentGameObject.transform.Find(childName);

            // Check if the child was found
            if (childTransform != null)
            {
                // Add the Container component to the child GameObject
                CreatureSpawner creatureSpawner = childTransform.gameObject.AddComponent<CreatureSpawner>();

                // Configure the Container properties
                creatureSpawner.m_creaturePrefab = creaturePrefab;

            }
            else
            {
                Debug.LogError("Child GameObject not found: " + childName);
            }
        }


    }
}
