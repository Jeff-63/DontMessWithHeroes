using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {
    Player player;
    GameObject spawnPoint;

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
        spawnPoint = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Spawn"));// cree le spawnpoint
        playerObj.transform.position = spawnPoint.transform.position;
        player = playerObj.GetComponent<Player>();
        player.Init();
    }

    
}
