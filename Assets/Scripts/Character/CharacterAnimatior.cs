using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatior : MonoBehaviour
{
    public enum HorizontalDirection {
        LEFT, RIGHT
    }

    private HorizontalDirection horizontalDirection = HorizontalDirection.RIGHT;

    public HorizontalDirection HDirection {
        get {
            return this.horizontalDirection;
        }
    }

    private MaterialAnimator animator;
    private IMovementProvider movenetProvider;

    void Start() {
        this.animator = this.GetComponentInChildren<MaterialAnimator>();
        this.movenetProvider = this.GetComponent<IMovementProvider>();
    }

    void FixedUpdate () {
        Vector3 movement = this.movenetProvider.GetMovement();
        this.UpdateHorizontalDirection(movement);
        this.UpdateAnimation(movement);
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
}
