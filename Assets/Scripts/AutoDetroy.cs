using UnityEngine;

public class AutoDetroy : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
