﻿using System;
namespace Assignment1.Entities
{
	public class Assignment
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public Assignment()
		{
		}
	}
}
