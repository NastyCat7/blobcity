using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlobData : ScriptableObject
{
   public Vector3 position;

   public int sunlight;
   public int humidity;
   public int nutrient;

   public int tolerance;

   //to be extended
}

