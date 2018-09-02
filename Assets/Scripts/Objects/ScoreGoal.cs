using UnityEngine;
using System.Collections;

public class ScoreGoal : MonoBehaviour
{
    [SerializeField]
    private GameObject RedGoalTrigger;
    [SerializeField]
    private GameObject BluGoalTrigger;
    [SerializeField]
    private Game controler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RedGoalTrigger || other.gameObject == BluGoalTrigger)
            controler.Score(other.gameObject);
    }
}
