using UnityEngine;

public class CollectionManger : MonoBehaviour
{
    public GameObject buttonSotay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSotay.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonSotay()
    {
        buttonSotay.SetActive(true);
    }
    public void ExitButtonSotay()
    {
        buttonSotay.SetActive(false);
    }
}
