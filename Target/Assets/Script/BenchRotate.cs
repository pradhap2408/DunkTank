using UnityEngine;

public class BenchRotate : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 2f;

    private bool moving = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position - new Vector3(0f, 0f, -moveDistance);
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                moving = false;
            }
        }
    }

    public void MoveBench()
    {
        if (!moving)
        {
            targetPosition = transform.position - new Vector3(0f, 0f, -moveDistance);
            moving = true;
        }
    }
}