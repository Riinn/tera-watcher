﻿using System;
using System.Collections.Generic;

using TeraWatcherAPI.Events;
using TeraWatcherAPI.Types;

namespace Watcher {
	class Parse : TeraWatcherAPI.IHandler {
		const int NAME_CHAR_MAX_LENGTH = 20;
		const int NAME_GUILD_MAX_LENGTH = 32;
		const int NAME_GUILDRANK_MAX_LENGTH = 32;
		const int DEBUG_LEVEL = 1;

		private delegate void Handle(byte[] data);

		public event gPacketHandler sPacket;

		public event sAbnormalAddHandler sAbnormalAdd;
		public event sAbnormalRemoveHandler sAbnormalRemove;
		public event sAbnormalUpdateHandler sAbnormalUpdate;
		public event sAbsorbDamageHandler sAbsorbDamage;
		public event sAnimateHandler sAnimate;
		public event sAttackEndHandler sAttackEnd;
		public event sAttackHomingHandler sAttackHoming;
		public event sAttackResultHandler sAttackResult;
		public event sAttackStartHandler sAttackStart;
		public event sChatMessageHandler sChatMessage;
		public event sCombatStatusHandler sCombatStatus;
		public event sConditionActivateHandler sConditionActivate;
		public event sConditionAddHandler sConditionAdd;
		public event sConditionListHandler sConditionList;
		public event sConditionRemoveHandler sConditionRemove;
		public event sCooldownItemHandler sCooldownItem;
		public event sCooldownSkillHandler sCooldownSkill;
		public event sGlyphsHandler sGlyphs;
		public event sGuildInfoHandler sGuildInfo;
		public event sImageHandler sImage;
		public event sLifeStatusHandler sLifeStatus;
		public event sLockedOnHandler sLockedOn;
		public event sLockonHandler sLockon;
		public event sLootQueueHandler sLootQueue;
		public event sLootReceivedHandler sLootReceived;
		public event sLootRemoveHandler sLootRemove;
		public event sLootRollHandler sLootRoll;
		public event sLootSpawnHandler sLootSpawn;
		public event sLootStatusHandler sLootStatus;
		public event sLootWindowHandler sLootWindow;
		public event sLootWonHandler sLootWon;
		public event sNpcCombatStatusHandler sNpcCombatStatus;
		public event sNpcEmotionHandler sNpcEmotion;
		public event sNpcHpHandler sNpcHp;
		public event sNpcInfoHandler sNpcInfo;
		public event sNpcStatusHandler sNpcStatus;
		public event sNpcUnloadHandler sNpcUnload;
		public event sPartyAbnormalAddHandler sPartyAbnormalAdd;
		public event sPartyAbnormalListHandler sPartyAbnormalList;
		public event sPartyAbnormalRemoveHandler sPartyAbnormalRemove;
		public event sPartyAbnormalUpdateHandler sPartyAbnormalUpdate;
		public event sPartyConditionActivateHandler sPartyConditionActivate;
		public event sPartyConditionAddHandler sPartyConditionAdd;
		public event sPartyConditionRemoveHandler sPartyConditionRemove;
		public event sPartyDeathHandler sPartyDeath;
		public event sPartyInvitePrivHandler sPartyInvitePriv;
		public event sPartyLeaderHandler sPartyLeader;
		public event sPartyListHandler sPartyList;
		public event sPartyUpdateHandler sPartyUpdate;
		public event sPartyUpdateHpHandler sPartyUpdateHp;
		public event sPartyUpdateMpHandler sPartyUpdateMp;
		public event sPartyUpdateReHandler sPartyUpdateRe;
		public event sPlayerInfoHandler sPlayerInfo;
		public event sProjectedAttackHandler sProjectedAttack;
		public event sProjectedAttackRemoveHandler sProjectedAttackRemove;
		public event sProjectileHandler sProjectile;
		public event sProjectileRemoveHandler sProjectileRemove;
		public event sSelfInfoHandler sSelfInfo;
		public event sSelfStaminaHandler sSelfStamina;
		public event sSystemMessageHandler sSystemMessage;
		public event sTargetInfoHandler sTargetInfo;
		public event sUpdateHpHandler sUpdateHp;
		public event sUpdateMpHandler sUpdateMp;
		public event sUpdateReHandler sUpdateRe;
		public event sUpdateStatsHandler sUpdateStats;
		public event sWhisperHandler sWhisper;

		public event gPacketHandler cPacket;

		public event cLockonHandler cLockon;
		public event cMoveHandler cMove;
		public event cSetGlyphsHandler cSetGlyphs;
		public event cTargetHandler cTarget;
		public event cWhisperHandler cWhisper;

		public Parse() {
		}

		public void Log(int level, string format, params object[] args) {
			Console.WriteLine(format, args);
		}

		public void ServerCommand(uint opCode, byte[] data) {
			var PacketArgs = new gPacketArgs {
				data = data,
				unknown = false
			};

			switch (opCode) {
				case 0xCD04: _sAbnormalAdd(data); break;
				case 0x67AE: _sAbnormalRemove(data); break;
				case 0x6668: _sAbnormalUpdate(data); break;
				case 0xCE49: _sAbsorbDamage(data); break;
				case 0xC391: _sAnimate(data); break;
				case 0xBD95: _sAttackEnd(data); break;
				case 0xC581: _sAttackHoming(data); break;
				case 0xA06C: _sAttackResult(data); break;
				case 0xAB46: _sAttackStart(data); break;
				case 0xA84B: _sChatMessage(data); break;
				case 0xA049: _sCombatStatus(data); break;
				case 0xC8F7: _sConditionActivate(data); break;
				case 0xE91C: _sConditionAdd(data); break;
				case 0xA77A: _sConditionList(data); break;
				case 0xA979: _sConditionRemove(data); break;
				case 0xC693: _sCooldownItem(data); break;
				case 0xA43D: _sCooldownSkill(data); break;
				case 0x8FBE: _sGlyphs(data); break;
				case 0xCE0E: _sGuildInfo(data); break;
				case 0x997D: _sImage(data); break;
				case 0xE583: _sLifeStatus(data); break;
				case 0xDDB2: _sLockedOn(data); break;
				case 0xF200: _sLockon(data); break;
				case 0x6556: _sLootQueue(data); break;
				case 0xCDA6: _sLootReceived(data); break;
				case 0xFB17: _sLootRemove(data); break;
				case 0x8C9D: _sLootRoll(data); break;
				case 0xF8AB: _sLootSpawn(data); break;
				case 0xB77A: _sLootStatus(data); break;
				case 0xA8EC: _sLootWindow(data); break;
				case 0x6335: _sLootWon(data); break;
				case 0x9DEE: _sNpcCombatStatus(data); break;
				case 0xF75A: _sNpcEmotion(data); break;
				case 0xFBB1: _sNpcHp(data); break;
				case 0xC84B: _sNpcInfo(data); break;
				case 0x9730: _sNpcStatus(data); break;
				case 0x541F: _sNpcUnload(data); break;
				case 0xADD9: _sPartyAbnormalAdd(data); break;
				case 0xCC23: _sPartyAbnormalList(data); break;
				case 0x8289: _sPartyAbnormalRemove(data); break;
				case 0xA58C: _sPartyAbnormalUpdate(data); break;
				case 0x611C: _sPartyConditionActivate(data); break;
				case 0xF15F: _sPartyConditionAdd(data); break;
				case 0xAB42: _sPartyConditionRemove(data); break;
				case 0xA87C: _sPartyDeath(data); break;
				case 0xB425: _sPartyInvitePriv(data); break;
				case 0xCB28: _sPartyLeader(data); break;
				case 0xCF40: _sPartyList(data); break;
				case 0xBF94: _sPartyUpdate(data); break;
				case 0x98A8: _sPartyUpdateHp(data); break;
				case 0x7C2A: _sPartyUpdateMp(data); break;
				case 0xA2AF: _sPartyUpdateRe(data); break;
				case 0x8BDD: _sPlayerInfo(data); break;
				case 0xB3B7: _sProjectedAttack(data); break;
				case 0x9411: _sProjectedAttackRemove(data); break;
				case 0xC75C: _sProjectile(data); break;
				case 0xB674: _sProjectileRemove(data); break;
				case 0xE48C: _sSelfInfo(data); break;
				case 0x6BCF: _sSelfStamina(data); break;
				case 0xADA3: _sSystemMessage(data); break;
				case 0xFBF1: _sTargetInfo(data); break;
				case 0x99C6: _sUpdateHp(data); break;
				case 0xBD7F: _sUpdateMp(data); break;
				case 0xBD41: _sUpdateRe(data); break;
				case 0x69D2: _sUpdateStats(data); break;
				case 0xE8D8: _sWhisper(data); break;
				default: PacketArgs.unknown = true; break;
			}

			var callback = sPacket;
			if (callback != null) callback(PacketArgs);
		}

		public void ClientCommand(uint opCode, byte[] data) {
			var PacketArgs = new gPacketArgs {
				data = data,
				unknown = false
			};

			switch (opCode) {
				case 0xDCDA: _cLockon(data); break;
				case 0xB3F3: _cMove(data); break;
				case 0x5207: _cSetGlyphs(data); break;
				case 0xD50E: _cTarget(data); break;
				case 0x88BC: _cWhisper(data); break;
				default: PacketArgs.unknown = true; break;
			}

			if (cPacket != null) cPacket(PacketArgs);
		}

		private string GetString(byte[] value, int startIndex, int maxLength) {
			int byteLength;
			return GetString(value, startIndex, maxLength, out byteLength);
		}

		private string GetString(byte[] value, int startIndex, int maxLength, out int byteLength) {
			int i;
			char c;
			string result = "";

			int maxIndex = startIndex + maxLength * 2;
			if (value.Length < maxIndex) maxIndex = value.Length;

			for (i = startIndex; i < maxIndex; i += 2) {
				c = BitConverter.ToChar(value, i);
				if (c == '\0') break;
				result += c;
			}

			byteLength = i - startIndex + 2;
			return result;
		}

		private void _sSelfInfo(byte[] data) {
			var callback = sSelfInfo;
			if (callback == null) return;

			var nameOffset = BitConverter.ToUInt16(data, 4);
			var details1Offset = BitConverter.ToUInt16(data, 6);
			var details1Length = BitConverter.ToUInt16(data, 8);
			var details2Offset = BitConverter.ToUInt16(data, 10);
			var details2Length = BitConverter.ToUInt16(data, 12);

			var appearance = new byte[8];
			Array.Copy(data, 51, appearance, 0, 8);

			var details1 = new byte[details1Length];
			Array.Copy(data, details1Offset, details1, 0, details1Length);

			var details2 = new byte[details2Length];
			Array.Copy(data, details2Offset, details2, 0, details2Length);

			callback(new sSelfInfoArgs {
				model = BitConverter.ToUInt32(data, 14),
				cid = BitConverter.ToUInt64(data, 18),
				pid = BitConverter.ToUInt64(data, 26),
				// unk
				appearance = appearance,
				// unk
				level = BitConverter.ToInt16(data, 61),
				name = GetString(data, nameOffset, NAME_CHAR_MAX_LENGTH),
				details1 = details1,
				details2 = details2,
			});
		}

		private void _sGuildInfo(byte[] data) {
			var callback = sGuildInfo;
			if (callback == null) return;

			ushort numRanks = BitConverter.ToUInt16(data, 4);
			ushort offsetRank = BitConverter.ToUInt16(data, 6);
			ushort offsetName = BitConverter.ToUInt16(data, 8);
			ushort offsetTitle = BitConverter.ToUInt16(data, 10);
			ushort offsetMaster = BitConverter.ToUInt16(data, 12);
			ushort offsetMotd = BitConverter.ToUInt16(data, 14);
			ushort offsetUnk = BitConverter.ToUInt16(data, 16);
			ushort offsetAd = BitConverter.ToUInt16(data, 18);

			var ranks = new List<GuildRank>(numRanks);
			while (offsetRank > 0) {
				ushort offsetRankName = BitConverter.ToUInt16(data, offsetRank + 4);
				ranks.Add(new GuildRank {
					Id = BitConverter.ToUInt32(data, offsetRank + 6),
					Permissions = BitConverter.ToUInt32(data, offsetRank + 10),
					Name = GetString(data, offsetRankName, 32)
				});
				offsetRank = BitConverter.ToUInt16(data, offsetRank + 2);
			}

			callback(new sGuildInfoArgs {
				name = GetString(data, offsetName, 32),
				title = GetString(data, offsetTitle, 32),
				master = GetString(data, offsetMaster, 32),
				motd = GetString(data, offsetMotd, 128),
				unk = GetString(data, offsetUnk, 32),
				ad = GetString(data, offsetAd, 64),
				ranks = ranks
			});
		}

		private void _sSelfStamina(byte[] data) {
			var callback = sSelfStamina;
			if (callback == null) return;

			callback(new sSelfStaminaArgs() {
				current = BitConverter.ToInt32(data, 4),
				max = BitConverter.ToInt32(data, 8),
				tier = BitConverter.ToInt16(data, 12)
			});
		}

		private void _sPlayerInfo(byte[] data) {
			var callback = sPlayerInfo;
			if (callback == null) return;

			ushort nameOffset = BitConverter.ToUInt16(data, 4);
			ushort guildOffset = BitConverter.ToUInt16(data, 6);
			ushort guildRankOffset = BitConverter.ToUInt16(data, 8);
			ushort details1Offset = BitConverter.ToUInt16(data, 10);
			ushort details1Length = BitConverter.ToUInt16(data, 12);
			ushort guildTitleOffset = BitConverter.ToUInt16(data, 14);
			ushort guildEmblemOffset = BitConverter.ToUInt16(data, 16);
			ushort details2Offset = BitConverter.ToUInt16(data, 18);
			ushort details2Length = BitConverter.ToUInt16(data, 20);
			
			string name = GetString(data, nameOffset, NAME_CHAR_MAX_LENGTH);
			string guild = GetString(data, guildOffset, NAME_GUILD_MAX_LENGTH);
			string guildRank = GetString(data, guildRankOffset, NAME_GUILDRANK_MAX_LENGTH);
			string guildTitle = GetString(data, guildTitleOffset, NAME_GUILDRANK_MAX_LENGTH);
			string guildEmblem = GetString(data, guildEmblemOffset, 64);

			var appearance = new byte[8];
			Array.Copy(data, 72, appearance, 0, 8);

			var details1 = new byte[details1Length];
			Array.Copy(data, details1Offset, details1, 0, details1Length);

			var details2 = new byte[details2Length];
			Array.Copy(data, details2Offset, details2, 0, details2Length);

			callback(new sPlayerInfoArgs {
				pid = BitConverter.ToUInt64(data, 22),
				uid = BitConverter.ToUInt64(data, 30),
				position = new Position {
					X = BitConverter.ToSingle(data, 38),
					Y = BitConverter.ToSingle(data, 42),
					Z = BitConverter.ToSingle(data, 46)
				},
				angle = BitConverter.ToInt16(data, 50),
				relation = BitConverter.ToInt32(data, 52),
				model = BitConverter.ToUInt32(data, 56),
				level = BitConverter.ToInt32(data, 169),
				appearance = appearance,
				name = name,
				guild = guild,
				guildRank = guildRank,
				details1 = details1,
				guildTitle = guildTitle,
				guildEmblem = guildEmblem,
				details2 = details2
			});
		}

		private void _sAttackStart(byte[] data) {
			var callback = sAttackStart;
			if (callback == null) return;

			callback(new sAttackStartArgs {
				source = BitConverter.ToUInt64(data, 8),
				position = new Position {
					X = BitConverter.ToSingle(data, 16),
					Y = BitConverter.ToSingle(data, 20),
					Z = BitConverter.ToSingle(data, 24)
				},
				angle = BitConverter.ToInt16(data, 28),
				model = BitConverter.ToUInt32(data, 30),
				skill = BitConverter.ToUInt32(data, 34),
				stage = BitConverter.ToUInt32(data, 38),
				speed = BitConverter.ToSingle(data, 42),
				id = BitConverter.ToUInt32(data, 46)
			});
		}

		private void _sAttackHoming(byte[] data) {
			var callback = sAttackHoming;
			if (callback == null) return;

			var numTargets = BitConverter.ToUInt16(data, 8);
			var offsetTargets = BitConverter.ToUInt16(data, 10);
			var numPositions = BitConverter.ToUInt16(data, 12);
			var offsetPositions = BitConverter.ToUInt16(data, 12);

			var targets = new List<ulong>(numTargets);
			var positions = new List<Position>(numPositions);

			while (offsetTargets > 0) {
				// unk <- Int32(offs + 4)
				targets.Add(BitConverter.ToUInt64(data, offsetTargets + 8));
				offsetTargets = BitConverter.ToUInt16(data, offsetTargets + 2);
			}

			while (offsetPositions > 0) {
				positions.Add(new Position {
					X = BitConverter.ToUInt64(data, offsetPositions + 4),
					Y = BitConverter.ToUInt64(data, offsetPositions + 8),
					Z = BitConverter.ToUInt64(data, offsetPositions + 12),
				});
				offsetPositions = BitConverter.ToUInt16(data, offsetPositions + 2);
			}

			callback(new sAttackHomingArgs {
				source = BitConverter.ToUInt64(data, 8),
				model = BitConverter.ToUInt32(data, 16),
				skill = BitConverter.ToUInt32(data, 20),
				id = BitConverter.ToUInt32(data, 24),
				targets = targets,
				positions = positions
			});
		}

		private void _sAttackResult(byte[] data) {
			var callback = sAttackResult;
			if (callback == null) return;

			callback(new sAttackResultArgs {
				source = BitConverter.ToUInt64(data, 8),
				target = BitConverter.ToUInt64(data, 16),
				model = BitConverter.ToUInt32(data, 24),
				skill = BitConverter.ToUInt32(data, 28),
				stage = BitConverter.ToUInt32(data, 32),
				unk1 = BitConverter.ToInt32(data, 36),
				id = BitConverter.ToUInt32(data, 40),
				time = BitConverter.ToInt32(data, 44),
				damage = BitConverter.ToUInt32(data, 48),
				type1a = BitConverter.ToUInt16(data, 52),
				type1b = BitConverter.ToUInt16(data, 54),
				crit = BitConverter.ToUInt16(data, 56)
			});
		}

		private void _sUpdateHp(byte[] data) {
			var callback = sUpdateHp;
			if (callback == null) return;

			callback(new sUpdateHpArgs {
				current = BitConverter.ToUInt32(data, 4),
				max = BitConverter.ToUInt32(data, 8),
				diff = BitConverter.ToInt32(data, 12),
				type = BitConverter.ToUInt32(data, 16),
				target = BitConverter.ToUInt64(data, 20),
				source = BitConverter.ToUInt64(data, 28),
				crit = data[36]
			});
		}

		private void _sUpdateMp(byte[] data) {
			var callback = sUpdateMp;
			if (callback == null) return;

			callback(new sUpdateMpArgs {
				current = BitConverter.ToUInt32(data, 4),
				max = BitConverter.ToUInt32(data, 8),
				diff = BitConverter.ToInt32(data, 12),
				type = BitConverter.ToUInt32(data, 16),
				target = BitConverter.ToUInt64(data, 20),
				source = BitConverter.ToUInt64(data, 28)
			});
		}

		private void _sUpdateRe(byte[] data) {
			var callback = sUpdateRe;
			if (callback == null) return;

			callback(new sUpdateReArgs {
				current = BitConverter.ToUInt32(data, 4),
				max = BitConverter.ToUInt32(data, 8),
				unk1 = BitConverter.ToInt32(data, 12),
				unk2 = BitConverter.ToInt32(data, 16),
				unk3 = BitConverter.ToInt32(data, 20)
			});
		}

		private void _sAbnormalAdd(byte[] data) {
			var callback = sAbnormalAdd;
			if (callback == null) return;

			callback(new sAbnormalAddArgs {
				target = BitConverter.ToUInt64(data, 4),
				source = BitConverter.ToUInt64(data, 12),
				abnormal = new Abnormal {
					Id = BitConverter.ToUInt32(data, 20),
					Duration = BitConverter.ToInt32(data, 24),
					Unk = BitConverter.ToInt32(data, 28),
					Stacks = BitConverter.ToInt32(data, 32)
				}
			});
		}

		private void _sAbnormalUpdate(byte[] data) {
			var callback = sAbnormalUpdate;
			if (callback == null) return;

			callback(new sAbnormalUpdateArgs {
				target = BitConverter.ToUInt64(data, 4),
				abnormal = new Abnormal {
					Id = BitConverter.ToUInt32(data, 12),
					Duration = BitConverter.ToInt32(data, 16),
					Unk = BitConverter.ToInt32(data, 20),
					Stacks = BitConverter.ToInt32(data, 24)
				}
			});
		}

		private void _sAbnormalRemove(byte[] data) {
			var callback = sAbnormalRemove;
			if (callback == null) return;

			callback(new sAbnormalRemoveArgs {
				target = BitConverter.ToUInt64(data, 4),
				id = BitConverter.ToUInt32(data, 12)
			});
		}

		private void _sPartyAbnormalAdd(byte[] data) {
			var callback = sPartyAbnormalAdd;
			if (callback == null) return;

			callback(new sPartyAbnormalAddArgs {
				target = BitConverter.ToUInt64(data, 4),
				abnormal = new Abnormal {
					Id = BitConverter.ToUInt32(data, 12),
					Duration = BitConverter.ToInt32(data, 16),
					Unk = BitConverter.ToInt32(data, 20),
					Stacks = BitConverter.ToInt32(data, 24)
				}
			});
		}

		private void _sPartyAbnormalUpdate(byte[] data) {
			var callback = sPartyAbnormalUpdate;
			if (callback == null) return;

			callback(new sPartyAbnormalUpdateArgs {
				target = BitConverter.ToUInt64(data, 4),
				abnormal = new Abnormal {
					Id = BitConverter.ToUInt32(data, 12),
					Duration = BitConverter.ToInt32(data, 16),
					Unk = BitConverter.ToInt32(data, 20),
					Stacks = BitConverter.ToInt32(data, 24)
				}
			});
		}

		private void _sPartyAbnormalRemove(byte[] data) {
			var callback = sPartyAbnormalRemove;
			if (callback == null) return;

			callback(new sPartyAbnormalRemoveArgs {
				target = BitConverter.ToUInt64(data, 4),
				id = BitConverter.ToUInt32(data, 12)
			});
		}

		private void _sCombatStatus(byte[] data) {
			var callback = sCombatStatus;
			if (callback == null) return;

			callback(new sCombatStatusArgs {
				target = BitConverter.ToUInt64(data, 4),
				status = BitConverter.ToUInt32(data, 12) // 0 = out, 1 = in, 2 = rest
				// unk -> 1 byte
			});
		}

		private void _sLifeStatus(byte[] data) {
			var callback = sLifeStatus;
			if (callback == null) return;

			callback(new sLifeStatusArgs {
				target = BitConverter.ToUInt64(data, 4),
				position = new Position {
					X = BitConverter.ToSingle(data, 12),
					Y = BitConverter.ToSingle(data, 16),
					Z = BitConverter.ToSingle(data, 20)
				},
				status = BitConverter.ToUInt16(data, 24),
				unk = data[26]
			});
		}

		private void _sAbsorbDamage(byte[] data) {
			var callback = sAbsorbDamage;
			if (callback == null) return;

			callback(new sAbsorbDamageArgs {
				target = BitConverter.ToUInt64(data, 4),
				amount = BitConverter.ToInt32(data, 12)
			});
		}

		private void _sConditionList(byte[] data) {
			var callback = sConditionList;
			if (callback == null) return;

			ushort count = BitConverter.ToUInt16(data, 4);
			ushort offset = BitConverter.ToUInt16(data, 6);

			var conditions = new List<Condition>(count);
			while (offset > 0) {
				conditions.Add(new Condition {
					Id = BitConverter.ToUInt32(data, offset + 4),
					Duration = BitConverter.ToInt32(data, offset + 8),
					Status = data[offset + 12]
				});
				offset = BitConverter.ToUInt16(data, offset + 2);
			}

			callback(new sConditionListArgs {
				target = BitConverter.ToUInt64(data, 8),
				conditions = conditions
			});
		}

		private void _sTargetInfo(byte[] data) {
			var callback = sTargetInfo;
			if (callback == null) return;

			ushort numAbnormals = BitConverter.ToUInt16(data, 4);
			ushort offsetAbnormals = BitConverter.ToUInt16(data, 6);
			ushort numConditions = BitConverter.ToUInt16(data, 8);
			ushort offsetConditions = BitConverter.ToUInt16(data, 10);

			var abnormals = new List<Abnormal>(numAbnormals);
			var conditions = new List<Condition>(numConditions);

			while (offsetAbnormals > 0) {
				abnormals.Add(new Abnormal {
					Id = BitConverter.ToUInt32(data, offsetAbnormals + 4),
					Duration = BitConverter.ToInt32(data, offsetAbnormals + 8),
					Unk = BitConverter.ToInt32(data, offsetAbnormals + 12),
					Stacks = BitConverter.ToInt32(data, offsetAbnormals + 16)
				});
				offsetAbnormals = BitConverter.ToUInt16(data, offsetAbnormals + 2);
			}

			while (offsetConditions > 0) {
				conditions.Add(new Condition {
					Id = BitConverter.ToUInt32(data, offsetConditions + 4),
					Duration = BitConverter.ToInt32(data, offsetConditions + 8),
					Status = data[offsetConditions + 12]
				});
				offsetConditions = BitConverter.ToUInt16(data, offsetConditions + 2);
			}

			callback(new sTargetInfoArgs {
				target = BitConverter.ToUInt64(data, 12),
				hp = BitConverter.ToSingle(data, 20),
				// unk -> 4
				level = BitConverter.ToUInt32(data, 28),
				// unk -> 4
				// unk -> 4
				edge = new Edge {
					d = BitConverter.ToInt32(data, 40),
					f = BitConverter.ToSingle(data, 44)
				},
				// unk -> 4 (always 40 1F 00 00 = 8,000?)
				abnormals = abnormals,
				conditions = conditions
			});
		}

		private void _sPartyAbnormalList(byte[] data) {
			var callback = sPartyAbnormalList;
			if (callback == null) return;

			ushort numAbnormals = BitConverter.ToUInt16(data, 4);
			ushort offsetAbnormals = BitConverter.ToUInt16(data, 6);
			ushort numConditions = BitConverter.ToUInt16(data, 8);
			ushort offsetConditions = BitConverter.ToUInt16(data, 10);

			var abnormals = new List<Abnormal>(numAbnormals);
			var conditions = new List<Condition>(numConditions);

			while (offsetAbnormals > 0) {
				abnormals.Add(new Abnormal {
					Id = BitConverter.ToUInt32(data, offsetAbnormals + 4),
					Duration = BitConverter.ToInt32(data, offsetAbnormals + 8),
					Unk = BitConverter.ToInt32(data, offsetAbnormals + 12),
					Stacks = BitConverter.ToInt32(data, offsetAbnormals + 16)
				});
				offsetAbnormals = BitConverter.ToUInt16(data, offsetAbnormals + 2);
			}

			while (offsetConditions > 0) {
				conditions.Add(new Condition {
					Id = BitConverter.ToUInt32(data, offsetConditions + 4),
					Duration = BitConverter.ToInt32(data, offsetConditions + 8),
					Status = data[offsetConditions + 12]
				});
				offsetConditions = BitConverter.ToUInt16(data, offsetConditions + 2);
			}

			callback(new sPartyAbnormalListArgs {
				target = BitConverter.ToUInt64(data, 12),
				abnormals = abnormals,
				conditions = conditions
			});
		}

		private void _sConditionAdd(byte[] data) {
			var callback = sConditionAdd;
			if (callback == null) return;

			callback(new sConditionAddArgs {
				target = BitConverter.ToUInt64(data, 4),
				condition = new Condition {
					Id = BitConverter.ToUInt32(data, 12),
					Status = data[16],
					Duration = BitConverter.ToInt32(data, 17)
				}
			});
		}

		private void _sConditionActivate(byte[] data) {
			var callback = sConditionActivate;
			if (callback == null) return;

			callback(new sConditionActivateArgs {
				id = BitConverter.ToUInt32(data, 4)
			});
		}

		private void _sConditionRemove(byte[] data) {
			var callback = sConditionRemove;
			if (callback == null) return;

			callback(new sConditionRemoveArgs {
				id = BitConverter.ToUInt32(data, 4)
			});
		}

		private void _sPartyConditionAdd(byte[] data) {
			var callback = sPartyConditionAdd;
			if (callback == null) return;

			callback(new sPartyConditionAddArgs {
				target = BitConverter.ToUInt64(data, 4),
				condition = new Condition {
					Id = BitConverter.ToUInt32(data, 12),
					Duration = BitConverter.ToInt32(data, 16),
					Status = data[20]
				}
			});
		}

		private void _sPartyConditionActivate(byte[] data) {
			var callback = sPartyConditionActivate;
			if (callback == null) return;

			callback(new sPartyConditionActivateArgs {
				target = BitConverter.ToUInt64(data, 4),
				id = BitConverter.ToUInt32(data, 12)
			});
		}

		private void _sPartyConditionRemove(byte[] data) {
			var callback = sPartyConditionRemove;
			if (callback == null) return;

			callback(new sPartyConditionRemoveArgs {
				target = BitConverter.ToUInt64(data, 4),
				id = BitConverter.ToUInt32(data, 12)
			});
		}

		private void _sProjectile(byte[] data) {
			var callback = sProjectile;
			if (callback == null) return;

			callback(new sProjectileArgs {
				source = BitConverter.ToUInt64(data, 4),
				model = BitConverter.ToUInt32(data, 12),
				unk = BitConverter.ToInt32(data, 16),
				id = BitConverter.ToUInt64(data, 20),
				skill = BitConverter.ToUInt32(data, 28),
				startPosition = new Position {
					X = BitConverter.ToSingle(data, 32),
					Y = BitConverter.ToSingle(data, 36),
					Z = BitConverter.ToSingle(data, 40)
				},
				startAngle = BitConverter.ToInt16(data, 44),
				targetPosition = new Position {
					X = BitConverter.ToSingle(data, 46),
					Y = BitConverter.ToSingle(data, 50),
					Z = BitConverter.ToSingle(data, 54)
				},
				targetAngle = BitConverter.ToInt16(data, 58)
			});
		}

		private void _sProjectileRemove(byte[] data) {
			var callback = sProjectileRemove;
			if (callback == null) return;

			callback(new sProjectileRemoveArgs {
				id = BitConverter.ToUInt64(data, 4),
				unk = data[12]
			});
		}

		private void _sProjectedAttack(byte[] data) {
			var callback = sProjectedAttack;
			if (callback == null) return;

			callback(new sProjectedAttackArgs {
				id = BitConverter.ToUInt64(data, 4),
				// (unk?) <- 4 bytes
				startPosition = new Position {
					X = BitConverter.ToSingle(data, 16),
					Y = BitConverter.ToSingle(data, 20),
					Z = BitConverter.ToSingle(data, 24)
				},
				startAngle = BitConverter.ToInt16(data, 28),
				targetPosition = new Position {
					X = BitConverter.ToSingle(data, 30),
					Y = BitConverter.ToSingle(data, 34),
					Z = BitConverter.ToSingle(data, 38)
				},
				targetAngle = BitConverter.ToInt16(data, 42),
				// (unk?) <- 4+1 bytes
				source = BitConverter.ToUInt64(data, 49),
				model = BitConverter.ToUInt32(data, 57)
			});
		}

		private void _sProjectedAttackRemove(byte[] data) {
			var callback = sProjectedAttackRemove;
			if (callback == null) return;

			callback(new sProjectedAttackRemoveArgs {
				id = BitConverter.ToUInt64(data, 4),
				unk = data[12]
			});
		}

		private void _sPartyList(byte[] data) {
			var callback = sPartyList;
			if (callback == null) return;

			ushort count = BitConverter.ToUInt16(data, 4);
			ushort offset = BitConverter.ToUInt16(data, 6);
			// IMS? <- 1 byte
			//byte type = data[9];
			// (unk?) <- 4 bytes
			// (unk?) <- 4 bytes
			// (unk?) <- 4 bytes
			//ulong leader = BitConverter.ToUInt64(data, 22);
			// (unk?) <- 4 bytes
			// (unk?) <- 4 bytes
			// (unk?) <- 2 bytes
			// (unk?) <- 4 bytes
			// (unk?) <- 4 bytes
			// (unk?) <- 1 byte

			var members = new List<PartyMember>(count);

			while (offset > 0) {
				members.Add(new PartyMember {
					pID = BitConverter.ToUInt64(data, offset + 6),
					level = BitConverter.ToInt32(data, offset + 14),
					job = BitConverter.ToInt32(data, offset + 18),
					status = data[offset + 22],
					cID = BitConverter.ToUInt64(data, offset + 23),
					partyPosition = BitConverter.ToInt32(data, offset + 31),
					canInvite = data[offset + 35],
					name = GetString(data, offset + 36, NAME_CHAR_MAX_LENGTH)
				});
				offset = BitConverter.ToUInt16(data, offset + 2);
			}

			callback(new sPartyListArgs {
				type = data[9],
				leader = BitConverter.ToUInt64(data, 22),
				members = members
			});
		}

		/*
		private void ParsePartyMemberMove(byte[] data) {
			ulong cUID = BitConverter.ToUInt64(data, 4);
			int pos = BitConverter.ToInt32(data, 12);
			Console.WriteLine("~~ {0} moved to position {1}", GetPlayerName(cUID), pos);
		}
		 */

		private void _sPartyDeath(byte[] data) {
			var callback = sPartyDeath;
			if (callback == null) return;

			callback(new sPartyDeathArgs {
				target = BitConverter.ToUInt64(data, 4)
			});
		}

		private void _sPartyUpdate(byte[] data) {
			var callback = sPartyUpdate;
			if (callback == null) return;

			callback(new sPartyUpdateArgs {
				target = BitConverter.ToUInt64(data, 4),
				currentHp = BitConverter.ToInt32(data, 12),
				currentMp = BitConverter.ToInt32(data, 16),
				maxHp = BitConverter.ToInt32(data, 20),
				maxMp = BitConverter.ToInt32(data, 24),
				level = BitConverter.ToInt16(data, 28),
				inCombat = BitConverter.ToInt16(data, 30),
				vitality = BitConverter.ToInt16(data, 32),
				status = data[34],
				stamina = BitConverter.ToInt32(data, 35),
				currentRe = BitConverter.ToInt32(data, 39),
				maxRe = BitConverter.ToInt32(data, 43),
				unk = BitConverter.ToInt32(data, 47)
			});
		}

		private void _sPartyUpdateHp(byte[] data) {
			var callback = sPartyUpdateHp;
			if (callback == null) return;

			callback(new sPartyUpdateHpArgs {
				target = BitConverter.ToUInt64(data, 4),
				current = BitConverter.ToInt32(data, 12),
				max = BitConverter.ToInt32(data, 16)
			});
		}

		private void _sPartyUpdateMp(byte[] data) {
			var callback = sPartyUpdateMp;
			if (callback == null) return;

			callback(new sPartyUpdateMpArgs {
				target = BitConverter.ToUInt64(data, 4),
				current = BitConverter.ToInt32(data, 12),
				max = BitConverter.ToInt32(data, 16)
			});
		}

		private void _sPartyUpdateRe(byte[] data) {
			var callback = sPartyUpdateRe;
			if (callback == null) return;

			callback(new sPartyUpdateReArgs {
				target = BitConverter.ToUInt64(data, 4),
				current = BitConverter.ToInt32(data, 12),
				max = BitConverter.ToInt32(data, 16),
				unk = BitConverter.ToInt32(data, 20)
			});
		}

		private void _sPartyInvitePriv(byte[] data) {
			var callback = sPartyInvitePriv;
			if (callback == null) return;

			callback(new sPartyInvitePrivArgs {
				target = BitConverter.ToUInt64(data, 4),
				canInvite = data[12]
			});
		}

		private void _sPartyLeader(byte[] data) {
			var callback = sPartyLeader;
			if (callback == null) return;

			ushort offset = BitConverter.ToUInt16(data, 4);
			callback(new sPartyLeaderArgs {
				target = BitConverter.ToUInt64(data, 6),
				name = GetString(data, offset, 32)
			});
		}

		private void _sNpcHp(byte[] data) {
			var callback = sNpcHp;
			if (callback == null) return;

			callback(new sNpcHpArgs {
				target = BitConverter.ToUInt64(data, 4),
				hp = BitConverter.ToSingle(data, 12),
				unk1 = data[16], // enemy?
				edge = new Edge {
					d = BitConverter.ToInt32(data, 17),
					f = BitConverter.ToSingle(data, 21)
				}
				// unk2 <- 4 (40 1F 00 00 = 8,000?)
				// unk3 <- 4 (03 00 00 00)
			});
		}

		private void _sNpcStatus(byte[] data) {
			var callback = sNpcStatus;
			if (callback == null) return;

			callback(new sNpcStatusArgs {
				creature = BitConverter.ToUInt64(data, 4),
				enraged = data[12],
				unk1 = BitConverter.ToInt32(data, 13), // (HP / 20)?
				target = BitConverter.ToUInt64(data, 17),
				unk2 = BitConverter.ToInt32(data, 25)
			});
		}

		private void _sNpcEmotion(byte[] data) {
			var callback = sNpcEmotion;
			if (callback == null) return;

			callback(new sNpcEmotionArgs {
				target = BitConverter.ToUInt64(data, 4),
				creature = BitConverter.ToUInt64(data, 12),
				emotion = BitConverter.ToInt32(data, 20)
			});
		}

		private void _sNpcInfo(byte[] data) {
			var callback = sNpcInfo;
			if (callback == null) return;

			callback(new sNpcInfoArgs {
				// (unk?) <- UInt32(..., 4)
				// shift <- UInt16(..., 8)
				id = BitConverter.ToUInt64(data, 10),
				target = BitConverter.ToUInt64(data, 18),
				position = new Position {
					X = BitConverter.ToSingle(data, 26),
					Y = BitConverter.ToSingle(data, 30),
					Z = BitConverter.ToSingle(data, 34),
				},
				angle = BitConverter.ToInt16(data, 38),
				// (unk?) <- 4 bytes, usually 0x0000000C
				npc = BitConverter.ToUInt32(data, 42),
				type = BitConverter.ToUInt16(data, 46),
				model = BitConverter.ToUInt32(data, 48),
				// (unk?) <- ...
				owner = BitConverter.ToUInt64(data, 85),
				// (unk?) <- ...
			});
		}

		private void _sNpcCombatStatus(byte[] data) {
			var callback = sNpcCombatStatus;
			if (callback == null) return;

			callback(new sNpcCombatStatusArgs {
				target = BitConverter.ToUInt64(data, 4),
				status = data[12]
			});
		}

		private void _sChatMessage(byte[] data) {
			var callback = sChatMessage;
			if (callback == null) return;

			ushort senderOffset = BitConverter.ToUInt16(data, 4);
			ushort messageOffset = BitConverter.ToUInt16(data, 6);

			callback(new sChatMessageArgs {
				type = BitConverter.ToUInt32(data, 8),
				authorId = BitConverter.ToUInt64(data, 12),
				unk1 = data[20],
				gm = data[21],
				unk2 = data[22],
				authorName = GetString(data, senderOffset, NAME_CHAR_MAX_LENGTH),
				message = GetString(data, messageOffset, 1023)
			});
		}

		private void _sWhisper(byte[] data) {
			var callback = sWhisper;
			if (callback == null) return;

			var authorOffset = BitConverter.ToUInt16(data, 4);
			var recipientOffset = BitConverter.ToUInt16(data, 6);
			var messageOffset = BitConverter.ToUInt16(data, 8);

			callback(new sWhisperArgs {
				player = BitConverter.ToUInt64(data, 10),
				unk1 = data[18],
				gm = data[19],
				unk2 = data[20],
				author = GetString(data, authorOffset, NAME_CHAR_MAX_LENGTH),
				recipient = GetString(data, recipientOffset, NAME_CHAR_MAX_LENGTH),
				message = GetString(data, messageOffset, 1023)
			});
		}

		private void _sSystemMessage(byte[] data) {
			var callback = sSystemMessage;
			if (callback == null) return;

			var strs = BitConverter.ToString(data).Split((char)11);
			var args = new Dictionary<string, string>();

			for (var i = 1; i < strs.Length; i += 2) {
				args[strs[i]] = strs[i + 1];
			}

			callback(new sSystemMessageArgs {
				id = strs[0].Substring(1),
				args = args
			});
		}

		private void _sImage(byte[] data) {
			var callback = sImage;
			if (callback == null) return;

			ushort nameOffset = BitConverter.ToUInt16(data, 4);
			ushort dataOffset = BitConverter.ToUInt16(data, 6);
			ushort dataLength = BitConverter.ToUInt16(data, 8);

			var imageData = new byte[dataLength];
			Array.Copy(data, dataOffset, imageData, 0, dataLength);

			callback(new sImageArgs {
				name = GetString(data, nameOffset, 64),
				data = imageData
			});
		}

		private void _sLockon(byte[] data) {
			var callback = sLockon;
			if (callback == null) return;

			callback(new sLockonArgs {
				target = BitConverter.ToUInt64(data, 4),
				attack = BitConverter.ToUInt32(data, 12),
				result = data[16]
			});
		}

		private void _sLootSpawn(byte[] data) {
			var callback = sLootSpawn;
			if (callback == null) return;

			ushort numOwners = BitConverter.ToUInt16(data, 4);
			ushort offsetOwners = BitConverter.ToUInt16(data, 6);

			var owners = new List<ulong>(numOwners);
			while (offsetOwners > 0) {
				owners.Add(BitConverter.ToUInt64(data, offsetOwners + 4));
				offsetOwners = BitConverter.ToUInt16(data, offsetOwners + 2);
			}

			callback(new sLootSpawnArgs {
				id = BitConverter.ToUInt64(data, 8),
				position = new Position {
					X = BitConverter.ToSingle(data, 16),
					Y = BitConverter.ToSingle(data, 20),
					Z = BitConverter.ToSingle(data, 24)
				},
				item = BitConverter.ToUInt32(data, 28),
				amount = BitConverter.ToUInt32(data, 32),
				expiry = BitConverter.ToInt32(data, 36),
				// unk
				mob = BitConverter.ToUInt64(data, 46)
			});
		}

		private void _sLootStatus(byte[] data) {
			var callback = sLootStatus;
			if (callback == null) return;

			callback(new sLootStatusArgs {
				id = BitConverter.ToUInt64(data, 4),
				waiting = data[12]
			});
		}

		private void _sLootReceived(byte[] data) {
			var callback = sLootReceived;
			if (callback == null) return;

			callback(new sLootReceivedArgs {
				target = BitConverter.ToUInt64(data, 4),
				unk1 = BitConverter.ToInt32(data, 12),
				unk2 = BitConverter.ToInt32(data, 16),
				id = BitConverter.ToUInt64(data, 20),
				unk3 = data[28]
			});
		}

		private void _sLootRoll(byte[] data) {
			var callback = sLootRoll;
			if (callback == null) return;

			callback(new sLootRollArgs {
				target = BitConverter.ToUInt64(data, 4),
				roll = BitConverter.ToInt32(data, 12)
			});
		}

		private void _sLootWindow(byte[] data) {
			var callback = sLootWindow;
			if (callback == null) return;

			/*
			var numUnk = BitConverter.ToUInt16(data, 4);
			var offsetUnk = BitConverter.ToUInt16(data, 6);

			var unk = new List<uint>(numUnk);
			while (offsetUnk > 0) {
				unk.Add(BitConverter.ToUInt32(data, offsetUnk + 4));
				offsetUnk = BitConverter.ToUInt16(data, offsetUnk + 2);
			}
			 */

			callback(new sLootWindowArgs {
				// num = UInt32(8)
				// unk1 = Int32(12)
				item = BitConverter.ToUInt32(data, 16),
				// unk2 = Int32(20)
				// unk3 = Int32(24)
				// unk4 = data[28]
				duration = BitConverter.ToInt32(data, 29),
				// unk5 = data[33]
				// unk6 = Int32(34)
				// unk7 = unk
			});
		}

		private void _sLootWon(byte[] data) {
			var callback = sLootWon;
			if (callback == null) return;

			callback(new sLootWonArgs {
				target = BitConverter.ToUInt64(data, 4)
			});
		}

		private void _sLootRemove(byte[] data) {
			var callback = sLootRemove;
			if (callback == null) return;

			callback(new sLootRemoveArgs {
				id = BitConverter.ToUInt64(data, 4)
			});
		}

		private void _sAnimate(byte[] data) {
			var callback = sAnimate;
			if (callback == null) return;

			callback(new sAnimateArgs {
				target = BitConverter.ToUInt64(data, 4),
				animation = BitConverter.ToInt32(data, 12),
				unk1 = BitConverter.ToInt32(data, 16),
				unk2 = data[20]
			});
		}

		private void _sNpcUnload(byte[] data) {
			var callback = sNpcUnload;
			if (callback == null) return;

			callback(new sNpcUnloadArgs {
				target = BitConverter.ToUInt64(data, 4),
				position = new Position {
					X = BitConverter.ToSingle(data, 12),
					Y = BitConverter.ToSingle(data, 16),
					Z = BitConverter.ToSingle(data, 20)
				},
				type = BitConverter.ToUInt32(data, 24),
				unk = BitConverter.ToInt32(data, 28)
			});
		}

		private void _sAttackEnd(byte[] data) {
			var callback = sAttackEnd;
			if (callback == null) return;

			callback(new sAttackEndArgs {
				source = BitConverter.ToUInt64(data, 4),
				position = new Position {
					X = BitConverter.ToSingle(data, 12),
					Y = BitConverter.ToSingle(data, 16),
					Z = BitConverter.ToSingle(data, 20)
				},
				angle = BitConverter.ToInt16(data, 24),
				model = BitConverter.ToUInt32(data, 26),
				skill = BitConverter.ToUInt32(data, 30),
				// unk = BitConverter.ToInt32(data, 34),
				id = BitConverter.ToUInt32(data, 38),
			});
		}
		
		private void _sCooldownItem(byte[] data) {
			var callback = sCooldownItem;
			if (callback == null) return;

			callback(new sCooldownItemArgs {
				item = BitConverter.ToUInt32(data, 4),
				cooldown = BitConverter.ToInt32(data, 8)
			});
		}
		
		private void _sCooldownSkill(byte[] data) {
			var callback = sCooldownSkill;
			if (callback == null) return;

			callback(new sCooldownSkillArgs {
				skill = BitConverter.ToUInt32(data, 4),
				cooldown = BitConverter.ToInt32(data, 8)
			});
		}
		
		private void _sGlyphs(byte[] data) {
			var callback = sGlyphs;
			if (callback == null) return;

			ushort count = BitConverter.ToUInt16(data, 4);
			ushort offset = BitConverter.ToUInt16(data, 6);

			var glyphs = new Dictionary<uint, byte>(count);
			while (offset > 0) {
				var id = BitConverter.ToUInt32(data, offset + 4);
				var enabled = data[offset + 8];
				glyphs[id] = enabled;
				offset = BitConverter.ToUInt16(data, offset + 2);
			}

			callback(new sGlyphsArgs {
				glyphs = glyphs
			});
		}
		
		private void _sLockedOn(byte[] data) {
			var callback = sLockedOn;
			if (callback == null) return;

			callback(new sLockedOnArgs {
				source = BitConverter.ToUInt64(data, 4),
				skill = BitConverter.ToUInt32(data, 12)
			});
		}
		
		private void _sLootQueue(byte[] data) {
			var callback = sLootQueue;
			if (callback == null) return;

			callback(new sLootQueueArgs {
				count = BitConverter.ToInt32(data, 4)
			});
		}
		
		private void _sUpdateStats(byte[] data) {
			var callback = sUpdateStats;
			if (callback == null) return;

			callback(new sUpdateStatsArgs {
				currentHp = BitConverter.ToInt32(data, 4),
				currentMp = BitConverter.ToInt32(data, 8),
				unk1 = BitConverter.ToInt32(data, 12),
				maxHp = BitConverter.ToInt32(data, 16),
				maxMp = BitConverter.ToInt32(data, 20),

				basePower = BitConverter.ToInt32(data, 24),
				baseEndurance = BitConverter.ToInt32(data, 28),
				baseImpactFactor = BitConverter.ToInt32(data, 32),
				baseBalanceFactor = BitConverter.ToInt32(data, 36),
				baseMovementSpeed = BitConverter.ToInt16(data, 40),
				baseUnkSpeed = BitConverter.ToInt16(data, 42),
				baseAttackSpeed = BitConverter.ToInt16(data, 44),
				baseCritRate = BitConverter.ToSingle(data, 46),
				baseCritResist = BitConverter.ToSingle(data, 50),
				baseCritPower = BitConverter.ToSingle(data, 54),
				baseAttack = BitConverter.ToInt32(data, 58),
				baseAttack2 = BitConverter.ToInt32(data, 62),
				baseDefense = BitConverter.ToInt32(data, 66),
				baseImpact = BitConverter.ToInt32(data, 70),
				baseBalance = BitConverter.ToInt32(data, 74),
				baseResistWeakening = BitConverter.ToSingle(data, 78),
				baseResistPeriodic = BitConverter.ToSingle(data, 82),
				baseResistStun = BitConverter.ToSingle(data, 86),

				bonusPower = BitConverter.ToInt32(data, 90),
				bonusEndurance = BitConverter.ToInt32(data, 94),
				bonusImpactFactor = BitConverter.ToInt32(data, 98),
				bonusBalanceFactor = BitConverter.ToInt32(data, 102),
				bonusMovementSpeed = BitConverter.ToInt16(data, 106),
				bonusUnkSpeed = BitConverter.ToInt16(data, 108),
				bonusAttackSpeed = BitConverter.ToInt16(data, 110),
				bonusCritRate = BitConverter.ToSingle(data, 112),
				bonusCritResist = BitConverter.ToSingle(data, 116),
				bonusCritPower = BitConverter.ToSingle(data, 120),
				bonusAttack = BitConverter.ToInt32(data, 124),
				bonusAttack2 = BitConverter.ToInt32(data, 128),
				bonusDefense = BitConverter.ToInt32(data, 132),
				bonusImpact = BitConverter.ToInt32(data, 136),
				bonusBalance = BitConverter.ToInt32(data, 140),
				bonusResistWeakening = BitConverter.ToSingle(data, 144),
				bonusResistPeriodic = BitConverter.ToSingle(data, 148),
				bonusResistStun = BitConverter.ToSingle(data, 152),

				level = BitConverter.ToInt32(data, 156),
				vitality = BitConverter.ToInt16(data, 160),
				status = data[162],
				bonusHp = BitConverter.ToInt32(data, 163),
				bonusMp = BitConverter.ToInt32(data, 167),
				currentStamina = BitConverter.ToInt32(data, 171),
				maxStamina = BitConverter.ToInt32(data, 175),
				unk2 = BitConverter.ToInt32(data, 179),
				unk3 = BitConverter.ToInt32(data, 183),
				unk4 = BitConverter.ToInt32(data, 187),
				unk5 = BitConverter.ToInt32(data, 191),
				itemLevelInventory = BitConverter.ToInt32(data, 195),
				itemLevel = BitConverter.ToInt32(data, 199),
				unk6 = BitConverter.ToInt32(data, 203),
				unk7 = BitConverter.ToInt32(data, 207),
				unk8 = BitConverter.ToInt32(data, 211),
				unk9 = BitConverter.ToInt32(data, 215),
			});
		}

		private void _cMove(byte[] data) {
			var callback = cMove;
			if (callback == null) return;

			callback(new cMoveArgs {
				pos1 = new Position {
					X = BitConverter.ToSingle(data, 4),
					Y = BitConverter.ToSingle(data, 8),
					Z = BitConverter.ToSingle(data, 12),
				},
				angle = BitConverter.ToInt16(data, 16),
				pos2 = new Position {
					X = BitConverter.ToSingle(data, 18),
					Y = BitConverter.ToSingle(data, 22),
					Z = BitConverter.ToSingle(data, 26),
				},
				// unk
			});
		}

		private void _cWhisper(byte[] data) {
			var callback = cWhisper;
			if (callback == null) return;

			callback(new cWhisperArgs {
				target = GetString(data, BitConverter.ToUInt16(data, 4), 64),
				message = GetString(data, BitConverter.ToUInt16(data, 6), 512)
			});
		}

		private void _cTarget(byte[] data) {
			var callback = cTarget;
			if (callback == null) return;

			callback(new cTargetArgs {
				target = BitConverter.ToUInt64(data, 4)
			});
		}

		private void _cLockon(byte[] data) {
			var callback = cLockon;
			if (callback == null) return;

			callback(new cLockonArgs {
				target = BitConverter.ToUInt64(data, 4),
				attack = BitConverter.ToUInt32(data, 12)
			});
		}

		private void _cSetGlyphs(byte[] data) {
			var callback = cSetGlyphs;
			if (callback == null) return;

			ushort count = BitConverter.ToUInt16(data, 4);
			ushort offset = BitConverter.ToUInt16(data, 6);

			var glyphs = new List<uint>(count);
			while (offset > 0) {
				glyphs.Add(BitConverter.ToUInt32(data, offset + 4));
				offset = BitConverter.ToUInt16(data, offset + 2);
			}

			callback(new cSetGlyphsArgs {
				glyphs = glyphs
			});
		}
	}
}
