﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    private MeshRenderer objectRenderer;
    public GameObject field;

    void Start() {
        this.objectRenderer = this.GetComponent<MeshRenderer>();
    }

    void FixedUpdate () {
        this.RaycastMousePositionToWorld();
	}

    private void RaycastMousePositionToWorld() {
        Vector3 mouseWindowPosition = this.GetMouseWindowPosition();
        Ray ray = this.CreateRayFromCameraToWorld(mouseWindowPosition);

        var t = - ray.origin.y / ray.direction.y;
        var p = ray.origin + t * ray.direction;

        this.SetMarkerPosition(new Vector3(p.x, hooveringHeight(), p.z));
        this.ShowMarker();

    }

    private void HideMarker() {
        this.objectRenderer.enabled = false;
    }

    private void ShowMarker() {
        this.objectRenderer.enabled = true;
    }

    private void SetMarkerPosition(Vector3 position) {
        this.transform.position = position;
    }

    private float hooveringHeight()
    {
        return field.transform.position.y + this.gameObject.transform.localScale.y / 2.0f;
    }

    private Ray CreateRayFromCameraToWorld(Vector3 windowPosition) {
        return Camera.main.ScreenPointToRay(windowPosition);
    } 

    private Vector3 GetMouseWindowPosition() {
        return Input.mousePosition;
    }
}
