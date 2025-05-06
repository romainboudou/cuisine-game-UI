using UnityEngine;

public class MenuController : MonoBehaviour
{
    private GameObject targetObject;
    private HandManager handManager;

    public void Setup(GameObject target, HandManager manager)
    {
        targetObject = target;
        handManager = manager;
        handManager.SetCurrentObject(targetObject);
    }

    public void AssignToRightHand()
    {
        handManager.AssignToRightHand();
        CloseMenu();
    }

    public void AssignToLeftHand()
    {
        handManager.AssignToLeftHand();
        CloseMenu();
    }

    public void RightHandPlace()
    {
        if (handManager.rightHand == null)
        {
            handManager.AssignToRightHand();
        }
        else
        {
            handManager.RightHandPlace();
        }
        CloseMenu();
    }

    public void LefttHandPlace()
    {
        if (handManager.leftHand == null)
        {
            handManager.AssignToLeftHand();
        }
        else
        {
            handManager.LeftHandPlace();
        }
        CloseMenu();
    }

    public void LeftOnTable()
    {
        handManager.LeftOnTable();
        CloseMenu();
    }

    public void RightOnTable()
    {
        handManager.RightToTable();
        CloseMenu();
    }

    private void CloseMenu()
    {
        Destroy(gameObject);
    }
}
