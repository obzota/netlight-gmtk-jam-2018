using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    private Text blueScore;

    [SerializeField]
    private Text redScore;

    public int BlueScore {
        get {
            return Int32.Parse(this.blueScore.text);
        }

        set {
            this.blueScore.text = value.ToString();
        }
    }

    public int RedScore {
        get {
            return Int32.Parse(this.redScore.text);
        }

        set {
            this.redScore.text = value.ToString();
        }
    }
}
