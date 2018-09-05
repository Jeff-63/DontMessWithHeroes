﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    readonly float CHARACTER_SIZE = 3;
    readonly float PIXEL_PER_UNIT_RATIO = 1.5f;
    enum AnimationTurn { PlayerTurn, EnnemiTurn }

    Text playerHp, playerMana, ennemiHP, ennemiMana;
    Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    BaseCharacterClass player, ennemi;
    GameObject playerObj, ennemiObj;
    GameObject uiActionContainer;
    Animator playerAnimator, ennemiAnimator;
    float screenWidth = Screen.width;
    float pixelPerUnit;
    AnimationTurn animTurn;
    private bool isShowingActionContainer = true;

    Vector2 playerStartingPosition, ennemiStartingPosition;

    public void Initialize()
    {
        animTurn = AnimationTurn.PlayerTurn;
        pixelPerUnit = CombatFlow.cl.combatUiCanvas.referencePixelsPerUnit * PIXEL_PER_UNIT_RATIO;
        uiActionContainer = CombatFlow.cl.uiActionContainer;

        playerStartingPosition = new Vector2(((-screenWidth / 2) / (pixelPerUnit)), 0);
        ennemiStartingPosition = new Vector2(((screenWidth / 2) / (pixelPerUnit)), 0);

        playerHp = CombatFlow.cl.playerHp; //pointeur vers le composant text des HP du joueur
        playerMana = CombatFlow.cl.playerMana; //pointeur vers le composant text de la mana du joueur
        ennemiHP = CombatFlow.cl.ennemiHP; //pointeur vers le composant text des HP de l'ennemi
        ennemiMana = CombatFlow.cl.ennemiMana; //pointeur vers le composant text de la mana de l'ennemi

        playerHpImage = CombatFlow.cl.playerHpImage; //pointeur vers le composant image des HP du joueur
        playerManaImage = CombatFlow.cl.playerManaImage; //pointeur vers le composant image de la mana du joueur
        ennemiHPImage = CombatFlow.cl.ennemiHPImage; //pointeur vers le composant image des HP de l'ennemi
        ennemiManaImage = CombatFlow.cl.ennemiManaImage; //pointeur vers le composant image de la mana de l'ennemi
        playerImage = CombatFlow.cl.playerImage; //pointeur vers le composant image du portrait du joueur
        ennemiImage = CombatFlow.cl.ennemiImage; //pointeur vers le composant image du portrait de l'ennemi

        switch (OmniPlayer.Instance.characterClass)
        {
            case CharacterClasses.Warrior:
                player = new Warrior();
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Gladiator_Portrait");
                break;

            case CharacterClasses.Wizard:
                player = new Wizard();
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Wizards_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }
        CombatFlow.cl.PlayerCharacter = player;

        switch (OmniEnemy.Instance.characterClass)
        {
            case CharacterClasses.Orc:
                ennemi = new Orc();
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Orc_Portrait");
                break;

            case CharacterClasses.Elemental:
                ennemi = new Elemental();
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Elemental_Portrait");
                break;

            case CharacterClasses.Boss:
                ennemi = new Boss();
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Golem_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }
        CombatFlow.cl.EnemyCharacter = ennemi;

        playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Warrior"));
        playerObj.transform.position = playerStartingPosition;
        playerObj.transform.localScale *= CHARACTER_SIZE;

        playerAnimator = playerObj.GetComponent<Animator>();

        ennemiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Orc"));
        ennemiObj.transform.position = ennemiStartingPosition;
        ennemiObj.transform.localScale *= CHARACTER_SIZE;

        ennemiAnimator = ennemiObj.GetComponent<Animator>();
    }

    public void UpdateUI(float dt)
    {
        playerHp.text = OmniPlayer.Instance.currentHP.ToString() + " / " + OmniPlayer.Instance.maxHP.ToString(); //update du texte des pv du personnage
        ennemiHP.text = OmniEnemy.Instance.currentHP.ToString() + " / " + OmniEnemy.Instance.maxHP.ToString(); //update du texte des pv de l'ennemi

        playerMana.text = OmniPlayer.Instance.currentMana.ToString() + " / " + OmniPlayer.Instance.maxMana.ToString();//update txt mana player
        ennemiMana.text = OmniEnemy.Instance.currentMana.ToString() + " / " + OmniEnemy.Instance.maxMana.ToString();//update txt mana enemy

        playerHpImage.fillAmount = ((float)OmniPlayer.Instance.currentHP / (float)OmniPlayer.Instance.maxHP); //update de l'image des pv du personnage
        ennemiHPImage.fillAmount = ((float)OmniEnemy.Instance.currentHP / (float)OmniEnemy.Instance.maxHP); //update de l'image des pv de l'ennemi
        try
        {
            playerManaImage.fillAmount = (OmniPlayer.Instance.currentMana / OmniPlayer.Instance.maxMana);//update mana bar player  
            ennemiManaImage.fillAmount = (OmniEnemy.Instance.currentMana / OmniEnemy.Instance.maxMana);//update mana bar enemy
        }
        catch
        {

        }

    }

    public void AttackAnimation()
    {
        switch (animTurn)
        {
            case AnimationTurn.PlayerTurn:
                playerAnimator.SetTrigger("Attack");
                ennemiAnimator.SetTrigger("GetDamage");
                Show_HideActionContainer();
                animTurn = AnimationTurn.EnnemiTurn;
                break;
            case AnimationTurn.EnnemiTurn:
                ennemiAnimator.SetTrigger("Attack");
                playerAnimator.SetTrigger("GetDamage");
                Show_HideActionContainer();
                animTurn = AnimationTurn.PlayerTurn;
                break;
            default:
                Debug.Log("Unhandled Value : " + animTurn);
                break;
        }

    }

    public void DefenseAnimation()
    {
        switch (animTurn)
        {
            case AnimationTurn.PlayerTurn:
                playerAnimator.SetTrigger("GetDamage");
                Show_HideActionContainer();
                animTurn = AnimationTurn.EnnemiTurn;
                break;
            case AnimationTurn.EnnemiTurn:
                ennemiAnimator.SetTrigger("GetDamage");
                Show_HideActionContainer();
                animTurn = AnimationTurn.PlayerTurn;
                break;
            default:
                Debug.Log("Unhandled Value : " + animTurn);
                break;
        }
    }

    public void RunAnimation()
    {
        playerAnimator.SetTrigger("Run");
    }

    public void Show_HideActionContainer()
    {
        isShowingActionContainer = !isShowingActionContainer;
        uiActionContainer.SetActive(isShowingActionContainer);
    }

}
