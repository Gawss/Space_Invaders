using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class EnemyManager : MonoBehaviour
{
    private Enemy enemy;
    private GameObject shield;
    private GameObject player;
    
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player");
        shield = transform.GetChild(0).gameObject;
        enemy.ChangeDirection();
    }

    void FixedUpdate(){
        enemy.Move(player);
        enemy.Remove();
    }

    public void Deactivate(){
        GlobalManager.Instance.GameManager().enemiesPool.ReleaseElement(this.gameObject);
        GlobalManager.Instance.GameManager().UpdateScore(enemy.points);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet" && other.GetComponent<Projectile>().activeSkin == enemy.type)
        {
            enemy.gameObject.GetComponent<AudioSource>().clip = GlobalManager.Instance.AudioManager().enemyDeath;
            enemy.gameObject.GetComponent<AudioSource>().Play();
            enemy.gameObject.GetComponent<Animator>().SetTrigger("dead");

        }else if(other.tag == "Bullet"){
            enemy.gameObject.GetComponent<Animator>().SetTrigger("drawShield");
            enemy.gameObject.GetComponent<AudioSource>().clip = GlobalManager.Instance.AudioManager().shield;
            enemy.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
