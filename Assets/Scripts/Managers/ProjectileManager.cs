using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class ProjectileManager : MonoBehaviour
{
    private Projectile projectile;
    private InputController inputController;
    private Player player;
    void Start(){
        projectile = GetComponent<Projectile>();
        player = GameObject.FindObjectOfType<Player>();
        inputController = player.gameObject.GetComponent<PlayerManager>().inputController;
    }
    void FixedUpdate()
    {
        Remove();
    }

    private void Remove()
    {
        if(transform.position.x < GlobalManager.Instance.SettingsManager().screenBorder_Left
            || transform.position.x > GlobalManager.Instance.SettingsManager().screenBorder_Right
            || transform.position.y > GlobalManager.Instance.SettingsManager().screenBorder_Top
            || transform.position.y < GlobalManager.Instance.SettingsManager().screenBorder_Bottom){

            GlobalManager.Instance.GameManager().bulletsPool.ReleaseElement(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            GlobalManager.Instance.GameManager().bulletsPool.ReleaseElement(this.gameObject);            
        }
    }
}
