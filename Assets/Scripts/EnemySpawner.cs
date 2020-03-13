using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    Transform transform;
    [SerializeField] GameObject enemy;
    public static int enemies = 0;
    float attackSpeed = 0;
    float speed = 0;
    int damage = 0;
    int health = 0;
    int number = 3;
    [SerializeField] float speedMult = 1.1f;
    [SerializeField] float attackSpeedMult = 1.1f; //do not make less than 1
    [SerializeField] int damageIncrease = 1;
    [SerializeField] int healthIncrease = 1;
    [SerializeField] BattleMusic battleMusic;
    [SerializeField] BattleMusic ambience;
    [SerializeField] float musicFade;
    //public Text enemyText;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == 0)
        {
            StartCoroutine(battleMusic.fadeOut(musicFade));
            StartCoroutine(this.playWaveEnd(musicFade, ambience));
            //instantiate some next wave button that calls the spawn enemies function when clicked
            this.waveEnd();
        }
       //enemyText.text = enemies.ToString();
    }

    public void spawnEnemies()
    {
        GameObject currentEnemy;
        AI collider;
        float angle;
        for (int i = 0; i < number; i++)
        {
            angle = Random.Range(0, 360);
            Vector3 position = new Vector3(transform.position.x - (Mathf.Cos(angle) * 5f), 12.5f, transform.position.z - (Mathf.Sin(angle) * 5f));
            currentEnemy = Instantiate(enemy, position, Quaternion.identity);
            enemies++;
            collider = currentEnemy.GetComponent<AI>();
            collider.increaseStats(attackSpeed, damage, health, speed);
            Debug.Log("looped");
        }
        StartCoroutine(ambience.fadeOut(musicFade));
        StartCoroutine(this.playWaveEnd(musicFade, battleMusic));
    }

    public void waveEnd()
    {
        attackSpeed *= attackSpeedMult;
        speed *= speedMult;
        health += healthIncrease;
        damage += damageIncrease;
        number++;
    }

    IEnumerator playWaveEnd(float delay, BattleMusic track)
    {
        yield return new WaitForSeconds(delay);
        track.play();
    }
}
