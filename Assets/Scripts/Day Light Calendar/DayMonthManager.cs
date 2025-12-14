using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayMonthManager : MonoBehaviour
{
    private LightingManager lightingManager;
    public int currentDay = 1;
    private float timeSpeed = 7.5f; //edit this back to 7.5 after testing
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightingManager = FindObjectOfType<LightingManager>();
        Application.targetFrameRate = 60; // Set target frame rate to 60 FPS
    }

    // Update is called once per frame
    void Update()
    {
        lightingManager.TimeOfDay += Time.deltaTime / timeSpeed;
        lightingManager.TimeOfDay %= 24; // Wrap around after 24 hours
        if (lightingManager.TimeOfDay >= 23.99f)
        {
            currentDay++;
        }

    }
}
