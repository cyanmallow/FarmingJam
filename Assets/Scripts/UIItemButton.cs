using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour
{

    public TMP_Text itemLevelText;
    public GameObject lockIcon;

    //public List<InventorySlot> inventory = new List<InventorySlot>();
    //public InventoryManager inventoryManager;
    public CropProgress cropProgress;
    public CropType thisButtonCropType;

    void Awake()
    {
        //inventoryManager = FindObjectOfType<InventoryManager>();
        //if (inventoryManager == null)
        //{
        //    Debug.Log("CropProgress could not find InventoryManager!");
        //}

        cropProgress = FindObjectOfType<CropProgress>();

        if (cropProgress == null)
        {
            Debug.Log("InventoryManager could not find cropProgress!");
        }


    }
    private void OnEnable()
    {
        if (cropProgress.IsCropUnlocked(thisButtonCropType))
            lockIcon.SetActive(false);
        else
            lockIcon.SetActive(true);

    }


    // on click, run farmingManager.PlantCrop with the selected crop type
    public void OnClick(CropType cropType)
    {
        if (cropProgress.IsCropUnlocked(cropType)){
            CropSelectionUI.Instance.activeFarmingManager.PlantCrop(cropType);
            CropSelectionUI.Instance.activeFarmingManager.cropSelectionUI.SetActive(false);
        }

        else
        {
            Debug.Log("Crop type " + cropType.cropName + " is locked and cannot be planted.");

        }
    }

}
