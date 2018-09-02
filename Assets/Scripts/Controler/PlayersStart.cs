using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersStart : MonoBehaviour {

    [SerializeField]
    GameObject Player1;
    [SerializeField]
    GameObject Player2;

    [SerializeField]
    private GameObject Spawn1;
    [SerializeField]
    private GameObject Spawn2;

    private void Start()
    {
        Reset();
    }

    // Use this for initialization
    public void Reset () {
        var start1 = Spawn1.transform.position;
        var start2 = Spawn2.transform.position;
        Player1.transform.position.Set(start1.x, start1.y, start1.z);
        Player2.transform.position.Set(start2.x, start2.y, start2.z);
	}
	
}
