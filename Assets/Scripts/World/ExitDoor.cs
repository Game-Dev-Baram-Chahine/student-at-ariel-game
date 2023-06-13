using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Transform Home;
    public Transform Library;
    public Transform Faculty;

    public Rigidbody2D rb;
    private void Start()
    {
        PutPlayerOnLastBuildingDoor();
    }
    /// <summary>
    /// This function is responsible for placing the player next to the last building door.
    /// </summary>
    private void PutPlayerOnLastBuildingDoor()
    {
        Debug.Log(StaticVariables.lastScene);
        switch (StaticVariables.lastScene)
        {
            case "Library":
                Debug.Log("Put player next to the library");
                rb.transform.position = Library.transform.position;
                break;
            case "Faculty":
                Debug.Log("Put player next to the Faculty");
                rb.transform.position = Faculty.transform.position;
                break;
            default:
                Debug.Log("Main Scene");
                break;
        }
    }
}