using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderResizer : MonoBehaviour {

	void Start () {
        SphereCollider sphereCollider = this.GetComponent<SphereCollider>();
        Bounds sprite3DBounds = this.GetComponentInChildren<Sprite3D>().GetBounds();
        float largestSide = Mathf.Max(sprite3DBounds.size.x, sprite3DBounds.size.y, sprite3DBounds.size.z);
        sphereCollider.radius = largestSide;
    }
}
