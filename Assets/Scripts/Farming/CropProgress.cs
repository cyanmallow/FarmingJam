using System.Collections.Generic;
using UnityEngine;

public class CropProgress : MonoBehaviour
{

    // inventory slot reference
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public FarmingManager farmingManager;
    public InventoryManager inventoryManager;

    public void Start()
    {
        farmingManager = FindObjectOfType<FarmingManager>();

        if (farmingManager == null)
        {
            Debug.Log("CropProgress could not find FarmingManager!");
        }
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.Log("CropProgress could not find InventoryManager!");
        }
    }

    public void LevelUpCrop()
    {
        if (farmingManager.currentCropType == null)
        {
            Debug.LogError("AddCrop called with NULL cropType!");
            return;
        }


        InventorySlot slot = inventoryManager.GetInventorySlot(farmingManager.currentCropType);

        if (slot != null)
        {
            slot.currentLevel += 1;
            Debug.Log("Crop at level " + slot.currentLevel);
        }
        else
        {
            Debug.Log("slot nulled, Leveled up a crop that does not exist in the inventory");
        }
    }
}
