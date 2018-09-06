using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CombatLinks : MonoBehaviour {

    [Header("Combat UI Setting")]
    public Text playerHp;
    public Text playerMana, ennemiHP, ennemiMana;
    public Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    public Canvas combatUiCanvas;
    public GameObject uiActionContainer;
    public Camera camera; // used in combatUI
    public Button attackButton;
    public Button defenseButton;
    public Button runAwayButton;
    public Vector2 playerPosition;


    [Header("CombatMachine Setting")]
    public CombatStateMachine csm;
    public CombatUI cUI;
    public BaseCharacterClass PlayerCharacter;
    public BaseCharacterClass EnemyCharacter;
}
