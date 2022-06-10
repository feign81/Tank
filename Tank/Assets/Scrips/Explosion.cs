using UnityEngine;

///<summary>
///
///<summary>

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}
