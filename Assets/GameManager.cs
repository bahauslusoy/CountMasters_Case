using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public bool isGameFinished; //OYUN BİTTİ Mİ
    bool isFinished;  // SONA GELDİK Mİ
    public List<GameObject> stainEffects;
    public List<GameObject> destroyEffects;
    public List<GameObject> enemyStainEffects;
    public CharController charControl;
    void Start()

    {

    }

    void Update()
    {

    }
    /*void AttackSituation()
    {
        if (isFinished)
        {

            isGameFinished = true;
            foreach (var item in enemies)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetTrigger("NoAttack");
                }
            }
            foreach (var item in characters)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetTrigger("Stop");
                }
            }

            mainCharacter.GetComponent<Animator>().SetTrigger("Stop");

            if (characterCount < HowManyEnemies || characterCount == HowManyEnemies)
            {
                Debug.Log("Kaybettin");
                charControl.FailPanel.SetActive(true);
            }
            else
            {
                charControl.SuccessPanel.SetActive(true);
                Debug.Log("win");

            }
        }

    }*/

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

    public void StainEffect(Transform pos, bool situation = false)
    {
        foreach (var item in stainEffects)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pos.position;
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
    /*public void EnemyTrigger()
    {
        foreach (var item in enemies)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<EnemyController>().EnemyAttackAnim();
            }
        }
        isFinished = true;
        AttackSituation();
    }*/
}