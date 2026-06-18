using System.Collections;
using System.Threading;
using UnityEngine;

public class Ban_Cung : MonoBehaviour
{
    public static Ban_Cung instance;
    public GameObject FrelafMuiTen;
    public Transform positionMuiten;
    public float speed;
    public int count;
    public int dame;

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
        count++;
        GameObject muiten = Instantiate(FrelafMuiTen, positionMuiten.position, Quaternion.identity);
        MuiTen mt=muiten.GetComponent<MuiTen>();
        AI_Chuyen_Dong Ai = GetComponent<AI_Chuyen_Dong>();
        Attack attack = GetComponent<Attack>();
        dame = attack.dame;
        mt.dame = dame;
        if (Ai.IsSkill == true)
        {
            mt.dame *= 2;
        }
       
        Rigidbody2D rb=muiten.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;
          
    }    
}
