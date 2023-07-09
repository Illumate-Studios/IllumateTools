using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Acts like target animator added. Copies rig
/// </summary>
public class MirrorAnimator : MonoBehaviour
{
    /// <summary>
    /// Original bones. Bones to copy
    /// </summary>
    private Transform[] oBones;

    /// <summary>
    /// My bones. Puppets bones
    /// </summary>
    private Transform[] mBones;


    public void SetTargetAnimator(Animator oAnimator)
    {
        const int HUMANOID_BONE_COUNT = 54;
        List<Transform> oBones = new List<Transform>();
        List<Transform> mBones = new List<Transform>();

        Animator mAnimator = GetComponent<Animator>();
        Debug.Assert(mAnimator != null);

        for (int i = 0; i < HUMANOID_BONE_COUNT; i++)
        {
            if (mAnimator.GetBoneTransform((HumanBodyBones)i) != null)
            {
                oBones.Add(oAnimator.GetBoneTransform((HumanBodyBones)i));
                mBones.Add(mAnimator.GetBoneTransform((HumanBodyBones)i));
            }
        }

        this.oBones = oBones.ToArray();
        this.mBones = mBones.ToArray();

        Destroy(mAnimator);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < mBones.Length; i++)
        {
#if UNITY_EDITOR
            Debug.Assert(mBones[i] != null, "Bone null: " + i);
            Debug.Assert(oBones[i] != null, "Bone null: " + i);
#endif
            mBones[i].position = oBones[i].position;
            mBones[i].rotation = oBones[i].rotation;
        }
    }


    //public void SetPuppeteer(Transform armature)
    //{
    ////    Non - humanoid solution
    //    void AddBones(Transform o, Transform m)
    //    {
    //        for (int i = 0; i < m.childCount; i++)
    //        {
    //            if (m.GetChild(i).name != o.GetChild(i).name)
    //                Debug.LogWarning(m.GetChild(i).name + " bone name does not match on original rig: " + o.GetChild(i).name);

    //            Debug.Assert(i < o.childCount, m.GetChild(i).name + " bone does not exists on original rig");

    //            oBones.Add(o.GetChild(i));
    //            mBones.Add(m.GetChild(i));

    //            if (m.childCount != 0)
    //                AddBones(o.GetChild(i), m.GetChild(i));
    //        }
    //    }

    //    AddBones(armature, transform);
    //}
}