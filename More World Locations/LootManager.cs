using UnityEngine;
using System.Collections.Generic;
using static DropTable;
using System.ComponentModel;
using Jotunn.Managers;

public class LootManager : MonoBehaviour
{
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
                Debug.LogWarning($"Prefab for {itemName} not found.");
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
            Debug.LogError("Child GameObject not found: " + childName);
        }
    }

}
