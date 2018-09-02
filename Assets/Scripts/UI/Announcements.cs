using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Announcements : MonoBehaviour {

    [SerializeField]
    private Text announcementText;

    private string currentAnnouncement = null;
    private float currentAnnouncementDuration;
    private float currentlyOnScreenTime;

	void Start () {
        this.announcementText.text = "";
	}

    void Update() {

        if (this.currentAnnouncement != null) {
            this.UpdateAnnouncement();
        }
    }

    public void MakeAnnouncement(string text, float duration) {
        this.currentAnnouncement = text;
        this.currentAnnouncementDuration = duration;
        this.currentlyOnScreenTime = 0.0f;

        this.announcementText.text = text;
    }

    private void UpdateAnnouncement() {
        this.currentlyOnScreenTime += Time.deltaTime;

        if (this.currentlyOnScreenTime >= this.currentAnnouncementDuration) {
            this.ResetAnnouncement();
        }
    }

    private void ResetAnnouncement() {
        this.announcementText.text = "";
        this.currentAnnouncement = null;
    }
}
