using UnityEngine;

namespace Illumate.Helper
{
    public class AnimatorRigDebug : MonoBehaviour
    {
        [SerializeField] private Transform[] boneTransforms = new Transform[HUMANOID_BONE_COUNT];

        private Animator mAnimator;

        private const int HUMANOID_BONE_COUNT = 54;


        private void Start()
        {

            //LazyUpdater.Init(this);
        }

        [ContextMenu("Print Bones")]
        private void PrintBones()
        {
            UpdateBoneList();

            string t = "";
            for (int i = 0; i < HUMANOID_BONE_COUNT; i++)
            {
                t += ((HumanBodyBones)i).ToString() + ": " + (boneTransforms[i] == null ? "Null" : boneTransforms[i].name) + "\n"; 
            }
            Debug.Log(t);
        }

        [ContextMenu("Update Bone List")]
        private void UpdateBoneList()
        {
            mAnimator = GetComponent<Animator>();
            for (int i = 0; i < HUMANOID_BONE_COUNT; i++)
            {
                boneTransforms[i] = mAnimator.GetBoneTransform((HumanBodyBones)i);
            }
        }

        private void Reset()
        {
            UpdateBoneList();
        }

    }
}