using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Counter : MonoBehaviour {

    public int CountFrom {
        get; set;
    }

    [SerializeField]
    private Text counter;

    private float currentValue = 100.0f;
    private bool isCounting = false;

	void Update () {
		
        if (this.isCounting) {
            this.currentValue -= Time.deltaTime;
            this.RenderCounter();
        }
	}

    public void Start() {
        this.currentValue = this.CountFrom;
        this.isCounting = true;
        this.counter.enabled = true;
    }

    public void Stop() {
        this.isCounting = false;
        this.currentValue = this.CountFrom;
        this.counter.enabled = false;
    }

    private void RenderCounter() {
        int asInt = (int) Mathf.Ceil(this.currentValue);
        this.counter.text = asInt.ToString();
    }
}
