using UnityEngine;

public class CoinUIReference : MonoBehaviour
{
    public static CoinUIReference instance;
    public Transform cointarget;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
