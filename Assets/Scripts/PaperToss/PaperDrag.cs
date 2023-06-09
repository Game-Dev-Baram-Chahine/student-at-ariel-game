using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDrag : MonoBehaviour
{
    public LineRenderer line;
    public Rigidbody2D rb;
    [SerializeField] public float dragLimit = 3f;
    [SerializeField] public float forceToAdd = 10f;

    private Camera cam;
    private bool isDragging;

    Vector3 MousePos
    {
        get
            {
                Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0f;
                return pos;
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        line.positionCount = 2;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canDrag())
        {
            DragStart();
        }
        else if(isDragging)
        {
            Drag();
        }
        if(stoppedDrag())
        {
            DragEnd();
        }
    }

    public bool canDrag()
    {
        return (Input.GetMouseButton(0) && !isDragging);
    }
    public bool stoppedDrag()
    {
        return (Input.GetMouseButtonUp(0) && isDragging);
    }
    private void DragStart()
    {
        line.enabled = true;
        isDragging = true;
        line.SetPosition(0, MousePos);
    }
    private void Drag()
    {
        Vector3 startPos = line.GetPosition(0);
        Vector3 curPos = MousePos;
        Vector3 delta = curPos - startPos;
        if(delta.magnitude <= dragLimit)
        {
            line.SetPosition(1, curPos);
        }
        else
        {
            Vector3 limitedVector = startPos + (delta.normalized * dragLimit);
            line.SetPosition(1, limitedVector);
        }

    }
    private void DragEnd()
    {
        isDragging = false;
        line.enabled = false;
        Vector3 startPos = line.GetPosition(0);
        Vector3 curPos = line.GetPosition(1);
        Vector3 delta = curPos - startPos;
        Vector3 finalForce = delta* forceToAdd;

        rb.AddForce(finalForce, ForceMode2D.Impulse);
    }

}
