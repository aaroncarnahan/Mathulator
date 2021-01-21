using System;
using System.Collections.Generic;
using System.Text;

namespace Mathulator
{
	public class TopBarNavigation
	{
		//TOPBAR NAVIGATION
		public List<String> nav = new List<String>();

		public void PrintNavigation()
		{
			int counter = nav.Count;
			int dashes = 0;
			foreach (var Navigation in nav)
			{
				Console.Write(Navigation);
				counter += 1;
				if (nav.Count > 1 && nav.Count > counter - nav.Count)
				{
					Console.Write(" > ");
					dashes += 3;
				}
			}

			Console.WriteLine("");

			foreach (var item in nav)
			{
				dashes += item.Length;
			}

			for (int i = 0; i < dashes; i++)
			{
				Console.Write('-');
			}
		}

		public void CheckNavigation(string navTitle)
		{
			bool contains = false;
			if (nav.Contains(navTitle))
			{
				contains = true;
			}

			if (contains == false)
			{
				nav.Add(navTitle);
			}
		}
	}
}
