using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float m_force;
    [SerializeField] private List<Sprite> m_skins = null;
    private SpriteRenderer m_spriteRenderer;

    private int m_activeSkin = 0;

    void Start(){
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeBullet(int skinNumber){
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = m_skins[skinNumber];
        m_activeSkin = skinNumber;
    }

    #region Get&Set

    public float force { set {m_force = force;} get{return this.m_force;}}
    public List<Sprite> skins {get{return this.m_skins;}}
    public int activeSkin {get{return this.m_activeSkin;}}

    #endregion
}
