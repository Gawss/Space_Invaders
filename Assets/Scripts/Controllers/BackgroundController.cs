using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private int m_speed = 1;
    
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0,17,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        transform.Translate(Vector3.down * m_speed * Time.deltaTime);
        if(GlobalManager.Instance.SettingsManager().screenBorder_Bottom > transform.position.y){
            transform.position = initialPosition;
        }
    }
}
