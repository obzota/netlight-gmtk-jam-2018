using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private struct Item {
        public string name;
        public float weight;

        public Item(string name, float weight) {
            this.name = name;
            this.weight = weight;
        }
    }

    private IList<Item> items;

    void Start() {
        this.items = new List<Item>();
    }

    public void AddItem(string name, float weight) {
        Item item = new Item(name, weight);
        this.items.Add(item);
    }
}
