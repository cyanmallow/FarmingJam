using UnityEngine;

[CreateAssetMenu(fileName = "CropType", menuName = "CropType")]
public class CropType : ScriptableObject
{
    public string cropName;
    public int cost;
    public float GrowthTime; // in days
    public int quantity;
    public int price;


}
