using UnityEngine;

[CreateAssetMenu(fileName = "CropType", menuName = "CropType")]
public class CropType : ScriptableObject
{
    public string cropName;
    public int cost;
    public float GrowthTime; // in days
    //public int quantity;
    public int price;

    public GameObject seedPrefab;
    public GameObject growingPrefab;
    public GameObject harvestPrefab;

    //public CropType harvestCropType;
    public int amountGainedPerHarvested;
    
}
