using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnleavableArea : MonoBehaviour {

    private BoxCollider boxCollider;

	void Start () {
        this.boxCollider = this.GetComponent<BoxCollider>();
	}

    void OnTriggerExit(Collider other) {
        //Vector3 direction = this.DirectionFromObjectToCenter(other.transform.position);
        other.transform.position = this.boxCollider.ClosestPoint(other.transform.position);
    }

    private Vector3 DirectionFromObjectToCenter(Vector3 objectPosition) {
        Vector3 towardsCenter = this.transform.position - objectPosition;
        towardsCenter.Normalize();
        return towardsCenter;
    }
}
