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

    private int currentNumberOfPickUps = 0;
	
	void Update () {
		
        if (this.currentNumberOfPickUps < this.targetNumberOfPickUps) {
            this.SpawnPickUp();
        }
	}

    private void SpawnPickUp() {
        PickUpData pickUpType = this.SelectRandomPickUpType();
        Vector3 spawnPosition = this.SelectRandomSpawnLocation();
        Vector3 pickUpPosition = this.GetSurfacePositionForSprite(pickUpType.sprite, spawnPosition);

        GameObject pickUpGameObject = Instantiate(this.pickupPrefab, pickUpPosition, Quaternion.identity);
        PickUp pickUp = pickUpGameObject.GetComponent<PickUp>();

        pickUp.SetOnPicked(this.OnPickUpDestoryed);
        pickUp.SetSprite(pickUpType.sprite);
        pickUp.SetWeight(pickUpType.weight);

        this.currentNumberOfPickUps++;
    }

    private Vector3 GetSurfacePositionForSprite(Sprite sprite, Vector3 position) {
        float ySurfacePosition = sprite.bounds.extents.y;
        return new Vector3(position.x, ySurfacePosition, position.z);
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
