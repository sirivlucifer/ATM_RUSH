using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Public Variables
        #endregion
        #region Serialized Variables
        [SerializeField] private StackManager stackManager;
        [SerializeField] private GameObject collectedObject; 
        #endregion
        #endregion
        private void OnTriggerEnter(Collider other)
        { 
            if(other.CompareTag("Collectable"))
            {
                // other.transform.parent = stackManager.transform;
                CollectableSignals.Instance.onMoneyCollection?.Invoke();
                stackManager.Colleted.Add(other.gameObject);
                other.tag ="Collected";
            }
        }
        public void SetMoney()
        {
            for (int i = stackManager.Colleted.Count - 1; i >= 0; i--)
            {
                int index = i;
                Vector3 scale = Vector3.one * 2;
                stackManager.Colleted[index].transform.DOScale(scale, 0.2f).OnComplete(() => { stackManager.Colleted[index].transform.DOScale(Vector3.one, 0.2f); });
                //yield return new WaitForSeconds(0.05f);
                return;
            }
        }
        #region Private Variables
        private float waitTime = 0.3f;

        #endregion
    }
}