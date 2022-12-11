
    using UnityEngine;
    using VContainer.Unity;

    public class GameInitializer : IStartable
    {

        private readonly GameObject gameObject;

        public GameInitializer(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Start()
        {
            GameObject.Instantiate(gameObject);
        }
    }
