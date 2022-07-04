using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public enum SpawnerState
    {
        additive,
        multiplier
    }

    public SpawnerState currentMathState;
    private PlayerCount playerCount;

    private SpriteRenderer spriteRenderer;
    public int size;
    public static bool isGateActive = true;

    private void Awake()
    {
        playerCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCount>();
        //sizeText = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isGateActive && other.tag == "SubPlayer")
        {
            spriteRenderer.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(GateActive());

            switch (currentMathState)
            {
                case SpawnerState.additive:
                    playerCount.Add(size);
                    break;
                case SpawnerState.multiplier:

                    playerCount.Multiply(size);
                    break;
            }
        }
    }

    public IEnumerator GateActive()
    {
        isGateActive = false;
        yield return new WaitForSeconds(1.7f);
        isGateActive = true;
    }
}
