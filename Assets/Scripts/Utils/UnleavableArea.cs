using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnleavableArea : MonoBehaviour {

    private BoxCollider boxCollider;

	void Start () {
        this.boxCollider = this.GetComponent<BoxCollider>();
	}

    void OnTriggerExit(Collider other) {
        Debug.Log("Here");
        if (this.isPhysicsObject(other.gameObject)) {
            Debug.Log("Physics");
            Vector3 direction = this.DirectionFromObjectToCenter(other.transform.position);
            other.GetComponent<Rigidbody>().velocity = direction;
        }

        else {
            Debug.Log("Other");
            other.transform.position = this.boxCollider.ClosestPoint(other.transform.position);
        }
    }

    private bool isPhysicsObject(GameObject go) {
        Rigidbody rb = go.GetComponent<Rigidbody>();

        if (rb == null) {
            return false;
        }

        return !rb.isKinematic;
    }

    private Vector3 DirectionFromObjectToCenter(Vector3 objectPosition) {
        Vector3 towardsCenter = this.transform.position - objectPosition;
        towardsCenter.Normalize();
        return towardsCenter;
    }
}
