using UnityEngine;

public class CustomerBuying : MonoBehaviour
{
    [SerializeField] private float buyingDuration = 3.0f; // Duration the customer spends buying
    private int itemBuyingCount; // Number of items the customer is buying
    private CropType itemBuyingType;

    public InventoryManager inventoryManager;


    public void SetItemBuying(CropType cropType, int count)
    {
        itemBuyingType = cropType;
        itemBuyingCount = count;
    }
    public void StartBuying()
    {
        // minus items from inventory
        inventoryManager.RemoveCrop(itemBuyingType, itemBuyingCount);
        // add coins to player
        inventoryManager.AddCoin(itemBuyingType.price * itemBuyingCount);
        Debug.Log("Customer is buying " + itemBuyingCount + " of " + itemBuyingType.cropName);
    }
}
