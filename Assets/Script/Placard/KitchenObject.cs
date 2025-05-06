using UnityEngine;

[CreateAssetMenu(menuName = "Kitchen/KitchenObject")]
public class KitchenObject : ScriptableObject
{
    public string description;
    public GameObject prefab;
    public Sprite image;

    public static KitchenObject CreateFromGameObject(GameObject gameObject)
    {
        KitchenObject kitchenObject = ScriptableObject.CreateInstance<KitchenObject>();
        InteractableObject interactableObject = gameObject.GetComponent<InteractableObject>();
        
        kitchenObject.prefab = gameObject;
        kitchenObject.description = interactableObject.hisName;
        kitchenObject.image = interactableObject.handIcon;
        
        return kitchenObject;
    }
}
