using UnityEngine;
using System.Collections.Generic;

public class RockIO : MonoBehaviour, IInteractable
{
    public bool IsBroken { get; private set; }
    public string RockID { get; private set; }
    public int taskID;
    public bool isNature;
    public Sprite brokenSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RockID ??= GlobalHelper.GenerateUniqueID(gameObject); 
    }

    public bool CanInteract()
    {
        return !IsBroken;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        BrokenRock();
        GameManager.GetInstance().CompleteTask(isNature, taskID);
    }

    private void BrokenRock()
    {
        SetBroken(true);
    }

    public void SetBroken(bool broken)
    {
        if(IsBroken = broken)
        {
            GetComponent<SpriteRenderer>().sprite = brokenSprite;
        }
    }
}
