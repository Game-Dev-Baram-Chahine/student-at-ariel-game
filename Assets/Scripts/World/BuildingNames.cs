using UnityEngine;
using UnityEngine.UI;
public class BuildingNames : MonoBehaviour
{
    public Text buildingScreenText;
    public GameObject message;
    public string buildingName;
    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.tag == "Player")
        {
            buildingScreenText.text = buildingName;
            message.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            buildingScreenText.text = buildingName;
            message.SetActive(false);
        }
    }
}