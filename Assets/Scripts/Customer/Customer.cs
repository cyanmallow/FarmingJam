using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer : ScriptableObject
{
    public string customerName;
    public GameObject prefab;
    public int budget;
    public Item favouriteItem;
    public float trust;
}
