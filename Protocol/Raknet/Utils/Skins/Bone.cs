
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ATRI.Protocol.Raknet.Utils.Skins
{
	public enum BoneName
	{
		Unknown,
		Root,
		Body,
		Waist,
		Head,
		Hat,
		LeftArm,
		RightArm,
		LeftLeg,
		RightLeg,
		Cape,
		LeftItem,
		RightItem,
		LeftSleeve,
		RightSleeve,
		LeftPants,
		RightPants,
		Jacket
	}

	public class Locators
	{
		[JsonProperty(PropertyName = "lead_hold")]
		public float[] LeadHold { get; set; }
	}

	public class Bone : ICloneable
	{
		public string Name { get; set; }
		
		[JsonProperty(PropertyName = "META_BoneType")]
		public string BoneType { get; set; }

		public string Material { get; set; }

		public string Parent { get; set; }
		public float[] Pivot { get; set; } = new float[3];
		public float[] Pos { get; set; } = new float[3];
		public float[] Rotation { get; set; } = new float[3];
		public List<Cube> Cubes { get; set; }
		public bool NeverRender { get; set; }
		public bool Reset { get; set; }
		public bool Mirror { get; set; }
		public Locators Locators { get; set; }

		public object Clone()
		{
			var bone = (Bone) MemberwiseClone();

			bone.Pivot = (float[]) Pivot?.Clone();
			bone.Pos = (float[]) Pos?.Clone();
			bone.Rotation = (float[]) Rotation?.Clone();

			if (Cubes != null)
			{
				bone.Cubes = new List<Cube>();
				foreach (var cube in Cubes)
				{
					bone.Cubes.Add((Cube) cube.Clone());
				}
			}

			return bone;
		}
	}
}