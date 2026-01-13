using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour
{

    public TMP_Text itemLevelText;
    public GameObject lockIcon;
    public CropProgress cropProgress;
    public CropType thisButtonCropType;

    public GameObject levelTextGO;
    public InventoryManager inventoryManager;

    private void OnEnable()
    {
        if (cropProgress.IsCropUnlocked(thisButtonCropType))
            lockIcon.SetActive(false);
        else
            lockIcon.SetActive(true);

        Refresh();

    }

    public void Refresh()
    {
        // update the level
        if (inventoryManager.GetInventorySlot(thisButtonCropType) == null)
            levelTextGO.GetComponent<TMP_Text>().text = "";
        else
            levelTextGO.GetComponent<TMP_Text>().text = "Level " + inventoryManager.GetInventorySlot(thisButtonCropType).currentLevel.ToString();
    }

    // on click, run farmingManager.PlantCrop with the selected crop type
    public void OnClick(CropType cropType)
    {
        Refresh();

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
