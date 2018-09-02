using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    private float speed;

    private MaterialAnimator animator;

    void Start() {
        this.animator = this.GetComponentInChildren<MaterialAnimator>();
    }

    void FixedUpdate () {
        Vector3 movement = this.ApplyMovement();
        this.UpdateAnimation(movement);
	}

    private Vector3 ApplyMovement() {
        Vector3 input = this.GetXInput() + this.GetYInput() + this.GetZInput();
        Vector3 movement = input * this.speed * Time.deltaTime;
        this.transform.Translate(movement);
        return movement;
    }

    private void UpdateAnimation(Vector3 movement) {

        if (movement.magnitude > 0.01) {
            this.animator.SetCurrentAnimation("Run");
        }

        else {
            this.animator.SetCurrentAnimation("Idle");
        }
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
