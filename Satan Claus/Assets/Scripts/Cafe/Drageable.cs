﻿using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Drag a Rigidbody2D by selecting one of its colliders by pressing the mouse down.
/// When the collider is selected, add a TargetJoint2D.
/// While the mouse is moving, continually set the target to the mouse position.
/// When the mouse is released, the TargetJoint2D is deleted.`
/// </summary>
public class Drageable : MonoBehaviour
{
	public LayerMask m_DragLayers;

	[Range (0.0f, 100.0f)]
	public float m_Damping = 1.0f;

	[Range (0.0f, 100.0f)]
	public float m_Frequency = 5.0f;

	public bool m_DrawDragLine = true;
	public Color m_Color = Color.cyan;

	public TargetJoint2D m_TargetJoint;

	public UnityEvent<bool> OnDrag;


    void Update ()
	{
		// Calculate the world position for the mouse.
		var worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0))
		{
			// Fetch the first collider.
			// NOTE: We could do this for multiple colliders.
			var collider = Physics2D.OverlapPoint (worldPos, m_DragLayers);
			if (!collider)
				return;

			// Fetch the collider body.
			var body = collider.attachedRigidbody;
			if (!body)
				return;

			// Add a target joint to the Rigidbody2D GameObject.
			OnDrag?.Invoke(true);
			m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint (worldPos);		
		}
		else if (Input.GetMouseButtonUp (0))
		{
			if(m_TargetJoint != null)
			{
				OnDrag?.Invoke(false);
			}
			
			Destroy (m_TargetJoint);
			m_TargetJoint = null;
			return;
		}

		// Update the joint target.
		if (m_TargetJoint)
		{
			m_TargetJoint.target = worldPos;

			// Draw the line between the target and the joint anchor.
			if (m_DrawDragLine)
				Debug.DrawLine (m_TargetJoint.transform.TransformPoint (m_TargetJoint.anchor), worldPos, m_Color);
		}
	}
}