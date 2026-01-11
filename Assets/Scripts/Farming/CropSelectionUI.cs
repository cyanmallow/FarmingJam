using UnityEngine;

public class CropSelectionUI : MonoBehaviour
{
    public static CropSelectionUI Instance;
    public FarmingManager activeFarmingManager;

    private void Awake()
    {

        Instance = this;
        Debug.Log("CropSelectionUI Instance set");
    }
}
