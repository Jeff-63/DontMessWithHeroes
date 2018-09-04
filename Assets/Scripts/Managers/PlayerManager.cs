using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager {
    Player player;
    GameObject spawnPoint;
    CinemachineVirtualCamera vcam;

    public void Init()
    {
        CreatePlayer();
    }
    public void Update(float dt)
    {
        if (player)
            player.UpdatePlayer(dt);
    }
    public void CreatePlayer()
    {
        GameObject playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Warrior")); //crée instance joueur
        spawnPoint = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Spawn"));// cree le spawnpoint
        playerObj.transform.position = spawnPoint.transform.position;
        player = playerObj.GetComponent<Player>();
        player.Init();
        GameFlow.gl.vcam.Follow = playerObj.transform;
    }
}
