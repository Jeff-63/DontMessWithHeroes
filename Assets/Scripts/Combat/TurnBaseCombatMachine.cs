using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseCombatMachine : MonoBehaviour {

    public enum CombatStates { Start, PlayerChoice, EnemyChoice, Lose, Win, PlayerAnimation, EnemyAnimation}

    private CombatStates currentState;
	// Use this for initialization
	void Start () {

        currentState = CombatStates.Start;
        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Current State : " + currentState);
        switch (currentState)
        {
            case CombatStates.Start:
                // init enemy and player + chose who go first (depends on who gets the highest agility)
                break;
            case CombatStates.PlayerChoice:
                // with buttons >> atk, defend, run
                break;
            case CombatStates.EnemyChoice:
                // atk or defend
                break;
            case CombatStates.Lose:
                // if player hp <=0
                break;
            case CombatStates.Win:
                // if enemy hp <= 0
                break;
            case CombatStates.PlayerAnimation:
                //player atking/defending/run away anim
                break;
            case CombatStates.EnemyAnimation:
                //enemy atking/defending
                break;
            default:
                break;
        }
        //maybe add damage calculation state and damage anim


    }
}
