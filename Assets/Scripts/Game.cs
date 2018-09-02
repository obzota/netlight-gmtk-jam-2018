﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private int blueScore;
    [SerializeField]
    private int redScore;
    [SerializeField]
    private GameObject blueGoal;
    [SerializeField]
    private GameObject redGoal;
    [SerializeField]
    private float timer;


    enum GameState {BEGIN, PLAY, SCORE, PAUSE, END}
    private GameState current = GameState.BEGIN;

    private Pause interrupt;

	// Use this for initialization
	void Start () {
        interrupt = gameObject.AddComponent<Pause>();
        Reset();
        GameInfo("start");
	}

    public void Reset()
    {
        redScore = 0;
        blueScore = 0;
        timer = 100.0f;
        current = GameState.BEGIN;
        ball.SetActive(false);
        interrupt.Begin(5.0f);
        GameInfo("reset");
    }

    public void Score(GameObject goal) {
        if (GameState.PLAY != current)
            return;
        
        if (goal.Equals(blueGoal))
            blueScore += 1;
        if (goal.Equals(redGoal))
            blueScore += 1;

        current = GameState.SCORE;
        interrupt.Begin(5.0f);
        GameInfo("goal " + gameObject.name);
        GameInfo("score: blue: " + blueScore);
        GameInfo("score: red: " + redScore);
    }

    void KickOff(){
        ball.transform.position = new Vector3(0, 10, 0);
        ball.SetActive(true);
        GameInfo("kickoff");
    }

    // Update is called once per frame
    void Update () {
        switch(current) {
            case GameState.END:
                return;
            case GameState.PLAY:
                timer -= Time.deltaTime;
                if (timer < 0)
                    End();
                break;
            case GameState.BEGIN:
            case GameState.PAUSE:
            case GameState.SCORE:
                if (!interrupt.GoOn())
                {
                    KickOff();
                    current = GameState.PLAY;
                } else {
                    GameInfo("interrupt");
                }
                break;
        }
	}

    void End(){
        current = GameState.END;
    }

    void GameInfo(string msg){
        Debug.Log("GAME INFO: " + msg);
    }
}