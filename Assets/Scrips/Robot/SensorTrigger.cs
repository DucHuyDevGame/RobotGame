using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Checkpoint"))
        {
            collision.GetComponent<Animator>().SetTrigger("activate");
            RobotController.Instance.runRobot = false;
        }
    }
}
