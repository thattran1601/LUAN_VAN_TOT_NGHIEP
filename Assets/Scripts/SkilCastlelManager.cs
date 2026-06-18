using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkilCastlelManager : MonoBehaviour
{
    public static SkilCastlelManager Instance;

    [Header("Skill UI")]
    public Image[] icon;
    public Button[] buttonskill;
    public Image[] MaskCooldown;
    public TextMeshProUGUI[] TextMana;
    public TextMeshProUGUI[] text;

    [Header("Skill Physical")]
    public SkillBase[] PhysicalSkills;

    [Header("Skill Magic")]
    public SkillBase[] MagicSkills;

    [Header("Skill Defense")]
    public SkillBase[] DefenseSkills;

    [Header("Preview")]
    public GameObject skillPreview;
    public Texture2D skillCursor;

    private SkillBase[] skillcurrent;
    private SkillBase skillselect;

    private bool isSelectingSkill;
    private bool justSelectedSkill;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LoadSkillByCastle();

        for (int i = 0; i < buttonskill.Length; i++)
        {
            int index = i;

            if (buttonskill[i] == null)
            {
                Debug.LogError("Chưa gán button skill slot " + i);
                continue;
            }

            buttonskill[i].onClick.AddListener(() => SelectSkill(index));
        }

        ResetSkillState();
    }

    void Update()
    {
        UpdateCooldown();
        HandlePreview();
        HandleTargetSkill();
    }

    public void LoadSkillByCastle()
    {
        if (CastleManager.Instance == null)
        {
            Debug.LogError("Không tìm thấy CastleManager, load mặc định Physical");
            skillcurrent = PhysicalSkills;
            RefectUI();
            return;
        }

        switch (CastleManager.Instance.CastleTypeCurrent)
        {
            case CastleType.Physical:
                skillcurrent = PhysicalSkills;
                break;

            case CastleType.Magic:
                skillcurrent = MagicSkills;
                break;

            default:
                //skillcurrent = PhysicalSkills;
                break;
        }

        Debug.Log("Đang load skill thành: " + CastleManager.Instance.CastleTypeCurrent);

        RefectUI();
    }

    public void RefectUI()
    {
        if (skillcurrent == null)
            return;

        for (int i = 0; i < icon.Length; i++)
        {
            if (i >= skillcurrent.Length || skillcurrent[i] == null)
            {
                icon[i].sprite = null;
                icon[i].enabled = false;

                if (buttonskill != null && i < buttonskill.Length && buttonskill[i] != null)
                    buttonskill[i].interactable = false;

                continue;
            }

            if (skillcurrent[i].icon == null)
            {
                icon[i].enabled = false;
                Debug.LogError("Skill " + skillcurrent[i].name + " chưa gán icon");
                continue;
            }

            icon[i].sprite = skillcurrent[i].icon;
            TextMana[i].text = skillcurrent[i].mana.ToString();
            icon[i].enabled = true;

            if (buttonskill != null && i < buttonskill.Length && buttonskill[i] != null)
                buttonskill[i].interactable = true;
        }
    }

    public void SelectSkill(int index)
    {
        if (skillcurrent == null)
            return;

        if (index < 0 || index >= skillcurrent.Length)
            return;

        SkillBase skill = skillcurrent[index];

        if (skill == null)
            return;

        if (!skill.IsRedy())
        {
            Debug.Log("Skill đang hồi");
            return;
        }

        if (ManaManager.instance != null &&
            ManaManager.instance.CurrentMana < skill.mana)
        {
            Debug.Log("Không đủ mana");
            return;
        }

        if (skill.type == SkillTargetType.Instant)
        {
            UseSkill(skill, Vector3.zero);
        }
        else
        {
            skillselect = skill;
            isSelectingSkill = true;
            justSelectedSkill = true;

            StartSelectingSkill();

            Debug.Log("Đang chọn vùng cho skill: " + skill.Name);
        }
    }

    void HandlePreview()
    {
        if (skillPreview == null)
            return;

        if (!isSelectingSkill || skillselect == null)
        {
            skillPreview.SetActive(false);
            return;
        }

        skillPreview.SetActive(true);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        skillPreview.transform.position = mousePos;
    }

    void HandleTargetSkill()
    {
        if (!isSelectingSkill || skillselect == null)
            return;

        if (justSelectedSkill)
        {
            justSelectedSkill = false;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Đã hủy chọn skill");
            ResetSkillState();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            UseSkill(skillselect, mousePos);

            ResetSkillState();
        }
    }

    void UseSkill(SkillBase skill, Vector3 pos)
    {
        if (skill == null)
            return;

        if (ManaManager.instance != null)
            ManaManager.instance.UseMana(skill.mana);

        skill.Cast(pos);
        skill.StartCooldown();

        Debug.Log("CurrentCooldown = " + skill.currentCooldown);
    }

    public void StartSelectingSkill()
    {
        Cursor.visible = true;

        if (skillCursor != null)
        {
            Vector2 hotSpot = new Vector2(
                skillCursor.width / 2f,
                skillCursor.height / 2f
            );

            Cursor.SetCursor(skillCursor, hotSpot, CursorMode.Auto);
        }

        if (skillPreview != null)
            skillPreview.SetActive(true);
    }

    void ResetSkillState()
    {
        isSelectingSkill = false;
        skillselect = null;
        justSelectedSkill = false;

        Cursor.visible = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (skillPreview != null)
            skillPreview.SetActive(false);
    }

    void UpdateCooldown()
    {
        if (skillcurrent == null)
            return;

        for (int i = 0; i < skillcurrent.Length; i++)
        {
            SkillBase skill = skillcurrent[i];

            if (skill == null)
                continue;

            skill.TickCooldown();

            bool isCooling = skill.currentCooldown > 0;

            if (MaskCooldown != null && i < MaskCooldown.Length && MaskCooldown[i] != null)
            {
                MaskCooldown[i].gameObject.SetActive(isCooling);

                MaskCooldown[i].fillAmount =
                    isCooling && skill.cooldown > 0
                    ? skill.currentCooldown / skill.cooldown
                    : 0;
            }

            if (text != null && i < text.Length && text[i] != null)
            {
                text[i].gameObject.SetActive(isCooling);
                text[i].text = isCooling
                    ? Mathf.CeilToInt(skill.currentCooldown).ToString()
                    : "";
            }
        }
    }
}