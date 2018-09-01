using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public delegate void OnPicked();

    [SerializeField]
    private float weight;

    [SerializeField]
    private Sprite sprite;

    private OnPicked onPicked = null;

    void OnTriggerEnter(Collider other) {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory) {

            if (this.onPicked != null) {
                this.onPicked();
            }

            inventory.AddItem(this);
            Destroy(this);
        }
    }

    public void SetOnPicked(OnPicked onPicked) {
        this.onPicked = onPicked;
    }

    public void SetWeight(float weight) {
        this.weight = weight;
    }

    public void SetSprite(Sprite sprite) {
        this.sprite = sprite;

        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = this.sprite;
    }
}
