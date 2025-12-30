using UnityEngine;

public enum CropState { NotPlanted, Growing, ReadyToHarvest }
public class FarmingManager : MonoBehaviour
{
    public CropState state = CropState.NotPlanted;
    public bool isWatered = false;
    public float growthProgress = 0f;
    public CropType currentCropType;

    [SerializeField] private InventoryManager inventoryManager;

    public void Interact()
    {
        switch (state)
        {
            case CropState.NotPlanted:
                Debug.Log("Crop is not planted. Planting crop...");
                if (currentCropType != null)
                    PlantCrop(currentCropType);
                break;

            case CropState.Growing:
                Debug.Log("Crop is growing. Please wait...");
                WaterCrop();
                break;

            case CropState.ReadyToHarvest:
                Debug.Log("Crop is ready to harvest. Harvesting crop...");
                HarvestCrop(currentCropType);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Farm"))
        {
            // show UI prompt to interact
            Debug.Log("Player entered farm area. You can interact with the farm.");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Farm"))
        {
            Debug.Log("Player exited farm area.");
        }
    }


    public void PlantCrop(CropType cropType)
    {
         Debug.Log("Planting " + cropType.ToString());
         state = CropState.Growing;
         // set current crop type
         currentCropType = cropType;

        // minus crop cost from player inventory
        inventoryManager.DeductCoins();
    }

    public void AdvanceGrowth(CropType currentCropType)
    {
        // countdown growth time by days
        if (state == CropState.Growing)
        {
            growthProgress += 1f; // TODO: change to actual time passage
            Debug.Log("Crop growing: " + growthProgress);
            // once growth time = GrowthTime, change state to ReadyToHarvest
            if (growthProgress >= currentCropType.GrowthTime) // TODO: change to cropType.GrowthTime
                state = CropState.ReadyToHarvest;
        }
    }

    private void FixedUpdate()
    {
        AdvanceGrowth(currentCropType);
    }


    public void WaterCrop()
    {
        if (state != CropState.Growing)
            return;
        isWatered = true;
        Debug.Log("Crop watered.");
    }

    public void HarvestCrop(CropType cropType)
    {
        inventoryManager.AddCrop(cropType);
        state = CropState.NotPlanted;
        currentCropType = null;
        isWatered = false;
        growthProgress = 0f;
        Debug.Log("Crop harvested.");
    }


    public void PutOnShelf(CropType cropType)
    {
        Debug.Log($"Put something on shelf...");
    }


    // on new day add growth to crops
    public void OnNewDay()
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
        }
        isWatered = false; // reset watered status for next day
    }

    // update visuals based on state

}