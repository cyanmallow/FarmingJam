using System;
using UnityEngine;

public class DisplayItems : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject ItemButtonPrefab;
    void OnEnable()
    {
        inventoryManager.ListInventoryItems();
        //SetUpButtons();
    }

    //private void SetUpButtons()
    //{
    //    foreach (Transform child in transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //    foreach (InventorySlot slot in inventoryManager.inventory)
    //    {
    //        Instantiate(ItemButtonPrefab, transform);
    //        //UpdateButtonContent();
    //    }
    //}

    public void UpdateButtonContent(CropType cropType, int quantity)
    {
        cropType = cropType;
        quantity = quantity;
    }

}
