using UnityEngine;
public interface IObstacleHandler
{
    void HandleObstacle(Vector2 origin, Vector2 direction, float distance, LayerMask layer);
}
