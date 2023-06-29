using UnityEngine;
using System.Collections.Generic;

public class FallingTrap : MonoBehaviour
{
    public List<GameObject> trapObjects = new List<GameObject>();
   
    public float trapDelay = 5f;
    public float respawnHeight = -20f; // Adjust this value as needed

    private Dictionary<GameObject, Vector2> originalPositions = new Dictionary<GameObject, Vector2>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Main Character")
        {
            Invoke("ActivateTraps", trapDelay);
        }
    }

    private void ActivateTraps()
    {
        foreach (GameObject trapObject in trapObjects)
        {
            Rigidbody2D trapRigidbody = trapObject.GetComponent<Rigidbody2D>();
            trapRigidbody.gravityScale = 1f;
            originalPositions[trapObject] = trapObject.transform.position;
        }
    }

    private void Update()
    {
        foreach (GameObject trapObject in trapObjects)
        {
            if (trapObject.transform.position.y < respawnHeight)
            {
                ResetTrapObject(trapObject);
            }
        }
    }

    private void ResetTrapObject(GameObject trapObject)
    {
        Rigidbody2D trapRigidbody = trapObject.GetComponent<Rigidbody2D>();
        trapRigidbody.gravityScale = 0f;
        trapRigidbody.velocity = Vector2.zero;
        trapObject.transform.position = originalPositions[trapObject];
    }
}
