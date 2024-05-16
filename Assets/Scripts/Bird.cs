using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] public GameObject[] gameObjects;
    [SerializeField] private SlingShot slingShots;
    [SerializeField] private Vector3 birdPosition;
    [SerializeField] private float takeInputTime;
    [SerializeField] private Transform spawnedDottedParent;

    [SerializeField]
    public int birdIndex;


    private void Start()
    {
        birdPosition = slingShots.midTransform.position;
        gameObjects[birdIndex].transform.position = birdPosition;
    }

    public void IncrementBirdIndex()
    {
        StartCoroutine(IncrementBirdIndexCoroutine());
    }


    public IEnumerator IncrementBirdIndexCoroutine()
    {
        if(birdIndex < gameObjects.Length)
        {
            yield return new WaitForSeconds(takeInputTime);
            Destroy(gameObjects[birdIndex]);
            foreach(Transform dot in spawnedDottedParent)
            {
                Destroy(dot.gameObject);
            }
            if(birdIndex == gameObjects.Length - 1)
            {
                yield break;
            }
            birdIndex++;
            gameObjects[birdIndex].transform.position = birdPosition;
            slingShots.canTakeInput = true;
        }
     
    }

    public Rigidbody2D GetCurrentBirdRigiBody()
    {
        return gameObjects[birdIndex].GetComponent<Rigidbody2D>();
    }

    public BirdDirection GetCurrentBirdDirection()
    {
        return gameObjects[birdIndex].GetComponent<BirdDirection>();
    }
}
