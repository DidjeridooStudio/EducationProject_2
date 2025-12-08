using UnityEngine;

namespace HW24_25
{
    public class ExplosivePulsation
    {
        private const string ScaleKey = "_Scale";
        private const string FresnelEdgeKey = "_FresnelEdge";
        private const float MinPulseValue = 0;
        private const float MaxPulseValue = 1;
        private const float PulsationSpeed = 3;

        private MeshRenderer _meshRenderer;

        private float scalePulseProgress = 0;
        private float galoPulseProgress = 1;
        private bool hasPulsationLimitReached = true;

        public ExplosivePulsation(MeshRenderer meshRenderer)
        {
            _meshRenderer = meshRenderer;
        }

        public void Update()
        {
            foreach (Material material in _meshRenderer.materials)
            {
                material.SetFloat(ScaleKey, scalePulseProgress * 2 * 0.1f);
                material.SetFloat(FresnelEdgeKey, galoPulseProgress * 10);
            }

            if (scalePulseProgress >= MinPulseValue && scalePulseProgress < MaxPulseValue && hasPulsationLimitReached)
            {
                scalePulseProgress += Time.deltaTime * PulsationSpeed;
                galoPulseProgress -= Time.deltaTime * PulsationSpeed;
            }
            else
            {
                if (scalePulseProgress >= MaxPulseValue)
                    hasPulsationLimitReached = false;

                scalePulseProgress -= Time.deltaTime * PulsationSpeed;
                galoPulseProgress += Time.deltaTime * PulsationSpeed;

                if (scalePulseProgress <= MinPulseValue)
                {
                    hasPulsationLimitReached = true;
                    scalePulseProgress = 0;
                    galoPulseProgress = 1;
                }
            }
        }
    }
}
