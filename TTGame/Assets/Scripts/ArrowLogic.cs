using UnityEngine;

public class ArrowLogic : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    public void RotateArrowTowards(Vector3 direction)
    {
        pivot.rotation = Quaternion.Euler(direction);
    }

    public void SetScale(float scale)
    {
        pivot.localScale = new Vector3(1, 1, scale);
    }
}
