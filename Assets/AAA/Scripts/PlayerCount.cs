using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCount : MonoBehaviour
{
    private int count = 1;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject failPanel;
    public TextMeshProUGUI playerCountText;

    public List<GameObject> characterList = new List<GameObject>();

    void Start()
    {

    }
    void Update()
    {
        playerCountText.text = characterList.Count.ToString();
        
        
           // Destroy(playerCountText);
        


    }

    private void GameLost()
    {
        Destroy(playerCountText.transform.parent.gameObject);
        failPanel.SetActive(true);
        Time.timeScale = 0;


        Debug.Log("Game Lost");
    }

    public void CharDead()
    {
        count--;

        if (count == 0)
        {
            GameLost();

        }
    }

    public void Multiply(int value)
    {
        SpawnChar((value - 1) * count);

        count *= value;
    }

    public void Add(int value)
    {
        count += value;
        SpawnChar(value);
    }

    public void SpawnChar(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject newPlayer = Instantiate(playerPrefab, PlayerPosition(), Quaternion.identity, transform);
            characterList.Add(newPlayer);
        }
    }

    public Vector3 PlayerPosition()
    {
        Vector3 pos = Random.insideUnitSphere * .2f;
        Vector3 newPos = transform.position + pos;
        newPos.y = 0.3f;
        return newPos;
    }
}