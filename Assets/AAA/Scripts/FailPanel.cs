using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : MonoBehaviour
{
      public void LevelRestart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {

         Scene GameScene2 = SceneManager.GetActiveScene();
          SceneManager.LoadScene(GameScene2.buildIndex + 1);
    }
}
