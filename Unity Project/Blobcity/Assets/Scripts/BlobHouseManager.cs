using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobHouseManager : MonoBehaviour
{
    [SerializeField] private List<BlobHouseElement> register = new List<BlobHouseElement>();

    public static BlobHouseManager Instance;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        Actions.OnRegisterBlobHouse += RegisterBlobHouse;
    }

    private void OnDisable()
    {
        Actions.OnRegisterBlobHouse -= RegisterBlobHouse;
    }

    void RegisterBlobHouse(GameObject blob, GameObject house)
    {
        BlobHouseElement temp = new BlobHouseElement();
        temp.blobGameObject = blob;
        temp.houseGameObject = house;

        //temp.blobData = blob.GetComponentInChildren<BlobManager>().blobData;
        //temp.houseData = house.GetComponent<HouseManager>().houseData;
        
        register.Add(temp);
    }

    public bool CheckForBlob(GameObject blob)
    {
        foreach (BlobHouseElement e in register)
        {
            Debug.Log("Appearance in the list? " + (e.blobGameObject == blob));
            
            if (e.blobGameObject == blob)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool CheckForHouse(GameObject house)
    {
        foreach (BlobHouseElement e in register)
        {
            if (e.houseGameObject == house)
            {
                return true;
            }
        }
        return false;
    }
}
