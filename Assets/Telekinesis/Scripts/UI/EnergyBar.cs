using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.UI
{
    public class EnergyBar : ESMonoBehaviour
    {
        public Texture2D EnergyBarImage;
        public float CurrentEnergy = 100f;
        public float EnergyRegenerationRate = 3f;
        public float EnergyRegenerationAmount = 10f;
        public float MaxEnergy = 100f;
        public Color BarColor;
        public Vector3 EnergyBarOffset = new Vector3(-0.5f, 1f, 0f);
        public float XPosition = 0f;
        public float YPosition = 0f;
        public GameObject ParentObject;

        private SpriteRenderer _energyBar;
        private Quaternion _initialEnergyBarRotation;


        protected void OnEnable()
        {
            _initialEnergyBarRotation = new Quaternion();
        }

        protected void Start()
        {
            _energyBar = new GameObject("EnergyBar").AddComponent<SpriteRenderer>();
            _energyBar.sprite = Sprite.Create(EnergyBarImage, new Rect(0, 0, 100, 20), Vector2.zero, 100);

            if (ParentObject == null)
            {
                CreateEnergyBarParentContainer();
            }
            else
            {
                _energyBar.gameObject.transform.parent = ParentObject.transform;
            }

            if (_energyBar != null)
                InvokeRepeating("RegenerateEnergy", 0f, EnergyRegenerationRate);

            _energyBar.gameObject.transform.position = CachedTransform.position + EnergyBarOffset;
            _energyBar.transform.localPosition = Vector3.zero + EnergyBarOffset;
            _initialEnergyBarRotation = _energyBar.transform.rotation;

            UpdateEnergyBar();
        }

        private void CreateEnergyBarParentContainer()
        {
            var container = GameObject.Find("EnergyBar Container");

            if (container == null)
                container = new GameObject("EnergyBar Container");

            _energyBar.gameObject.transform.parent = container.transform;
        }

        protected void LateUpdate()
        {
            _energyBar.transform.position = CachedTransform.position + EnergyBarOffset;
            _energyBar.transform.rotation = _initialEnergyBarRotation;
        }

        public void UpdateEnergyBar()
        {
            _energyBar.material.color = BarColor;
            _energyBar.transform.localScale = new Vector3(CurrentEnergy/MaxEnergy, 1, 1);
        }

        protected void OnGUI()
        {
            GUI.color = BarColor;
            GUI.DrawTexture(new Rect(XPosition, YPosition, CurrentEnergy, 25), EnergyBarImage);

            GUI.color = Color.black;
            string healthRatio = CurrentEnergy.ToString() + " / " + MaxEnergy;
            GUI.Label(new Rect(XPosition + 20, YPosition + 2f, 100, 20), healthRatio);
        }

        public void DrainEnergy(float energyDrained)
        {
            CurrentEnergy -= energyDrained;

            if (_energyBar != null)
                UpdateEnergyBar();
        }

        public void RegenerateEnergy()
        {
            CurrentEnergy += EnergyRegenerationAmount;

            if (CurrentEnergy >= MaxEnergy)
                CurrentEnergy = MaxEnergy;

            if (_energyBar != null)
                UpdateEnergyBar();
        }
    }
}



