using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlsButton : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    private Button button;

    void Start() {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(this.ShowControlsWindow);
    }

    private void ShowControlsWindow() {
        this.target.SetActive(true);
    }
}
