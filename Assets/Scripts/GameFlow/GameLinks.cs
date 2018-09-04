using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameLinks : MonoBehaviour {

    [Header ("Camera Setting")]
    public CinemachineVirtualCamera vcam;

    [Header("Combat UI Setting")]
    public Text playerHp;
    public Text playerMana, ennemiHP, ennemiMana;
    public Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    public Canvas CombatUiCanvas;
}
