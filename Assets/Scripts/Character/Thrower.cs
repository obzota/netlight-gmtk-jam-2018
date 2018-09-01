using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public float THROWING_SPEED = 3.0f;

    public Throwable Brick;
    public GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.Brick == null)
            return;
            
        Brick.gameObject.transform.position = this.gameObject.transform.position;

        if (Input.GetKey(KeyCode.Space))
            Throw();
	}

    void Throw(){
        if (this.Brick == null)
            return;

        Brick.start = this.gameObject.transform.position;
        Brick.end = this.Target.transform.position;

        Brick.Launch();

        this.Brick = null;

    }
}
