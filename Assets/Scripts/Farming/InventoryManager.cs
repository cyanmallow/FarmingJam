using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coin = 100;
    public int cropQuantity = 0;

    //display coin on UI
    public Transform coinUI;

    // inventory list
    public List<InventorySlot> inventory = new List<InventorySlot>();

    public List<CropType> CropDatabase;

    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject buttonPrefab;


    private void Awake()
    {
        UpdateCoinUI();
        // create inventoryslot for each crop type
        foreach (CropType cropType in CropDatabase)
        {
            inventory.Add(new InventorySlot(cropType, 0));
            Debug.Log($"Created new cropType in inventory and added 0 of {cropType.name}.");

        }
    }

    private void UpdateCoinUI()
    {
        coinUI.GetComponent<TextMeshProUGUI>().text = "Coins: " + coin.ToString();
    }

    // Method to deduct coins when planting a crop
    public void DeductCoins()
    {
        FarmingManager farmingManager = CropSelectionUI.Instance.activeFarmingManager;

        if (farmingManager == null)
        {
            Debug.Log("No active FarmingManager");
        }

        CropType currentCropType = farmingManager.currentCropType;
        if (currentCropType == null)
        {
            Debug.LogError("CurrentCropType is not set. Cannot deduct coins.");
            return;
        }

        coin -= currentCropType.cost;
        UpdateCoinUI();
        Debug.Log($"Deducted {farmingManager.currentCropType.cost} coins. Remaining coins: {coin}");
    } 

    public void AddCoin(int amount)
    {
        coin += amount;
    }

    public InventorySlot GetInventorySlot(CropType cropType)
    {
        if (cropType == null)
        {
            Debug.Log("GetInventorySlot called with NULL cropType!");
            return null;
        }
        return inventory.Find(s => s.cropType == cropType);
    }

    public void AddCrop(CropType cropType)
    {
        InventorySlot slot = GetInventorySlot(cropType);
        if (cropType == null)
        {
            Debug.LogError("AddCrop called with NULL cropType!");
            return;
        }

        if (slot != null)
        {
            slot.totalQuantity += cropType.amountGainedPerHarvested;
            Debug.Log($"To an existing cropType in inventory, added {cropType.amountGainedPerHarvested} of {cropType.name}.");
            Debug.Log($"Inventory has " + slot.totalQuantity + " " + cropType.cropName);
        }
        else
        {
            inventory.Add(new InventorySlot(cropType, cropType.amountGainedPerHarvested));
            Debug.Log($"Created new cropType in inventory and added {cropType.amountGainedPerHarvested} of {cropType.name}.");
            Debug.Log($"Inventory has " + cropType.amountGainedPerHarvested + " " + cropType.cropName);
        }
    }
    public void RemoveCrop(CropType cropType, int quantity)
    {
        InventorySlot slot = GetInventorySlot(cropType);
        if (cropType == null)
        {
            Debug.LogError("RemoveCrop called with NULL cropType!");
            return;
        }

        if (slot != null)
        {
            slot.Remove(quantity);
            Debug.Log($"Inventory has " + slot.totalQuantity + " " + cropType.cropName);
        }
        else
        {
            Debug.Log("None of this item to remove");
        }
    }

    // list things in inventory
    public void ListInventoryItems()
    {
        // code to list items in inventory
        foreach (CropType cropType in CropDatabase)
        {
            InventorySlot slot = GetInventorySlot(cropType);
            Debug.Log("Inventory has " + slot.totalQuantity + " " + cropType.cropName);

            if (slot.totalQuantity <= 0)
                continue;

            // Create UI button
            GameObject buttonGO = Instantiate(buttonPrefab, contentParent);

            // Get your custom button script
            DisplayItems button = buttonGO.GetComponent<DisplayItems>();

            // Fill data
            button.UpdateButtonContent(cropType, slot.totalQuantity);
        }
    }
}
