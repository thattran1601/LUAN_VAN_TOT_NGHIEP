using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;

public class ButtonSkill : MonoBehaviour
{
    public static ButtonSkill instance;
    public float Cooldown;
    public TextMeshProUGUI TextCoolDown;
    public GameObject CoolDown;
    public bool Iscooldown=false;

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
    public void onClick()
    {
        if (Iscooldown == true)
            return;
        if (UISetting.intance.isSetting == true)
            return;
       
            SkillManager.Instance.StartSelectingSkill();
            StartCoroutine(CooldownSKill());
           

    }
    public void OnclickSkillDatBiet()
    {
        if (Iscooldown == true)
            return;
        SkillDatBiet.Instance.buttonSkill();
        StartCoroutine(CooldownSKill());
    }    
    public IEnumerator CooldownSKill()
    {
        Iscooldown = true;
        CoolDown.SetActive(true);   
        float time = Cooldown;
        while(time>0)
        {
            TextCoolDown.text=Mathf.Ceil(time).ToString();
            time -= Time.deltaTime;
            yield return null;

        }
        TextCoolDown.text = "";
        CoolDown.SetActive(false);
        Iscooldown=false;
    }    
}