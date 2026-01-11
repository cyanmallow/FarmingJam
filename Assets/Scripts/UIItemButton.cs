using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour
{

    public TMP_Text itemLevelText;
    public GameObject lockIcon;

    private int itemIndex;

    public List<InventorySlot> inventory = new List<InventorySlot>();
    public InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.Log("CropProgress could not find InventoryManager!");
        }
    }

    // on click, run farmingManager.PlantCrop with the selected crop type
    public void OnClick(CropType cropType)
    {
        CropSelectionUI.Instance.activeFarmingManager.PlantCrop(cropType);
        CropSelectionUI.Instance.activeFarmingManager.cropSelectionUI.SetActive(false);
    }

}
