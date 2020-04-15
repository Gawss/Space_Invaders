using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class Player : MonoBehaviour
{
    private GameObject projectile;
    private Projectile projectileController;

    [SerializeField] private float m_screenOffset = 0.5f;
    [SerializeField] private float m_movementSpeed = 25;
    
    [Range(0.1f, 1.0f)] [SerializeField] private float m_attackSpeed;
    [SerializeField] private float m_maxAttackSpeed = 1;
    private bool m_canAttack;

    [SerializeField] private List<Sprite> m_skins = null;

    private SpriteRenderer m_spriteRenderer;

    private int m_currentSkin;
    private Vector3 m_initialPosition;
    
    void Start()
    {
        m_canAttack = true;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = m_skins[0];
        m_initialPosition = transform.position;
    }

    public void Move(Vector2 inputValue){
        
        Vector2 translation = new Vector2(inputValue.x * m_movementSpeed * Time.deltaTime, inputValue.y * m_movementSpeed * Time.deltaTime);
        Vector2 newPosition = new Vector2(transform.position.x + translation.x, transform.position.y + translation.y);

        float leftBorder = GlobalManager.Instance.SettingsManager().screenBorder_Left;
        float rightBorder = GlobalManager.Instance.SettingsManager().screenBorder_Right;
        float bottomBorder = GlobalManager.Instance.SettingsManager().screenBorder_Bottom;
        float topBorder = GlobalManager.Instance.SettingsManager().screenBorder_Top;
        
        if(newPosition.x > leftBorder-m_screenOffset && newPosition.x < rightBorder+m_screenOffset && newPosition.y > bottomBorder-m_screenOffset && newPosition.y < topBorder+m_screenOffset){
            transform.Translate(translation);
        }
    }

    public void NormalAttack(){
        
        StartCoroutine(RechargeProjectile());
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * projectileController.force),ForceMode2D.Impulse);
    }

    private IEnumerator RechargeProjectile(){
        m_canAttack = false;
        projectile = GlobalManager.Instance.GameManager().bulletsPool.GetObjectByTag("Bullet", 0);
        projectileController = projectile.GetComponent<Projectile>();
        projectileController.ChangeBullet(m_currentSkin);
        projectile.transform.position = transform.position;

        float t = 5/(m_maxAttackSpeed*m_attackSpeed);
        yield return new WaitForSeconds(t);
        m_canAttack = true;
    }

    public void ChangeShip(int skinNumber){
        m_currentSkin = skinNumber;
        m_spriteRenderer.sprite = m_skins[m_currentSkin];
    }

    #region Get&Set

    public float attackSpeed { set {m_attackSpeed = attackSpeed;} get{return this.m_attackSpeed;}}
    public bool canAttack { set {m_canAttack = canAttack;} get{return this.m_canAttack;}}
    public int currentSkin { set {m_currentSkin = currentSkin;} get{return this.m_currentSkin;}}
    public Vector3 initialPosition { set {m_initialPosition = initialPosition;} get{return this.m_initialPosition;}}

    #endregion
}
