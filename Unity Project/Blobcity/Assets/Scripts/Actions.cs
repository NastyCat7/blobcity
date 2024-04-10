using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions
{
    public static Action OnInputInfo;
    
    public static Action<Collider> OnColliderEnter;
    public static Action OnColliderExit;
    
    public static Action<Collision> OnCollisionEnter;
    public static Action OnCollisionExit;
    
    //Mark & Match
    public static Action OnMarked;
    public static Action OnMatch;
    
    //UI
    public static Action <BlobData> OnBlobMarked;
    public static Action <HouseData> OnHouseMarked;
    
    //Saving & Loading
    public static Action<GameObject, GameObject> OnRegisterBlobHouse;

}
