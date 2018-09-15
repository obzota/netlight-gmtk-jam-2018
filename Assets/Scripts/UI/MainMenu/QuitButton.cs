using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    private Button button;

	void Start () {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(this.Quit);
	}

    private void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
