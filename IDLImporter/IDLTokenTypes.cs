// $ANTLR 2.7.7 (20060930): "idl.g" -> "IDLParser.cs"$

/// --------------------------------------------------------------------------------------------
#region /// Copyright (c) 2002, SIL International. All Rights Reserved.   
/// <copyright from='2002' to='2002' company='SIL International'>
///		Copyright (c) 2002, SIL International. All Rights Reserved.   
///    
///		Distributable under the terms of either the Common Public License or the
///		GNU Lesser General Public License, as specified in the LICENSING.txt file.
/// </copyright> 
#endregion
/// 
/// File: idl.g
/// Responsibility: Eberhard Beilharz
/// Last reviewed: 
/// 
/// <remarks>
/// Defines the (partial) IDL grammar and some actions. It needs to be compiled with the ANTL 
/// tool
/// </remarks>
/// --------------------------------------------------------------------------------------------
#pragma warning disable 0618,0219, 0162

//#define DEBUG_IDLGRAMMAR

using System.Diagnostics;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace SIL.FieldWorks.Tools
{
	public class IDLTokenTypes
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int V1_ENUM = 4;
		public const int INT3264 = 5;
		public const int INT64 = 6;
		public const int SEMI = 7;
		public const int LBRACKET = 8;
		public const int RBRACKET = 9;
		public const int LITERAL_module = 10;
		public const int LBRACE = 11;
		public const int RBRACE = 12;
		public const int LITERAL_import = 13;
		public const int COMMA = 14;
		public const int LITERAL_library = 15;
		public const int LITERAL_coclass = 16;
		public const int LITERAL_uuid = 17;
		public const int LITERAL_version = 18;
		public const int LPAREN = 19;
		public const int RPAREN = 20;
		public const int LITERAL_async_uuid = 21;
		public const int LITERAL_local = 22;
		public const int LITERAL_object = 23;
		public const int LITERAL_pointer_default = 24;
		public const int LITERAL_endpoint = 25;
		public const int LITERAL_odl = 26;
		public const int LITERAL_optimize = 27;
		public const int LITERAL_proxy = 28;
		public const int LITERAL_aggregatable = 29;
		public const int LITERAL_appobject = 30;
		public const int LITERAL_bindable = 31;
		public const int LITERAL_control = 32;
		public const int LITERAL_custom = 33;
		public const int LITERAL_default = 34;
		public const int LITERAL_defaultbind = 35;
		public const int LITERAL_defaultcollelem = 36;
		public const int LITERAL_defaultvtable = 37;
		public const int LITERAL_displaybind = 38;
		public const int LITERAL_dllname = 39;
		public const int LITERAL_dual = 40;
		public const int LITERAL_entry = 41;
		public const int LITERAL_helpcontext = 42;
		public const int LITERAL_helpfile = 43;
		public const int LITERAL_helpstring = 44;
		public const int LITERAL_helpstringdll = 45;
		public const int LITERAL_hidden = 46;
		public const int LITERAL_id = 47;
		public const int LITERAL_idempotent = 48;
		public const int LITERAL_immediatebind = 49;
		public const int LITERAL_lcid = 50;
		public const int LITERAL_licensed = 51;
		public const int LITERAL_message = 52;
		public const int LITERAL_nonbrowsable = 53;
		public const int LITERAL_noncreatable = 54;
		public const int LITERAL_nonextensible = 55;
		public const int LITERAL_oleautomation = 56;
		public const int LITERAL_restricted = 57;
		public const int LITERAL_ref = 58;
		public const int LITERAL_ptr = 59;
		public const int LITERAL_function = 60;
		public const int LITERAL_scriptable = 61;
		public const int LITERAL_deprecated = 62;
		public const int LITERAL_Undefined = 63;
		public const int LITERAL_noscript = 64;
		public const int LITERAL_Null = 65;
		public const int LITERAL_nsid = 66;
		public const int LITERAL_domstring = 67;
		// "utf8string" = 68
		public const int LITERAL_cstring = 69;
		public const int LITERAL_astring = 70;
		public const int LITERAL_jsval = 71;
		public const int LITERAL_builtinclass = 72;
		public const int LITERAL_getter = 73;
		public const int LITERAL_setter = 74;
		public const int LITERAL_forward = 75;
		public const int LITERAL_importlib = 76;
		public const int LITERAL_interface = 77;
		public const int LITERAL_dispinterface = 78;
		public const int LITERAL_readonly = 79;
		public const int LITERAL_attribute = 80;
		public const int COLON = 81;
		public const int SCOPEOP = 82;
		public const int LITERAL_const = 83;
		public const int ASSIGN = 84;
		public const int STAR = 85;
		public const int OR = 86;
		public const int XOR = 87;
		public const int AND = 88;
		public const int LSHIFT = 89;
		public const int RSHIFT = 90;
		public const int PLUS = 91;
		public const int MINUS = 92;
		public const int DIV = 93;
		public const int MOD = 94;
		public const int TILDE = 95;
		public const int LITERAL_TRUE = 96;
		public const int LITERAL_true = 97;
		public const int LITERAL_FALSE = 98;
		public const int LITERAL_false = 99;
		public const int LITERAL_typedef = 100;
		public const int LITERAL_native = 101;
		public const int LITERAL_context_handle = 102;
		public const int LITERAL_handle = 103;
		public const int LITERAL_pipe = 104;
		public const int LITERAL_transmit_as = 105;
		public const int LITERAL_wire_marshal = 106;
		public const int LITERAL_represent_as = 107;
		public const int LITERAL_user_marshal = 108;
		public const int LITERAL_public = 109;
		public const int LITERAL_switch_type = 110;
		public const int LITERAL_signed = 111;
		public const int LITERAL_unsigned = 112;
		public const int LITERAL_octet = 113;
		public const int LITERAL_any = 114;
		public const int LITERAL_void = 115;
		public const int LITERAL_byte = 116;
		public const int LITERAL_wchar_t = 117;
		public const int LITERAL_handle_t = 118;
		public const int INT = 119;
		public const int HEX = 120;
		public const int LITERAL_unique = 121;
		public const int LITERAL_small = 122;
		public const int LITERAL_short = 123;
		public const int LITERAL_long = 124;
		public const int LITERAL_int = 125;
		public const int LITERAL_hyper = 126;
		public const int LITERAL_char = 127;
		public const int LITERAL_float = 128;
		public const int LITERAL_double = 129;
		public const int LITERAL_boolean = 130;
		public const int LITERAL_struct = 131;
		public const int LITERAL_union = 132;
		public const int LITERAL_switch = 133;
		public const int LITERAL_case = 134;
		public const int LITERAL_enum = 135;
		public const int LITERAL_sequence = 136;
		public const int LT_ = 137;
		public const int GT = 138;
		public const int LITERAL_string = 139;
		public const int RANGE = 140;
		public const int LITERAL_exception = 141;
		public const int LITERAL_callback = 142;
		public const int LITERAL_broadcast = 143;
		public const int LITERAL_ignore = 144;
		public const int LITERAL_notxpcom = 145;
		public const int LITERAL_nostdcall = 146;
		public const int LITERAL_propget = 147;
		public const int LITERAL_propput = 148;
		public const int LITERAL_propputref = 149;
		public const int LITERAL_uidefault = 150;
		public const int LITERAL_usesgetlasterror = 151;
		public const int LITERAL_vararg = 152;
		public const int LITERAL_optional_argc = 153;
		public const int LITERAL_implicit_jscontext = 154;
		public const int LITERAL_binaryname = 155;
		public const int LITERAL_raises = 156;
		public const int LITERAL_in = 157;
		public const int LITERAL_out = 158;
		public const int LITERAL_inout = 159;
		public const int LITERAL_retval = 160;
		public const int LITERAL_defaultvalue = 161;
		public const int LITERAL_optional = 162;
		public const int LITERAL_requestedit = 163;
		public const int LITERAL_iid_is = 164;
		public const int LITERAL_range = 165;
		public const int LITERAL_array = 166;
		public const int LITERAL_shared = 167;
		public const int LITERAL_size_is = 168;
		public const int LITERAL_max_is = 169;
		public const int LITERAL_length_is = 170;
		public const int LITERAL_first_is = 171;
		public const int LITERAL_last_is = 172;
		public const int LITERAL_switch_is = 173;
		public const int LITERAL_source = 174;
		public const int LITERAL_context = 175;
		public const int LITERAL_SAFEARRAY = 176;
		public const int OCTAL = 177;
		public const int LITERAL_L = 178;
		public const int STRING_LITERAL = 179;
		public const int CHAR_LITERAL = 180;
		public const int FLOAT = 181;
		public const int IDENT = 182;
		public const int LITERAL_cpp_quote = 183;
		public const int LITERAL_midl_pragma_warning = 184;
		public const int QUESTION = 185;
		public const int DOT = 186;
		public const int NOT = 187;
		public const int QUOTE = 188;
		public const int WS_ = 189;
		public const int PREPROC_DIRECTIVE = 190;
		public const int SL_COMMENT = 191;
		public const int OTHER_LANG_BLOCK = 192;
		public const int ML_COMMENT = 193;
		public const int ESC = 194;
		public const int VOCAB = 195;
		public const int DIGIT = 196;
		public const int OCTDIGIT = 197;
		public const int HEXDIGIT = 198;
		
	}
}
