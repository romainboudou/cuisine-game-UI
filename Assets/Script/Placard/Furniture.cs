using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] public ShelfGroup shelfGroup;
    [SerializeField] public Shelf shelf;

    [SerializeField] private List<KitchenObject> allKitchenObjects;

    [System.Serializable]
    public class ShelfContent
    {
        public List<KitchenObject> objects;
    }

    [SerializeField] public List<ShelfContent> shelfContents;

    public void AddItem(int shelf, KitchenObject item)
    {
        if (IsValidShelfIndex(shelf))
        {
            shelfContents[shelf].objects.Add(item);
        }
        else
        {
            Debug.LogWarning($"Invalid shelf index: {shelf}");
        }
    }

    public void RemoveItem(int shelf, KitchenObject item)
    {
        if (IsValidShelfIndex(shelf))
        {
            shelfContents[shelf].objects.Remove(item);
            Debug.Log($"Removed : {item}");
        }
        else
        {
            Debug.LogWarning($"Invalid shelf index: {shelf}");
        }
    }

    private bool IsValidShelfIndex(int shelf)
    {
        return shelf >= 0 && shelf < shelfContents.Count;
    }

    public void InitializeShelves()
    {
        shelfGroup.SetupShelves(this);
    }

    public void InitializeShelvesRandom()
    {
        // G�n�rer al�atoirement un nombre d'onglets (entre 1 et 4)
        int numShelves = Random.Range(1, 5);

        // Initialiser la liste d'objets pour les �tag�res
        shelfContents = new List<ShelfContent>();

        for (int i = 0; i < numShelves; i++)
        {
            // Cr�er un ShelfContent pour chaque �tag�re
            ShelfContent shelfContent = new ShelfContent();

            // G�n�rer un nombre d'objets al�atoire pour cet onglet (entre 2 et 10)
            int numItems = Random.Range(2, 11);

            // Ajouter des objets al�atoires � cette �tag�re
            shelfContent.objects = GetRandomObjects(numItems);

            // Ajouter cet ShelfContent � la liste d'�tag�res
            shelfContents.Add(shelfContent);
        }

        // Configurer les �tag�res dans ShelfGroup
        shelfGroup.SetupShelves(this);
    }

    // Fonction pour r�cup�rer une liste d'objets al�atoires
    private List<KitchenObject> GetRandomObjects(int numItems)
    {
        List<KitchenObject> randomObjects = new List<KitchenObject>();

        // Ajouter des objets al�atoires de la liste des KitchenObject possibles
        for (int i = 0; i < numItems; i++)
        {
            KitchenObject randomObject = allKitchenObjects[Random.Range(0, allKitchenObjects.Count)];
            randomObjects.Add(randomObject);
        }

        return randomObjects;
    }
}