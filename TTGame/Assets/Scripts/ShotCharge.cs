using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotCharge : MonoBehaviour
{
    [SerializeField] private float chargeSpeed = 1f;
    [SerializeField] private Slider slider;
    private float maxCharge = 10f;
    private float chargeValue = 0f;
    private bool isCharging = false;


    public void StartChargingShot()
    {
        if (isCharging) return;
        StartCoroutine(ChargeShotCoroutine());

    }
    private IEnumerator ChargeShotCoroutine()
    {
        slider.gameObject.SetActive(true);
        isCharging = true;
        chargeValue = 0f;
        while (isCharging)
        {
            slider.value = chargeValue;
            //Bounce the chargeValue between 0 and maxCharge
            chargeValue = Mathf.PingPong(Time.time * chargeSpeed, maxCharge);
            yield return null;
        }

    }

    // Stop the coroutine and return the charge value
    public float EndCharge()
    {
        slider.gameObject.SetActive(false);
        isCharging = false;
        return chargeValue;
    }
}
