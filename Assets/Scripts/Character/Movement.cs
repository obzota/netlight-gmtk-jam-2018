using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMovementProvider {

    [SerializeField]
    private float speed;

    private Vector3 movement;

    Vector3 IMovementProvider.GetMovement() {
        return movement;
    }

    void FixedUpdate () {
        this.ApplyMovement();
	}
        
    private void ApplyMovement() {
        Vector3 input = this.GetXInput() + this.GetYInput() + this.GetZInput();
        this.movement = input * this.speed * Time.deltaTime;
        this.transform.Translate(this.movement);
    }

    private Vector3 GetXInput() {
        return new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    }

    private Vector3 GetYInput() {
        return new Vector3(0.0f, 0.0f, 0.0f);
    }

    private Vector3 GetZInput() {
        return new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
    }
}
