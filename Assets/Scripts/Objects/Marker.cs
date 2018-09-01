using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    private MeshRenderer renderer;

    void Start() {
        this.renderer = this.GetComponent<MeshRenderer>();
    }

    void FixedUpdate () {
        this.RaycastMousePositionToWorld();
	}

    private void RaycastMousePositionToWorld() {
        Vector3 mouseWindowPosition = this.GetMouseWindowPosition();
        Ray ray = this.CreateRayFromCameraToWorld(mouseWindowPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            this.SetMarkerPosition(hit.point);
            this.ShowMarker();
        }

        else {
            this.HideMarker();
        }
    }

    private void HideMarker() {
        this.renderer.enabled = false;
    }

    private void ShowMarker() {
        this.renderer.enabled = true;
    }

    private void SetMarkerPosition(Vector3 position) {
        this.transform.position = position;
    }

    private Ray CreateRayFromCameraToWorld(Vector3 windowPosition) {
        return Camera.main.ScreenPointToRay(windowPosition);
    } 

    private Vector3 GetMouseWindowPosition() {
        return Input.mousePosition;
    }
}
