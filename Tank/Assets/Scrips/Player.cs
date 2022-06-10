using UnityEngine;

///<summary>
///玩家移动
///<summary>

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float defendTimeVal = 3;
    private bool isDefended = true;
    public bool isPlayer2;


    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject defenfEffectPrefab;
    public AudioSource moveAudio;
    public AudioClip[] TankAudio;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isDefended)
        {
            defenfEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                defenfEffectPrefab.SetActive(false);
            }
        }
        if (PlayerManager.Instance.isDefeat) { return; }
        //攻击CD
        if (timeVal >= 0.4f) { Attack(); }
        else
        {
            timeVal += Time.deltaTime;
        }

        //float Hor = Input.GetAxis("Horizontal");
        //float Ver = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.up * Ver * Time.deltaTime * 7);
        //transform.Rotate(-Vector3.forward * Hor * 20 * Time.deltaTime * 7);

    }

    private void FixedUpdate()
    {
        if (PlayerManager.Instance.isDefeat) { return; }
        Move();
    }

    private void Attack()
    {
        if (isPlayer2 && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
        }

        if (!isPlayer2 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
        }
    }
    private void Move()
    {


        float v = Input.GetAxis("Vertical");
        if (isPlayer2) { v = Input.GetAxis("Vertical2"); }
        this.transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        if (Mathf.Abs(v) > 0.05f)
        {
            moveAudio.clip = TankAudio[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        if (v != 0) return;


        float h = Input.GetAxis("Horizontal");
        if (isPlayer2) { h = Input.GetAxis("Horizontal2"); }
        this.transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
        if (Mathf.Abs(h) > 0.05f)
        {
            moveAudio.clip = TankAudio[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }

        }
        else
        {
            moveAudio.clip = TankAudio[0];

            if (!moveAudio.isPlaying) { moveAudio.Play(); }
        }

    }
    public void Die()
    {
        if (isDefended) { return; }
        PlayerManager.Instance.isDead = true;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
