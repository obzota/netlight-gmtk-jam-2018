using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {
    
    public float THROWING_SPEED = 3.0f;

    public Throwable Brick;
    public GameObject Target;
    public Vector3 throwableOffset = new Vector3(0, 0, -1);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.Brick == null)
            return;
            
        Brick.gameObject.transform.position = this.gameObject.transform.position + throwableOffset;

        if (Input.GetKey(KeyCode.Space))
            Throw();
	}

    public void PickItem(PickUp obj)
    {
        if(this.Brick != null){
            return;
        }
        this.Brick = obj.gameObject.AddComponent<Throwable>();
        Destroy(obj);
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
