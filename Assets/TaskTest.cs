using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Profiling;

public class TaskTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {


        DO();

  
    }

    private void DO()
    {
        Debug.Log($"###Start TaskMethod");
        /*await*/ TaskMethod(1);
        Debug.Log($"##End TaskMethod");

        Debug.Log($"Start VoidMethod");
        /*await*/ Task.Run(VoidMethod);
        Debug.Log($"End VoidMethod");
    }


    private async Task TaskMethod(int a)
    {
        Profiler.BeginThreadProfiling("My threads", "My thread 1");
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(1000);
            if (a ==1)
            Debug.Log($"aaaaa {i} , Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            else
                Debug.Log($"ccccc {i} , Thread ID: {Thread.CurrentThread.ManagedThreadId}");

        }
        Debug.Log($"End Task");
        Profiler.EndThreadProfiling();
    }



    private async void VoidMethod()
    {
        Profiler.BeginThreadProfiling("My threads", "My thread 2");

        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(1000);
                Debug.Log($"ddddd {i} , Thread ID: {Thread.CurrentThread.ManagedThreadId}");

        }
        Debug.Log($"End Void");
        Profiler.EndThreadProfiling();

    }


  
}
