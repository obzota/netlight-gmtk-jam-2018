using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovementProvider : MonoBehaviour, IMovementProvider {

    private Rigidbody rb;

    void Start() {
        this.rb = this.GetComponent<Rigidbody>();
    }

    Vector3 IMovementProvider.GetMovement() {
        return this.rb.velocity;
    }
}
