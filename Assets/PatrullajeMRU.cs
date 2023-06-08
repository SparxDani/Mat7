using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullajeMRU : MonoBehaviour
{
    [System.Serializable]
    public struct PatrolNode
    {
        public Transform node;
        public float time;
    }

    public PatrolNode[] patrolNodes;   

    private int currentNodeIndex = 0; 
    private float timeToReachNode;    
    private float timer;           
    private Vector3 startPosition;  
    private Vector3 targetPosition;  

    void Start()
    {
        startPosition = transform.position;
        SetTargetNode();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToReachNode)
        {
            SetTargetNode();
            timer = 0f;
        }

        float t = timer / timeToReachNode;
        transform.position = Vector3.Lerp(startPosition, targetPosition, t);
    }

    void SetTargetNode()
    {
        currentNodeIndex++;
        if (currentNodeIndex >= patrolNodes.Length)
            currentNodeIndex = 0;

        startPosition = transform.position;
        targetPosition = patrolNodes[currentNodeIndex].node.position;
        timeToReachNode = patrolNodes[currentNodeIndex].time;
    }

}
