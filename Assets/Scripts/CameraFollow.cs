
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private BirdController bird;
   
    [SerializeField] private float smoothSpeed = 0.5f;

    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if(bird == null )
        {
            return;
        }
        Vector3 desirePos = new Vector3(bird.GetCurrentTransform().position.x, 0 ) + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position,desirePos, smoothSpeed*Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}
