using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject player;

    // Waves
    public int currentWave = 0;
    public int enemiesLeft, totalEnemies;
    public bool spawned = false;
    GameObject[] enemies;

    public GameObject enemyObject1;
    public GameObject bossObject1;
    public GameObject bossObject2;

    // Update is called once per frame
    private void Update()
    {
        if (player.GetComponent<Health>().getHealth() >= 0)
        {
            SpawnEnemies();
        }
    }

    public void Restart()
    {
        float maxHealth = player.GetComponent<Health>().maxHealth;
        float playerHealth = player.GetComponent<Health>().getHealth();
        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var clone in clones)
        {
            string name = clone.transform.name;
            if (name == "Enemy1(Clone)" || name == "Enemy2(Clone)" || name == "Boss1(Clone)" || name == "Boss2(Clone)")
            {
                Destroy(clone);
            }
        }
        enemiesLeft = 0;
        spawned = false;
        currentWave = 0;
        player.transform.position = new Vector3(0f, 1f, 0f);
        player.GetComponent<Health>().currentHealth = maxHealth;
    }

    private void SpawnEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        int enemiesPrint = enemiesLeft - 3;
        text.SetText("Wave: " + currentWave + "/10 Enemies Left: " + enemiesPrint + "/" + totalEnemies);

        if (enemiesPrint <= 0)
        {
            currentWave++;
            spawned = false;
        }

        if (!spawned)
        {
            if (currentWave == 1)
            {
                totalEnemies = 3;
                enemiesLeft = totalEnemies;
                GameObject enemy1 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy2 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy3 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                spawned = true;
            }
            else if (currentWave == 2)
            {
                totalEnemies = 5;
                enemiesLeft = totalEnemies;
                GameObject enemy1 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy2 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy3 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject enemy4 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject enemy5 = Instantiate(enemyObject1, new Vector3(15.59f, 0.7f, 27.6f), Quaternion.identity);
                spawned = true;
            } 
            else if (currentWave == 3)
            {
                totalEnemies = 8;
                enemiesLeft = totalEnemies;
                GameObject enemy1 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy2 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy3 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject enemy4 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject enemy5 = Instantiate(enemyObject1, new Vector3(30.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy6 = Instantiate(enemyObject1, new Vector3(15.59f, 0.7f, 30.6f), Quaternion.identity);
                GameObject enemy7 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy8 = Instantiate(enemyObject1, new Vector3(32f, 0.7f, 27.6f), Quaternion.identity);

                spawned = true;
            }
            else if (currentWave == 4)
            {
                totalEnemies = 10;
                enemiesLeft = totalEnemies;
                GameObject enemy1 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy2 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy3 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject enemy4 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject enemy5 = Instantiate(enemyObject1, new Vector3(30.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy6 = Instantiate(enemyObject1, new Vector3(15.59f, 0.7f, 30.6f), Quaternion.identity);
                GameObject enemy7 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy8 = Instantiate(enemyObject1, new Vector3(32f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy9 = Instantiate(enemyObject1, new Vector3(30f, 0.7f, 17f), Quaternion.identity);
                GameObject enemy10 = Instantiate(enemyObject1, new Vector3(20f, 0.7f, 18f), Quaternion.identity);

                spawned = true;
            }
            else if (currentWave == 5)
            {
                totalEnemies = 1;
                enemiesLeft = totalEnemies;
                GameObject boss1 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                spawned = true;
            }
            else if (currentWave == 6)
            {
                totalEnemies = 15;
                enemiesLeft = totalEnemies;
                GameObject enemy1 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy2 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy3 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject enemy4 = Instantiate(enemyObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject enemy5 = Instantiate(enemyObject1, new Vector3(30.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy6 = Instantiate(enemyObject1, new Vector3(15.59f, 0.7f, 30.6f), Quaternion.identity);
                GameObject enemy7 = Instantiate(enemyObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy8 = Instantiate(enemyObject1, new Vector3(32f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy9 = Instantiate(enemyObject1, new Vector3(30f, 0.7f, 17f), Quaternion.identity);
                GameObject enemy10 = Instantiate(enemyObject1, new Vector3(20f, 0.7f, 18f), Quaternion.identity);
                GameObject enemy11 = Instantiate(enemyObject1, new Vector3(29.59f, 0.7f, 21.6f), Quaternion.identity);
                GameObject enemy12 = Instantiate(enemyObject1, new Vector3(21.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject enemy13 = Instantiate(enemyObject1, new Vector3(25.59f, 0.7f, 25.6f), Quaternion.identity);
                GameObject enemy14 = Instantiate(enemyObject1, new Vector3(23.59f, 0.7f, 13.6f), Quaternion.identity);
                GameObject enemy15 = Instantiate(enemyObject1, new Vector3(15.59f, 0.7f, 15.6f), Quaternion.identity);
                spawned = true;
            }
            else if (currentWave == 7)
            {
                totalEnemies = 3;
                enemiesLeft = totalEnemies;
                GameObject boss1 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss2 = Instantiate(bossObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss3 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);

                spawned = true;
            }
            else if (currentWave == 8)
            {
                totalEnemies = 5;
                enemiesLeft = totalEnemies;
                GameObject boss1 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss2 = Instantiate(bossObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss3 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject boss4 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject boss5 = Instantiate(bossObject1, new Vector3(30.59f, 0.7f, 27.6f), Quaternion.identity);
                spawned = true;
            }
            else if (currentWave == 9)
            {
                totalEnemies = 10;
                enemiesLeft = totalEnemies;
                GameObject boss1 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss2 = Instantiate(bossObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss3 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 20.6f), Quaternion.identity);
                GameObject boss4 = Instantiate(bossObject1, new Vector3(27.59f, 0.7f, 15.6f), Quaternion.identity);
                GameObject boss5 = Instantiate(bossObject1, new Vector3(30.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss6 = Instantiate(bossObject1, new Vector3(15.59f, 0.7f, 30.6f), Quaternion.identity);
                GameObject boss7 = Instantiate(bossObject1, new Vector3(20.59f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss8 = Instantiate(bossObject1, new Vector3(32f, 0.7f, 27.6f), Quaternion.identity);
                GameObject boss9 = Instantiate(bossObject1, new Vector3(30f, 0.7f, 17f), Quaternion.identity);
                GameObject boss10 = Instantiate(bossObject1, new Vector3(20f, 0.7f, 18f), Quaternion.identity);

                spawned = true;
            }
            else if (currentWave == 10)
            {
                totalEnemies = 1;
                enemiesLeft = totalEnemies;
                GameObject boss1 = Instantiate(bossObject2, new Vector3(27.59f, 0.7f, 27.6f), Quaternion.identity);
                spawned = true;
            }
        }
    }
}
