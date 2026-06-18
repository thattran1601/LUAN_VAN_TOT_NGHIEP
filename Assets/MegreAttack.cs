using System.Collections;
using System.Threading;
using UnityEngine;

public class MegreAttack : MonoBehaviour
{
    public static MegreAttack instance;
    public GameObject FrelafMuiTen;
    public Transform positionMuiten;
    public float speed;
    public int count;
    public int dame;
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
    public void BanTen()
    {
        if (UISetting.intance.isSetting == true)
            return;
        GameObject muiten = Instantiate(FrelafMuiTen, positionMuiten.position, Quaternion.identity);
        AI_Chuyen_Dong Ai = GetComponent<AI_Chuyen_Dong>();
        Attack attack = GetComponent<Attack>();
        dame = attack.dame;
        merge m = muiten.GetComponent<merge>();
      if(m!=null)
        {
            int Soluong = Ai.IsSkill ? 5 : 3;
            m.setup(Soluong, dame);
        }    

        Rigidbody2D rb = muiten.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;

    }
}
