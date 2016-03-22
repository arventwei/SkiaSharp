//
// Bindings for SKPath
//
// Author:
//   Bill Holmes
//
// Copyright 2016 Xamarin Inc
//
using System;

namespace SkiaSharp
{
	public class SkPathEffect : SKObject
	{
		[Preserve]
		internal SkPathEffect (IntPtr handle)
			: base (handle)
		{
		}
	}

	public class SkDashPathEffect : SkPathEffect
	{
		[Preserve]
		internal SkDashPathEffect (IntPtr handle)
			: base (handle)
		{
		}

		protected override void Dispose (bool disposing)
		{
			if (Handle != IntPtr.Zero) {
				SkiaApi.sk_dash_path_effect_unref (Handle);
			}

			base.Dispose (disposing);
		}

		public static SkDashPathEffect Create (float [] intervals, float phase)
		{
			var ptr = SkiaApi.sk_dash_path_effect_create (intervals, intervals.Length, phase);
			if (ptr == IntPtr.Zero)
				return null;

			return new SkDashPathEffect (ptr);
		}
	}
}

