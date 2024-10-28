using UnityEngine;

namespace Squirrel.Extension
{
	public static class RendererExtensions
	{
		public static bool IsVisibleFrom(this UnityEngine.Renderer renderer, UnityEngine.Camera camera)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
			return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		}
	}
}