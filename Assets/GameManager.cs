using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> stainEffects;
    public List<GameObject> destroyEffects;
    public List<GameObject> enemyStainEffects;

    void Start()

    {

    }

    void Update()
    {

    }


    public void DestroyEffect(Transform pos)
    {
        foreach (var item in destroyEffects)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pos.position;
                item.GetComponent<ParticleSystem>().Play();
                break;
            }  
        }
    }

    public void StainEffect(Vector3 pos, bool situation = false)
    {
        foreach (var item in stainEffects)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pos;
                item.GetComponent<ParticleSystem>().Play();

            }
        }
    }
    public void EnemyStainEffect(Transform pos, bool situation = false)
    {
        foreach (var item in enemyStainEffects)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pos.position;
                item.GetComponent<ParticleSystem>().Play();

            }
        }


    }

}