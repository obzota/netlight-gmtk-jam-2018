using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayAMatchButton : MonoBehaviour {

    private Button button;

	void Start () {
        this.button = this.GetComponent<Button>();
        this.button.onClick.AddListener(this.StartMatch);
	}

    private void StartMatch() {
        SceneManager.LoadScene("stadium-sto-henri");
    }
}
