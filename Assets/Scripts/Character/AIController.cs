using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour, IMovementProvider {

    public enum AIState {
        WAIT, LOOKING_FOR_PICKUP, THROWING_PICKUP_AT_BALL
    }

    [SerializeField]
    private GameObject ball;

    private AIState aiState;
    private NavMeshAgent navMeshAgent;
    private Thrower thrower;
    private MaterialAnimator materialAnimator;

    void Start () {
        this.aiState = AIState.LOOKING_FOR_PICKUP;
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.materialAnimator = this.GetComponentInChildren<MaterialAnimator>();

        this.thrower = this.GetComponent<Thrower>();
        this.thrower.GotItemListener = this.OnFoundPickUp;
	}
	
	// Update is called once per frame
	void Update () {

        if (this.aiState != AIState.WAIT && this.thrower.Brick != null) {
            this.aiState = AIState.THROWING_PICKUP_AT_BALL;
        }

        switch (this.aiState) {
            case AIState.LOOKING_FOR_PICKUP:
                this.SetGoalToFindNextPickUp();
                break;
            case AIState.THROWING_PICKUP_AT_BALL:
                this.ThrowPickUp();
                break;

        }
	}

    Vector3 IMovementProvider.GetMovement() {
        return this.navMeshAgent.velocity;
    }

    public void Wait() {
        this.aiState = AIState.WAIT;
    }

    public void Play() {

        if (this.thrower.Brick != null) {
            this.aiState = AIState.THROWING_PICKUP_AT_BALL;
        }

        else {
            this.aiState = AIState.LOOKING_FOR_PICKUP;
        }
    }

    private void ThrowPickUp() {
        this.materialAnimator.SetCurrentAnimation("Throw");
        this.thrower.Throw();
        this.aiState = AIState.LOOKING_FOR_PICKUP;
    }

    private void SetGoalToFindNextPickUp() {
        GameObject targetPickUp = this.FindClosesPickUp();
        if (targetPickUp == null) {
            return;
        }

        this.navMeshAgent.destination = targetPickUp.transform.position;
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
