

using System;
using System.Numerics;
using Newtonsoft.Json;

namespace ATRI.Protocol.Raknet.Utils.Skins
{
	public enum Face
	{
		None,
		Inside,
		Top,
		Bottom,
		Right,
		Front,
		Left,
		Back,
	}

	public class Cube : ICloneable
	{
		public float[] Origin { get; set; } = new float[3];
		public float[] Size { get; set; } = new float[3];
		public float[] Uv { get; set; } = new float[3];
		public float Inflate { get; set; }
		public bool Mirror { get; set; }

		[JsonIgnore] public Vector3 Velocity { get; set; } = Vector3.Zero;

		[JsonIgnore] public Face Face { get; set; } = Face.None;

		public object Clone()
		{
			var cube = (Cube) MemberwiseClone();

			cube.Origin = (float[]) Origin?.Clone();
			cube.Size = (float[]) Size?.Clone();
			cube.Uv = (float[]) Uv?.Clone();

			return cube;
		}
	}
}