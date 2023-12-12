using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour
{
    [Range(0, 100)] public float speed = 20f;
    public enum Direction {
        UP,
        DOWN
    };
    public Direction direction;
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;
        float s = speed;
        if(direction == Direction.DOWN)
        {
            dir = Vector3.down;
            s = -speed;
        }
       this.transform.RotateAround(this.transform.position, dir, s * Time.deltaTime);
        
    }
}
