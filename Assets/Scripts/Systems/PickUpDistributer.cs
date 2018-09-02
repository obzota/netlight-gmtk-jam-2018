using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDistributer : MonoBehaviour {

    [SerializeField]
    private GameObject pickupPrefab;

    [SerializeField]
    private List<PickUpData> pickUpTypes;

    [SerializeField]
    private List<PickUpSpawnArea> spawnAreas;

    [SerializeField]
    private int targetNumberOfPickUps;

    [SerializeField]
    private GameObject pickupContainer;

    private int currentNumberOfPickUps = 0;
	
	void Update () {
		
        if (this.currentNumberOfPickUps < this.targetNumberOfPickUps) {
            this.SpawnPickUp();
        }
	}

    private void SpawnPickUp() {
        PickUpData pickUpType = this.SelectRandomPickUpType();
        Vector3 spawnPosition = this.SelectRandomSpawnLocation();

        GameObject pickUpGameObject = Instantiate(this.pickupPrefab, spawnPosition, Quaternion.identity);
        if (pickupContainer != null)
            pickUpGameObject.transform.parent = pickupContainer.transform;
        
        PickUp pickUp = pickUpGameObject.GetComponent<PickUp>();

        pickUp.SetOnPicked(this.OnPickUpDestoryed);
        pickUp.SetMaterial(pickUpType.material);

        this.currentNumberOfPickUps++;
    }

    private PickUpData SelectRandomPickUpType() {
        int pickUpTypeIndex = Random.Range(0, this.pickUpTypes.Count);
        return this.pickUpTypes[pickUpTypeIndex];
    }

    private Vector3 SelectRandomSpawnLocation() {
        int spawnAreaIndex = Random.Range(0, this.spawnAreas.Count);
        PickUpSpawnArea spawnArea = this.spawnAreas[spawnAreaIndex];
        return spawnArea.GetRandomSpawnLocation();
    }

    private void OnPickUpDestoryed() {
        this.currentNumberOfPickUps--;
    }
}
