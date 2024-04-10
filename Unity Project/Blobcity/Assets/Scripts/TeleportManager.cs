using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnRegisterBlobHouse += BlobToHouse;
    }

    private void OnDisable()
    {
        Actions.OnRegisterBlobHouse -= BlobToHouse;
    }

    void TeleportAtoB(GameObject a, GameObject b)
    {
        a.transform.position = b.transform.position;
    }

    void BlobToHouse(GameObject blob, GameObject house)
    {
        blob.transform.rotation = new Quaternion(0, 180, 0, 0);
        TeleportAtoB(blob, house.transform.GetChild(0).gameObject);
    }
}
