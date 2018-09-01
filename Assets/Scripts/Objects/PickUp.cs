using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [SerializeField]
    private string pickupName;

    [SerializeField]
    private float weight;

    [SerializeField]
    private Sprite sprite;

    void Start() {
        this.SetSprite();
    }

    void OnTriggerEnter(Collider other) {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory) {
            inventory.AddItem(this.pickupName, this.weight);
            Destroy(this);
        }
    }

    private void SetSprite() {
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = this.sprite;
    }
}
