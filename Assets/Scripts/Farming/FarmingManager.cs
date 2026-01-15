using System.Collections.Generic;
using UnityEngine;

public enum CropState { NotPlanted, Growing, ReadyToHarvest }
public class FarmingManager : MonoBehaviour
{
    public CropState state = CropState.NotPlanted;
    public bool isWatered = false;
    public float growthProgress = 0f;
    public CropType currentCropType;

    [SerializeField] private InventoryManager inventoryManager;

    // different game objects for different crop states
    [SerializeField] private GameObject NotPlantedPlot;
    [SerializeField] private GameObject GrowingPlot;
    [SerializeField] private GameObject ReadyToHarvestPlot;



    public CropProgress cropProgress;

    // choose crop to plant
    public GameObject cropSelectionUI;

    public void Start()
    {
        ChangeVisual();
        cropProgress = FindObjectOfType<CropProgress>();

        if (cropProgress == null)
        {
            Debug.Log("InventoryManager could not find cropProgress!");
        }
    }
    public void Interact()
    {
        switch (state)
        {
            case CropState.NotPlanted:
                ChooseCrop();
                break;

            case CropState.Growing:
                Debug.Log("Crop is growing. Please wait...");
                WaterCrop();
                break;

            case CropState.ReadyToHarvest:
                Debug.Log("Crop is ready to harvest. Harvesting crop...");
                HarvestCrop();
                break;
        }
    }

    public void ChooseCrop()
    {
        cropSelectionUI.SetActive(true);

        CropSelectionUI.Instance.activeFarmingManager = this;
        Debug.Log("CropSelectionUI.Instance = " + CropSelectionUI.Instance);

    }

    public void PlantCrop(CropType cropType)
    {
        //cropSelectionUI.SetActive(false);

        state = CropState.Growing;
        currentCropType = cropType;
        Debug.Log("Planting " + cropType.ToString());
        ChangeVisual();

        // minus crop cost from player inventory
        inventoryManager.DeductCoins();
    }

    public void AdvanceGrowth()
    {
        if (state != CropState.Growing)
            return;
        if (!isWatered)
            return;

        growthProgress++;

        if (growthProgress >= currentCropType.GrowthTime)
        {
            state = CropState.ReadyToHarvest;
            Debug.Log("Crop is ready to harvest!");
            ChangeVisual();
        }
        isWatered = false;
    }

    public void WaterCrop()
    {
        if (state != CropState.Growing)
            return;
        isWatered = true;
        Debug.Log("Crop watered.");
    }

    public void HarvestCrop()
    {
        if (currentCropType == null)
        {
            return;
        }
        inventoryManager.AddCrop(currentCropType);

        cropProgress.LevelUpCrop(this);
        isWatered = false;
        growthProgress = 0f;
        Debug.Log("Crop harvested.");

        currentCropType = null;
        state = CropState.NotPlanted;

        ChangeVisual();
    }

    // update visuals based on state
    private void ChangeVisual()
    {
        NotPlantedPlot.SetActive(state == CropState.NotPlanted);
        GrowingPlot.SetActive(state == CropState.Growing);
        ReadyToHarvestPlot.SetActive(state == CropState.ReadyToHarvest);
    }
}