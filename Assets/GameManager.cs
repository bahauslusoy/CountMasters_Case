using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management_;


public class GameManager : MonoBehaviour
{



    public GameObject ArrivalPoint;

    public List<GameObject> characters;

    public List<GameObject> destroyEffects;

    public List<GameObject> stainEffects;
    public static int characterCount = 1;

    public List<GameObject> enemies;
    public int HowManyEnemies;
    public GameObject mainCharacter;

    public bool isGameFinished; //OYUN BİTTİ Mİ
    bool isFinished;  // SONA GELDİK Mİ

    public CharController charControl;
    void Start()
    {
        EnemyCreate();
    }
    public void EnemyCreate()
    {
        for (int i = 0; i < HowManyEnemies; i++)
        {
            enemies[i].SetActive(true);
        }
    }


    void Update()
    {

    }
    void AttackSituation()
    {


        if (isFinished)
        {
            if (characterCount == 1 || HowManyEnemies == 0)
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
                    Debug.Log("win");

                }

            }

        }

    }

    public void playerManagement(string process, int incomeNumber, Transform pos)
    {
        switch (process)
        {
            case "Multiply":

                MathLibrary.Multiply(incomeNumber, characters, pos);

                break;



            case "Addition":
                MathLibrary.Addition(incomeNumber, characters, pos);
                break;
        }
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
                characterCount--;
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
                characterCount--;
                if (!situation)
                {
                    characterCount--;
                }
                else
                {
                    HowManyEnemies--;
                }


                break;
            }
        }
        if (!isGameFinished)
        {
            AttackSituation();
        }


    }
    public void EnemyTrigger()
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
    }
}
