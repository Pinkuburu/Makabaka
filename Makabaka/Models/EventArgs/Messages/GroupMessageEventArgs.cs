﻿using Makabaka.Models.EventArgs.Meta;
using Makabaka.Models.Messages;
using Makabaka.Models.Senders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">群消息</a>事件参数
	/// </summary>
	public class GroupMessageEventArgs : MetaEventArgs
	{
		/// <summary>
		/// 消息 ID
		/// </summary>
		[JsonProperty("message_id")]
		public int MessageId { get; internal set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 匿名信息，如果不是匿名消息则为 null
		/// </summary>
		[JsonProperty("anonymous")]
		public GroupAnonymousSender Anonymous { get; internal set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; internal set; }

		/// <summary>
		/// 原始消息内容
		/// </summary>
		[JsonProperty("raw_message")]
		public string RawMessage { get; internal set; }

		/// <summary>
		/// 字体
		/// </summary>
		[JsonProperty("font")]
		public int Font { get; internal set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		[JsonProperty("sender")]
		public GroupSender Sender { get; internal set; }

		internal void PostProcessMessage()
		{
			for (int i = 0; i < Message.Count; i++)
			{
				Message[i] = Message[i].PostProcessSegment();
			}
		}
	}
}
