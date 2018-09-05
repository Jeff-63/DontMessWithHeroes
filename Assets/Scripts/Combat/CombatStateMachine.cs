using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStateMachine : MonoBehaviour
{
    float cooldown = 2;
    public BattleStates currentState;
    private StartState battleStartState = new StartState();
    Player p; // need player to get the enemy type from the collision and agility stat (from bcc) for who goes first ---- *********** need to get real player, not a new one **********
    Enemy e; // need enemy bcc to know who goes first ---- *************need to get real enemy, not a new one **********************
    bool hasAddedXP;
    public bool isDefending;
    int damage;
    Rect GUINextStateButton;
    bool start = true;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
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

                if (battleStartState.PlayerGoesFirst(OmniEnemy.Instance.agility, OmniPlayer.Instance.agility))
                {
                    Debug.Log("Player was faster");
                    if (start)
                    {
                        CombatFlow.cl.cUI.animTurn = CombatUI.AnimationTurn.PlayerTurn;
                    }
                    goto case BattleStates.PLAYERCHOICE;

                }
                else
                {
                    Debug.Log("Enemy was faster");
                    if(start)
                    {
                        CombatFlow.cl.cUI.animTurn = CombatUI.AnimationTurn.EnnemiTurn;
                        CombatFlow.cl.cUI.Show_HideActionContainer();
                        start = false;
                    }
                    goto case BattleStates.ENEMYCHOICE;

                }
            case BattleStates.PLAYERCHOICE:
                //choix de l'action du joueur
                Debug.Log("in player choice");
                if (OmniPlayer.Instance.currentHP <= 0)
                {
                    goto case BattleStates.LOSE; // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    goto case BattleStates.WIN;
                }
                break;
            case BattleStates.ENEMYCHOICE:
                //choix de l'action de l'ennemi
                Debug.Log("in enemy choice");
                cooldown -= Time.deltaTime;// timer so animation can take place
                if (cooldown < 0)
                {
                    damage = (int)CombatLogics.Attack(CombatFlow.cl.EnemyCharacter, CombatFlow.cl.PlayerCharacter);
                    GetDamageFromEnemy(OmniPlayer.Instance, damage);
                    CombatFlow.cl.cUI.AttackAnimation();
                    cooldown = 2;
                }

                if (OmniPlayer.Instance.currentHP <= 0)
                {
                    goto case BattleStates.LOSE; // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    goto case BattleStates.WIN;
                }
                break;
            case BattleStates.LOSE:
                Debug.Log("I LOSE");
                break;
            case BattleStates.WIN:
                Debug.Log("I WIN");
                SceneManager.LoadScene("GameScene");
                if (!hasAddedXP)
                {
                    //Fonction pour ajouter de l'XP
                    hasAddedXP = true;
                }
                break;
            case BattleStates.ESCAPE:
                Debug.Log("I ESCAPE");
                SceneManager.LoadScene("GameScene");
                //  SceneManager.LoadScene("GameScene");
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

    private void GetDamageFromEnemy(OmniPlayer player, int damage)
    {
        player = OmniPlayer.Instance;
        if (isDefending)
        {
            player.currentHP -= (int)(damage * 0.5);
            isDefending = false;
        }
        else
        {
            player.currentHP += damage;
        }


        CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.PLAYERCHOICE;
    }
}
