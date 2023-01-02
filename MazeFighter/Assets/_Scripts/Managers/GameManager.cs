using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterHealth characterHealth;
    // Start is called before the first frame update
    void Start()
    {
        CharacterHealth.OnCharacterDestroyed += OnCharacterDestroyed;
    }

    private void OnCharacterDestroyed(GameObject obj)
    {
        if (obj.tag == "Player")
            Debug.Log("GameOver");
        else if(obj.tag == "Enemy")
            Debug.Log("EnemyDestroyed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
