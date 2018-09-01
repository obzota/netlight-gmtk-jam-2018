using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite3DToPlane : MonoBehaviour {

    private float yPlane;

	void FixedUpdate () {
        this.MoveToYPlane();
	}

    private void MoveToYPlane() {
        // TODO: Doesn't make any sense why divide by ten
        Sprite3D sprite3D = this.GetComponentInChildren<Sprite3D>();
        float yPosition = this.yPlane + sprite3D.GetBounds().extents.z / 10.0f;

        Vector3 currentPosition = this.transform.position;
        this.transform.position = new Vector3(currentPosition.x, yPosition, currentPosition.z);
    }
}
