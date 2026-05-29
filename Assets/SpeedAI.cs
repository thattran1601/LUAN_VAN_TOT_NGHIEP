using UnityEngine;

public class SpeedAI : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Vector3 towtal;
    void Start()
    {
        towtal = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, towtal, 0.001f);
        if(Vector3.Distance(transform.position,towtal)<=0.1f)
        {
            if(towtal==posA.position)
            {
                towtal=posB.position;
                
            }
            else if(towtal==posB.position)
            {towtal=posA.position;

            }

        }    
    }
}
