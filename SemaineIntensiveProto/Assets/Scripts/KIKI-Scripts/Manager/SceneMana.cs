using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    Manager mana;
    public int timeToWait;
    bool doneOnce = false;
    public int indexNextScene;

    private void Start()
    {
        mana = FindObjectOfType<Manager>();
    }

    private void Update()
    {
        if(mana.endGame== true && doneOnce == false) { StartCoroutine(waitOtherScene()); }
    }

    IEnumerator waitOtherScene()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(indexNextScene);
    }
}
