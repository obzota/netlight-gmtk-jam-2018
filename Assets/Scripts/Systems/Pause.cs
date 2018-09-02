using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    
    private float duration;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (GoOn())
        {
            duration -= Time.deltaTime;
        }
    }

    public bool GoOn(){
        return duration > 0;
    }

    public void Begin(float TimeInSeconds){
        duration = TimeInSeconds;
    }
}
