using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CloseButton : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    private Button button;

	void Start () {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(this.Close);
	}

    private void Close() {
        this.target.SetActive(false);
    }
}
