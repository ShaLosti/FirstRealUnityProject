using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private static GameObject gameOverScreen;
    [SerializeField] private static GameObject startGameScreen;
    [SerializeField] private static TMPro.TextMeshProUGUI scoreTextForUi;
    [SerializeField] private static HPBarController hpFill;
    [SerializeField] private static GameObject menuPanel;

    private static GameObject targetPointForWayVisual;
    private static WayPoint wayPoint;
    private static GameObject scrollArea;

    public GameObject TargetPointForWayVisual
    {
        get => targetPointForWayVisual;
        set
        {
            wayPoint.TargetPointForWayVisual = value;
            targetPointForWayVisual = value;
        }
    }

    public static GameObject MenuPanel { get => menuPanel; set => menuPanel = value; }
    public static GameObject ScrollArea { get => scrollArea; set => scrollArea = value; }

    public void IdentifyObjects()
    {
        wayPoint = GameManager.FindObjectFromParentObject(gameObject, "WayPoint").GetComponent<WayPoint>();
        wayPoint.IdentifyObjects();
        ScrollArea = GameManager.FindObjectFromParentObject(gameObject, "ScrollArea");
        if (gameOverScreen == null) gameOverScreen = GameManager.FindObjectFromParentObject(gameObject, "GameOverScreen"); //game over screen when hp == 0
        if (startGameScreen == null) startGameScreen = GameManager.FindObjectFromParentObject(gameObject, "StartGameScreen"); //start screen when plr spawn
        if (scoreTextForUi == null) scoreTextForUi = GameManager.FindObjectFromParentObject(gameObject, "TextScore").GetComponent<TMPro.TextMeshProUGUI>(); //score right top
        if (hpFill == null) hpFill = GameManager.FindObjectFromParentObject(gameObject, "HealthBar").GetComponent<HPBarController>(); //hp left top
        if (MenuPanel == null) MenuPanel = GameManager.FindObjectFromParentObject(gameObject, "Menu"); //menu panel on Escape button 
    }

    private void Start()
    {
        StartLoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPanel.SetActive(!MenuPanel.activeSelf);
            if (MenuPanel.activeSelf)
            {
                DisablePanelTextForPlr();
                GameManager.CursorSwitch(true);
                GameManager.AllowPlrMovementAndRotateSwitch(false);
            }
            else
            {
                GameManager.CursorSwitch(false);
                GameManager.AllowPlrMovementAndRotateSwitch(true);
            }

            
            //Time.timeScale = 0;
        }
    }

    public static void StartLoadGame()
    {
        startGameScreen.SetActive(true);
    }

    public static void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public static void ShowMessage(string text = "")
    {
        GameManager.AllowPlrMovementAndRotateSwitch(false);
        GameManager.CursorSwitch(true);
        ScrollArea.transform.parent.parent.gameObject.SetActive(true);
        ScrollArea.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }

    public static void DisablePanelTextForPlr()
    {
        ScrollArea.transform.parent.parent.gameObject.SetActive(false);
        GameManager.AllowPlrMovementAndRotateSwitch(true);
        GameManager.CursorSwitch(false);
    }

    public static void SetMaxUIFillHealth(float health)
    {
        hpFill.UpdateMaxHPFill(health);
    }

    public static void SetUIFillHealth(float health)
    {
        hpFill.UpdateCurrentHPFill(health);
    }
    public static void AddScoreUIForFPP(int points = 1)
    {
        scoreTextForUi.text = (int.Parse(scoreTextForUi.text) + points).ToString();
    }
}
