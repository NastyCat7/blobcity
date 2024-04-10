using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputManager : MonoBehaviour
{
    private void Update()
    {
        // Check for Info-Key: H
        if (Input.GetKeyDown(KeyCode.H))
        {
            Actions.OnInputInfo?.Invoke();
        }
        
        //Check for Mark-Key: M
        if (Input.GetKeyDown(KeyCode.M))
        {
            Actions.OnMarked?.Invoke();
        }
        
        //Check for Match-Key: P
        if (Input.GetKeyDown(KeyCode.P))
        {
            Actions.OnMatch?.Invoke();
        }
        
    }
    
}
