using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayMonthManager : MonoBehaviour
{
    private LightingManager lightingManager;
    public int currentDay = 1;
    private float timeSpeed = 6.5f; //edit this back to 7.5 after testing

    // display day on UI
    public Transform dateUI;

    // farming manager reference
    public GameObject farmingManagerObject;
    private float previousTimeOfDay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightingManager = FindObjectOfType<LightingManager>();
        Application.targetFrameRate = 60; // Set target frame rate to 60 FPS
        dateUI.GetComponent<TextMeshProUGUI>().text = "Day " + currentDay.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        previousTimeOfDay = lightingManager.TimeOfDay;
        lightingManager.TimeOfDay += Time.deltaTime / timeSpeed;

        if (lightingManager.TimeOfDay >= 24f)
        {
            lightingManager.TimeOfDay = 0f;
        }

        if (previousTimeOfDay > lightingManager.TimeOfDay)
        {
            NewDay();
        }

    }

    private void NewDay()
    {
        currentDay++;
        // display new day on UI
        dateUI.GetComponent<TextMeshProUGUI>().text = "Day " + currentDay.ToString();
        // run the function OnNewDay() in farming manager
        farmingManagerObject.GetComponent<FarmingManager>().AdvanceGrowth();
    }
}
