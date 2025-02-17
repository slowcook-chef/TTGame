using TreeEditor;
using UnityEngine;
using UnityEngine.Splines;

// This script is responsible for the movement of the ball
// It adds a force to the ball when the space key is pressed
public class Arms : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 1f;
    [SerializeField] private ArrowLogic arrowLogic;
    [SerializeField] private Vector3 targetDirection;

    public void ShootBall(Rigidbody2D rb, float shotCharge)
    {
        rb.WakeUp();
        rb.AddForce(GetDirection() * (shotCharge * forceMultiplier), ForceMode2D.Impulse);
    }
    //Helper functions
    private Vector2 GetDirection()
    {
        Vector2 direction = Vector2.up + Vector2.right + Vector2.up + Vector2.up; ;
        direction.Normalize();
        print(direction);
        arrowLogic.RotateArrowTowards(direction);

        return direction;
    }

}
