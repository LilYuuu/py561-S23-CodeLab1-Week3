using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public int restarted = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        restarted = 1;
        
        GameManager.Instance.currentLevel = 0;
        GameManager.Instance.score = 0;
        // GameManager.Instance.currTime = 0.0f;
        WASDControl.Instance.rb2d.gameObject.SetActive(true);
        WASDControl.Instance.rb2d.position = new Vector2(0, 8);
        SceneManager.LoadScene(0);
        
        // Debug.Log("reset current time: " + GameManager.Instance.currTime);
        
    }
}
