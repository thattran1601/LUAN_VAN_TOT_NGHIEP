using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlyIconEffect : MonoBehaviour
{
    public static FlyIconEffect Instance;
    public GameObject prelafIcon;
    public Canvas canvas;
    public float speedfly = 0.35f;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startFly(Vector3 starPos,Sprite icon,Vector3 endPos)
    {
        StartCoroutine(fly(starPos, icon, endPos));
    }
    IEnumerator fly(Vector3 starPos,Sprite icon,Vector3 endPos)
    {
        GameObject ojb = Instantiate(prelafIcon, canvas.transform);
        Image image = ojb.GetComponent<Image>();
        image.sprite = icon;
        RectTransform rect = ojb.GetComponent<RectTransform>();
        rect.position = starPos;
        float t = 0;
        while(t<1)
        {
            t=Time.deltaTime/speedfly;
            rect.position = Vector3.Lerp(starPos, endPos, t);
            rect.localScale = Vector3.Lerp(Vector3.one * 1.2f, Vector3.one * 0.8f, t);
            yield return null;
        }    
    }    
}
