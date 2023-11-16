using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float speed = 2.0f;

    private int currentWaypointIndex = 0;

    protected virtual void FixedUpdate()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        transform.LookAt(waypoints[currentWaypointIndex].position);

        float distanceToTarget = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);

        if (distanceToTarget < 0.1f)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex++;
            }
            else
            {
                System.Array.Reverse(waypoints);
                currentWaypointIndex = 0;
            }
        }
    }
}
