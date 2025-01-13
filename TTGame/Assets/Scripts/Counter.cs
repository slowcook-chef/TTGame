using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int count = 0;
    [SerializeField] private TMPro.TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = count.ToString();
    }
    public void Increment()
    {
        text.text = count++.ToString();
    }
}
