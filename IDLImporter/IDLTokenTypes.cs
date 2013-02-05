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
		public const int LITERAL_dictionary = 8;
		public const int COLON = 9;
		public const int LBRACE = 10;
		public const int RBRACE = 11;
		public const int LBRACKET = 12;
		public const int RBRACKET = 13;
		public const int LITERAL_module = 14;
		public const int LITERAL_import = 15;
		public const int COMMA = 16;
		public const int LITERAL_library = 17;
		public const int LITERAL_coclass = 18;
		public const int LITERAL_uuid = 19;
		public const int LITERAL_version = 20;
		public const int LPAREN = 21;
		public const int RPAREN = 22;
		public const int LITERAL_async_uuid = 23;
		public const int LITERAL_local = 24;
		public const int LITERAL_object = 25;
		public const int LITERAL_pointer_default = 26;
		public const int LITERAL_endpoint = 27;
		public const int LITERAL_odl = 28;
		public const int LITERAL_optimize = 29;
		public const int LITERAL_proxy = 30;
		public const int LITERAL_aggregatable = 31;
		public const int LITERAL_appobject = 32;
		public const int LITERAL_bindable = 33;
		public const int LITERAL_control = 34;
		public const int LITERAL_custom = 35;
		public const int LITERAL_default = 36;
		public const int LITERAL_defaultbind = 37;
		public const int LITERAL_defaultcollelem = 38;
		public const int LITERAL_defaultvtable = 39;
		public const int LITERAL_displaybind = 40;
		public const int LITERAL_dllname = 41;
		public const int LITERAL_dual = 42;
		public const int LITERAL_entry = 43;
		public const int LITERAL_helpcontext = 44;
		public const int LITERAL_helpfile = 45;
		public const int LITERAL_helpstring = 46;
		public const int LITERAL_helpstringdll = 47;
		public const int LITERAL_hidden = 48;
		public const int LITERAL_id = 49;
		public const int LITERAL_idempotent = 50;
		public const int LITERAL_immediatebind = 51;
		public const int LITERAL_lcid = 52;
		public const int LITERAL_licensed = 53;
		public const int LITERAL_message = 54;
		public const int LITERAL_nonbrowsable = 55;
		public const int LITERAL_noncreatable = 56;
		public const int LITERAL_nonextensible = 57;
		public const int LITERAL_oleautomation = 58;
		public const int LITERAL_restricted = 59;
		public const int LITERAL_ref = 60;
		public const int LITERAL_ptr = 61;
		public const int LITERAL_function = 62;
		public const int LITERAL_scriptable = 63;
		public const int LITERAL_deprecated = 64;
		public const int LITERAL_Undefined = 65;
		public const int LITERAL_noscript = 66;
		public const int LITERAL_Null = 67;
		public const int LITERAL_nsid = 68;
		public const int LITERAL_domstring = 69;
		// "utf8string" = 70
		public const int LITERAL_cstring = 71;
		public const int LITERAL_astring = 72;
		public const int LITERAL_jsval = 73;
		public const int LITERAL_builtinclass = 74;
		public const int LITERAL_getter = 75;
		public const int LITERAL_stringifier = 76;
		public const int LITERAL_setter = 77;
		public const int LITERAL_forward = 78;
		public const int LITERAL_importlib = 79;
		public const int QUESTION = 80;
		public const int ASSIGN = 81;
		public const int LITERAL_interface = 82;
		public const int LITERAL_dispinterface = 83;
		public const int LITERAL_readonly = 84;
		public const int LITERAL_attribute = 85;
		public const int SCOPEOP = 86;
		public const int LITERAL_const = 87;
		public const int STAR = 88;
		public const int OR = 89;
		public const int XOR = 90;
		public const int AND = 91;
		public const int LSHIFT = 92;
		public const int RSHIFT = 93;
		public const int PLUS = 94;
		public const int MINUS = 95;
		public const int DIV = 96;
		public const int MOD = 97;
		public const int TILDE = 98;
		public const int LITERAL_TRUE = 99;
		public const int LITERAL_true = 100;
		public const int LITERAL_FALSE = 101;
		public const int LITERAL_false = 102;
		public const int LITERAL_typedef = 103;
		public const int LITERAL_native = 104;
		public const int LITERAL_context_handle = 105;
		public const int LITERAL_handle = 106;
		public const int LITERAL_pipe = 107;
		public const int LITERAL_transmit_as = 108;
		public const int LITERAL_wire_marshal = 109;
		public const int LITERAL_represent_as = 110;
		public const int LITERAL_user_marshal = 111;
		public const int LITERAL_public = 112;
		public const int LITERAL_switch_type = 113;
		public const int LITERAL_signed = 114;
		public const int LITERAL_unsigned = 115;
		public const int LITERAL_octet = 116;
		public const int LITERAL_any = 117;
		public const int LITERAL_void = 118;
		public const int LITERAL_byte = 119;
		public const int LITERAL_wchar_t = 120;
		public const int LITERAL_handle_t = 121;
		public const int INT = 122;
		public const int HEX = 123;
		public const int LITERAL_unique = 124;
		public const int LITERAL_small = 125;
		public const int LITERAL_short = 126;
		public const int LITERAL_long = 127;
		public const int LITERAL_int = 128;
		public const int LITERAL_hyper = 129;
		public const int LITERAL_char = 130;
		public const int LITERAL_float = 131;
		public const int LITERAL_double = 132;
		public const int LITERAL_boolean = 133;
		public const int LITERAL_struct = 134;
		public const int LITERAL_union = 135;
		public const int LITERAL_switch = 136;
		public const int LITERAL_case = 137;
		public const int LITERAL_enum = 138;
		public const int LITERAL_sequence = 139;
		public const int LT_ = 140;
		public const int GT = 141;
		public const int LITERAL_string = 142;
		public const int RANGE = 143;
		public const int LITERAL_exception = 144;
		public const int LITERAL_callback = 145;
		public const int LITERAL_broadcast = 146;
		public const int LITERAL_ignore = 147;
		public const int LITERAL_notxpcom = 148;
		public const int LITERAL_nostdcall = 149;
		public const int LITERAL_propget = 150;
		public const int LITERAL_propput = 151;
		public const int LITERAL_propputref = 152;
		public const int LITERAL_uidefault = 153;
		public const int LITERAL_usesgetlasterror = 154;
		public const int LITERAL_vararg = 155;
		public const int LITERAL_optional_argc = 156;
		public const int LITERAL_implicit_jscontext = 157;
		public const int LITERAL_binaryname = 158;
		public const int LITERAL_infallible = 159;
		public const int LITERAL_raises = 160;
		public const int LITERAL_in = 161;
		public const int LITERAL_out = 162;
		public const int LITERAL_inout = 163;
		public const int LITERAL_retval = 164;
		public const int LITERAL_defaultvalue = 165;
		public const int LITERAL_optional = 166;
		public const int LITERAL_requestedit = 167;
		public const int LITERAL_iid_is = 168;
		public const int LITERAL_range = 169;
		public const int LITERAL_array = 170;
		public const int LITERAL_shared = 171;
		public const int LITERAL_size_is = 172;
		public const int LITERAL_max_is = 173;
		public const int LITERAL_length_is = 174;
		public const int LITERAL_first_is = 175;
		public const int LITERAL_last_is = 176;
		public const int LITERAL_switch_is = 177;
		public const int LITERAL_source = 178;
		public const int LITERAL_context = 179;
		public const int LITERAL_SAFEARRAY = 180;
		public const int OCTAL = 181;
		public const int LITERAL_L = 182;
		public const int STRING_LITERAL = 183;
		public const int CHAR_LITERAL = 184;
		public const int FLOAT = 185;
		public const int IDENT = 186;
		public const int LITERAL_cpp_quote = 187;
		public const int LITERAL_midl_pragma_warning = 188;
		public const int DOT = 189;
		public const int NOT = 190;
		public const int QUOTE = 191;
		public const int WS_ = 192;
		public const int PREPROC_DIRECTIVE = 193;
		public const int SL_COMMENT = 194;
		public const int OTHER_LANG_BLOCK = 195;
		public const int ML_COMMENT = 196;
		public const int ESC = 197;
		public const int VOCAB = 198;
		public const int DIGIT = 199;
		public const int OCTDIGIT = 200;
		public const int HEXDIGIT = 201;
		
	}
}
