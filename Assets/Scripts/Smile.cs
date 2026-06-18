using UnityEngine;

public class Smile : MonoBehaviour
{
    public GameObject prelafSlime1;
    public GameObject prelafSlime2;

    void Start()
    {
        Instantiate(prelafSlime1, transform.position+Vector3.right*1f, Quaternion.identity);
        Instantiate(prelafSlime2, transform.position+Vector3.right * 1.5f, Quaternion.identity);
        Debug.Log("Spawn slime");
    }

    // Update is called once per frame
    void Update()
    {
      
     
    }
       
}
