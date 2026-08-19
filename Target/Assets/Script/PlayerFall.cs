using UnityEngine;
using System.Collections;

public class PlayerFall : MonoBehaviour
{
    public Animator animator;

    [Header("Tank Fall Position")]
    public Transform tankFallPoint;

    [Header("Fall Settings")]
    public float fallDelay = 1.0f;

    private bool isFalling = false;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void FallIntoTank()
    {
        if (isFalling)
            return;

        isFalling = true;

        // Stop player movement
        if (controller != null)
            controller.enabled = false;

        // Play Fall animation
        if (animator != null)
        {
            animator.SetTrigger("Fall");
        }

        StartCoroutine(MoveIntoTank());
    }

    IEnumerator MoveIntoTank()
    {
        yield return new WaitForSeconds(fallDelay);

        if (tankFallPoint != null)
        {
            transform.position = tankFallPoint.position;
            transform.rotation = tankFallPoint.rotation;
        }
    }
}