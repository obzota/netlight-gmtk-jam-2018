using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private struct Item {
        public Sprite sprite;
        public float weight;

        public Item(Sprite sprite, float weight) {
            this.sprite = sprite;
            this.weight = weight;
        }
    }

    private IList<Item> items;

    void Start() {
        this.items = new List<Item>();
    }

    public void AddItem(Sprite sprite, float weight) {
        Item item = new Item(sprite, weight);
        this.items.Add(item);
    }
}
