using UnityEngine;

public class TextWindow : MonoBehaviour
{
   public  void OnGUI()
    {
        GUI.Box(new Rect(600, 700, Screen.width, Screen.height), "You Win!!!");
    }
}