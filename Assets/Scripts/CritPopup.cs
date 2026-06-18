using TMPro;
using UnityEngine;

public class CritPopup : MonoBehaviour
{
    public TextMeshProUGUI textCrit;
    public float time = 0.3f;
    public float speed = 80f;
    public float timer;
    
    public void setup(bool iscrit,float dame)
    {
        if(iscrit==true)
        {
            textCrit.text=dame.ToString();
            textCrit.color=Color.yellow;
        }
        else
        {
            textCrit.text = dame.ToString();
            textCrit.color = Color.white;
        }
    }
    public void setup1(bool isdame,float dame)
    {
        if(isdame==true)
        {
            textCrit.text = dame.ToString();
            textCrit.color = Color.red;
        }
     
    }
    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if(timer>time)
        {
            Destroy(gameObject);
        }    
    }

}
