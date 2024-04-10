using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public HouseData houseData;
    private bool open = true;
    void Start()
    {
        houseData.position = transform.position;
    }

    public void ShowData()
    {
        Debug.Log("Position: " + houseData.position);
        Debug.Log("Sunlight: " + houseData.sunlight);
        Debug.Log("Humidity: " + houseData.humidity);
        Debug.Log("Nutrient: " + houseData.nutrient);
    }
    
    public bool HasBlob()
    {
        if (!open || BlobHouseManager.Instance.CheckForHouse(gameObject))
        {
            open = false; //Add a seperate Set-Method later!
            return true;
        }

        open = true;
        return false;
    }
}
