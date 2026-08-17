using UnityEngine;

public class BallHit : MonoBehaviour
{
    private BenchRotate bench;
    private PlayerFall playerFall;

    void Start()
    {
        bench = FindFirstObjectByType<BenchRotate>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerFall = player.GetComponent<PlayerFall>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Target"))
            return;

        // Bench move
        if (bench != null)
        {
            bench.MoveBench();
        }

        // Player falls into tank
        if (playerFall != null)
        {
            playerFall.FallIntoTank();
        }
    }
}