using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SIL.FieldWorks.Tools
{
	/// <summary>
	/// Used for a a very simple implementation of reading coments from idl files.
	/// </summary>
	public static class CommentSnatcher
	{		
		private static string s_lastComment = string.Empty;

		/// <summary>
		/// Stores and Cleans a Comment, removing the comment markers
		/// Ignores comments that contain "BEGIN LICENSE BLOCK"
		/// Wraps the comment in a <summary/> block.
		/// </summary>
		/// <param name="rawComment">the actual comment including comment markers</param>
		/// <param name="isMultiLine">true if the comment is a multiple (cstyle) comment</param>
		public static void StoreComment(string rawComment, bool isMultiLine)
		{
			// Ignore that file license comment.
			if (rawComment.Contains("BEGIN LICENSE BLOCK"))
			{
				s_lastComment = String.Empty;
				return;
			}

			if (!isMultiLine)
			{
				rawComment = rawComment.TrimStart('/');				
			}
			else
			{
				rawComment = rawComment.Trim().TrimStart('/', '*');
				rawComment = rawComment.Trim().TrimEnd('*', '/');
			}
			
			StringBuilder cleanedComment = new StringBuilder();
			cleanedComment.Append("<summary>");
			foreach (string line in rawComment.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
			{
				cleanedComment.Append(Environment.NewLine);
				// Remove '*' at start of line that look like they are used for layout
				cleanedComment.Append(Regex.Replace(line, @"^\s*\*[\s]*", " ").TrimEnd(' '));				
			}

			if (!isMultiLine)
				cleanedComment.Append(Environment.NewLine);

			cleanedComment.Append(" </summary>");
			s_lastComment = cleanedComment.ToString();
		}

		/// <summary>
		/// Forget the current comment.
		/// </summary>
		public static void ClearComment()
		{
			s_lastComment = string.Empty;
		}

		/// <summary>
		/// Get the current comment.
		/// </summary>
		/// <returns>The comment or String.Empty if there is no comment.</returns>
		public static string GetLastComment()
		{
			return s_lastComment;
		}		
	}
}
