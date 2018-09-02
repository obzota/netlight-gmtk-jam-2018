using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour, IMovementProvider {

    public enum AIState {
        LOOKING_FOR_PICKUP, GOING_TO_PICKUP, THROWING_PICKUP_AT_BALL
    }

    private AIState aiState;
    private NavMeshAgent navMeshAgent;
    private Inventory inventory;

    void Start () {
        this.aiState = AIState.LOOKING_FOR_PICKUP;
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();

        this.inventory = this.GetComponent<Inventory>();
        this.inventory.GotItemListener = this.OnFoundPickUp;
	}
	
	// Update is called once per frame
	void Update () {
        switch (this.aiState) {
            case AIState.LOOKING_FOR_PICKUP:
                this.SetGoalToFindNextPickUp();
                break;
            case AIState.THROWING_PICKUP_AT_BALL:
                // TODO: Implement
                this.aiState = AIState.LOOKING_FOR_PICKUP;
                break;

        }
	}

    Vector3 IMovementProvider.GetMovement() {
        return this.navMeshAgent.velocity;
    }

    private void SetGoalToFindNextPickUp() {
        GameObject targetPickUp = this.FindClosesPickUp();
        if (targetPickUp == null) {
            return;
        }

        this.navMeshAgent.destination = targetPickUp.transform.position;
        this.aiState = AIState.GOING_TO_PICKUP;
    }

    private void OnFoundPickUp() {
        this.aiState = AIState.THROWING_PICKUP_AT_BALL;
    }

    // TODO: Can be optimized with spatial data structures
    private GameObject FindClosesPickUp() {
        GameObject[] pickUps = GameObject.FindGameObjectsWithTag("PickUp");

        if (pickUps.Length == 0) {
            return null;
        }

        GameObject closestPickUp = pickUps[0];
        float distanceToClosest = this.GetDistanceTo(closestPickUp.transform);

        foreach (GameObject pickUp in pickUps) {
            float distance = this.GetDistanceTo(pickUp.transform);
            if (distance < distanceToClosest) {
                closestPickUp = pickUp;
                distanceToClosest = distance;
            }
        }

        return closestPickUp;
    }

    private float GetDistanceTo(Transform other) {
        return (other.position - this.transform.position).magnitude;
    }
}
