using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectUnitComfin : MonoBehaviour
{
    public static SelectUnitComfin Instance;
    public List<UnitData> allUnit;
    public List<UnitData> SelectUnit=new List<UnitData>();
    public Image[] images;
    public Sprite daucong;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Loaddoihinh();
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public bool selectedunit(UnitData unit)
    {
        if(SelectUnit.Contains(unit))
        {
            SelectUnit.Remove(unit);
            Debug.Log("da xoa " + unit.name);
            updateUI();
            return false;
            
        }    
        else
        {
            if(SelectUnit.Count>=4)
            {
                Debug.Log("Da day ");
                updateUI();
                return false;
            }
           
           SelectUnit.Add(unit);
            updateUI();
            return true;
        }
       
    }
    public void LuuDoiHinh()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);

        GameData.UnitData = new List<UnitData>(SelectUnit);

        for (int i = 0; i < 4; i++)
        {
            if (i < SelectUnit.Count && SelectUnit[i] != null)
            {
                SaveGameManager.instance.SaveTeamSlot(i,SelectUnit[i].Id);
                Debug.Log("Lưu slot " + i + " id = " + SelectUnit[i].Id);
            }
            else
            {
                SaveGameManager.instance.SaveTeamSlot(i, -1);
            }
        }

        Debug.Log("Đã lưu đội hình: " + GameData.UnitData.Count);
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }
    public void Loaddoihinh()
    {

        SelectUnit.Clear();

        for (int i = 0; i < 4; i++)
        {
            int id = SaveGameManager.instance.LoadTeamSlot(i);

            if (id != -1)
            {
                UnitData unit = allUnit.FirstOrDefault(x => x.Id == id);

                if (unit != null)
                {
                    SelectUnit.Add(unit);
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy unit có Id = " + id);
                }
            }
        }

        GameData.UnitData = new List<UnitData>(SelectUnit);
    }
    public void Thoat()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);

        SceneTransition.Instance.LoadSceneManager("Lobby");
        SelectUnit.Clear();

        for (int i = 0; i < 4; i++)
        {
            int id = SaveGameManager.instance.LoadTeamSlot(i);

            if (id != -1)
            {
                UnitData unit = allUnit.FirstOrDefault(x => x.Id == id);

                if (unit != null)
                {
                    SelectUnit.Add(unit);
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy unit có Id = " + id);
                }
            }
        }

        GameData.UnitData = new List<UnitData>(SelectUnit);

    }    
    public void updateUI()
    {
        for(int i=0; i<images.Length;i++)
        {
            if(i<SelectUnit.Count)
            {
                images[i].sprite = SelectUnit[i].icon;
                images[i].color = new Color(1, 1, 1, 1);

            }
            else
            {
                images[i].sprite=daucong;
                images[i].color = new Color(1, 1, 1, 1);

            }    
        }    
    }
   
}
