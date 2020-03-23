using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMovement : MonoBehaviour
{
    private Transform follower;
    private float smoothTime = 0.15f;

    public void SetFollower(Transform follower)
    {
        this.follower = follower;
    } 
    
    private void FixedUpdate()
    {
        if(follower != null)
        {
            Vector2 velocity = Vector2.zero;
            
            Vector2 position = Vector2.SmoothDamp(transform.position, follower.position, ref velocity, smoothTime);  
            transform.position = new Vector3( position.x, position.y, transform.position.z);
        }
    }
}
