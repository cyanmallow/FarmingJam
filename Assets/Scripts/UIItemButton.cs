using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour
{
    public TMP_Text label;          
    private int itemIndex;
    CropType cropType;

    public FarmingManager farmingManager;

    void Awake()
    {
        if (label == null)
            label = GetComponentInChildren<TMP_Text>();
    }
    public void Setup(CropType cropType, int index)
    {
        label.text = cropType.cropName;
        itemIndex = index;
    }

    // on click, run farmingManager.PlantCrop with the selected crop type
    public void OnClick()
    {
        farmingManager.PlantCrop(cropType);
        // hide crop selection UI
        farmingManager.cropSelectionUI.SetActive(false);
    }

}
