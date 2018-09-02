using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {

    [SerializeField]
    private Text menuText;

    public bool Visible {
        get {
            return this.menuText.enabled;
        }

        set {
            this.menuText.enabled = value;
        }
    }
}
