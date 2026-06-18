using System.Collections;
using TMPro.Examples;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [Header("State")]
    public bool isSelectingSkill;

    [Header("Cursor")]
    public Texture2D normalCursor;
    public Texture2D skillCursor;

    [Header("Skill")]
    public GameObject fireballEffect;

    public float damageRadius = 2f;

    [Header("Preview")]
    public GameObject skillPreview;

    public float rangerandom = 2f;
    public float hightSpawn = 6f;
    public int countSkill = 10;
    public float delay = 0.2f;
    public GameObject MagicCirle;
    public float DelayMagic=0.5f;
    public float DelayMagicCirle;
    public ManaManager ManagerMana;
    public int Mana;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        HandlePreview();
        if (GameManager.instance.IsOver)
            return;
        if (GameManager.instance.IsWin)
            return;

        if (!isSelectingSkill)
            return;

        // click trái cast
        if (Input.GetMouseButtonDown(0))
        {
           Vector3 movePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePos.z = 0;
            StartCoroutine(skill(movePos));
            ResetSkillState();

            
           
        }

        // click phải cancel
        if (Input.GetMouseButtonDown(1))
        {
            CancelSkill();
        }
    }

    void HandlePreview()
    {
        if (!isSelectingSkill)
        {
            skillPreview.SetActive(false);
            return;
        }

        skillPreview.SetActive(true);

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0f;

        skillPreview.transform.position = mousePos;
    }

    public IEnumerator skill(Vector3 centerpos)
    {
        if (ManagerMana.CurrentMana >= Mana)
        {
            ManagerMana.UseMana(Mana);
            GameObject Magic = Instantiate(MagicCirle, centerpos, Quaternion.identity);
            for (int i = 0; i < countSkill; i++)
            {
                CastSkill(centerpos);
                yield return new WaitForSeconds(delay);
            }
            Destroy(Magic, 1f);
        }
    }  
    public void CastSkill(Vector3 centerpos)
    {
   

        float randomx = Random.Range(-rangerandom, rangerandom);
        Vector3 targetpos = new Vector3(centerpos.x - randomx, centerpos.y, 0);
        Vector3 spawn = new Vector3(targetpos.x, hightSpawn, 0);
       
        GameObject methot = Instantiate(fireballEffect, spawn, Quaternion.identity);
        methot.GetComponent<FireballProjectile>().targetPosition=targetpos;

        

    }

    public void StartSelectingSkill()
    {
      
            isSelectingSkill = true;
            Cursor.visible = false;
            skillPreview.SetActive(true);
        

        //Cursor.SetCursor(
        //    skillCursor,
        //    Vector2.zero,
        //    CursorMode.Auto
        //);
    }

    void CancelSkill()
    {
        ResetSkillState();
    }

    void ResetSkillState()
    {
        isSelectingSkill = false;
        skillPreview.SetActive(false);

      Cursor.visible = true;
    }
   
}