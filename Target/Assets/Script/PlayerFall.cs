using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    public Animator animator;

    [Header("Tank Fall Position")]
    public Transform tankFallPoint;

    public void FallIntoTank()
    {
        // Play fall animation
        if (animator != null)
        {
            animator.SetTrigger("Fall");
        }

        // Move player into tank
        if (tankFallPoint != null)
        {
            transform.position = tankFallPoint.position;
            transform.rotation = tankFallPoint.rotation;
        }
    }
}