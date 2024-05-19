using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdPower : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float forcePower;
    [SerializeField] protected Vector3 birdPosition;
    [SerializeField] bool canPowerUp = true;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && canPowerUp)
        {

            PowerUp();
            canPowerUp = false;
        }
        birdPosition = transform.position;

    }

    protected virtual void PowerUp()
    {
    }
}
