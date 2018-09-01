using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    private float speed;
	
	void FixedUpdate () {
        ApplyMovement();
	}

    private void ApplyMovement() {
        Vector3 input = this.GetXInput() + this.GetYInput() + this.GetZInput();
        Vector3 movement = input * this.speed * Time.deltaTime;
        this.transform.Translate(movement);
    }

    private Vector3 GetXInput() {
        return new Vector3((-1.0f) * Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    }

    private Vector3 GetYInput() {
        return new Vector3(0.0f, 0.0f, 0.0f);
    }

    private Vector3 GetZInput() {
        return new Vector3(0.0f, (-1.0f) * Input.GetAxis("Vertical"), 0.0f);
    }
}
