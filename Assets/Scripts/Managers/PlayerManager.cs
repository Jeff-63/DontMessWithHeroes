using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {
    Player player;
    Vector3 startingPos = new Vector3(-17,4);

    public void Init()
    {
        CreatePlayer();
    }
    public void Update()
    {
        if (player)
            player.UpdatePlayer();
    }
    public void CreatePlayer()
    {
        GameObject playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Player")); //crée instance joueur
        playerObj.transform.position = startingPos;
        player = playerObj.GetComponent<Player>();
        player.Init();
    }

    
}
