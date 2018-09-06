using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStateMachine : MonoBehaviour
{
    readonly float STATS_BOOST_PER_LVL = 1.1f;
    readonly float EXP_MOAR_NEED_PER_LVL = 1.5f;
    readonly float COOLDOWN_BASE_VALUE = 1.5f;
    readonly float DEFENSE_BUFF_VALUE = 0.5f;

    float cooldown = 2;
    public BattleStates currentState;
    private StartState battleStartState = new StartState();
    bool hasAddedXP;
    public bool isDefending;
    int damage;
    bool start = true;
    bool cooldownStart = false;

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
    }

    void Update()
    {
        switch (currentState)
        {
            case BattleStates.START:
                //setup Combat
                //Choix de celui qui commence
                cooldownStart = false;

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
                    if (!cooldownStart)
                    {
                        CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.PlayerTurn);
                        cooldownStart = true;
                    }
                    StartCoroutine(EndBattle(BattleStates.LOSE)); // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    if (!cooldownStart)
                    {
                        CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.EnnemiTurn);
                        cooldownStart = true;
                    }
                    goto case BattleStates.LVLUPCHECK;
                }
                break;
            case BattleStates.ENEMYCHOICE:
                //choix de l'action de l'ennemi
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
                    if (!cooldownStart)
                    {
                        CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.PlayerTurn);
                        cooldownStart = true;
                    }
                    StartCoroutine(EndBattle(BattleStates.LOSE)); // si vie du player a 0 goto lose state
                }
                else if (OmniEnemy.Instance.currentHP <= 0)// si vie de l'ennemi a 0 win state
                {
                    if (!cooldownStart)
                    {
                        CombatFlow.cl.cUI.DieAnimation(CombatUI.AnimationTurn.EnnemiTurn);
                        cooldownStart = true;
                    }
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
                        GetNewLvl();

                    StartCoroutine(EndBattle(BattleStates.WIN));

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
            player.currentHP -= (int)(damage * DEFENSE_BUFF_VALUE);
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
        OmniPlayer.Instance.characterLevel++;
        OmniPlayer.Instance.experience = 0;
        OmniPlayer.Instance.maxExperience = (int)((float)OmniPlayer.Instance.maxExperience * EXP_MOAR_NEED_PER_LVL);
        OmniPlayer.Instance.strenght = (int)((float)OmniPlayer.Instance.strenght * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.endurance = (int)((float)OmniPlayer.Instance.endurance * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.intelligence = (int)((float)OmniPlayer.Instance.intelligence * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.agility++;
        OmniPlayer.Instance.maxHP = (int)((float)OmniPlayer.Instance.maxHP * STATS_BOOST_PER_LVL);
        OmniPlayer.Instance.currentHP = (int)((float)OmniPlayer.Instance.maxHP);
        OmniPlayer.Instance.maxMana = (int)((float)OmniPlayer.Instance.maxMana * STATS_BOOST_PER_LVL);

        GameObject lvlUpParticle = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/LevelUp"));
        lvlUpParticle.transform.position = CombatFlow.cl.playerPosition;
        foreach (ParticleSystem p in lvlUpParticle.GetComponents<ParticleSystem>())
        {
            p.Play();
        }

    }

    IEnumerator EndBattle(BattleStates state)
    {

        float cooldown = COOLDOWN_BASE_VALUE;

        while (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            yield return null;

        }
        currentState = state;
    }
}
