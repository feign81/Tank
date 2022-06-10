using UnityEngine;

///<summary>
///
///<summary>

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject heartExplosionPrefab;
    public Sprite BrokenSprite;
    public AudioClip dieAudio;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void HeartDie()
    {
        Instantiate(heartExplosionPrefab, transform.position, transform.rotation);
        sr.sprite = BrokenSprite;
        PlayerManager.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);

    }
}
