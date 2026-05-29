using UnityEngine;

public class ButtonResetData : MonoBehaviour
{
    public static ButtonResetData instance;
    public GameObject ResetPanel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetButton()
    {
        ResetPanel.SetActive(true);
    }    
    public void close()
    {
        ResetPanel.SetActive(false);
    }    
}
