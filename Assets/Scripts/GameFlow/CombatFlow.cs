using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow
{

    UIManager uiManagerPlayer, uiManagerEnemy;
    public static GameLinks gl;
    BaseCharacterClass bcc;
    Player p;
    Enemy e;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        gl = GameObject.FindObjectOfType<GameLinks>(); //récupérations de tous les liens de la scene
        uiManagerPlayer = new UIManager();
        uiManagerEnemy = new UIManager();
        bcc = new BaseCharacterClass();
        p = new Player();
        e = new Enemy();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
    }

    //FixedUpdate de tous éléments du flux
    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
