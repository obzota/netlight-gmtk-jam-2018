using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour {

	void Update () {
        this.RotateTowardsCameraInXZPlane();
    }

    private void RotateTowardsCameraInXZPlane() {
        // TODO: Check which of these methods to use
        /*
        Vector3 fromThisToCamera = this.GetVectorXZFromThisToCamera();
        Vector3 lookRotation = (-1.0f) * fromThisToCamera;
        this.transform.rotation = Quaternion.LookRotation(lookRotation);
        */

        float cameraYRotation = Camera.main.transform.rotation.eulerAngles.y;
        this.transform.rotation = Quaternion.AngleAxis(cameraYRotation, Vector3.up);
    }

    private Vector3 GetVectorXZFromThisToCamera() {
        Vector3 cameraPosition = this.GetCameraXZPosition();
        Vector3 thisPosition = this.GetThisXZPosition();

        return cameraPosition - thisPosition;
    }

    private Vector3 GetThisXZPosition() {
        Vector3 position = this.transform.position;
        return new Vector3(position.x, 0.0f, position.z);
    }

    private Vector3 GetCameraXZPosition() {
        Vector3 cameraPosition = Camera.main.transform.position;
        return new Vector3(cameraPosition.x, 0.0f, cameraPosition.z);
    }
}
