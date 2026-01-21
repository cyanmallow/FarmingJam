using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayMonthManager : MonoBehaviour
{
    private LightingManager lightingManager;
    public int currentDay = 1;
    private float timeSpeed = 7.5f; //edit this back to 7.5 after testing

    // display day on UI
    public TextMeshProUGUI dateUI;
    public TextMeshProUGUI timeUI;

    // farming manager reference
    public FarmingManager[] farmingManagerObjects;
    private float previousTimeOfDay;
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private GameObject player;

    // new day gameobject
    [SerializeField] private GameObject newDayUI;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightingManager = FindObjectOfType<LightingManager>();
        Application.targetFrameRate = 60; // Set target frame rate to 60 FPS
        dateUI.text = "Day " + currentDay.ToString();
        if (screenFader == null)
        {
            Debug.LogError("ScreenFader reference is missing in DayMonthManager.");
            screenFader = FindObjectOfType<ScreenFader>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        previousTimeOfDay = lightingManager.TimeOfDay;
        lightingManager.TimeOfDay += Time.deltaTime / timeSpeed;

        // end the day at 22:00, end start at 5:00
        if (lightingManager.TimeOfDay >= 22f)
        {
            EndDay();
        }

        // cheat to end of day
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndDay();
        }

        //if (lightingManager.TimeOfDay >= 24f)
        //{
        //    lightingManager.TimeOfDay = 0f;
        //}

        //if (previousTimeOfDay > lightingManager.TimeOfDay)
        //{
        //    NewDay();
        //}

        int hour = Mathf.FloorToInt(lightingManager.TimeOfDay);
        //int minute = Mathf.FloorToInt((lightingManager.TimeOfDay - hour) * 60f);
        //timeUI.text = $"{hour:00}:{minute:00}";
        timeUI.text = $"{hour:00}:00";
    }

    // go to sleep at 22:00
    private void EndDay()
    {
        // animation for sleep
        // fade to black
        screenFader.FadeToBlack();
        // teleport to bed position
        player.transform.position = new Vector3(78.6f, 0f, 65.7f); // change to bed position

        lightingManager.TimeOfDay = 5f;
        NewDay();
    }
    private void NewDay()
    {
        currentDay++;
        screenFader.FadeFromBlack();
        lightingManager.TimeOfDay = 5f;
        newDayUI.SetActive(true);
        dateUI.text = "Day " + currentDay.ToString();

        // run the function OnNewDay() in farming manager
        foreach (FarmingManager farm in farmingManagerObjects)
        {
            farm.AdvanceGrowth();
        }
    }
}
