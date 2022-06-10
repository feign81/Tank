using UnityEngine;



///<summary>
///玩家移动
///<summary>

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float timeValChangeDirection;
    private float v = -1;
    private float h;



    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        //攻击CD
        if (timeVal >= 2.5f) { Attack(); }
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
        Move();

    }

    private void Attack()
    {

        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        timeVal = 0;

    }
    private void Move()
    {
        if (timeValChangeDirection >= 2)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1; h = 0;
            }
            else if (num == 0)
            {
                v = 1; h = 0;
            }
            else if (num > 2 && num <= 4)
            {
                v = 0; h = 1;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0; h = -1;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.deltaTime;
        }


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
        if (v != 0) return;



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
    }
    private void Die()
    {
        PlayerManager.Instance.playerScore++;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 2;
        }
    }
}
