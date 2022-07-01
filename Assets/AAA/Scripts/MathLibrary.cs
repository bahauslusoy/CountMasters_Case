using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Management_
{
public class MathLibrary : MonoBehaviour
{
    public static void Multiply(int incomeNumber, List<GameObject> characters, Transform pos)
    
    {
        int LoopNumber = (GameManager.characterCount * incomeNumber) - GameManager.characterCount;
        //                     10                           3                 10 =     20
        //                      5                         6                    5 = 25                Dongu sayısını yapabilmek için 
        int number = 0;

        foreach (var item in characters)
        {

            if (number < LoopNumber)
            {
                if (!item.activeInHierarchy)
                {
                    item.transform.position = pos.position;
                    item.SetActive(true);
                    number++;

                }
            }
            else
            {
                number = 0;
                break;
            }
        }



        GameManager.characterCount *= incomeNumber;

    }

    public static void Addition(int incomeNumber, List<GameObject> characters, Transform pos)
    {
        int number2 = 0;

                foreach (var item in characters)
                {

                    if (number2 < incomeNumber)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = pos.position;
                            item.SetActive(true);
                            number2++;

                        }
                    }
                    else
                    {
                        number2 = 0;
                        break;
                    }
                }
                GameManager.characterCount += incomeNumber;
    }
}





}
