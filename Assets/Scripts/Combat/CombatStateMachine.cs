using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : MonoBehaviour
{

    public static BattleStates currentState;
    private StartState battleStartState = new StartState();
    Player p; // need player to get the enemy type from the collision and agility stat (from bcc) for who goes first ---- *********** need to get real player, not a new one **********
    Enemy e; // need enemy bcc to know who goes first ---- *************need to get real enemy, not a new one **********************
    bool hasAddedXP;
    Rect GUINextStateButton;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        CALCULDAMAGE,
        LOSE,
        WIN,
        ESCAPE
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
                //     battleStartState.InitEnemy(p.enemyType); // instanciate the good enemy type from the collision
                //Choix de celui qui commence

                if (battleStartState.PlayerGoesFirst(OmniEnemy.Instance.agility,OmniPlayer.Instance.agility))
                {
                    Debug.Log("Player was faster");
                    goto case BattleStates.PLAYERCHOICE;
                    
                }
                else
                {
                    Debug.Log("Enemy was faster");
                    goto case BattleStates.ENEMYCHOICE;
                
                }
            case BattleStates.PLAYERCHOICE:
                //choix de l'action du joueur
                Debug.Log("in player choice");
                break;
            case BattleStates.ENEMYCHOICE:
                //choix de l'action de l'ennemi
                Debug.Log("in enemy choice");
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
            case BattleStates.ESCAPE:
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
