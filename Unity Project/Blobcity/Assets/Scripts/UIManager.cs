using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIMarkedBlob;
    public GameObject UIMarkedHouse;

    public TextMeshProUGUI textField;
    
    private void OnEnable()
    {
        Actions.OnBlobMarked += ChangeBlobUI;
        Actions.OnHouseMarked += ChangeHouseUI;
        Actions.OnMatch += DisableUI;
    }

    private void OnDisable()
    {
        Actions.OnBlobMarked -= ChangeBlobUI;
        Actions.OnHouseMarked -= ChangeHouseUI;
        Actions.OnMatch -= DisableUI;
    }

    private void ChangeBlobUI(BlobData data)
    {
        UIMarkedBlob.SetActive(true); //Enables the UI always if marked.

        textField = UIMarkedBlob.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = "Humidity: " + data.humidity + "\nSunlight: " +
                         data.sunlight + "\nNutrients: " + data.nutrient +
                         "\n \nTolerance: " + data.tolerance + "%";
        
    }

    private void ChangeHouseUI(HouseData data)
    {
        UIMarkedHouse.SetActive(true); //Enables the UI always if marked.
        
        textField = UIMarkedHouse.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = "Humidity: " + data.humidity + "\nSunlight: " +
                         data.sunlight + "\nNutrients: " + data.nutrient;
    }

    private void DisableUI()
    {
        UIMarkedBlob.SetActive(false);
        UIMarkedHouse.SetActive(false);
    }
}
