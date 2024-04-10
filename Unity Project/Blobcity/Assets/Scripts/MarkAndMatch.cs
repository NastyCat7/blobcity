using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkAndMatch : MonoBehaviour
{
    //RULES FOR NOW:
    //Marking is always possible, even if you already marked that type of object.
    //Marking should not work on already matched objects. (open-bool)

    private GameObject markedHouse;
    private GameObject markedBlob;

    private Collider colliderToCheck;

    private void OnEnable()
    {
        #region ColliderInformation

        Actions.OnColliderEnter += ColliderDetected;
        Actions.OnColliderExit += ColliderGone;

        #endregion

        Actions.OnMarked += CheckMarked;
        Actions.OnMatch += CheckMatch;
    }

    private void OnDisable()
    {
        Actions.OnMarked -= CheckMarked;
        Actions.OnMatch -= CheckMatch;
    }

    private void CheckMarked()
    {
        ObjectTypeEnum type = CheckIfBlobOrHouse();
        Debug.Log(type);
        
        switch (type)
        {
            case ObjectTypeEnum.None:
                break;

            case ObjectTypeEnum.Blob:
                if (markedBlob != null)
                {
                    Debug.Log("Replaced a previously marked blob.");
                }
                
                markedBlob = colliderToCheck.transform.root.gameObject;
                Actions.OnBlobMarked?.Invoke(markedBlob.GetComponentInChildren<BlobManager>().blobData); //UI Action
                break;

            case ObjectTypeEnum.House:
                if (markedHouse != null)
                {
                    Debug.Log("Replaced a previously marked house.");
                }

                markedHouse = colliderToCheck.transform.gameObject;
                Actions.OnHouseMarked?.Invoke(markedHouse.GetComponent<HouseManager>().houseData); //UI Action
                break;
        }

        //Check later for roots and hierarchies, do you need Houses-Parent? Or Blobs-Parent?
    }

    private void ColliderDetected(Collider a)
    {
        colliderToCheck = a;
    }

    private void ColliderGone()
    {
        colliderToCheck = null;
    }

    private ObjectTypeEnum CheckIfBlobOrHouse()
    {
        if (colliderToCheck == null)
        {
            Debug.Log("There is nothing!");
            return ObjectTypeEnum.None;
        }

        if (colliderToCheck.CompareTag("House") &&
            !colliderToCheck.GetComponent<HouseManager>().HasBlob()) //Check Tag & open-bool!
        {
            return ObjectTypeEnum.House;
        }

        if (colliderToCheck.gameObject.CompareTag("Blob") &&
            !colliderToCheck.GetComponent<BlobManager>().HasHouse()) //Check Tag & open-bool!
        {
            return ObjectTypeEnum.Blob;
        }

        return ObjectTypeEnum.None;
    }

    private void CheckMatch()
    {
        if (markedBlob != null && markedHouse != null)
        {
            HouseManager house = markedHouse.GetComponent<HouseManager>();
            BlobManager blob = markedBlob.GetComponentInChildren<BlobManager>();

            if (CompareStats(blob.blobData, house.houseData))
            {
                AssignBlobToHouse();
                Debug.Log("A good match!");
            
                markedBlob = null;
                markedHouse = null;
            } 
            else
            {
                Debug.Log("Not a match.");
            } 
        }
    }

    private bool CompareStats(BlobData b, HouseData h)
    {
            float humTol = h.humidity * ((float)b.tolerance / 100); //Tolerance-Range
            if (!(Math.Abs(b.humidity - h.humidity) <= humTol))
            {
                return false;
            }
            
            float sunTol = h.sunlight * ((float)b.tolerance / 100); //Tolerance-Range
            if (!(Math.Abs(b.sunlight - h.sunlight) <= sunTol))
            {
                return false;
            }
        
            float nutTol = h.nutrient * ((float)b.tolerance / 100); //Tolerance-Range
            if (!(Math.Abs(b.nutrient - h.nutrient) <= nutTol))
            {
                return false;
            }
            
            return true;
    }

    private void AssignBlobToHouse()
    {
        Actions.OnRegisterBlobHouse?.Invoke(markedBlob, markedHouse);
        markedHouse.transform.GetChild(1).gameObject.SetActive(true);
    }

}

