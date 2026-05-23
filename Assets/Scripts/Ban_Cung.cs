using UnityEngine;

public class Ban_Cung : MonoBehaviour
{
    public GameObject FrelafMuiTen;
    public Transform positionMuiten;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BanTen()
    {
        if (UISetting.intance.isSetting == true)
            return;
        GameObject muiten = Instantiate(FrelafMuiTen, positionMuiten.position, Quaternion.identity);
        Rigidbody2D rb=muiten.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;
    }    
}
