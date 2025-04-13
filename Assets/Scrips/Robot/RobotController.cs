using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : BYSingletonMono<RobotController>
{
    Vector2 moveDirection;
    public bool runRobot;
    [SerializeField] Rigidbody2D rigi;
    [SerializeField] float timeSpeed;
    void Start()
    {
        moveDirection = Vector2.right;
    }
    void FixedUpdate()
    {
        if(runRobot)
            rigi.velocity = moveDirection * timeSpeed;
    }
}
