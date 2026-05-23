using UnityEngine;

public class archerEnemy : MonoBehaviour
{
    public float speed;
    public GameObject prelafArrow;
    public Transform AttackPosition;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void Acher()
    {
      GameObject arrow=  Instantiate(prelafArrow, AttackPosition.position, Quaternion.identity);
        Rigidbody2D rb= arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;

    }    
}
