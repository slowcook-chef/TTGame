using UnityEngine;

public class BallReset : MonoBehaviour
{
    private BallFactory ballFactory;
    private Rigidbody2D rb;
    [SerializeField] private float lifespan = 2f;

    private float timer = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetFactory(BallFactory factory)
    {
        ballFactory = factory;
    }

    // Update is called once per frame
    void Update()
    {
        // If the ball is not moving, start counting down the timer
        // If the timer reaches the lifespan, reset the ball
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            timer += Time.deltaTime;
            if (timer >= lifespan)
            {
                ResetBall();
            }
        }
        else
        {
            timer = 0f;
        }
    }

    public void ResetBall()
    {
        ballFactory.ReturnBall(gameObject);
    }


}
