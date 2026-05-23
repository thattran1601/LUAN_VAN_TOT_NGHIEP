using UnityEngine;

public class DamePopup : MonoBehaviour
{
    public static DamePopup intance;
    public GameObject CritPrelaf;
    public Canvas canvas;

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
}
