using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///<summary>
///
///<summary>

public class PlayerManager : MonoBehaviour
{
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeat;

    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;
    public GameObject[] playerPrefabList;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToMainMenu", 3);
            return;
        }
        if (isDead)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();

    }
    private void Recover()
    {

        if (lifeValue <= 0)
        {
            //游戏结束
            isDefeat = true;
            Invoke("ReturnToMainMenu", 3);
        }
        else
        {
            lifeValue--;

            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity); go.GetComponent<Born>().createPlayer = true;





            isDead = false;
        }
    }
    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
