using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    [SerializeField] private ObjectTable objectTable; // Référence à ObjectTable

    public Image rightHandImage;
    public Image leftHandImage;

    public GameObject leftHand;
    public GameObject rightHand;

    public Transform ingredients;

    private GameObject currentObject;
    private KitchenObject selectedKitchenObject;
    
    private Furniture currentFurniture; 
    private int currentShelfIndex; 
    
    public void AssignToLeftHand()
    {
        Debug.Log("Left Hand :" + leftHand);
        Debug.Log("Current Object :" + currentObject);
        Debug.Log("Selected Object : " + selectedKitchenObject);
        if (leftHand != null)
        {
            leftHand.SetActive(true);
        }

        if (selectedKitchenObject != null)
        {
            if (currentFurniture != null)
            {
                if (leftHand == null)
                {
                    currentFurniture.RemoveItem(currentShelfIndex, selectedKitchenObject);
                    currentFurniture.InitializeShelves();
                    currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);

                    GameObject instantiatedObject = Instantiate(selectedKitchenObject.prefab, ingredients);
                    currentObject = instantiatedObject;
                }
                else
                {
                    currentFurniture.RemoveItem(currentShelfIndex, selectedKitchenObject);
                    KitchenObject kitchenObject = KitchenObject.CreateFromGameObject(leftHand);
                    currentFurniture.AddItem(currentShelfIndex, kitchenObject);
                    currentFurniture.InitializeShelves();
                    currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);

                    GameObject instantiatedObject = Instantiate(selectedKitchenObject.prefab, ingredients);
                    currentObject = instantiatedObject;
                }
                
                Debug.Log(leftHand);
                selectedKitchenObject = null;
            }
        }

        if (currentObject != null)
        {
            if (leftHand != null)
            {
                Vector3 currentPosition = currentObject.transform.position;
                currentObject.transform.position = leftHand.transform.position;
                leftHand.transform.position = currentPosition;
            }
            leftHand = currentObject;
            currentObject.SetActive(false);
            UpdateHandImage(currentObject, leftHandImage);
            Debug.Log(leftHand);
            currentObject = null;
        }
    }

    public void AssignToRightHand()
    {
        if (rightHand != null)
        {
            rightHand.SetActive(true);
        }

        if (selectedKitchenObject != null)
        {
            if (currentFurniture != null)
            {
                if (rightHand == null)
                {
                    currentFurniture.RemoveItem(currentShelfIndex, selectedKitchenObject);
                    currentFurniture.InitializeShelves();
                    currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);

                    GameObject instantiatedObject = Instantiate(selectedKitchenObject.prefab, ingredients);
                    currentObject = instantiatedObject;
                }
                else
                {
                    currentFurniture.RemoveItem(currentShelfIndex, selectedKitchenObject);
                    KitchenObject kitchenObject = KitchenObject.CreateFromGameObject(rightHand);
                    currentFurniture.AddItem(currentShelfIndex, kitchenObject);
                    currentFurniture.InitializeShelves();
                    currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);

                    GameObject instantiatedObject = Instantiate(selectedKitchenObject.prefab, ingredients);
                    currentObject = instantiatedObject;
                }
            }
            selectedKitchenObject = null;
        }

        Debug.Log(rightHand);
        if (currentObject != null)
        {
            if (rightHand != null)
            {
                Vector3 currentPosition = currentObject.transform.position;
                currentObject.transform.position = rightHand.transform.position;
                rightHand.transform.position = currentPosition;
            }
            rightHand = currentObject;
            currentObject.SetActive(false);
            UpdateHandImage(currentObject, rightHandImage);
            Debug.Log(rightHand);
            currentObject = null;
        }
    }

    public void RightHandPlace()
    {
        if (rightHand != null)
        {
            Debug.Log(currentObject);
            Debug.Log(currentObject.transform.position);
            rightHand.transform.SetParent(currentObject.transform, true);
            rightHand.transform.position = currentObject.transform.position;
            rightHand.SetActive(true);
            UpdateHandImage(currentObject, rightHandImage);
            if (rightHand.layer == LayerMask.NameToLayer("Takeable"))
            {
                rightHand.layer = LayerMask.NameToLayer("Default");
            }
        }

        rightHand = null;
    }

    public void LeftHandPlace()
    {
        if (leftHand != null)
        {
            Debug.Log(currentObject);
            Debug.Log(currentObject.transform.position);
            leftHand.transform.SetParent(currentObject.transform, true);
            leftHand.transform.position = currentObject.transform.position;
            leftHand.SetActive(true);
            UpdateHandImage(currentObject, leftHandImage);
            if (leftHand.layer == LayerMask.NameToLayer("Takeable"))
            {
                leftHand.layer = LayerMask.NameToLayer("Default");
            }
        }

        leftHand = null;
    }

    public void AddLeftHandToInventory()
    {
        if (currentFurniture != null)
        {
            Debug.Log("LEFT HAND :" + leftHand);
            if (leftHand != null)
            {
                Debug.Log("JE SUIS BIEN DEDANS");
                KitchenObject kitchenObject = KitchenObject.CreateFromGameObject(leftHand);
                Debug.Log("KITCHEN OBJECT OK");
                Debug.Log("FURNITURE :" + currentFurniture);
                currentFurniture.AddItem(currentShelfIndex, kitchenObject);
                Debug.Log("SHELF INDEX : " + currentShelfIndex);
                currentFurniture.InitializeShelves();
                currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);
                leftHand = null;
                UpdateHandImage(leftHand, leftHandImage);
            }
        }
    }

    public void AddRightHandToInventory()
    {
        if (currentFurniture != null)
        {
            if (rightHand != null)
            {
                KitchenObject kitchenObject = KitchenObject.CreateFromGameObject(rightHand);
                currentFurniture.AddItem(currentShelfIndex, kitchenObject);
                currentFurniture.InitializeShelves();
                currentFurniture.shelfGroup.ShowShelf(currentShelfIndex);
                rightHand = null;
                UpdateHandImage(rightHand, rightHandImage);
            }
        }
    }

    public void LeftOnTable()
    {
        if(leftHand != null)
        {
            Debug.Log("PUT ON THE TABLE !");
            Vector3 targetPosition = objectTable.clickPosition;
            leftHand.transform.position = targetPosition;
            leftHand.SetActive(true);
            leftHand = null;
            UpdateHandImage(leftHand, leftHandImage);
        }
    }

    public void RightToTable()
    {
        if (rightHand != null)
        {
            Vector3 targetPosition = objectTable.clickPosition;
            rightHand.transform.position = targetPosition;
            rightHand.SetActive(true);
            rightHand = null;
            UpdateHandImage(rightHand, rightHandImage);
        }
    }

    public void SetCurrentObject(GameObject obj)
    {
        Debug.Log(obj);
        currentObject = obj;
    }

    private void UpdateHandImage(GameObject obj, Image handImage)
    {
        if(obj == null)
        {
            handImage.sprite = null;
            handImage.color = new Color(0, 0, 0, 0);
        }
        else
        {
            InteractableObject interactableObject = obj.GetComponent<InteractableObject>();
            if (interactableObject != null && interactableObject.handIcon != null)
            {
                handImage.sprite = interactableObject.handIcon;
                handImage.color = Color.white;
            }
            else
            {
                handImage.sprite = null;
                handImage.color = new Color(0, 0, 0, 0);
            }
        }
    }

    public void SetSelectedKitchenObject(KitchenObject obj, Furniture furniture, int shelfIndex)
    {
        selectedKitchenObject = obj;
        currentFurniture = furniture;
        currentShelfIndex = shelfIndex;

        Debug.Log($"Objet sélectionné : {obj.name}, Meuble : {furniture.name}, Étagère : {shelfIndex}");
    }

    public void SetSelectedShelf(int shelfIndex, Furniture furniture)
    {
        currentShelfIndex = shelfIndex;
        currentFurniture = furniture;
    }
    
    public void SetCurrentFurniture(Furniture furniture)
    {
        currentFurniture = furniture;
        Debug.Log($"Current furniture updated: {currentFurniture.name}");
    }

    
}