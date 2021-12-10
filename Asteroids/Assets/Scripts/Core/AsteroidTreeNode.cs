using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTreeNode 
{
    public AsteroidTreeNode left;
    public AsteroidTreeNode middle;
    public AsteroidTreeNode right;

    public AsteroidTreeNode parent;
    public  bool isDestroyed;

    public AsteroidTreeNode(AsteroidTreeNode parent)
    {
        this.parent = parent;
        left = middle= right = null;
        isDestroyed = false;
        
    }

    
    public static AsteroidTreeNode GetRoot(AsteroidTreeNode node)
    {
        
        if(node.parent!=null) return GetRoot(node.parent); 
        else return node;
    }

    public static int GetDepth(AsteroidTreeNode node)
    {
        int depth = 0;

        if(node.parent!=null)depth = GetDepth(node.parent);
        return depth+1;
    }
}
