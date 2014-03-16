﻿using TeraWatcherAPI.Types;

namespace TeraWatcherAPI.Events {
	public delegate void sAttackEndHandler(sAttackEndArgs args);

	public class sAttackEndArgs : System.EventArgs {
		public ulong source;
		public Position position;
		public short angle;
		public uint model;
		public uint skill;
		public uint id;
	}
}
