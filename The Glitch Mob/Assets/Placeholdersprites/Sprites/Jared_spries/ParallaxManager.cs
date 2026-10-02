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
    public ParallaxLayer[] layers;

    public Transform camTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = transform.position;
    }

    void LateUpdate()
    {
        Vector3 comeraDelta = camTransform.position - lastCameraPosition;

        foreach (ParallaxLayer layer in layers)
        {
            float moveX = comeraDelta.x * layer.parallaxFactor;
            float moveY = comeraDelta.y * layer.parallaxFactor;

            layer.layer.position += new Vector3(moveX, 0);
        }

        lastCameraPosition = camTransform.position;
    }
}
