using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {
    
    public Vector3 start;
    public Vector3 end;
    public float travelingTime = 2;
    public float maxHeight = 10;
    private float traveledTime = 0.0f;
    private bool isTraveling = false;
    public LayerMask targetLayer = 8;

	// Use this for initialization
	void Start () {
        
	}

    public void Launch()
    {
        gameObject.transform.position = start;
        travelingTime = 2.0f;
        traveledTime = 0.0f;
        isTraveling = true;
        maxHeight = (start - end).magnitude/2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( (1 << other.gameObject.layer & targetLayer.value) != 0) {
            Destroy(this);
        }
            
    }

    // Update is called once per frame
    void Update () {
        
	}

    private void FixedUpdate()
    {
        if (!this.isTraveling)
            return;
        
        traveledTime += Time.fixedDeltaTime;
        this.gameObject.transform.position = LerpPosition(start, end, traveledTime/travelingTime);
    }

    protected Vector3 LerpPosition(Vector3 start, Vector3 end, float ratio) {
        return start + (end - start) * ratio + (4*ratio*(1-ratio)) * Vector3.up * maxHeight; 
    }
}
