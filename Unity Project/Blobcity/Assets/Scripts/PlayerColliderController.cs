using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered.");

        Actions.OnColliderEnter?.Invoke(other);
    }

    public void OnTriggerExit(Collider other)
    {
        Actions.OnColliderExit?.Invoke();
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided.");

        Actions.OnCollisionEnter?.Invoke(other);
    }
    
    public void OnCollisionExit(Collision other)
    {
        Actions.OnCollisionExit?.Invoke();
    }
}
