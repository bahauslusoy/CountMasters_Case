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
    public GameObject dangerImage;

    void Start()
    {
        dangerImage.SetActive(false);
    }
    void Update()
    {
        playerCountText.text = characterList.Count.ToString();

    }

    private void GameLost()
    {
        Destroy(playerCountText.transform.parent.gameObject);
        failPanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void CharDead()
    {

        StartCoroutine(DangerActive());
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
        newPos.y = 0f;
        return newPos;
    }
    public IEnumerator DangerActive()
    {
        dangerImage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dangerImage.SetActive(false);
    }
}