using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView= 1,
    HomeView = 2,
    WeaponView = 3,

}
public class ViewParam
{

}
public class ViewConfig 
{
    public static ViewIndex[] viewIndices = {
        ViewIndex.EmptyView, 
        ViewIndex.HomeView,
        ViewIndex.WeaponView,
    };
}
 