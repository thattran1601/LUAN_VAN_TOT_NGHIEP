using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public static ManaManager instance;
    public int MaxMana=100;
    public int CurrentMana;
    public Image IconMana;
    public TextMeshProUGUI TextMana;
    public int ManaForSeconds=2;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrentMana = MaxMana;
       StartCoroutine( manaPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
       ;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CurrentMana>0)
            {
                UseMana(20);

            }
        }    
    }
    public void UseMana(int mana)
    {
        if(CurrentMana>=mana)
        {
            CurrentMana -= mana;
            ShowMana();
        }    
      
    }    
    public void ShowMana()
    {
        IconMana.fillAmount = (float)CurrentMana / MaxMana;
        TextMana.text=CurrentMana.ToString()+"/"+MaxMana.ToString();
    }

    IEnumerator manaPerSecond()
    {

      while(true)
        {
            yield return new WaitForSeconds(1f);
            if(CurrentMana<MaxMana)
            {
                CurrentMana += ManaForSeconds;
                if (CurrentMana > MaxMana)
                    CurrentMana = MaxMana;
               ShowMana() ;
            }    
        }
        
    }

}
