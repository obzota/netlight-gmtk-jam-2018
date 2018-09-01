using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnArea : MonoBehaviour {

    private BoxCollider boxCollider;

    void Start() {
        this.boxCollider = this.GetComponent<BoxCollider>();
    }

    public Vector3 GetRandomSpawnLocation() {
        Bounds spawnArea = this.boxCollider.bounds;

        float xSpawnPosition = this.GetRandomPositionOnAxis(spawnArea.center.x, spawnArea.extents.x);
        float zSpawnPosition = this.GetRandomPositionOnAxis(spawnArea.center.z, spawnArea.extents.z);

        return new Vector3(xSpawnPosition, 0.0f, zSpawnPosition);
    }

    private float GetRandomPositionOnAxis(float axisCenter, float axisExtent) {
        return axisCenter + this.GetRandomValueAroundZero(axisExtent);
    }

    private float GetRandomValueAroundZero(float extent) {
        return Random.Range((-1.0f) * extent, extent);
    }
}
