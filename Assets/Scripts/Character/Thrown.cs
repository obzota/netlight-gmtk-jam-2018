using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour {
    
    public Vector3 _start;
    public Vector3 _end;
    public float _speed;

	// Use this for initialization
	void Start () {
        Reset();
	}

    public void Reset()
    {
        gameObject.transform.position = _start;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("alter throw")){
            //Destroy(this);
        //}
    }

    // Update is called once per frame
    void Update () {
        
	}

    private void FixedUpdate()
    {

        Vector3 updatedPos = Time.deltaTime * _speed * (_end - _start).normalized + gameObject.transform.position;
        this.gameObject.transform.position = updatedPos;
    }
}
