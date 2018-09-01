using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public delegate void OnPicked();

    [SerializeField]
    private Material material;

    private OnPicked onPicked = null;

    void OnTriggerEnter(Collider other) {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory) {
            this.HandlePickingUp(inventory);
        }
    }

    public void SetOnPicked(OnPicked onPicked) {
        this.onPicked = onPicked;
    }

    public void SetMaterial(Material material) {
        this.material = material;

        Sprite3D sprite3D = this.GetComponentInChildren<Sprite3D>();
        sprite3D.SetMaterial(this.material);
    }

    private void HandlePickingUp(Inventory inventory) {

        if (this.onPicked != null) {
            this.onPicked();
        }

        this.GetComponentInChildren<Sprite3D>().Visible = false;
        inventory.AddItem(this);
        Destroy(this);
    }
}
