﻿using Newtonsoft.Json;

namespace Neo.RPC.DTOs
{
	public class Stack
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}