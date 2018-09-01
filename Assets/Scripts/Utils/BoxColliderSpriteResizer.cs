using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderSpriteResizer : MonoBehaviour {

    [SerializeField]
    private float depth = 0.4f;

	void Start () {
        this.ResizeBoxColliderToFitSprite();
    }

    private void ResizeBoxColliderToFitSprite() {
        Bounds sprite3DBounds = this.GetComponentInChildren<Sprite3D>().GetBounds();

        BoxCollider boxCollider = this.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(sprite3DBounds.size.x, sprite3DBounds.size.z, this.depth);
    }
}
