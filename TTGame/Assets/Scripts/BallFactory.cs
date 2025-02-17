using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform poolSpawnPoint;
    private List<GameObject> ballPool = new List<GameObject>();

    private void Start()
    {
        InstatiatePool();
    }

    private void InstatiatePool()
    {
        ballPool.Clear();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab, poolSpawnPoint.position, Quaternion.identity);
            ball.GetComponent<BallReset>().SetFactory(this);
            ball.SetActive(false);
            ballPool.Add(ball);
        }
        Debug.LogWarning("Ball pool created: " + ballPool.Count);
    }

    public GameObject GetBall()
    {
        // Find the first ball that is not active and return it
        foreach (GameObject ball in ballPool)
        {
            if (!ball.activeInHierarchy)
            {
                ball.SetActive(true);
                ball.transform.position = poolSpawnPoint.position;
                return ball;
            }
        }
        Debug.LogWarning("No balls available in the pool");

        return null;
    }

    public void ReturnBall(GameObject ball)
    {
        ball.GetComponent<Rigidbody2D>().Sleep();
        ball.transform.position = poolSpawnPoint.position;
        ball.SetActive(false);
    }

}
