using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
   public void Retry()
   {
      SceneManager.LoadScene("Scenes/Level-1"); // switch to level 1 if the user wants to retry
   }

   public void MainMenu()
   {
      SceneManager.LoadScene("Scenes/GameStartScreen"); // switch to Gamestart if user wants to exit to menu
   }
}
