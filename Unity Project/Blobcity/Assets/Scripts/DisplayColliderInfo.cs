using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayColliderInfo : MonoBehaviour
{
    private Collider colliderInfo;
    private Collision collisionInfo;

    private void OnEnable()
    {
        Actions.OnColliderEnter += GetCollider;
        Actions.OnColliderExit += DeleteCollider;
        Actions.OnCollisionEnter += GetCollision;
        Actions.OnCollisionExit += DeleteCollider;
        Actions.OnInputInfo += GetColliderInfoInput;
    }

    private void OnDisable()
    {
        Actions.OnColliderEnter -= GetCollider;
        Actions.OnColliderExit -= DeleteCollider;
        Actions.OnCollisionEnter -= GetCollision;
        Actions.OnCollisionExit -= DeleteCollider;
        Actions.OnInputInfo -= GetColliderInfoInput;
    }
    
    public void GetCollider(Collider col)
    {
        colliderInfo = col;
    }
    
    public void DeleteCollider()
    {
        colliderInfo = null;
    }
    
    public void GetCollision(Collision col)
    {
        collisionInfo = col;
    }
    
    public void DeleteCollision()
    {
        collisionInfo = null;
    }

    public void GetColliderInfoInput()
    {
        if (colliderInfo != null)
        {
            if (colliderInfo.CompareTag("House"))
            {
                colliderInfo.gameObject.GetComponent<HouseManager>().ShowData();
            }
            else if(colliderInfo.gameObject.CompareTag("Blob"))
            {
                colliderInfo.gameObject.GetComponent<BlobManager>().ShowData();
            }
            
        }
    }
    
}
