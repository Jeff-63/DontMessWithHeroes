﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{

    Text playerHp, playerMana, ennemiHP, ennemiMana;
    Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    Player p;
    BaseCharacterClass player, ennemi;

    float characterSize = 3;

    Vector2 playerStartingPosition,  ennemiStartingPosition;

    void Start()
    {
        player = new Warrior();
        ennemi = new Orc();

        playerStartingPosition = new Vector2(-7, 0);
        ennemiStartingPosition = new Vector2(7, 0);

        playerHp = GameObject.Find("PlayerHealthValue").GetComponent<Text>(); //pointeur vers le composant text des HP du joueur
        playerMana = GameObject.Find("PlayerManaValue").GetComponent<Text>(); //pointeur vers le composant text de la mana du joueur
        ennemiHP = GameObject.Find("EnnemiHealthValue").GetComponent<Text>(); //pointeur vers le composant text des HP de l'ennemi
        ennemiMana = GameObject.Find("EnnemiManaValue").GetComponent<Text>(); //pointeur vers le composant text de la mana de l'ennemi

        playerHpImage = GameObject.Find("PlayerHealthBar").GetComponent<Image>(); //pointeur vers le composant image des HP du joueur
        playerManaImage = GameObject.Find("PlayerMana").GetComponent<Image>(); //pointeur vers le composant image de la mana du joueur
        ennemiHPImage = GameObject.Find("EnnemiHealthBar").GetComponent<Image>(); //pointeur vers le composant image des HP de l'ennemi
        ennemiManaImage = GameObject.Find("EnnemiMana").GetComponent<Image>(); //pointeur vers le composant image de la mana de l'ennemi
        playerImage = GameObject.Find("PlayerPortrait").GetComponent<Image>(); //pointeur vers le composant image du portrait du joueur
        ennemiImage = GameObject.Find("EnnemiPortrait").GetComponent<Image>(); //pointeur vers le composant image du portrait de l'ennemi

        switch (player.characterClass)
        {
            case CharacterClasses.Warrior:
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Gladiator_Portrait");
                break;

            case CharacterClasses.Wizard:
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Wizards_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }

        switch (ennemi.characterClass)
        {
            case CharacterClasses.Orc:
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Orc_Portrait");
                break;

            case CharacterClasses.Elemental:
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Elemental_Portrait");
                break;

            case CharacterClasses.Boss:
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Golem_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + ennemi.characterClass);
                break;
        }

        GameObject playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Warrior")); 
        playerObj.transform.position = playerStartingPosition;
        playerObj.transform.localScale *= characterSize;

        GameObject ennemiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Orc"));
        ennemiObj.transform.position = ennemiStartingPosition;
        ennemiObj.transform.localScale *= characterSize;

    }

    /*public void Initialize()
    {      
        player = new Warrior();
        ennemi = new Orc();

        player.currentHP -= 10;
        ennemi.currentHP -= 15;

        playerHp = GameObject.Find("PlayerHealthValue").GetComponent<Text>(); //pointeur vers le composant text des HP du joueur
        playerMana = GameObject.Find("PlayerManaValue").GetComponent<Text>(); //pointeur vers le composant text de la mana du joueur
        ennemiHP = GameObject.Find("EnnemiHealthValue").GetComponent<Text>(); //pointeur vers le composant text des HP de l'ennemi
        ennemiMana = GameObject.Find("EnnemiManaValue").GetComponent<Text>(); //pointeur vers le composant text de la mana de l'ennemi

        playerHpImage = GameObject.Find("PlayerHealthBar").GetComponent<Image>(); //pointeur vers le composant image des HP du joueur
        playerManaImage = GameObject.Find("PlayerMana").GetComponent<Image>(); //pointeur vers le composant image de la mana du joueur
        ennemiHPImage = GameObject.Find("EnnemiHealthBar").GetComponent<Image>(); //pointeur vers le composant image des HP de l'ennemi
        ennemiManaImage = GameObject.Find("EnnemiMana").GetComponent<Image>(); //pointeur vers le composant image de la mana de l'ennemi
        playerImage = GameObject.Find("PlayerPortrait").GetComponent<Image>(); //pointeur vers le composant image du portrait du joueur
        ennemiImage = GameObject.Find("EnnemiPortrait").GetComponent<Image>(); //pointeur vers le composant image du portrait de l'ennemi

        switch (player.characterClass)
        {
            case "Warrior":
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Gladiator_Portrait");
                break;

            case "Mage":
                playerImage.sprite = Resources.Load<Sprite>("Sprites/Wizards_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }

        ennemiImage.sprite = Resources.Load<Sprite>(String.Format("Sprites/{0}_Portrait",ennemi.characterClass));


        switch (ennemi.characterClass)
        {
            case "Orc":
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Orc_Portrait");
                break;

            case "Elemental":
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Elemental_Portrait");
                break;

            case "Boss":
                ennemiImage.sprite = Resources.Load<Sprite>("Sprites/Golem_Portrait");
                break;

            default:
                Debug.Log("Unhandeled character class : " + ennemi.characterClass);
                break;
        }

    }*/

    private void Update()
    {
        playerHp.text = OmniPlayer.Instance.currentHP.ToString() + " / " + OmniPlayer.Instance.maxHP.ToString(); //update du texte des pv du personnage
        ennemiHP.text = OmniEnemy.Instance.currentHP.ToString() + " / " + OmniEnemy.Instance.maxHP.ToString(); //update du texte des pv de l'ennemi

        playerMana.text = OmniPlayer.Instance.currentMana.ToString() + " / " + OmniPlayer.Instance.maxMana.ToString();//update txt mana player
        ennemiMana.text = OmniEnemy.Instance.currentMana.ToString() + " / " + OmniEnemy.Instance.maxMana.ToString();//update txt mana enemy

        playerHpImage.fillAmount = ((float)OmniPlayer.Instance.currentHP / (float)OmniPlayer.Instance.maxHP); //update de l'image des pv du personnage
        ennemiHPImage.fillAmount = ((float)OmniEnemy.Instance.currentHP / (float)OmniEnemy.Instance.maxHP); //update de l'image des pv de l'ennemi

        playerManaImage.fillAmount = (OmniPlayer.Instance.currentMana / OmniPlayer.Instance.maxMana);//update mana bar player  
        ennemiManaImage.fillAmount = (OmniEnemy.Instance.currentMana / OmniEnemy.Instance.maxMana);//update mana bar enemy
            
    }

    /*public void UpdateUI(float dt)
    {
        playerHp.text = player.currentHP.ToString() + " / " + player.maxHP.ToString(); //update du texte des pv du personnage
        ennemiHP.text = ennemi.currentHP.ToString() + " / " + ennemi.maxHP.ToString(); //update du texte des pv de l'ennemi

        playerHpImage.fillAmount = ((float)player.currentHP / (float)player.maxHP); //update de l'image des pv du personnage
        ennemiHPImage.fillAmount = ((float)ennemi.currentHP / (float)ennemi.maxHP); //update de l'image des pv de l'ennemi
    }*/

    /*public void FixedUpdateUI(float dt)
    {

    }*/
}
