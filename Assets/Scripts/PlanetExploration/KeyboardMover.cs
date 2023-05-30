using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMover : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;
    [SerializeField] TileBase alienMaterial = null;
    [SerializeField] InputAction moveAction;

    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    protected Vector3 NewPosition()
    {
        if (moveAction.WasPerformedThisFrame())
        {
            Vector3 movement = moveAction.ReadValue<Vector2>(); // Implicitly convert Vector2 to Vector3, setting z=0.
            // Debug.Log("movement: " + movement);
            return transform.position + movement;
        }
        else
        {
            return transform.position;
        }
    }

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    private void IsChest(TileBase tile)
    {
        if (alienMaterial == tile)
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex + 1);
        }
    }

    private void GoTile()
    {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contain(tileOnNewPosition))
        {
            transform.position = newPosition;
            IsChest(tileOnNewPosition);
        }
        else
        {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "! ");
        }
    }

    void Update()
    {
        GoTile();

    }
}