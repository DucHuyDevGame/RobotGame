using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    Vector2 moveDirection;
    public bool runRobot, timeStart;
    [SerializeField] Rigidbody2D rigi;
    [SerializeField] float timeSpeed;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Vector2 sizeRobot;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundRadius = 0.1f;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] float distance;
    [SerializeField] GameObject obstacleCheck;
    [SerializeField] float roundDistance;
    void Start()
    {
        moveDirection = Vector2.right;
    }
    private void Update()
    {
        HandleObstacle(obstacleCheck.transform.position, Vector2.right, distance, wallLayer);
    }
    public void HandleObstacle(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layer);
        Debug.DrawRay(origin, direction * distance, Color.green);
        if (hit.collider == null)
            return;
        Jump();
    }
    void FixedUpdate()
    {
        if (IsGrounded())
        {
            rigi.velocity = new Vector2(moveDirection.x * timeSpeed, rigi.velocity.y);
        }
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            rigi.velocity = new Vector2(rigi.velocity.x, 0f);
            Vector2 jumpDirection = (Vector2.up + moveDirection).normalized;
            rigi.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        }
        Debug.Log($"Is ground: {IsGrounded()}");
    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, sizeRobot, 0, -transform.up, roundDistance,groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position - transform.up * roundDistance, sizeRobot);
    }

}
