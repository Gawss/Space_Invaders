using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[System.Serializable]
public class ObjectPoolItem {

    public GameObject objPrefab;
    public int poolSize = 0;

}

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> objects;
    [SerializeField] private List<ObjectPoolItem> elementsToPool = null;
    
    private Vector2 initialPosition;

    
    void Start()
    {
        initialPosition = new Vector2(GlobalManager.Instance.SettingsManager().screenBorder_Right + 5.0f, 0.0f);
        InitPooler();
    }

    private void InitPooler()
    {
        objects = new List<GameObject>();

        foreach (ObjectPoolItem element in elementsToPool) {
            for (int i = 0; i < element.poolSize; i++) {
                AddObject(element.objPrefab);
            }
        }
    }

    private void AddObject(GameObject element)
    {
        GameObject instance = (GameObject)Instantiate(element,transform);
        instance.name = instance.tag;
		instance.transform.position = initialPosition;
        instance.gameObject.SetActive(false);
        objects.Add(instance);
    }

    /// Return element from the pool, filtering by tag
    public GameObject GetObjectByTag(string tag, int objType)
    {
        for (int i = 0; i < objects.Count; i++) {
            if (!objects[i].activeInHierarchy && objects[i].tag == tag) {
                if(tag == "Enemy"){
                    if(objects[i].GetComponent<Enemy>().type == objType){
                        return AllocateObject(objects[i]);
                    }
                }else if(tag == "Bullet"){
                    return AllocateObject(objects[i]);
                }
            }
        }

        GameObject element = elementsToPool[objType].objPrefab;
        AddObject(element);
        return AllocateObject(element);
    }

    private GameObject AllocateObject(GameObject element)
    {
        objects.Remove(element);
        element.SetActive(true);
        return element;
    }

    public void ReleaseElement(GameObject element)
    {
        element.SetActive(false);
        if(element.tag == "Bullet"){
            element.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        element.transform.position = initialPosition;        

        objects.Add(element);
    }
}
