using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobManager : MonoBehaviour
{
    public BlobData blobData;
    private bool open = true;
    void Start()
    {
        blobData.position = transform.position;
    }

    public void ShowData()
    {
        Debug.Log("Position: " + blobData.position);
        Debug.Log("Sunlight: " + blobData.sunlight);
        Debug.Log("Humidity: " + blobData.humidity);
        Debug.Log("Nutrient: " + blobData.nutrient);
        Debug.Log("Tolerance %: " + blobData.tolerance);
    }

    public bool HasHouse()
    {
        if (!open || BlobHouseManager.Instance.CheckForBlob(gameObject.transform.root.gameObject))
        {
            open = false; //Add a seperate Set-Method later!
            return true;
        }

        open = true;
        return false;
    }
    
}
