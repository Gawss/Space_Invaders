using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed = 5;    

    private float m_newDirectionX = 0;
    [SerializeField] private int m_type = 0;

    [SerializeField] private int m_points = 1;
    public void Move(GameObject goal)
    {
        if(transform.position.x < GlobalManager.Instance.SettingsManager().screenBorder_Left
            || transform.position.x > GlobalManager.Instance.SettingsManager().screenBorder_Right){

            m_newDirectionX = -m_newDirectionX;
        }
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(m_newDirectionX*m_movementSpeed, -m_movementSpeed);
    }

    public void Remove()
    {
        if(transform.position.y < GlobalManager.Instance.SettingsManager().screenBorder_Bottom){

            GlobalManager.Instance.GameManager().enemiesPool.ReleaseElement(this.gameObject);
        }
    }

    public void ChangeDirection(){
        m_newDirectionX = Random.Range(-2.0f, 2.0f);
    }

    #region Get&Set

    public float movementSpeed { set {m_movementSpeed = movementSpeed;} get{return this.m_movementSpeed;}}
    public int type { set {m_type  = type;} get{return this.m_type;}}
    public int points { set {m_points  = points;} get{return this.m_points;}}

    #endregion
}
