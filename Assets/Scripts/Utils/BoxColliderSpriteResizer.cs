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
        Bounds spriteBounds = this.GetComponent<SpriteRenderer>().sprite.bounds;

        BoxCollider boxCollider = this.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(spriteBounds.size.x, spriteBounds.size.y, this.depth);
    }
}
