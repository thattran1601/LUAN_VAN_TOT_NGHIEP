using TMPro;
using UnityEngine;

public class HeathCong : MonoBehaviour
{
    public TextMeshProUGUI TextHeath;
    public float MaxHp;
    public float CurrentHp;
    void Start()
    {
        CurrentHp = MaxHp;
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            TakeDame(1000);
        }  
        if(CurrentHp<=0)
        {
            GameManager.instance.victory();
        }    
    }
    public void TakeDame(float dame)
    {
        CurrentHp-=dame;
        Show();

    }   
    public void Show()
    {
        TextHeath.text=CurrentHp.ToString()+"/"+MaxHp.ToString();
    }    
}
