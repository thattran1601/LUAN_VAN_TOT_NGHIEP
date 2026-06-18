using Unity.Jobs;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    public static SwordProjectile Instance;
    public float Speed;
    public float dame;
    public int dameDuyTri;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            Heals heals = collision.gameObject.GetComponent<Heals>();
            if(heals!=null)
            {
                //heals.NgonLua();
                heals.NgonLuaSkill(dameDuyTri);

                heals.TakeDamage(dame);
            }
        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss heals = collision.gameObject.GetComponent<Heals_boss>();
            if(heals!=null)
            {
                //heals.NgonLua();

                heals.takedame(dame);
            }
        }
    }

}
