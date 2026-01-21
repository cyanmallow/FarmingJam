using UnityEngine;

public class GoInside : MonoBehaviour
{
    [SerializeField] GameObject outsideHouseModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // if the object colliding has the tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            outsideHouseModel.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            outsideHouseModel.SetActive(true);
        }
    }
}
