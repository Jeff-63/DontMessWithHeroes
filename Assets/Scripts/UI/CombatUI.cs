using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{

    Text playerHp, playerMana, ennemiHP, ennemiMana;
    Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    Player p;
    BaseCharacterClass player, ennemi;
    float UIWidth;
    float pixelPerUnitUI;

    float characterSize = 3;

    Vector2 playerStartingPosition, ennemiStartingPosition;

    public void Initialize()
    {
        UIWidth = CombatFlow.gl.CombatUiCanvas.pixelRect.size.x;
        pixelPerUnitUI = CombatFlow.gl.CombatUiCanvas.referencePixelsPerUnit;

        player = new Warrior();
        ennemi = new Orc();

        player.currentHP -= 10;
        ennemi.currentHP -= 15;

        playerStartingPosition = new Vector2((-UIWidth / pixelPerUnitUI), 0);
        ennemiStartingPosition = new Vector2((UIWidth / pixelPerUnitUI), 0);

        playerHp = CombatFlow.gl.playerHp.GetComponent<Text>(); //pointeur vers le composant text des HP du joueur
        playerMana = CombatFlow.gl.playerMana.GetComponent<Text>(); //pointeur vers le composant text de la mana du joueur
        ennemiHP = CombatFlow.gl.ennemiHP.GetComponent<Text>(); //pointeur vers le composant text des HP de l'ennemi
        ennemiMana = CombatFlow.gl.ennemiMana.GetComponent<Text>(); //pointeur vers le composant text de la mana de l'ennemi

        playerHpImage = CombatFlow.gl.playerHpImage.GetComponent<Image>(); //pointeur vers le composant image des HP du joueur
        playerManaImage = CombatFlow.gl.playerManaImage.GetComponent<Image>(); //pointeur vers le composant image de la mana du joueur
        ennemiHPImage = CombatFlow.gl.ennemiHPImage.GetComponent<Image>(); //pointeur vers le composant image des HP de l'ennemi
        ennemiManaImage = CombatFlow.gl.ennemiManaImage.GetComponent<Image>(); //pointeur vers le composant image de la mana de l'ennemi
        playerImage = CombatFlow.gl.playerImage.GetComponent<Image>(); //pointeur vers le composant image du portrait du joueur
        ennemiImage = CombatFlow.gl.ennemiImage.GetComponent<Image>(); //pointeur vers le composant image du portrait de l'ennemi

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

    /*public void FixedUpdateUI(float dt)
    {

    }*/
}
