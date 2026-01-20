using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer : ScriptableObject
{
    public string customerName;
    public GameObject designPrefab;
    public int budget;
    public CropType favouriteItem;
    public float trust;
}
