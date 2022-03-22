using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WhenWaitAllAny : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Start");
        //Task.Run( ResultFuncWaitAll);

        //Task.Run(ResultFuncWhenAll);
    }


    public async void Btn_WaitAll()
    {
        int target = 5;
        var task1 = Task.Run<int>(() => GetTaskIntValue(target));
        var task2 = Task.Run<bool>(() => GetTaskBoolValue(target));

        Task.WaitAll(task1, task2);

        Debug.Log($"Result : {task1.Result} / {task2.Result}");
    }



    public async void Btn_WhenAll()
    {
        int target = 5;
        var task1 = Task.Run<int>(() => GetTaskIntValue(target));
        var task2 = Task.Run<bool>(() => GetTaskBoolValue(target));
        await Task.WhenAll(task1, task2);

        Debug.Log($"Result : {task1.Result} / {task2.Result}");
    }


    public async void Btn_WaitAny()
    {
        int target = 5;
        var task1 = Task.Run<int>(() => GetTaskIntValue(target));
        var task2 = Task.Run<bool>(() => GetTaskBoolValue(target));

        Task[] tasks = { task1, task2 };
        int index = Task.WaitAny(tasks);

        if(tasks[index].Equals(task1))
            Debug.Log($"Result : {task1.Result}");
        else
            Debug.Log($"Result : {task2.Result}");


    }


    public async void Btn_WhenAny()
    {
        int target = 5;
        var task1 = Task.Run<int>(() => GetTaskIntValue(target));
        var task2 = Task.Run<bool>(() => GetTaskBoolValue(target));

        Task t = await Task.WhenAny(task1, task2);

        if (t.Equals(task1))
            Debug.Log($"Result : {task1.Result}");
        else
            Debug.Log($"Result : {task2.Result}");
    }





    private async Task<int> GetTaskIntValue(int target)
    {
        int result = target > 0 ? target * target : target*-1;
        Debug.Log($"GetTaskIntValue Complete : {result}");
        return result;
    }

    private async Task<bool> GetTaskBoolValue(int target)
    {
        Debug.Log($"GetTaskBoolValue Wait @@@@");

        await Task.Delay(3000);

        bool result = target % 2 == 0;
        Debug.Log($"GetTaskBoolValue Complete : {result}");

        return result;
    }
}
