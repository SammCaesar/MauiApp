﻿using System;
namespace Assignment1.Entities
{
	public class Person
	{
		public string Name { get; set; }
        public string Classification { get; set; }
        public List<int> Grades = new();
        public Person()
		{
		}

        public override string ToString()
        {
            return $"{Name} | {Classification}";
        }
    }
}

