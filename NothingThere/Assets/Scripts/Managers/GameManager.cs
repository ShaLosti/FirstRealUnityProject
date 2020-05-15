using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameObject plrGameObject;

    [Header("Saves")]
    static public Transform savePointPosition;

    [Header("Cubes")]
    static public List<GameObject> cubesForReset = new List<GameObject>();

    static public UIController uiController;
    static private CharacterController plrCharacterController;

    public void Awake()
    {
        if (QualitySettings.vSyncCount == 0) Application.targetFrameRate = 144;
        IdentifyObjects();
    }

    private static void IdentifyObjects()
    {
        if (uiController == null) uiController = FindObjectOfType<UIController>();
        //if (plrGameObject == null) plrGameObject = FindObjectOfType<FirstPersonController>().gameObject;
        if (plrGameObject == null) plrGameObject = FindObjectOfType<RigidbodyFirstPersonController>().gameObject;
        plrCharacterController = plrGameObject.GetComponent<CharacterController>();
        uiController.IdentifyObjects();
    }

    public static void AllowPlrMovementAndRotateSwitch(bool cond)
    {
        plrGameObject.GetComponent<FirstPersonController>().IsPlrAllowMove = cond;
    }

    public static void CursorSwitch(bool cond)
    {
        plrGameObject.GetComponent<FirstPersonController>().EnableCursor(cond);
    }

    public static void GameOver()
    {
        UIController.GameOver();
        plrGameObject.GetComponent<FirstPersonController>().IsPlrAllowMove = false;
    }

    public static void Restart(bool restartNative = true)
    {
        if (restartNative)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PawnManager.TeleportPawn(savePointPosition);
            UIController.StartLoadGame();
            plrGameObject.GetComponent<FirstPersonController>().IsPlrAllowMove = true;
            plrGameObject.GetComponent<PlayerLogic>().DefaultValues();
            if (cubesForReset.Count > 0 && !(cubesForReset == null))
            {
                foreach (var cube in cubesForReset)
                {
                    cube.GetComponent<CubeController>().ResetCubeColor();
                }
            }

        }
    }

    public static GameObject FindObjectFromParentObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
