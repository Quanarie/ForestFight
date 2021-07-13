using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private const float diffMultiplierForMinMaxTime = 1.05f;
    private static bool isBossSpawned = false;

    public void GameLvlChanged(int lvl)
    {
        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.SetMinTimeBetweenSpawn(enemySpawner.GetMinTimeBetweenSpawn() / diffMultiplierForMinMaxTime);
        enemySpawner.SetMaxTimeBetweenSpawn(enemySpawner.GetMaxTimeBetweenSpawn() / diffMultiplierForMinMaxTime);

        switch (lvl)
        {
            case 1:
                enemySpawner.SetLvlOfEnemies(1);
                break;
            case 2: 
                enemySpawner.SetLvlOfEnemies(2);
                break;
            case 3:
                enemySpawner.SetLvlOfEnemies(3);
                break;
            case 4: break;
            case 5:
                enemySpawner.SetLvlOfEnemies(4);
                if (!isBossSpawned)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BossSpawner>().Spawn();
                    isBossSpawned = true;
                    Destroy(gameObject);
                }
                break;
            case 6:
                isBossSpawned = false;
                break;
            case 7:
                enemySpawner.SetLvlOfEnemies(5);
                break;
            case 8: break;
            case 9:
                enemySpawner.SetLvlOfEnemies(6);
                break;
            case 10: break;
            case 11:
                enemySpawner.SetLvlOfEnemies(7);
                break;
            case 12: break;
            case 13:
                enemySpawner.SetLvlOfEnemies(8);
                break;
            case 14: break;
            case 15:
                enemySpawner.SetLvlOfEnemies(9);
                if (!isBossSpawned)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BossSpawner>().Spawn();
                    isBossSpawned = true;
                    Destroy(gameObject);
                }
                break;
            case 16:
                isBossSpawned = false; 
                break;
            case 17: break;
            case 18:
                enemySpawner.SetLvlOfEnemies(10);
                break;
            case 19: break;
            case 20: break;
            case 25:
                if (!isBossSpawned)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BossSpawner>().Spawn();
                    isBossSpawned = true;
                    Destroy(gameObject);
                }
                break;
            case 26:
                isBossSpawned = false;
                break;
            case 35:
                if (!isBossSpawned)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BossSpawner>().Spawn();
                    isBossSpawned = true;
                    Destroy(gameObject);
                }
                break;
            case 36:
                isBossSpawned = false;
                break;
            case 45:
                if (!isBossSpawned)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BossSpawner>().Spawn();
                    isBossSpawned = true;
                    Destroy(gameObject);
                }
                break;
            case 46:
                isBossSpawned = false;
                break;
        }

    }
}
