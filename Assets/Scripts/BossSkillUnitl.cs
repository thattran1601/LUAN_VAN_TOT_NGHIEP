using System.Collections;
using UnityEngine;

public class BossSkillUnitl : MonoBehaviour
{
    Animator animator;
    public GameObject PortalEffectPrelaf;
    public GameObject DoomHandPrelaf;
    public Transform target;
    int count;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        target = ManagerLimit.instance.PositionUntil;
    }

    void Update()
    {
        if (Heals_boss.instance.hphientai <= Heals_boss.instance.maxhp / 2&&count==0)
        {
            count = 1;
            StartCoroutine(Until());
        }
    }
    public IEnumerator Until()
    {
        
            animator.SetBool("until", true);
        yield return new WaitForSeconds(1f);
        if (count==1)
        {
            Instantiate(PortalEffectPrelaf, target.position, Quaternion.identity);

        }
       
        if (count == 1)
        {
            Instantiate(DoomHandPrelaf, target.position, Quaternion.identity);

        }
        animator.SetBool("until", false);
        
    }    
}
