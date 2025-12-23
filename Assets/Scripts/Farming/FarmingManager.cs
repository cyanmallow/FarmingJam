using UnityEngine;

public enum CropState { NotPlanted, Growing, ReadyToHarvest }
public class FarmingManager : MonoBehaviour
{
    public CropState state = CropState.NotPlanted;
    public bool isWatered = false;
    public float growthProgress = 0f;
    public CropType currentCropType;

    public void OnInteract()
    {
        // TODO: interact with the farming field


        // use watering cans to water crops


    }

    public void PlantCrop(CropType cropType)
    {
        if (state == CropState.NotPlanted)
        {
            Debug.Log("Planting " + cropType.ToString());
            state = CropState.Growing;
            // set current crop type
            currentCropType = cropType;

            // minus crop cost from player inventory

        }
    }

    public void CropGrowing(CropType currentCropType)
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
    public void HarvestCrop(CropType currentCropType)
    {
        if (state == CropState.ReadyToHarvest)
        {
            Debug.Log("Harvesting crop");
            state = CropState.NotPlanted;
            growthProgress = 0f;
            //Todo: add crop to inventory

        }

    }

    public void WaterCrop()
    {
        if (!isWatered)
        {
            isWatered = true;
            Debug.Log("Crop watered");

        }
    }
}