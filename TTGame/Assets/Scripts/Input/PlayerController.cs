using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShotCharge shotCharge;
    [SerializeField] private BallFactory ballFactory;
    [SerializeField] private Arms arms;
    private InputSystem_Actions inputActions;

    // Actions are mapped to callback functions
    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Shoot.started += OnShotClicked;
        inputActions.Player.Shoot.canceled += OnShotCanceled;
    }

    void OnDisable()
    {
        inputActions.Player.Shoot.started -= OnShotClicked;
        inputActions.Player.Shoot.canceled -= OnShotCanceled;
        inputActions.Player.Disable();
    }
    //*

    //Callback functions
    private void OnShotClicked(InputAction.CallbackContext context)
    {
        //Charge the shot
        shotCharge.StartChargingShot();

    }

    private void OnShotCanceled(InputAction.CallbackContext context)
    {
        //Shoot the ball
        Rigidbody2D ball = ballFactory.GetBall().GetComponent<Rigidbody2D>();
        arms.ShootBall(ball, shotCharge.EndCharge());
    }
    //*


}