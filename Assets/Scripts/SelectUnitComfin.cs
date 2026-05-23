using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectUnitComfin : MonoBehaviour
{
    public List<UnitData> allUnit;
    public List<UnitData> SelectUnit=new List<UnitData>();
    public Image[] images;
    public Sprite daucong;
    
    void Start()
    {
        SelectUnit = new List<UnitData>(GameData.UnitData);
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
        if (SelectUnit.Count == 0)
            return;
        GameData.UnitData = new List<UnitData>(SelectUnit);
        Debug.Log("Đã lưu đội hình: " + GameData.UnitData.Count);
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }  
    public void Thoat()
    {
        SceneTransition.Instance.LoadSceneManager("Lobby");
        
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
