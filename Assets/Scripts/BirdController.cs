using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    [SerializeField] public GameObject[] gameObjects;
    [SerializeField] private SlingShot slingShots;
    [SerializeField] private HitBox hitBox;
    [SerializeField] private Vector3 birdPosition;
    [SerializeField] private float takeInputTime;
    [SerializeField] private Transform spawnedDottedParent;

    [SerializeField]
    public int birdIndex;


    [SerializeField]private ParticleSystem birdDeathFeather;
    [SerializeField]private ParticleSystem woodDestroy;



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
            Instantiate(birdDeathFeather, gameObjects[birdIndex].transform.position, Quaternion.identity);
            foreach (GameObject dot in GetCurrentBirdDirection().spawnedDottedObjects)
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

    public BirdPower GetCurrentBirdPower()
    {
        return gameObjects[birdIndex].GetComponent<BirdPower>();
    }

    public BirdDirection GetCurrentBirdDirection()
    {
        return gameObjects[birdIndex].GetComponent<BirdDirection>();
    }

    public Transform GetCurrentTransform()
    {
        if (birdIndex < 0 || birdIndex >= gameObjects.Length)
        {
            Debug.LogWarning("Bird index out of range!");
            return null;
        }

        GameObject currentBird = gameObjects[birdIndex];

        if (currentBird != null)
        {
            return currentBird.transform;
        }
        else
        {

            return slingShots.midTransform;
        }
    }

}
