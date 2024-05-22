using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDirection : MonoBehaviour
{
    [SerializeField] private Vector2 prevPosition;
    [SerializeField] private GameObject dottedObject;
    public bool isFlying;
    public List<GameObject> spawnedDottedObjects;
   
    void Start()
    {
        prevPosition = transform.position;
    }

   
    void Update()
    {
        if (!isFlying) return;
        float distance = Vector2.Distance(transform.position, prevPosition);
        if(distance > 0.7)
        {
            GameObject spawnedDot = Instantiate(dottedObject, transform.position, Quaternion.identity);
            spawnedDottedObjects.Add(spawnedDot);
            prevPosition = transform.position;
        }
    }
}
