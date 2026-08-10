using UnityEngine;
using UnityEngine.InputSystem;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform shootPoint;
    public float shootForce = 15f;

    public InputActionReference triggerAction;

    private void OnEnable()
    {
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
    }

    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(
            ballPrefab,
            shootPoint.position,
            shootPoint.rotation
        );

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(
                shootPoint.forward * shootForce,
                ForceMode.Impulse
            );
        }
    }
}