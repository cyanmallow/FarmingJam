using System.Collections.Generic;
using UnityEngine;

public class CropProgress : MonoBehaviour
{

    // inventory slot reference
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public InventoryManager inventoryManager;
    public UIItemButton uiItemButton;


    //unlock new crop
    public CropType grass;
    public CropType lettuce;
    public CropType tomato;
    public CropType spinach;
    public CropType cabbage;
    public CropType pepper;
    public CropType eggplant;

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
            Debug.Log("LevelUpCrop called with NULL cropType!");
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
        //uiItemButton.Refresh();
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

        if (cropType == spinach)
        {
            InventorySlot lettuceSlot = inventoryManager.GetInventorySlot(lettuce);
            if (lettuceSlot != null && lettuceSlot.currentLevel >= 2)
                return true;
        }

        if (cropType == cabbage)
        {
            InventorySlot lettuceSlot = inventoryManager.GetInventorySlot(lettuce);
            if (lettuceSlot != null && lettuceSlot.currentLevel >= 3)
                return true;
        }
        if (cropType == pepper)
        {
            InventorySlot tomatoSlot = inventoryManager.GetInventorySlot(tomato);
            InventorySlot lettuceSlot = inventoryManager.GetInventorySlot(lettuce);
            if (tomatoSlot != null && tomatoSlot.currentLevel >= 2 && lettuceSlot != null && lettuceSlot.currentLevel >= 2)
                return true;
        }
        if (cropType == eggplant)
        {
            InventorySlot pepperSlot = inventoryManager.GetInventorySlot(pepper);
            if (pepperSlot != null && pepperSlot.currentLevel >= 2)
                return true;
        }
        return false;
    }
}
