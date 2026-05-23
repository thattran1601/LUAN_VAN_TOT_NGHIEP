using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static CameraShake instance;
    public Vector3 starpos;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator camerashake(float during, float strength)
    {
        starpos=transform.position;
        float timer = 0f;
        while(timer<during)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;
            transform.position = starpos + new Vector3(x, y);
            timer += Time.deltaTime;
            yield return null;
        }           
        transform.position = starpos;

    }    
}
