using UnityEngine;

public class LobbyMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBMG(AudioManager.instance.LobbySource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
