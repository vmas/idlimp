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
		public const int UUID = 17;
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
		public const int ID = 47;
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
		public const int SCRIPTABLE = 61;
		public const int LITERAL_importlib = 62;
		public const int LITERAL_interface = 63;
		public const int LITERAL_dispinterface = 64;
		public const int LITERAL_readonly = 65;
		public const int LITERAL_attribute = 66;
		public const int COLON = 67;
		public const int SCOPEOP = 68;
		public const int LITERAL_const = 69;
		public const int ASSIGN = 70;
		public const int STAR = 71;
		public const int OR = 72;
		public const int XOR = 73;
		public const int AND = 74;
		public const int LSHIFT = 75;
		public const int RSHIFT = 76;
		public const int PLUS = 77;
		public const int MINUS = 78;
		public const int DIV = 79;
		public const int MOD = 80;
		public const int TILDE = 81;
		public const int LITERAL_TRUE = 82;
		public const int LITERAL_true = 83;
		public const int LITERAL_FALSE = 84;
		public const int LITERAL_false = 85;
		public const int LITERAL_typedef = 86;
		public const int LITERAL_native = 87;
		public const int LITERAL_context_handle = 88;
		public const int LITERAL_handle = 89;
		public const int LITERAL_pipe = 90;
		public const int LITERAL_transmit_as = 91;
		public const int LITERAL_wire_marshal = 92;
		public const int LITERAL_represent_as = 93;
		public const int LITERAL_user_marshal = 94;
		public const int LITERAL_public = 95;
		public const int LITERAL_switch_type = 96;
		public const int LITERAL_signed = 97;
		public const int LITERAL_unsigned = 98;
		public const int LITERAL_octet = 99;
		public const int LITERAL_any = 100;
		public const int LITERAL_void = 101;
		public const int LITERAL_byte = 102;
		public const int LITERAL_wchar_t = 103;
		public const int LITERAL_handle_t = 104;
		public const int INT = 105;
		public const int HEX = 106;
		public const int LITERAL_unique = 107;
		public const int PTR = 108;
		public const int LITERAL_small = 109;
		public const int LITERAL_short = 110;
		public const int LITERAL_long = 111;
		public const int LITERAL_int = 112;
		public const int LITERAL_hyper = 113;
		public const int LITERAL_char = 114;
		public const int LITERAL_float = 115;
		public const int LITERAL_double = 116;
		public const int LITERAL_boolean = 117;
		public const int LITERAL_struct = 118;
		public const int LITERAL_union = 119;
		public const int LITERAL_switch = 120;
		public const int LITERAL_case = 121;
		public const int LITERAL_enum = 122;
		public const int LITERAL_sequence = 123;
		public const int LT_ = 124;
		public const int GT = 125;
		public const int LITERAL_string = 126;
		public const int RANGE = 127;
		public const int LITERAL_exception = 128;
		public const int LITERAL_callback = 129;
		public const int LITERAL_broadcast = 130;
		public const int LITERAL_ignore = 131;
		public const int LITERAL_noscript = 132;
		public const int LITERAL_notxpcom = 133;
		public const int LITERAL_propget = 134;
		public const int LITERAL_propput = 135;
		public const int LITERAL_propputref = 136;
		public const int LITERAL_uidefault = 137;
		public const int LITERAL_usesgetlasterror = 138;
		public const int LITERAL_vararg = 139;
		public const int LITERAL_optional_argc = 140;
		public const int LITERAL_raises = 141;
		public const int LITERAL_in = 142;
		public const int LITERAL_out = 143;
		public const int LITERAL_inout = 144;
		public const int LITERAL_retval = 145;
		public const int LITERAL_defaultvalue = 146;
		public const int LITERAL_optional = 147;
		public const int LITERAL_requestedit = 148;
		public const int LITERAL_iid_is = 149;
		public const int LITERAL_range = 150;
		public const int LITERAL_array = 151;
		public const int LITERAL_size_is = 152;
		public const int LITERAL_max_is = 153;
		public const int LITERAL_length_is = 154;
		public const int LITERAL_first_is = 155;
		public const int LITERAL_last_is = 156;
		public const int LITERAL_switch_is = 157;
		public const int LITERAL_source = 158;
		public const int LITERAL_context = 159;
		public const int LITERAL_SAFEARRAY = 160;
		public const int OCTAL = 161;
		public const int LITERAL_L = 162;
		public const int STRING_LITERAL = 163;
		public const int CHAR_LITERAL = 164;
		public const int FLOAT = 165;
		public const int IDENT = 166;
		public const int LITERAL_cpp_quote = 167;
		public const int LITERAL_midl_pragma_warning = 168;
		public const int QUESTION = 169;
		public const int DOT = 170;
		public const int NOT = 171;
		public const int QUOTE = 172;
		public const int WS_ = 173;
		public const int PREPROC_DIRECTIVE = 174;
		public const int SL_COMMENT = 175;
		public const int OTHER_LANG_BLOCK = 176;
		public const int ML_COMMENT = 177;
		public const int ESC = 178;
		public const int VOCAB = 179;
		public const int DIGIT = 180;
		public const int OCTDIGIT = 181;
		public const int HEXDIGIT = 182;
		
	}
}
