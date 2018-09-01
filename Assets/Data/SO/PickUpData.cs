using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "PickUp", order = 1)]
public class PickUpData : ScriptableObject {
    public string pickUpName;
    public Sprite sprite;
    public float weight;
}
