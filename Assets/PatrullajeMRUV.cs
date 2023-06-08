using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrullajeMRUV : MonoBehaviour
{
    public float acceleration;
    public List<Transform> nodes = new List<Transform>();
    private int currentNodeIndex = 0;

    private float velocity;
    private float time;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = 0f;
        time = 0f;

        if (nodes.Count > 0)
        {
            transform.position = nodes[currentNodeIndex].position;
        }
    }

    private void Update()
    {
        if (nodes.Count == 0)
            return;

        time += Time.deltaTime;
        velocity = acceleration * time;

        Vector2 targetPosition = nodes[currentNodeIndex].position;

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentNodeIndex = (currentNodeIndex + 1) % nodes.Count;
        }

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        rb.velocity = direction * velocity;
    }
}
