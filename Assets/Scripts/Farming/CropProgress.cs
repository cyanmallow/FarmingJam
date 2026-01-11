using System.Collections.Generic;
using UnityEngine;

public class CropProgress : MonoBehaviour
{

    // inventory slot reference
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public InventoryManager inventoryManager;


    //unlock new crop
    public CropType grass;
    public CropType lettuce;
    public CropType tomato;
    public void Start()
    {
        
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.Log("CropProgress could not find InventoryManager!");
        }
    }

    public void LevelUpCrop(FarmingManager farmingManager)
    {
        if (farmingManager.currentCropType == null)
        {
            Debug.Log("AddCrop called with NULL cropType!");
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

    // unlock new crop types based on level
    public bool IsCropUnlocked(CropType cropType)
    {
        if (cropType == grass)
            return true; // grass is always unlocked
        if (cropType == lettuce)
        {
            InventorySlot grassSlot = inventoryManager.GetInventorySlot(grass);
            if (grassSlot != null && grassSlot.currentLevel >= 2)
                return true;
        }
        if (cropType == tomato)
        {
            InventorySlot grassSlot = inventoryManager.GetInventorySlot(grass);
            if (grassSlot != null && grassSlot.currentLevel >= 3)
                return true;
        }
        return false;
    }
}
