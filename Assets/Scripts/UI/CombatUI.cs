using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    readonly float CHARACTER_SIZE = 3;
    readonly int FILL_VALUE = 1;

    public enum AnimationTurn { PlayerTurn, EnnemiTurn }
    public AnimationTurn animTurn;

    Text playerHp, playerMana, ennemiHP, ennemiMana;
    Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    BaseCharacterClass player, ennemi;
    ParticleSystem[] playerEffect;
    ParticleSystem[] ennemiEffect;
    GameObject playerObj, ennemiObj;
    GameObject uiActionContainer;
    Animator playerAnimator, ennemiAnimator;
    private bool isShowingActionContainer = true;


    Vector2 playerStartingPosition, ennemiStartingPosition;

    public void Initialize()
    {
        uiActionContainer = CombatFlow.cl.uiActionContainer;

        //utilisation du viewport de la camera pour placer les characters
        playerStartingPosition = CombatFlow.cl.camera.ViewportToWorldPoint(new Vector2(.2f, .5f));
        ennemiStartingPosition = CombatFlow.cl.camera.ViewportToWorldPoint(new Vector2(.8f, .5f));

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
                playerImage.sprite = GameObject.Instantiate<Sprite>(Resources.Load<Sprite>("Sprites/Gladiator_Portrait"));
                playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Warrior"));
                break;

            case CharacterClasses.Wizard:
                player = new Wizard();
                playerImage.sprite = GameObject.Instantiate<Sprite>(Resources.Load<Sprite>("Sprites/Wizards_Portrait"));
                playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Wizard"));
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }
        CombatFlow.cl.PlayerCharacter = ChargerPlayer(player);

        switch (OmniEnemy.Instance.characterClass)
        {
            case CharacterClasses.Orc:
                ennemi = new Orc();
                ennemiImage.sprite = GameObject.Instantiate<Sprite>(Resources.Load<Sprite>("Sprites/Orc_Portrait"));
                ennemiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Orc"));
                break;

            case CharacterClasses.Elemental:
                ennemi = new Elemental();
                ennemiImage.sprite = GameObject.Instantiate<Sprite>(Resources.Load<Sprite>("Sprites/Elemental_Portrait"));
                ennemiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Elemental"));
                break;

            case CharacterClasses.Boss:
                ennemi = new Boss();
                ennemiImage.sprite = GameObject.Instantiate<Sprite>(Resources.Load<Sprite>("Sprites/Golem_Portrait"));
                ennemiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Boss"));
                break;

            default:
                Debug.Log("Unhandeled character class : " + player.characterClass);
                break;
        }
        CombatFlow.cl.EnemyCharacter = ennemi;


        playerObj.transform.position = CombatFlow.cl.playerPosition = playerStartingPosition;
        playerObj.transform.localScale *= CHARACTER_SIZE;
        playerAnimator = playerObj.GetComponent<Animator>();

        ennemiObj.transform.position = ennemiStartingPosition;
        ennemiObj.transform.localScale *= CHARACTER_SIZE;
        ennemiAnimator = ennemiObj.GetComponent<Animator>();

        playerEffect = playerObj.GetComponentsInChildren<ParticleSystem>();
        ennemiEffect = playerObj.GetComponentsInChildren<ParticleSystem>();
    }

    public void UpdateUI(float dt)
    {

        playerHp.text = OmniPlayer.Instance.currentHP.ToString() + " / " + OmniPlayer.Instance.maxHP.ToString(); //update du texte des pv du personnage
        ennemiHP.text = OmniEnemy.Instance.currentHP.ToString() + " / " + OmniEnemy.Instance.maxHP.ToString(); //update du texte des pv de l'ennemi

        playerMana.text = OmniPlayer.Instance.currentMana.ToString() + " / " + OmniPlayer.Instance.maxMana.ToString();//update txt mana player
        ennemiMana.text = OmniEnemy.Instance.currentMana.ToString() + " / " + OmniEnemy.Instance.maxMana.ToString();//update txt mana enemy

        playerHpImage.fillAmount = ((float)OmniPlayer.Instance.currentHP / (float)OmniPlayer.Instance.maxHP); //update de l'image des pv du personnage
        ennemiHPImage.fillAmount = ((float)OmniEnemy.Instance.currentHP / (float)OmniEnemy.Instance.maxHP); //update de l'image des pv de l'ennemi


        if (OmniPlayer.Instance.maxMana > 0)
        {
            playerManaImage.fillAmount = (OmniPlayer.Instance.currentMana / OmniPlayer.Instance.maxMana);//update mana bar player  
        }
        else
        {
            playerManaImage.fillAmount = FILL_VALUE;//update mana bar player 
        }
        if (OmniEnemy.Instance.maxMana > 0)
        {
            ennemiManaImage.fillAmount = (OmniEnemy.Instance.currentMana / OmniEnemy.Instance.maxMana);//update mana bar enemy
        }
        else
        {
            ennemiManaImage.fillAmount = FILL_VALUE;//update mana bar player 
        }
    }

    public void AttackAnimation()
    {
        float timer = 1;
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
                Show_HideActionContainer();// le UI s'affiche avant le debut du tour du joueur
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
                ActivateShieldPlayer();
                Show_HideActionContainer();
                animTurn = AnimationTurn.EnnemiTurn;
                break;
            case AnimationTurn.EnnemiTurn:
                ActivateShieldEnnemi();
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
        Show_HideActionContainer();
        animTurn = AnimationTurn.EnnemiTurn;
    }

    public void DieAnimation(AnimationTurn type)
    {
        switch (type)
        {
            case AnimationTurn.PlayerTurn:
                playerAnimator.SetTrigger("Die");
                break;
            case AnimationTurn.EnnemiTurn:
                ennemiAnimator.SetTrigger("Die");
                break;
            default:
                break;
        }
    }

    public void Show_HideActionContainer()
    {
        isShowingActionContainer = !isShowingActionContainer;
        uiActionContainer.SetActive(isShowingActionContainer);
    }

    public void ActivateShieldPlayer()
    {
        foreach (ParticleSystem ps in playerEffect)
        {
            ps.Play();
        }
    }

    public void ActivateShieldEnnemi()
    {
        foreach (ParticleSystem ps in ennemiEffect)
        {
            ps.Play();
        }
    }

    public BaseCharacterClass ChargerPlayer(BaseCharacterClass player)
    {
        player.characterClass = OmniPlayer.Instance.characterClass;
        player.characterLevel = OmniPlayer.Instance.characterLevel;
        player.experience = OmniPlayer.Instance.experience;
        player.maxExperience = OmniPlayer.Instance.maxExperience;
        player.strenght = OmniPlayer.Instance.strenght;
        player.endurance = OmniPlayer.Instance.endurance;
        player.intelligence = OmniPlayer.Instance.intelligence;
        player.agility = OmniPlayer.Instance.agility;
        player.currentHP = OmniPlayer.Instance.currentHP;
        player.maxHP = OmniPlayer.Instance.maxHP;
        player.currentMana = OmniPlayer.Instance.currentMana;
        player.maxMana = OmniPlayer.Instance.maxMana;

        return player;
    }
}
