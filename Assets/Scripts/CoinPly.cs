using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPly : MonoBehaviour
{
    public float speed = 8f;
    private Vector3 target;
    public int value;
    public bool startPly;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPly == false || target == null)
            return;
        transform.position =Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(Vector3.Distance(transform.position,target)<0.2f)
        {
            GoldManager.instance.AddGold(value);
            Destroy(gameObject);
        }    
    }
    public void setup(int amount)
    {
        value = amount;
        Vector3 Batra = Random.insideUnitSphere;
        transform.position += (Vector3)Batra;
        Invoke(nameof(startfly), 0.3f);
    }
    public void startfly()
    {
        startPly = true;
        target = CoinUIReference.instance.cointarget.position;
    }

}
