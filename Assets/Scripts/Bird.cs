using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] public GameObject[] gameObjects;
    [SerializeField] private SlingShot slingShots;
    [SerializeField] private Vector3 birdPosition;

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
        yield return new WaitForSeconds(1);
        birdIndex++;
        gameObjects[birdIndex].transform.position = birdPosition;
    }

    public Rigidbody2D GetCurrentBirdRigidbody()
    {
        return gameObjects[birdIndex].GetComponent<Rigidbody2D>();
    }
}
