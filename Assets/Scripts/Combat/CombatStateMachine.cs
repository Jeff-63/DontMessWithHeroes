using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStateMachine : MonoBehaviour
{
    readonly float STATS_BOOST_PER_LVL = 1.1f;
    readonly float EXP_MOAR_NEED_PER_LVL = 1.5f;
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
        ESCAPE,
        LVLUPCHECK
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
                    if (start)
                    {
                        CombatFlow.cl.cUI.animTurn = CombatUI.AnimationTurn.PlayerTurn;
                    }
                    goto case BattleStates.PLAYERCHOICE;

                }
                else
                {
                    if (start)
                    {
                        CombatFlow.cl.cUI.animTurn = CombatUI.AnimationTurn.EnnemiTurn;
                        CombatFlow.cl.cUI.Show_HideActionContainer();
                        start = false;
                    }
                    goto case BattleStates.ENEMYCHOICE;

                }
            case BattleStates.PLAYERCHOICE:
                //choix de l'action du joueur
                if (OmniPlayer.Instance.currentHP <= 0)
                {
                    CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.PlayerTurn);
                    goto case BattleStates.LOSE; // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.EnnemiTurn);
                    goto case BattleStates.LVLUPCHECK;
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
                    CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.PlayerTurn);
                    goto case BattleStates.LOSE; // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.EnnemiTurn);
                    goto case BattleStates.LVLUPCHECK;
                }
                break;
            case BattleStates.LOSE:
              
                OmniPlayer.Instance.characterLevel = 0;
                SceneManager.LoadScene("GameOver");
                break;
            case BattleStates.WIN:
                SceneManager.LoadScene("GameScene");
                break;
            case BattleStates.ESCAPE:
                SceneManager.LoadScene("GameScene");
                break;
            case BattleStates.LVLUPCHECK:
                if (!hasAddedXP)
                {
                    OmniPlayer.Instance.experience += OmniEnemy.Instance.experience;
                    hasAddedXP = true;
                    if (OmniPlayer.Instance.experience >= OmniPlayer.Instance.maxExperience)
                    {
                        GetNewLvl();
                        StartCoroutine(Timer());
                    }
                    else
                    {
                        goto case BattleStates.WIN;
                    }
                }
                break;
            default:
                break;
        }

        Debug.Log(currentState);
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
            player.currentHP -= damage;
        }
        CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.PLAYERCHOICE;
    }

    private void GetNewLvl()
    {
        OmniPlayer.Instance.characterLevel += 1;
        OmniPlayer.Instance.experience = 0;
        OmniPlayer.Instance.maxExperience = (int)((float)OmniPlayer.Instance.maxExperience * EXP_MOAR_NEED_PER_LVL);
        OmniPlayer.Instance.strenght = (int)((float)OmniPlayer.Instance.strenght * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.endurance = (int)((float)OmniPlayer.Instance.endurance * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.intelligence = (int)((float)OmniPlayer.Instance.intelligence * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.agility += 1;
        OmniPlayer.Instance.maxHP = (int)((float)OmniPlayer.Instance.maxHP * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.currentHP = (int)((float)OmniPlayer.Instance.maxHP);
        OmniPlayer.Instance.maxMana = (int)((float)OmniPlayer.Instance.maxMana * STATS_BOOST_PER_LVL);
        Debug.Log("lvlupiscalled");

        GameObject lvlUpParticle = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/LevelUp"));
        lvlUpParticle.transform.position = CombatFlow.cl.playerPosition;
        foreach (ParticleSystem p in lvlUpParticle.GetComponents<ParticleSystem>())
        {
            p.Play();
        }

    }

    IEnumerator Timer()
    {
        float cooldown = 1.5f;

        while (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            yield return null;

        }
        currentState = BattleStates.WIN;
    }
}
