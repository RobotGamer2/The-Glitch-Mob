using System;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        [Range(0, 1)] public float parallaxFactor;
    }
    public ParallaxLayer[] layer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
