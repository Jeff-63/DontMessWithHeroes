using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager{

    List<Enemy> ennemies;

    public void Init()
    {
        ennemies = new List<Enemy>();
        CreateEnnemi();
    }

    public void Update(float dt)
    {
        foreach (Enemy ennemi in ennemies)
        {
            ennemi.UpdateEnnemi(dt);
        }
    }

    public void CreateEnnemi()
    {
        GameObject enemyObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Orc")); //crée instance ennemi
        enemyObj.transform.position = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/EnnemiSpawn")).transform.position;
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.Init();
        ennemies.Add(enemy);
    }

}
