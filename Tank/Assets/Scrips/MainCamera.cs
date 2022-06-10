using UnityEngine;

///<summary>
///
///<summary>

public class MainCamera : MonoBehaviour
{
    public void IsQuit(bool quit)
    {
        if (quit)
        {
            Application.Quit();
        }
    }
}
