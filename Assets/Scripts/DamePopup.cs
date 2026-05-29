using UnityEngine;

public class DamePopup : MonoBehaviour
{
    public static DamePopup intance;
    public GameObject CritPrelaf;
    public Canvas canvas;
    public GameObject textprelaf;

    private void Awake()
    {
        intance = this;
    }
    public void show(bool iscrit,Vector3 screen,float dame)
    {
        Vector3 camenra=Camera.main.WorldToScreenPoint(screen);
        GameObject obj = Instantiate(CritPrelaf, camenra, Quaternion.identity, canvas.transform);
        obj.GetComponent<CritPopup>().setup(iscrit, dame);
    }    
    public void showtext(string text, Vector3 screen)
    {
        Vector3 camera = Camera.main.WorldToScreenPoint(screen);
        GameObject obj = Instantiate(textprelaf, camera, Quaternion.identity, canvas.transform);
        obj.GetComponent<ShowText>().setup(text);
    }    
}
