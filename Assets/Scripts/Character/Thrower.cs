using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public float THROWING_SPEED = 3.0f;

    public GameObject Brick;
    public GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
            Throw();
	}

    void Throw(){
        if (this.Brick == null)
            return;

        Thrown behavior = Brick.GetComponent<Thrown>();
        if (behavior != null)
            Destroy(behavior);

        behavior = this.Brick.AddComponent<Thrown>();

        behavior._start = this.gameObject.transform.position;
        behavior._end = this.Target.transform.position;
        behavior._speed = THROWING_SPEED;

        this.Brick = null;

    }
}
