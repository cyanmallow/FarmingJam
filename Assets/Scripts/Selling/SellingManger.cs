using UnityEngine;

public class SellingManger : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Interact()
    {
        // open menu item
        InventoryUI.SetActive(true);
        pauseGame.Pause();
    }
    public void PutItemOnShelf()
    {
        // choose item to put on shelf
    }
}
