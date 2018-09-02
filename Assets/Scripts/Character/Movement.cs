using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public enum HorizontalDirection {
        LEFT, RIGHT
    }

    [SerializeField]
    private float speed;

    private HorizontalDirection horizontalDirection = HorizontalDirection.RIGHT;

    private MaterialAnimator animator;

    void Start() {
        this.animator = this.GetComponentInChildren<MaterialAnimator>();
    }

    void FixedUpdate () {
        Vector3 movement = this.ApplyMovement();
        this.UpdateHorizontalDirection(movement);
        this.UpdateAnimation(movement);
	}

    private Vector3 ApplyMovement() {
        Vector3 input = this.GetXInput() + this.GetYInput() + this.GetZInput();
        Vector3 movement = input * this.speed * Time.deltaTime;
        this.transform.Translate(movement);
        return movement;
    }

    private void UpdateHorizontalDirection(Vector3 movement) {

        if (Mathf.Abs(movement.x) < 0.01) {
            return;
        }

        if (movement.x >= 0) {
            this.horizontalDirection = HorizontalDirection.RIGHT;
        }

        else {
            this.horizontalDirection = HorizontalDirection.LEFT;
        }
    }

    private void UpdateAnimation(Vector3 movement) {
        bool flipAnim = this.horizontalDirection == HorizontalDirection.LEFT;

        if (movement.magnitude > 0.01) {
            this.animator.SetCurrentAnimation("Run", flipAnim);
        }

        else {
            this.animator.SetCurrentAnimation("Idle", flipAnim);
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
