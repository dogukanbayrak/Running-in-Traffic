using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fuelSystem : MonoBehaviour
{

    public float startFuel;

    public float maxFuel = 100f;

    public float fuelConsumptionRate;

    public Slider fuelIndicatorSld;

    public TextMeshProUGUI fuelIndicatorTxt;



   
    void Start()
    {
        if(startFuel>maxFuel)
        {
            startFuel = maxFuel;
        }
        fuelIndicatorSld.maxValue = maxFuel;
        UpdateUI();
    }


    public void ReduceFuel()
    {
        startFuel -= Time.deltaTime * fuelConsumptionRate;
        UpdateUI();
    }

    void UpdateUI()
    {
        fuelIndicatorSld.value = startFuel;
        fuelIndicatorTxt.text = "Fuel left : " + startFuel.ToString("0") + "%";

        if(startFuel <= 0)
        {
            startFuel = 0;
            fuelIndicatorTxt.text = "Out of fuel !!! ";
        }

        if (startFuel > 100)
        {
            startFuel = 100;
            
        }


    }
}
