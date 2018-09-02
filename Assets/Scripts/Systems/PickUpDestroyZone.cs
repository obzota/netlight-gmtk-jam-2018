using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDestroyZone : MonoBehaviour {

    private void OnTriggerExit(Collider other) {

        if (other.GetComponent<Throwable>()) {
            Destroy(other.gameObject);
        }
    }
}
