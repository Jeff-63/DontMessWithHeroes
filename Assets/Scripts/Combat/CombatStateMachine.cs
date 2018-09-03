﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : MonoBehaviour
{

    public static BattleStates currentState;
    bool hasAddedXP;
    Rect GUINextStateButton;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        CALCULDAMAGE,
        LOSE,
        WIN
    }

    void Start()
    {
        hasAddedXP = false;
        currentState = BattleStates.START;
        GUINextStateButton = new Rect(10, 10, 60, 30);
    }

    void Update()
    {
        switch (currentState)
        {
            case BattleStates.START:
                //setup Combat
                //Choix de celui qui commence
                break;
            case BattleStates.PLAYERCHOICE:
                //choix de l'action du joueur
                break;
            case BattleStates.ENEMYCHOICE:
                //choix de l'action de l'ennemi
                break;
            case BattleStates.LOSE:
                break;
            case BattleStates.WIN:
                if (!hasAddedXP)
                {
                    //Fonction pour ajouter de l'XP
                    hasAddedXP = true;
                }
                break;
            default:
                break;
        }

        Debug.Log(currentState);
    }

    private void OnGUI()
    {
        if (GUI.Button(GUINextStateButton, "NEXT STATE"))
        {
            if (currentState == BattleStates.START)
                currentState = BattleStates.PLAYERCHOICE;
            else if (currentState == BattleStates.PLAYERCHOICE)
                currentState = BattleStates.ENEMYCHOICE;
            else if (currentState == BattleStates.ENEMYCHOICE)
                currentState = BattleStates.WIN;
            else if (currentState == BattleStates.WIN)
                currentState = BattleStates.LOSE;
            else if (currentState == BattleStates.LOSE)
                currentState = BattleStates.START;
        }
    }
}
