using UnityEngine;

public class ManagerLimit : MonoBehaviour
{
    public static ManagerLimit instance;
    public Transform GioiHanChuyenDong;
    private void Awake()
    {
        instance = this;
    }

}
