using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux du jeu
public class GameFlow : Flow {

    public static GameLinks gl;
    PlayerManager playerManager;
    EnemyManager enemyManager;
    GameUIManager gameUIManager;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        gl = GameObject.FindObjectOfType<GameLinks>(); //récupérations de tous les liens de la scene
        playerManager = new PlayerManager();
        enemyManager = new EnemyManager();
        gameUIManager = new GameUIManager();
        playerManager.Init();// initialisation du joueur
        enemyManager.Init();
        gameUIManager.Init();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        playerManager.Update(dt);
        gameUIManager.Update(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
