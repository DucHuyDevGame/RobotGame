using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : BYSingletonMono<RobotController>
{
    Vector2 moveDirection;
    public bool runRobot, timeStart;
    [SerializeField] Rigidbody2D rigi;
    public Rigidbody2D RigiBody => rigi;
    [SerializeField] float timeSpeed;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Vector2 sizeRobot;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundRadius;
    [SerializeField] float roundDistance;
    void Start()
    {
        moveDirection = Vector2.right;
    }
    void FixedUpdate()
    {
        if(!runRobot)
            rigi.velocity = Vector2.zero;
        else
        {
            if(IsGrounded())
                rigi.velocity = new Vector2(moveDirection.x * timeSpeed, rigi.velocity.y);
        }
    }
    public void Jump()
    {
        if (!IsGrounded())
            return;
        rigi.velocity = new Vector2(rigi.velocity.x, 0f);
        Vector2 jumpDirection = (Vector2.up + moveDirection).normalized;
        rigi.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, sizeRobot, 0, -transform.up, roundDistance, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position - transform.up * roundDistance, sizeRobot);
    }
}
