using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GetInstance()
    {
        return _instance;
    }
    private static GameManager _instance;
    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] bool[] natureTasks;
    [SerializeField] bool[] religionTasks;
    
    public void CompleteTask(bool isNature = true, int taskID = 0)
    {
        if (isNature)
        {
            natureTasks[taskID] = true;
            return;
        }

        religionTasks[taskID] = true;
    }

    public bool IsTaskComplete(bool isNature = true, int taskID = 0)
    {
        if (isNature)
        {
            return natureTasks[taskID];
        }

        return religionTasks[taskID];
    }

    public int NatureTasksompleted()
    {
        int count = 0;
        for (int i = 0; i < natureTasks.Length; i++)
        {
            if (natureTasks[i])
            {
                count++;
            }
        }
        return count;
    }

    public int RelgionTasksCompleted()
    {
        int count = 0;
        for (int i = 0; i < religionTasks.Length; i++)
        {
            if (religionTasks[i])
            {
                count++;
            }
        }
        return count;
    }
}
