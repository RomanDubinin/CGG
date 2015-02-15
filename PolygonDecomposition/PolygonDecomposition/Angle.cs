﻿using System;

namespace PolygonDecomposition
{
	public struct Angle
	{
		private Angle(double grad)
		{
			Grad = grad;
		}

		public readonly double Grad;

		public double Radian
		{
			get { return Grad * Math.PI / 180; }
		}

		public static Angle Zero
		{
			get { return new Angle(0); }
		}

		public static Angle Pi
		{
			get { return new Angle(180); }
		}

		public static Angle HalfPi
		{
			get { return new Angle(90); }
		}

		public static Angle FromGrad(double grad)
		{
			return new Angle(grad);
		}

		public static Angle FromRad(double rad)
		{
			return new Angle(rad * 180.0 / Math.PI);
		}

		public double Cos
		{
			get { return Math.Cos(Radian); }
		}

		public double Sin
		{
			get { return Math.Sin(Radian); }
		}
	}
}
