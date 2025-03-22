using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogIndex
{
    PauseDialog = 1,
    CancelDialog = 2,

}
public class DialogParam
{

}

public class DialogConfig 
{
    public static DialogIndex[] dialogIndices =
    {
        DialogIndex.PauseDialog,
        DialogIndex.CancelDialog,
    };
}
