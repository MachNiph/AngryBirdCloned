using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDirection : MonoBehaviour
{
    [SerializeField] private Vector2 prevPosition;
    [SerializeField] private GameObject dottedObject;
    [SerializeField] private Transform spawnedDottedObjectParent;
    public bool isFlying;
   
    void Start()
    {
        prevPosition = transform.position;
    }

   
    void Update()
    {
        if (!isFlying) return;
        float distance = Vector2.Distance(transform.position, prevPosition);
        if(distance > 0.5)
        {
            GameObject spawnedDottedObject =  Instantiate(dottedObject, transform.position, Quaternion.identity);
            spawnedDottedObject.transform.SetParent(spawnedDottedObjectParent.transform);
            prevPosition = transform.position;
        }
    }
}
