using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite3D : MonoBehaviour {

    public bool Visible {
        get {
            return this.GetComponent<MeshRenderer>().enabled;
        }

        set {
            this.GetComponent<MeshRenderer>().enabled = value;
        }
    }

    public void SetMaterial(Material material) {
        this.GetComponent<MeshRenderer>().material = material;
    }

    public Bounds GetBounds() {
        return this.GetComponent<MeshFilter>().mesh.bounds;
    }
}
