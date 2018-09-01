﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private IList<Throwable> items;

    void Start() {
        this.items = new List<Throwable>();
    }

    public void AddItem(PickUp item) {
        Throwable _item = item.gameObject.AddComponent<Throwable>();
        AddItem(_item);
    }

    public void AddItem(Throwable item) {
        this.items.Add(item);
        item.gameObject.SetActive(false);
    }

    public Throwable Retrieve(){
        var item = items[0];
        items.RemoveAt(0);
        return item;
    }
}
