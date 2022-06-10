using UnityEngine;

///<summary>
///
///<summary>

public class Quit : MonoBehaviour
{
    public void AppExit()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }

    }

}
