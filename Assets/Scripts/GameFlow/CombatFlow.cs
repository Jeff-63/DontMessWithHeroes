using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow
{

    UIManager uiManager;
    public static CombatLinks cl;
    BaseCharacterClass bcc;
    Player p;
    Enemy e;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        cl = GameObject.FindObjectOfType<CombatLinks>(); //récupérations de tous les liens de la scene
        bcc = new BaseCharacterClass();
        uiManager = new UIManager();
        uiManager.Init();
        p = new Player();
        e = new Enemy();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        uiManager.Update(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
