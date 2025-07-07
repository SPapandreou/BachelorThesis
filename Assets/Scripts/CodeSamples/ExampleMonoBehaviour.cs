using System;
using UnityEngine;

namespace CodeSamples
{
    public class ExampleMonoBehaviour : MonoBehaviour
    {
        // serialized variable, displayed in the inspector
        public float speed;
        // not serialized variable
        private int _currentScore;
        // gets executed when the application starts
        private void Awake(){}
        // gets executed after all Awake() methods have been called
        private void Start(){}
        // gets executed once per frame
        private void Update(){}
        // gets executed when the component is enabled
        private void OnEnable(){}
        // gets executed when the component is disabled
        private void OnDisable(){}
        // gets executed when the component is destroyed
        private void OnDestroy(){}
    }
}