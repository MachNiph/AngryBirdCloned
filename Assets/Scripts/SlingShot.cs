using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShot : MonoBehaviour
{
    [Header("LineRenderer")]
    [SerializeField] private LineRenderer leftLineRenderer;
    [SerializeField] private LineRenderer rightLineRenderer;

    [Header("Transforms")]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] public Transform midTransform;

    [Header("Offsets")]
    [SerializeField] private Vector2 offset;

    [Header("BirdData")]
    [SerializeField] private float forceMultiplier;
    [SerializeField] private Bird bird;

    public bool canTakeInput = true;

    private void Start()
    {
        ResetSlingSlot();
    }

    void Update()
    {
        if(!canTakeInput)
        {
            return;
        }
        if (Mouse.current.leftButton.isPressed)
        {
            bird.GetCurrentBirdRigiBody().velocity = Vector2.zero;
            bird.GetCurrentBirdRigiBody().isKinematic = true;
            DrawSlingShot();
           
        }

        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            canTakeInput = false;
            ThrowBird();
            ResetSlingSlot();
        }
    }

    private void ResetSlingSlot()
    {
        leftLineRenderer.SetPosition(0, leftPos.position);
        leftLineRenderer.SetPosition(1, leftPos.position);
        rightLineRenderer.SetPosition(0, rightPos.position);
        rightLineRenderer.SetPosition(1, rightPos.position);
    }

    void DrawSlingShot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint((Mouse.current.position.ReadValue()));
        DrawSlingLines(mousePosition);
        MoveBird(mousePosition);
    }


    void DrawSlingLines(Vector3 mousePosition)
    {
        if (Mathf.Abs(mousePosition.x - midTransform.position.x) < 2)
        {
            leftLineRenderer.SetPosition(1, new Vector2(mousePosition.x, leftLineRenderer.GetPosition(1).y));
        }
        if (Mathf.Abs(mousePosition.y - midTransform.position.y) < 2)
        {
            leftLineRenderer.SetPosition(1, new Vector2(leftLineRenderer.GetPosition(1).x, mousePosition.y));
        }

        if (Mathf.Abs(mousePosition.x - midTransform.position.x) < 2)
        {
            rightLineRenderer.SetPosition(1, new Vector2(mousePosition.x, rightLineRenderer.GetPosition(1).y));
        }
        if (Mathf.Abs(mousePosition.y - midTransform.position.y) < 2)
        {
            rightLineRenderer.SetPosition(1, new Vector2(rightLineRenderer.GetPosition(1).x, mousePosition.y));
        }
    }

    void MoveBird(Vector3 mousePosition)
    {
        Vector3 lastPos= leftLineRenderer.GetPosition(1);
        Vector3 birdPosition = lastPos ;
        birdPosition.z= 0;
        float x = (birdPosition.x + midTransform.position.x) /2;
        float y = (birdPosition.y + midTransform.position.y) / 2;

        bird.gameObjects[bird.birdIndex].transform.position = new Vector3(x, y, 0);
        
    }


    void ThrowBird()
    {
        Vector3 endPosition = leftLineRenderer.GetPosition(1);
        Vector3 force = endPosition - midTransform.position;
        bird.GetCurrentBirdRigiBody().isKinematic = false;
        bird.GetCurrentBirdDirection().isFlying = true;
        bird.GetCurrentBirdRigiBody().AddForce(-force * forceMultiplier, ForceMode2D.Impulse);
        bird.IncrementBirdIndex();
    }
}
