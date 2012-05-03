// $ANTLR 2.7.7 (20060930): "idl.g" -> "IDLLexer.cs"$

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
	// Generate header specific to lexer CSharp file
	using System;
	using Stream                          = System.IO.Stream;
	using TextReader                      = System.IO.TextReader;
	using Hashtable                       = System.Collections.Hashtable;
	using Comparer                        = System.Collections.Comparer;
	
	using TokenStreamException            = antlr.TokenStreamException;
	using TokenStreamIOException          = antlr.TokenStreamIOException;
	using TokenStreamRecognitionException = antlr.TokenStreamRecognitionException;
	using CharStreamException             = antlr.CharStreamException;
	using CharStreamIOException           = antlr.CharStreamIOException;
	using ANTLRException                  = antlr.ANTLRException;
	using CharScanner                     = antlr.CharScanner;
	using InputBuffer                     = antlr.InputBuffer;
	using ByteBuffer                      = antlr.ByteBuffer;
	using CharBuffer                      = antlr.CharBuffer;
	using Token                           = antlr.Token;
	using IToken                          = antlr.IToken;
	using CommonToken                     = antlr.CommonToken;
	using SemanticException               = antlr.SemanticException;
	using RecognitionException            = antlr.RecognitionException;
	using NoViableAltForCharException     = antlr.NoViableAltForCharException;
	using MismatchedCharException         = antlr.MismatchedCharException;
	using TokenStream                     = antlr.TokenStream;
	using LexerSharedInputState           = antlr.LexerSharedInputState;
	using BitSet                          = antlr.collections.impl.BitSet;
	
	public 	class IDLLexer : antlr.CharScanner	, TokenStream
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
		
		public IDLLexer(Stream ins) : this(new ByteBuffer(ins))
		{
		}
		
		public IDLLexer(TextReader r) : this(new CharBuffer(r))
		{
		}
		
		public IDLLexer(InputBuffer ib)		 : this(new LexerSharedInputState(ib))
		{
		}
		
		public IDLLexer(LexerSharedInputState state) : base(state)
		{
			initialize();
		}
		private void initialize()
		{
			caseSensitiveLiterals = true;
			setCaseSensitive(true);
			literals = new Hashtable(100, (float) 0.4, null, Comparer.Default);
			literals.Add("local", 22);
			literals.Add("size_is", 168);
			literals.Add("optional", 162);
			literals.Add("proxy", 28);
			literals.Add("last_is", 172);
			literals.Add("nsid", 66);
			literals.Add("byte", 116);
			literals.Add("public", 109);
			literals.Add("represent_as", 107);
			literals.Add("case", 134);
			literals.Add("message", 52);
			literals.Add("short", 123);
			literals.Add("uidefault", 150);
			literals.Add("raises", 156);
			literals.Add("defaultbind", 35);
			literals.Add("object", 23);
			literals.Add("ignore", 144);
			literals.Add("readonly", 79);
			literals.Add("lcid", 50);
			literals.Add("propputref", 149);
			literals.Add("octet", 113);
			literals.Add("wire_marshal", 106);
			literals.Add("implicit_jscontext", 154);
			literals.Add("shared", 167);
			literals.Add("licensed", 51);
			literals.Add("module", 10);
			literals.Add("unsigned", 112);
			literals.Add("const", 83);
			literals.Add("float", 128);
			literals.Add("context_handle", 102);
			literals.Add("context", 175);
			literals.Add("length_is", 170);
			literals.Add("inout", 159);
			literals.Add("source", 174);
			literals.Add("retval", 160);
			literals.Add("defaultvalue", 161);
			literals.Add("ptr", 59);
			literals.Add("appobject", 30);
			literals.Add("first_is", 171);
			literals.Add("optional_argc", 153);
			literals.Add("noncreatable", 54);
			literals.Add("control", 32);
			literals.Add("handle", 103);
			literals.Add("Null", 65);
			literals.Add("optimize", 27);
			literals.Add("importlib", 76);
			literals.Add("small", 122);
			literals.Add("binaryname", 155);
			literals.Add("ref", 58);
			literals.Add("handle_t", 118);
			literals.Add("setter", 74);
			literals.Add("cstring", 69);
			literals.Add("cpp_quote", 183);
			literals.Add("notxpcom", 145);
			literals.Add("custom", 33);
			literals.Add("range", 165);
			literals.Add("function", 60);
			literals.Add("out", 158);
			literals.Add("callback", 142);
			literals.Add("library", 15);
			literals.Add("displaybind", 38);
			literals.Add("native", 101);
			literals.Add("iid_is", 164);
			literals.Add("hyper", 126);
			literals.Add("L", 178);
			literals.Add("deprecated", 62);
			literals.Add("entry", 41);
			literals.Add("FALSE", 98);
			literals.Add("usesgetlasterror", 151);
			literals.Add("oleautomation", 56);
			literals.Add("jsval", 71);
			literals.Add("propput", 148);
			literals.Add("version", 18);
			literals.Add("typedef", 100);
			literals.Add("nonbrowsable", 53);
			literals.Add("interface", 77);
			literals.Add("sequence", 136);
			literals.Add("uuid", 17);
			literals.Add("array", 166);
			literals.Add("switch_type", 110);
			literals.Add("pointer_default", 24);
			literals.Add("broadcast", 143);
			literals.Add("immediatebind", 49);
			literals.Add("coclass", 16);
			literals.Add("aggregatable", 29);
			literals.Add("midl_pragma_warning", 184);
			literals.Add("dispinterface", 78);
			literals.Add("any", 114);
			literals.Add("double", 129);
			literals.Add("SAFEARRAY", 176);
			literals.Add("utf8string", 68);
			literals.Add("nonextensible", 55);
			literals.Add("noscript", 64);
			literals.Add("Undefined", 63);
			literals.Add("union", 132);
			literals.Add("getter", 73);
			literals.Add("__int3264", 5);
			literals.Add("enum", 135);
			literals.Add("pipe", 104);
			literals.Add("propget", 147);
			literals.Add("int", 125);
			literals.Add("exception", 141);
			literals.Add("switch_is", 173);
			literals.Add("boolean", 130);
			literals.Add("max_is", 169);
			literals.Add("requestedit", 163);
			literals.Add("char", 127);
			literals.Add("astring", 70);
			literals.Add("defaultvtable", 37);
			literals.Add("string", 139);
			literals.Add("default", 34);
			literals.Add("odl", 26);
			literals.Add("id", 47);
			literals.Add("dual", 40);
			literals.Add("helpstringdll", 45);
			literals.Add("builtinclass", 72);
			literals.Add("false", 99);
			literals.Add("nostdcall", 146);
			literals.Add("user_marshal", 108);
			literals.Add("restricted", 57);
			literals.Add("helpfile", 43);
			literals.Add("bindable", 31);
			literals.Add("dllname", 39);
			literals.Add("attribute", 80);
			literals.Add("v1_enum", 4);
			literals.Add("async_uuid", 21);
			literals.Add("struct", 131);
			literals.Add("__int64", 6);
			literals.Add("helpcontext", 42);
			literals.Add("forward", 75);
			literals.Add("signed", 111);
			literals.Add("import", 13);
			literals.Add("endpoint", 25);
			literals.Add("in", 157);
			literals.Add("TRUE", 96);
			literals.Add("void", 115);
			literals.Add("wchar_t", 117);
			literals.Add("transmit_as", 105);
			literals.Add("switch", 133);
			literals.Add("defaultcollelem", 36);
			literals.Add("helpstring", 44);
			literals.Add("true", 97);
			literals.Add("long", 124);
			literals.Add("hidden", 46);
			literals.Add("scriptable", 61);
			literals.Add("unique", 121);
			literals.Add("domstring", 67);
			literals.Add("idempotent", 48);
			literals.Add("vararg", 152);
		}
		
		override public IToken nextToken()			//throws TokenStreamException
		{
			IToken theRetToken = null;
tryAgain:
			for (;;)
			{
				IToken _token = null;
				int _ttype = Token.INVALID_TYPE;
				resetText();
				try     // for char stream error handling
				{
					try     // for lexical error handling
					{
						switch ( cached_LA1 )
						{
						case ';':
						{
							mSEMI(true);
							theRetToken = returnToken_;
							break;
						}
						case '?':
						{
							mQUESTION(true);
							theRetToken = returnToken_;
							break;
						}
						case '(':
						{
							mLPAREN(true);
							theRetToken = returnToken_;
							break;
						}
						case ')':
						{
							mRPAREN(true);
							theRetToken = returnToken_;
							break;
						}
						case '[':
						{
							mLBRACKET(true);
							theRetToken = returnToken_;
							break;
						}
						case ']':
						{
							mRBRACKET(true);
							theRetToken = returnToken_;
							break;
						}
						case '{':
						{
							mLBRACE(true);
							theRetToken = returnToken_;
							break;
						}
						case '}':
						{
							mRBRACE(true);
							theRetToken = returnToken_;
							break;
						}
						case '|':
						{
							mOR(true);
							theRetToken = returnToken_;
							break;
						}
						case '^':
						{
							mXOR(true);
							theRetToken = returnToken_;
							break;
						}
						case '&':
						{
							mAND(true);
							theRetToken = returnToken_;
							break;
						}
						case ',':
						{
							mCOMMA(true);
							theRetToken = returnToken_;
							break;
						}
						case '=':
						{
							mASSIGN(true);
							theRetToken = returnToken_;
							break;
						}
						case '!':
						{
							mNOT(true);
							theRetToken = returnToken_;
							break;
						}
						case '+':
						{
							mPLUS(true);
							theRetToken = returnToken_;
							break;
						}
						case '-':
						{
							mMINUS(true);
							theRetToken = returnToken_;
							break;
						}
						case '~':
						{
							mTILDE(true);
							theRetToken = returnToken_;
							break;
						}
						case '*':
						{
							mSTAR(true);
							theRetToken = returnToken_;
							break;
						}
						case '\t':  case '\n':  case '\r':  case ' ':
						{
							mWS_(true);
							theRetToken = returnToken_;
							break;
						}
						case '#':
						{
							mPREPROC_DIRECTIVE(true);
							theRetToken = returnToken_;
							break;
						}
						case '\'':
						{
							mCHAR_LITERAL(true);
							theRetToken = returnToken_;
							break;
						}
						case 'A':  case 'B':  case 'C':  case 'D':
						case 'E':  case 'F':  case 'G':  case 'H':
						case 'I':  case 'J':  case 'K':  case 'L':
						case 'M':  case 'N':  case 'O':  case 'P':
						case 'Q':  case 'R':  case 'S':  case 'T':
						case 'U':  case 'V':  case 'W':  case 'X':
						case 'Y':  case 'Z':  case '_':  case 'a':
						case 'b':  case 'c':  case 'd':  case 'e':
						case 'f':  case 'g':  case 'h':  case 'i':
						case 'j':  case 'k':  case 'l':  case 'm':
						case 'n':  case 'o':  case 'p':  case 'q':
						case 'r':  case 's':  case 't':  case 'u':
						case 'v':  case 'w':  case 'x':  case 'y':
						case 'z':
						{
							mIDENT(true);
							theRetToken = returnToken_;
							break;
						}
						default:
							if ((cached_LA1=='.') && (cached_LA2=='.'))
							{
								mRANGE(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='<') && (cached_LA2=='<')) {
								mLSHIFT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='>') && (cached_LA2=='>')) {
								mRSHIFT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1==':') && (cached_LA2==':')) {
								mSCOPEOP(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='/') && (cached_LA2=='/')) {
								mSL_COMMENT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='%') && (cached_LA2=='{')) {
								mOTHER_LANG_BLOCK(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='/') && (cached_LA2=='*')) {
								mML_COMMENT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='"') && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff'))) {
								mSTRING_LITERAL(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='0') && (cached_LA2=='X'||cached_LA2=='x')) {
								mHEX(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='.') && ((cached_LA2 >= '0' && cached_LA2 <= '9'))) {
								mFLOAT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1==':') && (true)) {
								mCOLON(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='.') && (true)) {
								mDOT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='<') && (true)) {
								mLT_(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='>') && (true)) {
								mGT(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='/') && (true)) {
								mDIV(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='%') && (true)) {
								mMOD(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='"') && (true)) {
								mQUOTE(true);
								theRetToken = returnToken_;
							}
							else if (((cached_LA1 >= '0' && cached_LA1 <= '9')) && (true)) {
								mINT(true);
								theRetToken = returnToken_;
							}
						else
						{
							if (cached_LA1==EOF_CHAR) { uponEOF(); returnToken_ = makeToken(Token.EOF_TYPE); }
				else {throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());}
						}
						break; }
						if ( null==returnToken_ ) goto tryAgain; // found SKIP token
						_ttype = returnToken_.Type;
						_ttype = testLiteralsTable(_ttype);
						returnToken_.Type = _ttype;
						return returnToken_;
					}
					catch (RecognitionException e) {
							throw new TokenStreamRecognitionException(e);
					}
				}
				catch (CharStreamException cse) {
					if ( cse is CharStreamIOException ) {
						throw new TokenStreamIOException(((CharStreamIOException)cse).io);
					}
					else {
						throw new TokenStreamException(cse.Message);
					}
				}
			}
		}
		
	public void mSEMI(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SEMI;
		
		match(';');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mQUESTION(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = QUESTION;
		
		match('?');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLPAREN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LPAREN;
		
		match('(');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRPAREN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RPAREN;
		
		match(')');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLBRACKET(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LBRACKET;
		
		match('[');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRBRACKET(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RBRACKET;
		
		match(']');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLBRACE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LBRACE;
		
		match('{');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRBRACE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RBRACE;
		
		match('}');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OR;
		
		match('|');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mXOR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = XOR;
		
		match('^');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mAND(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = AND;
		
		match('&');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOLON(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COLON;
		
		match(':');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOMMA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COMMA;
		
		match(',');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDOT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DOT;
		
		match('.');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRANGE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RANGE;
		
		match("..");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mASSIGN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = ASSIGN;
		
		match('=');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mNOT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = NOT;
		
		match('!');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLT_(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LT_;
		
		match('<');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLSHIFT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LSHIFT;
		
		match("<<");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mGT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = GT;
		
		match('>');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRSHIFT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RSHIFT;
		
		match(">>");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDIV(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DIV;
		
		match('/');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPLUS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PLUS;
		
		match('+');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mMINUS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = MINUS;
		
		match('-');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mTILDE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = TILDE;
		
		match('~');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSTAR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = STAR;
		
		match('*');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mMOD(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = MOD;
		
		match('%');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSCOPEOP(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SCOPEOP;
		
		match("::");
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mQUOTE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = QUOTE;
		
		match('"');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mWS_(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = WS_;
		
		{
			switch ( cached_LA1 )
			{
			case ' ':
			{
				match(' ');
				break;
			}
			case '\t':
			{
				match('\t');
				break;
			}
			case '\n':
			{
				match('\n');
				newline();
				break;
			}
			case '\r':
			{
				match('\r');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		_ttype = Token.SKIP;
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPREPROC_DIRECTIVE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PREPROC_DIRECTIVE;
		
		match('#');
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_0_.member(cached_LA1)))
				{
					matchNot('\n');
				}
				else
				{
					goto _loop318_breakloop;
				}
				
			}
_loop318_breakloop:			;
		}    // ( ... )*
		match('\n');
		newline(); _ttype = Token.SKIP;
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSL_COMMENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SL_COMMENT;
		
		match("//");
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_0_.member(cached_LA1)))
				{
					matchNot('\n');
				}
				else
				{
					goto _loop321_breakloop;
				}
				
			}
_loop321_breakloop:			;
		}    // ( ... )*
		match('\n');
		_ttype = Token.SKIP; CommentSnatcher.StoreComment(text.ToString(_begin, text.Length-_begin), false); newline();
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mOTHER_LANG_BLOCK(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OTHER_LANG_BLOCK;
		
		match("%{");
		{    // ( ... )*
			for (;;)
			{
				if ((cached_LA1=='%') && (tokenSet_1_.member(cached_LA2)))
				{
					match('%');
					matchNot('}');
				}
				else if ((cached_LA1=='\n')) {
					match('\n');
					newline();
				}
				else if ((tokenSet_2_.member(cached_LA1))) {
					matchNot('%');
				}
				else
				{
					goto _loop324_breakloop;
				}
				
			}
_loop324_breakloop:			;
		}    // ( ... )*
		match("%}");
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_0_.member(cached_LA1)))
				{
					matchNot('\n');
				}
				else
				{
					goto _loop326_breakloop;
				}
				
			}
_loop326_breakloop:			;
		}    // ( ... )*
		_ttype = Token.SKIP;
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mML_COMMENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = ML_COMMENT;
		
		match("/*");
		{    // ( ... )*
			for (;;)
			{
				if ((cached_LA1=='\r') && (cached_LA2=='\n') && ((LA(3) >= '\u0000' && LA(3) <= '\u00ff')) && ((LA(4) >= '\u0000' && LA(4) <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true))
				{
					match('\r');
					match('\n');
					newline();
				}
				else if (((cached_LA1=='*') && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')) && ((LA(3) >= '\u0000' && LA(3) <= '\u00ff')))&&( LA(2)!='/' )) {
					match('*');
				}
				else if ((cached_LA1=='\r') && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')) && ((LA(3) >= '\u0000' && LA(3) <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true)) {
					match('\r');
					newline();
				}
				else if ((cached_LA1=='\n')) {
					match('\n');
					newline();
				}
				else if ((tokenSet_3_.member(cached_LA1))) {
					{
						match(tokenSet_3_);
					}
				}
				else
				{
					goto _loop330_breakloop;
				}
				
			}
_loop330_breakloop:			;
		}    // ( ... )*
		match("*/");
		_ttype = Token.SKIP; CommentSnatcher.StoreComment(text.ToString(_begin, text.Length-_begin), true);
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCHAR_LITERAL(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = CHAR_LITERAL;
		
		match('\'');
		{
			if ((cached_LA1=='\\'))
			{
				mESC(false);
			}
			else if ((tokenSet_4_.member(cached_LA1))) {
				matchNot('\'');
			}
			else
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			
		}
		match('\'');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mESC(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = ESC;
		
		match('\\');
		{
			switch ( cached_LA1 )
			{
			case 'n':
			{
				match('n');
				break;
			}
			case 't':
			{
				match('t');
				break;
			}
			case 'v':
			{
				match('v');
				break;
			}
			case 'b':
			{
				match('b');
				break;
			}
			case 'r':
			{
				match('r');
				break;
			}
			case 'f':
			{
				match('f');
				break;
			}
			case 'a':
			{
				match('a');
				break;
			}
			case '\\':
			{
				match('\\');
				break;
			}
			case '?':
			{
				match('?');
				break;
			}
			case '\'':
			{
				match('\'');
				break;
			}
			case '"':
			{
				match('"');
				break;
			}
			case '0':  case '1':  case '2':  case '3':
			{
				{
					switch ( cached_LA1 )
					{
					case '0':
					{
						match('0');
						break;
					}
					case '1':
					{
						match('1');
						break;
					}
					case '2':
					{
						match('2');
						break;
					}
					case '3':
					{
						match('3');
						break;
					}
					default:
					{
						throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
					}
					 }
				}
				{
					if (((cached_LA1 >= '0' && cached_LA1 <= '7')) && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true))
					{
						mOCTDIGIT(false);
						{
							if (((cached_LA1 >= '0' && cached_LA1 <= '7')) && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true))
							{
								mOCTDIGIT(false);
							}
							else if (((cached_LA1 >= '\u0000' && cached_LA1 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true)) {
							}
							else
							{
								throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
							}
							
						}
					}
					else if (((cached_LA1 >= '\u0000' && cached_LA1 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true)) {
					}
					else
					{
						throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
					}
					
				}
				break;
			}
			case 'x':
			{
				match('x');
				mHEXDIGIT(false);
				{
					if ((tokenSet_5_.member(cached_LA1)) && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true))
					{
						mHEXDIGIT(false);
					}
					else if (((cached_LA1 >= '\u0000' && cached_LA1 <= '\u00ff')) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true) && (true)) {
					}
					else
					{
						throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
					}
					
				}
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSTRING_LITERAL(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = STRING_LITERAL;
		
		int _saveIndex = 0;
		_saveIndex = text.Length;
		match('"');
		text.Length = _saveIndex;
		{    // ( ... )*
			for (;;)
			{
				if ((cached_LA1=='\\'))
				{
					mESC(false);
				}
				else if ((tokenSet_6_.member(cached_LA1))) {
					matchNot('"');
				}
				else
				{
					goto _loop335_breakloop;
				}
				
			}
_loop335_breakloop:			;
		}    // ( ... )*
		_saveIndex = text.Length;
		match('"');
		text.Length = _saveIndex;
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mOCTDIGIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = OCTDIGIT;
		
		matchRange('0','7');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mHEXDIGIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = HEXDIGIT;
		
		{
			switch ( cached_LA1 )
			{
			case '0':  case '1':  case '2':  case '3':
			case '4':  case '5':  case '6':  case '7':
			case '8':  case '9':
			{
				matchRange('0','9');
				break;
			}
			case 'a':  case 'b':  case 'c':  case 'd':
			case 'e':  case 'f':
			{
				matchRange('a','f');
				break;
			}
			case 'A':  case 'B':  case 'C':  case 'D':
			case 'E':  case 'F':
			{
				matchRange('A','F');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mVOCAB(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = VOCAB;
		
		matchRange('\x3','\xff');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mDIGIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DIGIT;
		
		matchRange('0','9');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mHEX(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = HEX;
		
		{
			if ((cached_LA1=='0') && (cached_LA2=='x'))
			{
				match("0x");
			}
			else if ((cached_LA1=='0') && (cached_LA2=='X')) {
				match("0X");
			}
			else
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			
		}
		{ // ( ... )+
			int _cnt350=0;
			for (;;)
			{
				if ((tokenSet_5_.member(cached_LA1)))
				{
					mHEXDIGIT(false);
				}
				else
				{
					if (_cnt350 >= 1) { goto _loop350_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt350++;
			}
_loop350_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mINT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = INT;
		
		{ // ( ... )+
			int _cnt353=0;
			for (;;)
			{
				if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
				{
					mDIGIT(false);
				}
				else
				{
					if (_cnt353 >= 1) { goto _loop353_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt353++;
			}
_loop353_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mFLOAT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = FLOAT;
		
		match('.');
		{ // ( ... )+
			int _cnt356=0;
			for (;;)
			{
				if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
				{
					mDIGIT(false);
				}
				else
				{
					if (_cnt356 >= 1) { goto _loop356_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt356++;
			}
_loop356_breakloop:			;
		}    // ( ... )+
		{
			if ((cached_LA1=='E'||cached_LA1=='e'))
			{
				{
					switch ( cached_LA1 )
					{
					case 'e':
					{
						match('e');
						break;
					}
					case 'E':
					{
						match('E');
						break;
					}
					default:
					{
						throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
					}
					 }
				}
				{
					switch ( cached_LA1 )
					{
					case '+':
					{
						match('+');
						break;
					}
					case '-':
					{
						match('-');
						break;
					}
					case '0':  case '1':  case '2':  case '3':
					case '4':  case '5':  case '6':  case '7':
					case '8':  case '9':
					{
						break;
					}
					default:
					{
						throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
					}
					 }
				}
				{ // ( ... )+
					int _cnt361=0;
					for (;;)
					{
						if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
						{
							mDIGIT(false);
						}
						else
						{
							if (_cnt361 >= 1) { goto _loop361_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
						}
						
						_cnt361++;
					}
_loop361_breakloop:					;
				}    // ( ... )+
			}
			else {
			}
			
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mIDENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = IDENT;
		
		{
			switch ( cached_LA1 )
			{
			case 'a':  case 'b':  case 'c':  case 'd':
			case 'e':  case 'f':  case 'g':  case 'h':
			case 'i':  case 'j':  case 'k':  case 'l':
			case 'm':  case 'n':  case 'o':  case 'p':
			case 'q':  case 'r':  case 's':  case 't':
			case 'u':  case 'v':  case 'w':  case 'x':
			case 'y':  case 'z':
			{
				matchRange('a','z');
				break;
			}
			case 'A':  case 'B':  case 'C':  case 'D':
			case 'E':  case 'F':  case 'G':  case 'H':
			case 'I':  case 'J':  case 'K':  case 'L':
			case 'M':  case 'N':  case 'O':  case 'P':
			case 'Q':  case 'R':  case 'S':  case 'T':
			case 'U':  case 'V':  case 'W':  case 'X':
			case 'Y':  case 'Z':
			{
				matchRange('A','Z');
				break;
			}
			case '_':
			{
				match('_');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		{    // ( ... )*
			for (;;)
			{
				switch ( cached_LA1 )
				{
				case 'a':  case 'b':  case 'c':  case 'd':
				case 'e':  case 'f':  case 'g':  case 'h':
				case 'i':  case 'j':  case 'k':  case 'l':
				case 'm':  case 'n':  case 'o':  case 'p':
				case 'q':  case 'r':  case 's':  case 't':
				case 'u':  case 'v':  case 'w':  case 'x':
				case 'y':  case 'z':
				{
					matchRange('a','z');
					break;
				}
				case 'A':  case 'B':  case 'C':  case 'D':
				case 'E':  case 'F':  case 'G':  case 'H':
				case 'I':  case 'J':  case 'K':  case 'L':
				case 'M':  case 'N':  case 'O':  case 'P':
				case 'Q':  case 'R':  case 'S':  case 'T':
				case 'U':  case 'V':  case 'W':  case 'X':
				case 'Y':  case 'Z':
				{
					matchRange('A','Z');
					break;
				}
				case '_':
				{
					match('_');
					break;
				}
				case '0':  case '1':  case '2':  case '3':
				case '4':  case '5':  case '6':  case '7':
				case '8':  case '9':
				{
					matchRange('0','9');
					break;
				}
				default:
				{
					goto _loop365_breakloop;
				}
				 }
			}
_loop365_breakloop:			;
		}    // ( ... )*
		_ttype = testLiteralsTable(_ttype);
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = new long[8];
		data[0]=-1025L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = new long[8];
		data[0]=-1L;
		data[1]=-2305843009213693953L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = new long[8];
		data[0]=-137438954497L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = new long[8];
		data[0]=-4398046520321L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = new long[8];
		data[0]=-549755813889L;
		data[1]=-268435457L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = { 287948901175001088L, 541165879422L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = new long[8];
		data[0]=-17179869185L;
		data[1]=-268435457L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	
}
}
