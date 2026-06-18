using TMPro;
using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour
{
    public static spawn instance;
    public GameObject Prefab_linh;

    public Transform spawnpoint;

    public int Gold_Remove;

    public int Gold_current;

    public float cooldown = 3f;

    public GameObject spawnCooldown;

    public TextMeshProUGUI cooldownText;
    public Transform GioiHanChuyenDong;

    private bool isCooldown = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Gold_current = GoldManager.instance.CurrentGold;

        spawnCooldown.SetActive(false);
    }

    void Update()
    {
       
        Gold_current = GoldManager.instance.CurrentGold;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (GameManager.instance.IsOver)
            return;
        if (GameManager.instance.IsWin)
            return;
        if (isCooldown)
            return;
        if (UISetting.intance.isSetting == true)
            return;

        
        if (Gold_Remove <= Gold_current)
        {
            GameObject linh= Instantiate(
                Prefab_linh,
                spawnpoint.position,
                Quaternion.identity
            );
            linh.GetComponent<AI_Chuyen_Dong>().GioiHanChuyeDong = GioiHanChuyenDong;
         
            Gold_current -= Gold_Remove;

            GoldManager.instance.CurrentGold = Gold_current;

            GoldManager.instance.UpdateGoldUI();

            StartCoroutine(CooldownRoutine());
        }
    }

    public IEnumerator CooldownRoutine()
    {
        isCooldown = true;

        spawnCooldown.SetActive(true);

        float timer = cooldown;

        while (timer > 0)
        {
            cooldownText.text =
                Mathf.Ceil(timer).ToString();

            timer -= Time.deltaTime;

            yield return null;
        }

        cooldownText.text = "";

        spawnCooldown.SetActive(false);

        isCooldown = false;
    }
}