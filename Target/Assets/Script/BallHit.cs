using UnityEngine;

public class BallHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DunkTarget"))
        {
            Debug.Log("TARGET HIT!");

            Animator animator = collision.gameObject
                .GetComponentInParent<Animator>();

            if (animator != null)
            {
                animator.SetTrigger("Fall");
            }
            else
            {
                Debug.LogError("Person Animator not found!");
            }

            Destroy(gameObject);
        }
    }
}