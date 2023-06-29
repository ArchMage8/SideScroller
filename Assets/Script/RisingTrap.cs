using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTrap : MonoBehaviour
{
    public Transform trap;
    public float upperLimitY = 5f;
    public GameObject player;
    public float speed = 1f;
    public float risedelay = 1f;
    public float returndelay = 1f;

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = trap.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            StartCoroutine(MoveTrap());
        }
    }

    private System.Collections.IEnumerator MoveTrap()
    {
        yield return new WaitForSeconds(risedelay);

        while(trap.position.y < upperLimitY)
        {
            trap.position += Vector3.up * speed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(returndelay);
        
        while(trap.position.y > originalPosition.y)
        {
            trap.position += Vector3.down * speed * Time.deltaTime;

            yield return null;
        }
    }
}
