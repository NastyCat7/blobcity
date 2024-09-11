using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneExit : MonoBehaviour
{
    public string sceneToLoad;
    private GameObject player;
    private GameObject manager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
