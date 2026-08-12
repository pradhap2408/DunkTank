using UnityEngine;

public class BenchRotate : MonoBehaviour
{
    public float rotateSpeed = 300f;

    private bool rotating = false;
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        if (rotating)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                rotating = false;
            }
        }
    }

    public void RotateBench()
    {
        if (!rotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            rotating = true;
        }
    }
}