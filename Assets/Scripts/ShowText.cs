using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public float time = 0.3f;
    public float speed = 50f;
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed*Time.deltaTime;
        timer+= Time.deltaTime;
        if(timer>time)
        {
          
            Destroy(gameObject);
        }    
    }
    public void setup(string text)
    {
         textUI.text = text;
        textUI.color = Color.white;

    }    
}
