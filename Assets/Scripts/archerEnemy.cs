using UnityEngine;

public class archerEnemy : MonoBehaviour
{
    public float speed;
    public GameObject prelafArrow;
    public Transform AttackPosition;
    public int count;
    public int dame;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void Acher()
    {
        count++;
      GameObject arrow=  Instantiate(prelafArrow, AttackPosition.position, Quaternion.identity);
        Rigidbody2D rb= arrow.GetComponent<Rigidbody2D>();
        arrowEnemy arrowDame = rb.GetComponent<arrowEnemy>();
        rb.linearVelocity = Vector2.left * speed;
        if (count >= 5)
        {
            arrowDame.dame = dame * 5;
            count = 0;
        }
    }    
}
