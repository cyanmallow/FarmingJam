using System.Collections.Generic;
using UnityEngine;

public class PopulateItemPrefabs : MonoBehaviour
{
    [Header("References")]
    public Transform contentParent;     // Panel with Layout Group
    public GameObject buttonPrefab;     // Your Button prefab

    [Header("Crop Data")]
    public List<CropType> items = new List<CropType>();

    void OnEnable()
    {
        PopulateList();
    }

    public void PopulateList()
    {
        // Clear existing items
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Create new items
        for (int i = 0; i < items.Count; i++)
        {
            GameObject buttonGO = Instantiate(buttonPrefab, contentParent);

            UIItemButton itemButton = buttonGO.GetComponent<UIItemButton>();
            itemButton.Setup(items[i], i);
        }
    }
}

