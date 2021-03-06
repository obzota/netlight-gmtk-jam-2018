﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public delegate void OnGotItem();

    public float THROWING_SPEED = 3.0f;

    public OnGotItem GotItemListener {
        get; set;
    }

    public Throwable Brick;
    public GameObject Target;
    public Vector3 throwableOffset = new Vector3(0, 0, -1);

    public float cooldown = 1.0f;
    private float sinceLastThrow = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.Brick == null)
            return;

        Brick.gameObject.transform.position = this.gameObject.transform.position + throwableOffset;

        this.sinceLastThrow += Time.deltaTime;
	}

    public void PickItem(PickUp obj)
    {
        if(this.Brick != null){
            return;
        }

        if (this.GotItemListener != null) {
            this.GotItemListener();
        }

        this.Brick = obj.gameObject.AddComponent<Throwable>();
        this.Brick.tag = "Untagged";
        Destroy(obj);
    }

    public void Throw() {
        if (this.Brick == null)
            return;

        if (this.cooldown > this.sinceLastThrow) {
            return;
        }

        Brick.start = this.gameObject.transform.position;
        Brick.end = this.Target.transform.position;

        this.ReadyBrickToThrow();

        Brick.Launch();

        this.Brick = null;
        this.sinceLastThrow = 0.0f;

    }

    public void Throw(Vector3 position){
        if (this.Brick == null)
            return;

        if (this.cooldown > this.sinceLastThrow)
        {
            return;
        }

        Brick.start = this.gameObject.transform.position;
        Brick.end = position;

        this.ReadyBrickToThrow();

        Brick.Launch();

        this.Brick = null;
        this.sinceLastThrow = 0.0f;

    }

    private void ReadyBrickToThrow() {
        this.Brick.GetComponent<Rigidbody>().isKinematic = false;
        this.Brick.GetComponent<SphereCollider>().isTrigger = false;
    }
}
