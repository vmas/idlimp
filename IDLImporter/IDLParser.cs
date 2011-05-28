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
	// Generate the header common to all output files.
	using System;
	
	using TokenBuffer              = antlr.TokenBuffer;
	using TokenStreamException     = antlr.TokenStreamException;
	using TokenStreamIOException   = antlr.TokenStreamIOException;
	using ANTLRException           = antlr.ANTLRException;
	using LLkParser = antlr.LLkParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using TokenStream              = antlr.TokenStream;
	using RecognitionException     = antlr.RecognitionException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using ParserSharedInputState   = antlr.ParserSharedInputState;
	using BitSet                   = antlr.collections.impl.BitSet;
	using AST                      = antlr.collections.AST;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
/**
 *  This is a complete parser for the IDL language as defined
 *  by the CORBA 2.0 specification.  It will allow those who
 *  need an IDL parser to get up-and-running very quickly.
 *  Though IDL's syntax is very similar to C++, it is also
 *  much simpler, due in large part to the fact that it is
 *  a declarative-only language.
 *  
 *  Some things that are not included are: Symbol table construction
 *  (it is not necessary for parsing, btw) and preprocessing (for
 *  IDL compiler #pragma directives). You can use just about any
 *  C or C++ preprocessor, but there is an interesting semantic
 *  issue if you are going to generate code: In C, #include is
 *  a literal include, in IDL, #include is more like Java's import:
 *  It adds definitions to the scope of the parse, but included
 *  definitions are not generated.
 *
 *  Jim Coker, jcoker@magelang.com
 */
	public 	class IDLParser : antlr.LLkParser
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
		public const int LITERAL_importlib = 72;
		public const int LITERAL_interface = 73;
		public const int LITERAL_dispinterface = 74;
		public const int LITERAL_readonly = 75;
		public const int LITERAL_attribute = 76;
		public const int COLON = 77;
		public const int SCOPEOP = 78;
		public const int LITERAL_const = 79;
		public const int ASSIGN = 80;
		public const int STAR = 81;
		public const int OR = 82;
		public const int XOR = 83;
		public const int AND = 84;
		public const int LSHIFT = 85;
		public const int RSHIFT = 86;
		public const int PLUS = 87;
		public const int MINUS = 88;
		public const int DIV = 89;
		public const int MOD = 90;
		public const int TILDE = 91;
		public const int LITERAL_TRUE = 92;
		public const int LITERAL_true = 93;
		public const int LITERAL_FALSE = 94;
		public const int LITERAL_false = 95;
		public const int LITERAL_typedef = 96;
		public const int LITERAL_native = 97;
		public const int LITERAL_context_handle = 98;
		public const int LITERAL_handle = 99;
		public const int LITERAL_pipe = 100;
		public const int LITERAL_transmit_as = 101;
		public const int LITERAL_wire_marshal = 102;
		public const int LITERAL_represent_as = 103;
		public const int LITERAL_user_marshal = 104;
		public const int LITERAL_public = 105;
		public const int LITERAL_switch_type = 106;
		public const int LITERAL_signed = 107;
		public const int LITERAL_unsigned = 108;
		public const int LITERAL_octet = 109;
		public const int LITERAL_any = 110;
		public const int LITERAL_void = 111;
		public const int LITERAL_byte = 112;
		public const int LITERAL_wchar_t = 113;
		public const int LITERAL_handle_t = 114;
		public const int INT = 115;
		public const int HEX = 116;
		public const int LITERAL_unique = 117;
		public const int LITERAL_small = 118;
		public const int LITERAL_short = 119;
		public const int LITERAL_long = 120;
		public const int LITERAL_int = 121;
		public const int LITERAL_hyper = 122;
		public const int LITERAL_char = 123;
		public const int LITERAL_float = 124;
		public const int LITERAL_double = 125;
		public const int LITERAL_boolean = 126;
		public const int LITERAL_struct = 127;
		public const int LITERAL_union = 128;
		public const int LITERAL_switch = 129;
		public const int LITERAL_case = 130;
		public const int LITERAL_enum = 131;
		public const int LITERAL_sequence = 132;
		public const int LT_ = 133;
		public const int GT = 134;
		public const int LITERAL_string = 135;
		public const int RANGE = 136;
		public const int LITERAL_exception = 137;
		public const int LITERAL_callback = 138;
		public const int LITERAL_broadcast = 139;
		public const int LITERAL_ignore = 140;
		public const int LITERAL_notxpcom = 141;
		public const int LITERAL_propget = 142;
		public const int LITERAL_propput = 143;
		public const int LITERAL_propputref = 144;
		public const int LITERAL_uidefault = 145;
		public const int LITERAL_usesgetlasterror = 146;
		public const int LITERAL_vararg = 147;
		public const int LITERAL_optional_argc = 148;
		public const int LITERAL_implicit_jscontext = 149;
		public const int LITERAL_binaryname = 150;
		public const int LITERAL_raises = 151;
		public const int LITERAL_in = 152;
		public const int LITERAL_out = 153;
		public const int LITERAL_inout = 154;
		public const int LITERAL_retval = 155;
		public const int LITERAL_defaultvalue = 156;
		public const int LITERAL_optional = 157;
		public const int LITERAL_requestedit = 158;
		public const int LITERAL_iid_is = 159;
		public const int LITERAL_range = 160;
		public const int LITERAL_array = 161;
		public const int LITERAL_shared = 162;
		public const int LITERAL_size_is = 163;
		public const int LITERAL_max_is = 164;
		public const int LITERAL_length_is = 165;
		public const int LITERAL_first_is = 166;
		public const int LITERAL_last_is = 167;
		public const int LITERAL_switch_is = 168;
		public const int LITERAL_source = 169;
		public const int LITERAL_context = 170;
		public const int LITERAL_SAFEARRAY = 171;
		public const int OCTAL = 172;
		public const int LITERAL_L = 173;
		public const int STRING_LITERAL = 174;
		public const int CHAR_LITERAL = 175;
		public const int FLOAT = 176;
		public const int IDENT = 177;
		public const int LITERAL_cpp_quote = 178;
		public const int LITERAL_midl_pragma_warning = 179;
		public const int QUESTION = 180;
		public const int DOT = 181;
		public const int NOT = 182;
		public const int QUOTE = 183;
		public const int WS_ = 184;
		public const int PREPROC_DIRECTIVE = 185;
		public const int SL_COMMENT = 186;
		public const int OTHER_LANG_BLOCK = 187;
		public const int ML_COMMENT = 188;
		public const int ESC = 189;
		public const int VOCAB = 190;
		public const int DIGIT = 191;
		public const int OCTDIGIT = 192;
		public const int HEXDIGIT = 193;
		
		
	private CodeNamespace m_Namespace = null;
	private IDLConversions m_Conv = null;
		
		protected void initialize()
		{
			tokenNames = tokenNames_;
			initializeFactory();
		}
		
		
		protected IDLParser(TokenBuffer tokenBuf, int k) : base(tokenBuf, k)
		{
			initialize();
		}
		
		public IDLParser(TokenBuffer tokenBuf) : this(tokenBuf,1)
		{
		}
		
		protected IDLParser(TokenStream lexer, int k) : base(lexer,k)
		{
			initialize();
		}
		
		public IDLParser(TokenStream lexer) : this(lexer,1)
		{
		}
		
		public IDLParser(ParserSharedInputState state) : base(state,1)
		{
			initialize();
		}
		
	public void specification(
		CodeNamespace cnamespace, IDLConversions conv
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST specification_AST = null;
		
				m_Namespace = cnamespace; 
				m_Conv = conv;
			
		
		try {      // for error handling
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_0_.member(LA(1))))
					{
						definition();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop3_breakloop;
					}
					
				}
_loop3_breakloop:				;
			}    // ( ... )*
			AST tmp1_AST = null;
			tmp1_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp1_AST);
			match(Token.EOF_TYPE);
			specification_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				
						reportError(ex);
						return;
					
			}
			else
			{
				throw;
			}
		}
		returnAST = specification_AST;
	}
	
	public void definition() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST definition_AST = null;
		AST c_AST = null;
		AST e_AST = null;
		AST l_AST = null;
		AST m_AST = null;
		AST mi_AST = null;
		
				Hashtable attributes = new Hashtable();
				CodeTypeMember type = null; 
				CodeTypeDeclaration decl = null;
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					const_dcl();
					if (0 == inputState.guessing)
					{
						c_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					match(SEMI);
					if (0==inputState.guessing)
					{
						
									#if DEBUG_IDLGRAMMAR
										System.Diagnostics.Debug.WriteLine(string.Format("\nConstant found {0}\n\n", c_AST != null ? c_AST.ToStringList() : "<null>"));
									#endif
									
					}
					break;
				}
				case LITERAL_exception:
				{
					except_dcl();
					if (0 == inputState.guessing)
					{
						e_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					match(SEMI);
					if (0==inputState.guessing)
					{
						
									#if DEBUG_IDLGRAMMAR
										System.Diagnostics.Debug.WriteLine(string.Format("\nException declaration found {0}\n\n", e_AST != null ? e_AST.ToStringList() : "<null>"));
									#endif
									
					}
					break;
				}
				case LITERAL_module:
				{
					module();
					if (0 == inputState.guessing)
					{
						m_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					match(SEMI);
					if (0==inputState.guessing)
					{
						
									#if DEBUG_IDLGRAMMAR
										System.Diagnostics.Debug.WriteLine(string.Format("\nModule found {0}\n\n", m_AST != null ? m_AST.ToStringList() : "<null>"));
									#endif
									
					}
					break;
				}
				case LITERAL_importlib:
				{
					importlib();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					match(SEMI);
					break;
				}
				case LITERAL_cpp_quote:
				{
					cpp_quote();
					break;
				}
				case LITERAL_midl_pragma_warning:
				{
					midl_pragma_warning();
					if (0 == inputState.guessing)
					{
						mi_AST = (AST)returnAST;
					}
					if (0==inputState.guessing)
					{
						
									#if DEBUG_IDLGRAMMAR
										System.Diagnostics.Debug.WriteLine(string.Format("\nMIDL pragma found {0}\n\n", mi_AST != null ? mi_AST.ToStringList() : "<null>"));
									#endif
									
					}
					break;
				}
				default:
					bool synPredMatched7 = false;
					if (((tokenSet_1_.member(LA(1)))))
					{
						int _m7 = mark();
						synPredMatched7 = true;
						inputState.guessing++;
						try {
							{
								type_dcl();
								match(SEMI);
							}
						}
						catch (RecognitionException)
						{
							synPredMatched7 = false;
						}
						rewind(_m7);
						inputState.guessing--;
					}
					if ( synPredMatched7 )
					{
						type=type_dcl();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						match(SEMI);
						if (0==inputState.guessing)
						{
							
										#if DEBUG_IDLGRAMMAR
											System.Diagnostics.Debug.WriteLine(string.Format("\nType declaration found {0}\n\n", type != null ? type.Name : "<empty>"));
										#endif
											if (type != null && type is CodeTypeDeclaration)
											{
												m_Namespace.Types.Add((CodeTypeDeclaration)type); 
												m_Namespace.UserData.Add(type.Name, type);
											}
										
						}
					}
					else if ((LA(1)==LITERAL_import)) {
						import();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						match(SEMI);
					}
					else if ((tokenSet_2_.member(LA(1)))) {
						{
							switch ( LA(1) )
							{
							case LBRACKET:
							{
								AST tmp8_AST = null;
								tmp8_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp8_AST);
								match(LBRACKET);
								attribute_list(attributes);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								AST tmp9_AST = null;
								tmp9_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp9_AST);
								match(RBRACKET);
								break;
							}
							case INT3264:
							case INT64:
							case LITERAL_import:
							case LITERAL_library:
							case LITERAL_coclass:
							case LITERAL_uuid:
							case LITERAL_version:
							case LITERAL_object:
							case LITERAL_control:
							case LITERAL_entry:
							case LITERAL_hidden:
							case LITERAL_id:
							case LITERAL_message:
							case LITERAL_ref:
							case LITERAL_ptr:
							case LITERAL_scriptable:
							case LITERAL_jsval:
							case LITERAL_interface:
							case LITERAL_dispinterface:
							case SCOPEOP:
							case LITERAL_native:
							case LITERAL_handle:
							case LITERAL_signed:
							case LITERAL_unsigned:
							case LITERAL_octet:
							case LITERAL_any:
							case LITERAL_void:
							case LITERAL_byte:
							case LITERAL_wchar_t:
							case LITERAL_handle_t:
							case LITERAL_unique:
							case LITERAL_small:
							case LITERAL_short:
							case LITERAL_long:
							case LITERAL_int:
							case LITERAL_hyper:
							case LITERAL_char:
							case LITERAL_float:
							case LITERAL_double:
							case LITERAL_boolean:
							case LITERAL_struct:
							case LITERAL_union:
							case LITERAL_string:
							case LITERAL_callback:
							case LITERAL_retval:
							case LITERAL_range:
							case LITERAL_array:
							case LITERAL_source:
							case LITERAL_SAFEARRAY:
							case IDENT:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						{
							switch ( LA(1) )
							{
							case LITERAL_library:
							{
								library();
								if (0 == inputState.guessing)
								{
									l_AST = (AST)returnAST;
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								if (0==inputState.guessing)
								{
									
														#if DEBUG_IDLGRAMMAR
														System.Diagnostics.Debug.WriteLine(string.Format("\nLibrary found {0}\n\n", l_AST != null ? l_AST.ToStringList() : "<null>"));
														#endif
													
								}
								break;
							}
							case LITERAL_interface:
							case LITERAL_dispinterface:
							{
								decl=interf();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								if (0==inputState.guessing)
								{
									
														if (!(bool)decl.UserData["IsPartial"])
														{
															#if DEBUG_IDLGRAMMAR
															System.Diagnostics.Debug.WriteLine(string.Format("\nInterface declaration found {0}\n\n", decl.Name));
															#endif
															m_Conv.HandleInterface(decl, m_Namespace, attributes);
															m_Namespace.Types.Add(decl);
															// Remove any existing definition of the interface (maybe a forward declare) 
															if (m_Namespace.UserData[decl.Name] != null)
																m_Namespace.UserData.Remove(decl.Name);
															m_Namespace.UserData.Add(decl.Name, decl);
														}
														else
														{
															// Include the Forward declared interfaces in our UserData type list,
															// if it hasn't already been defined.
															if (m_Namespace.UserData[decl.Name] == null)
																m_Namespace.UserData.Add(decl.Name, decl);
														}
													
								}
								break;
							}
							case LITERAL_coclass:
							{
								decl=coclass();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								if (0==inputState.guessing)
								{
									
														if (!(bool)decl.UserData["IsPartial"])
														{
															#if DEBUG_IDLGRAMMAR
															System.Diagnostics.Debug.WriteLine(string.Format("\nCoclass declaration found {0}\n\n", decl.Name));
															#endif
															m_Conv.HandleCoClassInterface(decl, m_Namespace, attributes);
															// Add coclass interface
															m_Namespace.Types.Add(decl);		
															// Add coclass object
															m_Namespace.Types.Add(m_Conv.DeclareCoClassObject(decl, m_Namespace, attributes));
															// Add coclass creator object
															m_Namespace.Types.Add(m_Conv.DeclareCoClassCreator(decl, m_Namespace, attributes));
															attributes.Clear();
														}
													
								}
								break;
							}
							case INT3264:
							case INT64:
							case LITERAL_import:
							case LITERAL_uuid:
							case LITERAL_version:
							case LITERAL_object:
							case LITERAL_control:
							case LITERAL_entry:
							case LITERAL_hidden:
							case LITERAL_id:
							case LITERAL_message:
							case LITERAL_ref:
							case LITERAL_ptr:
							case LITERAL_scriptable:
							case LITERAL_jsval:
							case SCOPEOP:
							case LITERAL_native:
							case LITERAL_handle:
							case LITERAL_signed:
							case LITERAL_unsigned:
							case LITERAL_octet:
							case LITERAL_any:
							case LITERAL_void:
							case LITERAL_byte:
							case LITERAL_wchar_t:
							case LITERAL_handle_t:
							case LITERAL_unique:
							case LITERAL_small:
							case LITERAL_short:
							case LITERAL_long:
							case LITERAL_int:
							case LITERAL_hyper:
							case LITERAL_char:
							case LITERAL_float:
							case LITERAL_double:
							case LITERAL_boolean:
							case LITERAL_struct:
							case LITERAL_union:
							case LITERAL_string:
							case LITERAL_callback:
							case LITERAL_retval:
							case LITERAL_range:
							case LITERAL_array:
							case LITERAL_source:
							case LITERAL_SAFEARRAY:
							case IDENT:
							{
								param_type_spec();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								identifier();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								parameter_dcls();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								match(SEMI);
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
					}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				break; }
			}
			definition_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = definition_AST;
	}
	
	public CodeTypeMember  type_dcl() //throws RecognitionException, TokenStreamException
{
		CodeTypeMember type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST type_dcl_AST = null;
		
				type = null; 
				string ignored;
				Hashtable attributes = new Hashtable();
			
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_typedef:
			{
				AST tmp11_AST = null;
				tmp11_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp11_AST);
				match(LITERAL_typedef);
				{
					switch ( LA(1) )
					{
					case LBRACKET:
					{
						AST tmp12_AST = null;
						tmp12_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp12_AST);
						match(LBRACKET);
						type_attributes();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp13_AST = null;
						tmp13_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp13_AST);
						match(RBRACKET);
						break;
					}
					case INT3264:
					case INT64:
					case LITERAL_import:
					case LITERAL_uuid:
					case LITERAL_version:
					case LITERAL_object:
					case LITERAL_control:
					case LITERAL_entry:
					case LITERAL_hidden:
					case LITERAL_id:
					case LITERAL_message:
					case LITERAL_ref:
					case LITERAL_ptr:
					case LITERAL_scriptable:
					case LITERAL_jsval:
					case SCOPEOP:
					case LITERAL_const:
					case LITERAL_native:
					case LITERAL_handle:
					case LITERAL_signed:
					case LITERAL_unsigned:
					case LITERAL_octet:
					case LITERAL_any:
					case LITERAL_void:
					case LITERAL_byte:
					case LITERAL_wchar_t:
					case LITERAL_handle_t:
					case LITERAL_unique:
					case LITERAL_small:
					case LITERAL_short:
					case LITERAL_long:
					case LITERAL_int:
					case LITERAL_hyper:
					case LITERAL_char:
					case LITERAL_float:
					case LITERAL_double:
					case LITERAL_boolean:
					case LITERAL_struct:
					case LITERAL_union:
					case LITERAL_enum:
					case LITERAL_sequence:
					case LITERAL_string:
					case LITERAL_callback:
					case LITERAL_retval:
					case LITERAL_range:
					case LITERAL_array:
					case LITERAL_source:
					case IDENT:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				type=type_declarator();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_dcl_AST = currentAST.root;
				break;
			}
			case LITERAL_struct:
			{
				type=struct_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_dcl_AST = currentAST.root;
				break;
			}
			case LITERAL_union:
			{
				union_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_dcl_AST = currentAST.root;
				break;
			}
			case LITERAL_enum:
			{
				type=enum_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_dcl_AST = currentAST.root;
				break;
			}
			case SEMI:
			{
				type_dcl_AST = currentAST.root;
				break;
			}
			case LITERAL_native:
			{
				AST tmp14_AST = null;
				tmp14_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp14_AST);
				match(LITERAL_native);
				ignored=declarator(attributes);
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_dcl_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_dcl_AST;
		return type;
	}
	
	public void import() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST import_AST = null;
		
		try {      // for error handling
			AST tmp15_AST = null;
			tmp15_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp15_AST);
			match(LITERAL_import);
			string_literal();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp16_AST = null;
						tmp16_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp16_AST);
						match(COMMA);
						string_literal();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop13_breakloop;
					}
					
				}
_loop13_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				import_AST = (AST)currentAST.root;
				
							#if DEBUG_IDLGRAMMAR
								System.Diagnostics.Debug.WriteLine(import_AST.ToStringList());
							#endif
							
			}
			import_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = import_AST;
	}
	
	public void const_dcl() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST const_dcl_AST = null;
		string ignored;
		
		try {      // for error handling
			AST tmp17_AST = null;
			tmp17_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp17_AST);
			match(LITERAL_const);
			const_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp18_AST = null;
			tmp18_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp18_AST);
			match(ASSIGN);
			ignored=const_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			const_dcl_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = const_dcl_AST;
	}
	
	public void except_dcl() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST except_dcl_AST = null;
		CodeTypeMemberCollection ignored = new CodeTypeMemberCollection();
		
		try {      // for error handling
			AST tmp19_AST = null;
			tmp19_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp19_AST);
			match(LITERAL_exception);
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp20_AST = null;
			tmp20_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp20_AST);
			match(LBRACE);
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_5_.member(LA(1))))
					{
						member(ignored);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop210_breakloop;
					}
					
				}
_loop210_breakloop:				;
			}    // ( ... )*
			AST tmp21_AST = null;
			tmp21_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp21_AST);
			match(RBRACE);
			except_dcl_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = except_dcl_AST;
	}
	
	public void attribute_list(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST attribute_list_AST = null;
		
		try {      // for error handling
			attribute(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp22_AST = null;
						tmp22_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp22_AST);
						match(COMMA);
						attribute(attributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop27_breakloop;
					}
					
				}
_loop27_breakloop:				;
			}    // ( ... )*
			attribute_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_6_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attribute_list_AST;
	}
	
	public void library() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST library_AST = null;
		
		try {      // for error handling
			AST tmp23_AST = null;
			tmp23_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp23_AST);
			match(LITERAL_library);
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp24_AST = null;
			tmp24_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp24_AST);
			match(LBRACE);
			{ // ( ... )+
				int _cnt19=0;
				for (;;)
				{
					if ((tokenSet_0_.member(LA(1))))
					{
						definition();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt19 >= 1) { goto _loop19_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt19++;
				}
_loop19_breakloop:				;
			}    // ( ... )+
			AST tmp25_AST = null;
			tmp25_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp25_AST);
			match(RBRACE);
			match(SEMI);
			library_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = library_AST;
	}
	
	public CodeTypeDeclaration  interf() //throws RecognitionException, TokenStreamException
{
		CodeTypeDeclaration type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interf_AST = null;
		AST name_AST = null;
		
				bool fForwardDeclaration = true;
				StringCollection inherits;
				type = new CodeTypeDeclaration(); 
				type.IsInterface = true;
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_interface:
				{
					AST tmp27_AST = null;
					tmp27_AST = astFactory.create(LT(1));
					astFactory.makeASTRoot(ref currentAST, tmp27_AST);
					match(LITERAL_interface);
					break;
				}
				case LITERAL_dispinterface:
				{
					AST tmp28_AST = null;
					tmp28_AST = astFactory.create(LT(1));
					astFactory.makeASTRoot(ref currentAST, tmp28_AST);
					match(LITERAL_dispinterface);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			identifier();
			if (0 == inputState.guessing)
			{
				name_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			inherits=inheritance_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LBRACE:
				{
					match(LBRACE);
					{    // ( ... )*
						for (;;)
						{
							if ((tokenSet_7_.member(LA(1))))
							{
								fForwardDeclaration=interface_body(type);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else
							{
								goto _loop46_breakloop;
							}
							
						}
_loop46_breakloop:						;
					}    // ( ... )*
					match(RBRACE);
					break;
				}
				case EOF:
				case INT3264:
				case INT64:
				case SEMI:
				case LBRACKET:
				case LITERAL_module:
				case RBRACE:
				case LITERAL_import:
				case LITERAL_library:
				case LITERAL_coclass:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_importlib:
				case LITERAL_interface:
				case LITERAL_dispinterface:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_typedef:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_string:
				case LITERAL_exception:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case LITERAL_SAFEARRAY:
				case IDENT:
				case LITERAL_cpp_quote:
				case LITERAL_midl_pragma_warning:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
				
							/// we don't treat a forward declaration as real declaration
							type.Name = name_AST.getText();
							type.UserData.Add("IsPartial", fForwardDeclaration);
							type.UserData.Add("inherits", inherits);
						
			}
			interf_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = interf_AST;
		return type;
	}
	
	public CodeTypeDeclaration  coclass() //throws RecognitionException, TokenStreamException
{
		CodeTypeDeclaration type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST coclass_AST = null;
		AST name_AST = null;
		
				Hashtable attributes = new Hashtable(); 
				type = new CodeTypeDeclaration(); 
				type.IsInterface = true;
				type.UserData.Add("IsPartial", false); // The isPartial property is a .Net 2.0 feature
			
		
		try {      // for error handling
			AST tmp31_AST = null;
			tmp31_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp31_AST);
			match(LITERAL_coclass);
			identifier();
			if (0 == inputState.guessing)
			{
				name_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				type.Name = name_AST.getText();
			}
			AST tmp32_AST = null;
			tmp32_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp32_AST);
			match(LBRACE);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==LBRACKET||LA(1)==LITERAL_interface||LA(1)==LITERAL_dispinterface))
					{
						{
							switch ( LA(1) )
							{
							case LBRACKET:
							{
								AST tmp33_AST = null;
								tmp33_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp33_AST);
								match(LBRACKET);
								attribute_list(attributes);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								AST tmp34_AST = null;
								tmp34_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp34_AST);
								match(RBRACKET);
								break;
							}
							case LITERAL_interface:
							case LITERAL_dispinterface:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						interf_declr(type.BaseTypes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						{
							switch ( LA(1) )
							{
							case SEMI:
							{
								match(SEMI);
								break;
							}
							case LBRACKET:
							case RBRACE:
							case LITERAL_interface:
							case LITERAL_dispinterface:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
					}
					else
					{
						goto _loop24_breakloop;
					}
					
				}
_loop24_breakloop:				;
			}    // ( ... )*
			AST tmp36_AST = null;
			tmp36_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp36_AST);
			match(RBRACE);
			coclass_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = coclass_AST;
		return type;
	}
	
	public void param_type_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST param_type_spec_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case INT3264:
				case INT64:
				case LITERAL_native:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				{
					base_type_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case LITERAL_string:
				{
					string_type();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					scoped_name();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						switch ( LA(1) )
						{
						case LT_:
						{
							AST tmp37_AST = null;
							tmp37_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp37_AST);
							match(LT_);
							identifier();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							{    // ( ... )*
								for (;;)
								{
									if ((LA(1)==COMMA))
									{
										AST tmp38_AST = null;
										tmp38_AST = astFactory.create(LT(1));
										astFactory.addASTChild(ref currentAST, tmp38_AST);
										match(COMMA);
										identifier();
										if (0 == inputState.guessing)
										{
											astFactory.addASTChild(ref currentAST, returnAST);
										}
									}
									else
									{
										goto _loop262_breakloop;
									}
									
								}
_loop262_breakloop:								;
							}    // ( ... )*
							AST tmp39_AST = null;
							tmp39_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp39_AST);
							match(GT);
							break;
						}
						case LITERAL_import:
						case COMMA:
						case LITERAL_uuid:
						case LITERAL_version:
						case RPAREN:
						case LITERAL_object:
						case LITERAL_control:
						case LITERAL_entry:
						case LITERAL_hidden:
						case LITERAL_id:
						case LITERAL_message:
						case LITERAL_ref:
						case LITERAL_ptr:
						case LITERAL_scriptable:
						case LITERAL_jsval:
						case LITERAL_const:
						case STAR:
						case LITERAL_handle:
						case LITERAL_unique:
						case LITERAL_struct:
						case LITERAL_union:
						case LITERAL_callback:
						case LITERAL_retval:
						case LITERAL_range:
						case LITERAL_array:
						case LITERAL_source:
						case IDENT:
						{
							break;
						}
						default:
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						 }
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==STAR))
							{
								AST tmp40_AST = null;
								tmp40_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp40_AST);
								match(STAR);
							}
							else
							{
								goto _loop264_breakloop;
							}
							
						}
_loop264_breakloop:						;
					}    // ( ... )*
					break;
				}
				case LITERAL_SAFEARRAY:
				{
					AST tmp41_AST = null;
					tmp41_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp41_AST);
					match(LITERAL_SAFEARRAY);
					AST tmp42_AST = null;
					tmp42_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp42_AST);
					match(LPAREN);
					identifier();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==STAR))
							{
								AST tmp43_AST = null;
								tmp43_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp43_AST);
								match(STAR);
							}
							else
							{
								goto _loop266_breakloop;
							}
							
						}
_loop266_breakloop:						;
					}    // ( ... )*
					AST tmp44_AST = null;
					tmp44_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp44_AST);
					match(RPAREN);
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==STAR))
							{
								AST tmp45_AST = null;
								tmp45_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp45_AST);
								match(STAR);
							}
							else
							{
								goto _loop268_breakloop;
							}
							
						}
_loop268_breakloop:						;
					}    // ( ... )*
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			param_type_spec_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_8_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = param_type_spec_AST;
	}
	
	public void identifier() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST identifier_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_uuid:
			{
				AST tmp46_AST = null;
				tmp46_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp46_AST);
				match(LITERAL_uuid);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_scriptable:
			{
				AST tmp47_AST = null;
				tmp47_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp47_AST);
				match(LITERAL_scriptable);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_id:
			{
				AST tmp48_AST = null;
				tmp48_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp48_AST);
				match(LITERAL_id);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_range:
			{
				AST tmp49_AST = null;
				tmp49_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp49_AST);
				match(LITERAL_range);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_ptr:
			{
				AST tmp50_AST = null;
				tmp50_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp50_AST);
				match(LITERAL_ptr);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_source:
			{
				AST tmp51_AST = null;
				tmp51_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp51_AST);
				match(LITERAL_source);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_array:
			{
				AST tmp52_AST = null;
				tmp52_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp52_AST);
				match(LITERAL_array);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_version:
			{
				AST tmp53_AST = null;
				tmp53_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp53_AST);
				match(LITERAL_version);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_unique:
			{
				AST tmp54_AST = null;
				tmp54_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp54_AST);
				match(LITERAL_unique);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_object:
			{
				AST tmp55_AST = null;
				tmp55_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp55_AST);
				match(LITERAL_object);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_message:
			{
				AST tmp56_AST = null;
				tmp56_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp56_AST);
				match(LITERAL_message);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_ref:
			{
				AST tmp57_AST = null;
				tmp57_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp57_AST);
				match(LITERAL_ref);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_handle:
			{
				AST tmp58_AST = null;
				tmp58_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp58_AST);
				match(LITERAL_handle);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_control:
			{
				AST tmp59_AST = null;
				tmp59_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp59_AST);
				match(LITERAL_control);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_hidden:
			{
				AST tmp60_AST = null;
				tmp60_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp60_AST);
				match(LITERAL_hidden);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_callback:
			{
				AST tmp61_AST = null;
				tmp61_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp61_AST);
				match(LITERAL_callback);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_import:
			{
				AST tmp62_AST = null;
				tmp62_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp62_AST);
				match(LITERAL_import);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_union:
			{
				AST tmp63_AST = null;
				tmp63_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp63_AST);
				match(LITERAL_union);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_struct:
			{
				AST tmp64_AST = null;
				tmp64_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp64_AST);
				match(LITERAL_struct);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_entry:
			{
				AST tmp65_AST = null;
				tmp65_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp65_AST);
				match(LITERAL_entry);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_jsval:
			{
				AST tmp66_AST = null;
				tmp66_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp66_AST);
				match(LITERAL_jsval);
				identifier_AST = currentAST.root;
				break;
			}
			case LITERAL_retval:
			{
				AST tmp67_AST = null;
				tmp67_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp67_AST);
				match(LITERAL_retval);
				identifier_AST = currentAST.root;
				break;
			}
			case IDENT:
			{
				AST tmp68_AST = null;
				tmp68_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp68_AST);
				match(IDENT);
				identifier_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_9_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = identifier_AST;
	}
	
	public CodeParameterDeclarationExpressionCollection  parameter_dcls() //throws RecognitionException, TokenStreamException
{
		CodeParameterDeclarationExpressionCollection paramColl;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST parameter_dcls_AST = null;
		
				paramColl = new CodeParameterDeclarationExpressionCollection(); 
				CodeParameterDeclarationExpression param;
			
		
		try {      // for error handling
			match(LPAREN);
			{
				switch ( LA(1) )
				{
				case INT3264:
				case INT64:
				case LBRACKET:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_in:
				case LITERAL_out:
				case LITERAL_inout:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case LITERAL_SAFEARRAY:
				case IDENT:
				{
					param=param_dcl();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						paramColl.Add(param);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								match(COMMA);
								param=param_dcl();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								if (0==inputState.guessing)
								{
									paramColl.Add(param);
								}
							}
							else
							{
								goto _loop226_breakloop;
							}
							
						}
_loop226_breakloop:						;
					}    // ( ... )*
					break;
				}
				case RPAREN:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			match(RPAREN);
			parameter_dcls_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_10_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = parameter_dcls_AST;
		return paramColl;
	}
	
	public void module() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST module_AST = null;
		AST d_AST = null;
		
		try {      // for error handling
			AST tmp72_AST = null;
			tmp72_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp72_AST);
			match(LITERAL_module);
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp73_AST = null;
			tmp73_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp73_AST);
			match(LBRACE);
			definition_list();
			if (0 == inputState.guessing)
			{
				d_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp74_AST = null;
			tmp74_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp74_AST);
			match(RBRACE);
			module_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = module_AST;
	}
	
	public void importlib() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST importlib_AST = null;
		AST str_AST = null;
		
		try {      // for error handling
			AST tmp75_AST = null;
			tmp75_AST = astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, tmp75_AST);
			match(LITERAL_importlib);
			AST tmp76_AST = null;
			tmp76_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp76_AST);
			match(LPAREN);
			string_literal();
			if (0 == inputState.guessing)
			{
				str_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp77_AST = null;
			tmp77_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp77_AST);
			match(RPAREN);
			if (0==inputState.guessing)
			{
				
							#if DEBUG_IDLGRAMMAR
								System.Diagnostics.Debug.WriteLine("importlib " + str_AST.getText());
							#endif
							
			}
			importlib_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = importlib_AST;
	}
	
	public void cpp_quote() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cpp_quote_AST = null;
		
		try {      // for error handling
			AST tmp78_AST = null;
			tmp78_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp78_AST);
			match(LITERAL_cpp_quote);
			AST tmp79_AST = null;
			tmp79_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp79_AST);
			match(LPAREN);
			string_literal();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp80_AST = null;
			tmp80_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp80_AST);
			match(RPAREN);
			cpp_quote_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = cpp_quote_AST;
	}
	
	public void midl_pragma_warning() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST midl_pragma_warning_AST = null;
		
		try {      // for error handling
			AST tmp81_AST = null;
			tmp81_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp81_AST);
			match(LITERAL_midl_pragma_warning);
			AST tmp82_AST = null;
			tmp82_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp82_AST);
			match(LPAREN);
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_12_.member(LA(1))))
					{
						AST tmp83_AST = null;
						tmp83_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp83_AST);
						matchNot(RPAREN);
					}
					else
					{
						goto _loop282_breakloop;
					}
					
				}
_loop282_breakloop:				;
			}    // ( ... )*
			AST tmp84_AST = null;
			tmp84_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp84_AST);
			match(RPAREN);
			midl_pragma_warning_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = midl_pragma_warning_AST;
	}
	
	public void definition_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST definition_list_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt16=0;
				for (;;)
				{
					if ((tokenSet_0_.member(LA(1))))
					{
						definition();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt16 >= 1) { goto _loop16_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt16++;
				}
_loop16_breakloop:				;
			}    // ( ... )+
			definition_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = definition_list_AST;
	}
	
	public void string_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST string_literal_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_L:
				{
					AST tmp85_AST = null;
					tmp85_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp85_AST);
					match(LITERAL_L);
					break;
				}
				case STRING_LITERAL:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{ // ( ... )+
				int _cnt273=0;
				for (;;)
				{
					if ((LA(1)==STRING_LITERAL))
					{
						AST tmp86_AST = null;
						tmp86_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp86_AST);
						match(STRING_LITERAL);
					}
					else
					{
						if (_cnt273 >= 1) { goto _loop273_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt273++;
				}
_loop273_breakloop:				;
			}    // ( ... )+
			string_literal_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = string_literal_AST;
	}
	
	public void interf_declr(
		CodeTypeReferenceCollection baseTypes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interf_declr_AST = null;
		AST name_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_interface:
				{
					AST tmp87_AST = null;
					tmp87_AST = astFactory.create(LT(1));
					astFactory.makeASTRoot(ref currentAST, tmp87_AST);
					match(LITERAL_interface);
					break;
				}
				case LITERAL_dispinterface:
				{
					AST tmp88_AST = null;
					tmp88_AST = astFactory.create(LT(1));
					astFactory.makeASTRoot(ref currentAST, tmp88_AST);
					match(LITERAL_dispinterface);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			identifier();
			if (0 == inputState.guessing)
			{
				name_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
						baseTypes.Add(name_AST.getText());
					
			}
			interf_declr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_15_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = interf_declr_AST;
	}
	
	public void attribute(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST attribute_AST = null;
		AST uuid_AST = null;
		AST name_AST = null;
		AST value_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_uuid:
			{
				AST tmp89_AST = null;
				tmp89_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp89_AST);
				match(LITERAL_uuid);
				uuid_literal();
				if (0 == inputState.guessing)
				{
					uuid_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					attributes.Add("Guid", new CodeAttributeArgument(new CodePrimitiveExpression(uuid_AST.ToStringList().Replace(" ", ""))));
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_version:
			{
				AST tmp90_AST = null;
				tmp90_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp90_AST);
				match(LITERAL_version);
				AST tmp91_AST = null;
				tmp91_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp91_AST);
				match(LPAREN);
				{ // ( ... )+
					int _cnt30=0;
					for (;;)
					{
						if ((tokenSet_12_.member(LA(1))))
						{
							AST tmp92_AST = null;
							tmp92_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp92_AST);
							matchNot(RPAREN);
						}
						else
						{
							if (_cnt30 >= 1) { goto _loop30_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
						}
						
						_cnt30++;
					}
_loop30_breakloop:					;
				}    // ( ... )+
				AST tmp93_AST = null;
				tmp93_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp93_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_async_uuid:
			{
				AST tmp94_AST = null;
				tmp94_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp94_AST);
				match(LITERAL_async_uuid);
				uuid_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_local:
			{
				AST tmp95_AST = null;
				tmp95_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp95_AST);
				match(LITERAL_local);
				if (0==inputState.guessing)
				{
					attributes["local"] = true;
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_object:
			{
				AST tmp96_AST = null;
				tmp96_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp96_AST);
				match(LITERAL_object);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_pointer_default:
			{
				AST tmp97_AST = null;
				tmp97_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp97_AST);
				match(LITERAL_pointer_default);
				AST tmp98_AST = null;
				tmp98_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp98_AST);
				match(LPAREN);
				ptr_attr();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp99_AST = null;
				tmp99_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp99_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_endpoint:
			{
				AST tmp100_AST = null;
				tmp100_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp100_AST);
				match(LITERAL_endpoint);
				AST tmp101_AST = null;
				tmp101_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp101_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==COMMA))
						{
							AST tmp102_AST = null;
							tmp102_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp102_AST);
							match(COMMA);
							string_literal();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else
						{
							goto _loop32_breakloop;
						}
						
					}
_loop32_breakloop:					;
				}    // ( ... )*
				AST tmp103_AST = null;
				tmp103_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp103_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_odl:
			{
				AST tmp104_AST = null;
				tmp104_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp104_AST);
				match(LITERAL_odl);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_optimize:
			{
				AST tmp105_AST = null;
				tmp105_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp105_AST);
				match(LITERAL_optimize);
				AST tmp106_AST = null;
				tmp106_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp106_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp107_AST = null;
				tmp107_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp107_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_proxy:
			{
				AST tmp108_AST = null;
				tmp108_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp108_AST);
				match(LITERAL_proxy);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_aggregatable:
			{
				AST tmp109_AST = null;
				tmp109_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp109_AST);
				match(LITERAL_aggregatable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_appobject:
			{
				AST tmp110_AST = null;
				tmp110_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp110_AST);
				match(LITERAL_appobject);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_bindable:
			{
				AST tmp111_AST = null;
				tmp111_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp111_AST);
				match(LITERAL_bindable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_control:
			{
				AST tmp112_AST = null;
				tmp112_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp112_AST);
				match(LITERAL_control);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_custom:
			{
				AST tmp113_AST = null;
				tmp113_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp113_AST);
				match(LITERAL_custom);
				AST tmp114_AST = null;
				tmp114_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp114_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					name_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp115_AST = null;
				tmp115_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp115_AST);
				match(COMMA);
				non_rparen();
				if (0 == inputState.guessing)
				{
					value_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp116_AST = null;
				tmp116_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp116_AST);
				match(RPAREN);
				if (0==inputState.guessing)
				{
					
								attributes.Add("custom", new CodeAttributeArgument(name_AST.getText(), 
									new CodePrimitiveExpression(value_AST.getText())));
							
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_default:
			{
				AST tmp117_AST = null;
				tmp117_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp117_AST);
				match(LITERAL_default);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_defaultbind:
			{
				AST tmp118_AST = null;
				tmp118_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp118_AST);
				match(LITERAL_defaultbind);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_defaultcollelem:
			{
				AST tmp119_AST = null;
				tmp119_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp119_AST);
				match(LITERAL_defaultcollelem);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_defaultvtable:
			{
				AST tmp120_AST = null;
				tmp120_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp120_AST);
				match(LITERAL_defaultvtable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_displaybind:
			{
				AST tmp121_AST = null;
				tmp121_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp121_AST);
				match(LITERAL_displaybind);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_dllname:
			{
				AST tmp122_AST = null;
				tmp122_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp122_AST);
				match(LITERAL_dllname);
				AST tmp123_AST = null;
				tmp123_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp123_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp124_AST = null;
				tmp124_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp124_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_dual:
			{
				AST tmp125_AST = null;
				tmp125_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp125_AST);
				match(LITERAL_dual);
				if (0==inputState.guessing)
				{
					attributes.Add("dual", new CodeAttributeArgument());
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_entry:
			{
				AST tmp126_AST = null;
				tmp126_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp126_AST);
				match(LITERAL_entry);
				AST tmp127_AST = null;
				tmp127_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp127_AST);
				match(LPAREN);
				{ // ( ... )+
					int _cnt34=0;
					for (;;)
					{
						if ((tokenSet_12_.member(LA(1))))
						{
							AST tmp128_AST = null;
							tmp128_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp128_AST);
							matchNot(RPAREN);
						}
						else
						{
							if (_cnt34 >= 1) { goto _loop34_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
						}
						
						_cnt34++;
					}
_loop34_breakloop:					;
				}    // ( ... )+
				AST tmp129_AST = null;
				tmp129_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp129_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_helpcontext:
			{
				AST tmp130_AST = null;
				tmp130_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp130_AST);
				match(LITERAL_helpcontext);
				AST tmp131_AST = null;
				tmp131_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp131_AST);
				match(LPAREN);
				integer_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp132_AST = null;
				tmp132_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp132_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_helpfile:
			{
				AST tmp133_AST = null;
				tmp133_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp133_AST);
				match(LITERAL_helpfile);
				AST tmp134_AST = null;
				tmp134_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp134_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp135_AST = null;
				tmp135_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp135_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_helpstring:
			{
				AST tmp136_AST = null;
				tmp136_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp136_AST);
				match(LITERAL_helpstring);
				AST tmp137_AST = null;
				tmp137_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp137_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp138_AST = null;
				tmp138_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp138_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_helpstringdll:
			{
				AST tmp139_AST = null;
				tmp139_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp139_AST);
				match(LITERAL_helpstringdll);
				AST tmp140_AST = null;
				tmp140_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp140_AST);
				match(LPAREN);
				string_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp141_AST = null;
				tmp141_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp141_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_hidden:
			{
				AST tmp142_AST = null;
				tmp142_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp142_AST);
				match(LITERAL_hidden);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_id:
			{
				AST tmp143_AST = null;
				tmp143_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp143_AST);
				match(LITERAL_id);
				AST tmp144_AST = null;
				tmp144_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp144_AST);
				match(LPAREN);
				{
					switch ( LA(1) )
					{
					case INT:
					case HEX:
					case OCTAL:
					{
						integer_literal();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case LITERAL_import:
					case LITERAL_uuid:
					case LITERAL_version:
					case LITERAL_object:
					case LITERAL_control:
					case LITERAL_entry:
					case LITERAL_hidden:
					case LITERAL_id:
					case LITERAL_message:
					case LITERAL_ref:
					case LITERAL_ptr:
					case LITERAL_scriptable:
					case LITERAL_jsval:
					case LITERAL_handle:
					case LITERAL_unique:
					case LITERAL_struct:
					case LITERAL_union:
					case LITERAL_callback:
					case LITERAL_retval:
					case LITERAL_range:
					case LITERAL_array:
					case LITERAL_source:
					case IDENT:
					{
						identifier();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				AST tmp145_AST = null;
				tmp145_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp145_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_idempotent:
			{
				AST tmp146_AST = null;
				tmp146_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp146_AST);
				match(LITERAL_idempotent);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_immediatebind:
			{
				AST tmp147_AST = null;
				tmp147_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp147_AST);
				match(LITERAL_immediatebind);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_lcid:
			{
				AST tmp148_AST = null;
				tmp148_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp148_AST);
				match(LITERAL_lcid);
				AST tmp149_AST = null;
				tmp149_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp149_AST);
				match(LPAREN);
				integer_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp150_AST = null;
				tmp150_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp150_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_licensed:
			{
				AST tmp151_AST = null;
				tmp151_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp151_AST);
				match(LITERAL_licensed);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_message:
			{
				AST tmp152_AST = null;
				tmp152_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp152_AST);
				match(LITERAL_message);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_nonbrowsable:
			{
				AST tmp153_AST = null;
				tmp153_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp153_AST);
				match(LITERAL_nonbrowsable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_noncreatable:
			{
				AST tmp154_AST = null;
				tmp154_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp154_AST);
				match(LITERAL_noncreatable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_nonextensible:
			{
				AST tmp155_AST = null;
				tmp155_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp155_AST);
				match(LITERAL_nonextensible);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_oleautomation:
			{
				AST tmp156_AST = null;
				tmp156_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp156_AST);
				match(LITERAL_oleautomation);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_restricted:
			{
				AST tmp157_AST = null;
				tmp157_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp157_AST);
				match(LITERAL_restricted);
				if (0==inputState.guessing)
				{
					attributes.Add("restricted", new CodeAttributeArgument());
				}
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_ref:
			{
				AST tmp158_AST = null;
				tmp158_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp158_AST);
				match(LITERAL_ref);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_ptr:
			{
				AST tmp159_AST = null;
				tmp159_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp159_AST);
				match(LITERAL_ptr);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_function:
			{
				AST tmp160_AST = null;
				tmp160_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp160_AST);
				match(LITERAL_function);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_scriptable:
			{
				AST tmp161_AST = null;
				tmp161_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp161_AST);
				match(LITERAL_scriptable);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_deprecated:
			{
				AST tmp162_AST = null;
				tmp162_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp162_AST);
				match(LITERAL_deprecated);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_Undefined:
			{
				AST tmp163_AST = null;
				tmp163_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp163_AST);
				match(LITERAL_Undefined);
				AST tmp164_AST = null;
				tmp164_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp164_AST);
				match(LPAREN);
				identifier();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp165_AST = null;
				tmp165_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp165_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_noscript:
			{
				AST tmp166_AST = null;
				tmp166_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp166_AST);
				match(LITERAL_noscript);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_Null:
			{
				AST tmp167_AST = null;
				tmp167_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp167_AST);
				match(LITERAL_Null);
				AST tmp168_AST = null;
				tmp168_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp168_AST);
				match(LPAREN);
				identifier();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp169_AST = null;
				tmp169_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp169_AST);
				match(RPAREN);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_nsid:
			{
				AST tmp170_AST = null;
				tmp170_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp170_AST);
				match(LITERAL_nsid);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_domstring:
			{
				AST tmp171_AST = null;
				tmp171_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp171_AST);
				match(LITERAL_domstring);
				attribute_AST = currentAST.root;
				break;
			}
			case 68:
			{
				AST tmp172_AST = null;
				tmp172_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp172_AST);
				match(68);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_cstring:
			{
				AST tmp173_AST = null;
				tmp173_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp173_AST);
				match(LITERAL_cstring);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_astring:
			{
				AST tmp174_AST = null;
				tmp174_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp174_AST);
				match(LITERAL_astring);
				attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_jsval:
			{
				AST tmp175_AST = null;
				tmp175_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp175_AST);
				match(LITERAL_jsval);
				attribute_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attribute_AST;
	}
	
	public void uuid_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST uuid_literal_AST = null;
		AST value_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			non_rparen();
			if (0 == inputState.guessing)
			{
				value_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			match(RPAREN);
			uuid_literal_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = uuid_literal_AST;
	}
	
	public void ptr_attr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST ptr_attr_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_ref:
			{
				AST tmp178_AST = null;
				tmp178_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp178_AST);
				match(LITERAL_ref);
				ptr_attr_AST = currentAST.root;
				break;
			}
			case LITERAL_unique:
			{
				AST tmp179_AST = null;
				tmp179_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp179_AST);
				match(LITERAL_unique);
				ptr_attr_AST = currentAST.root;
				break;
			}
			case LITERAL_ptr:
			{
				AST tmp180_AST = null;
				tmp180_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp180_AST);
				match(LITERAL_ptr);
				ptr_attr_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_17_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = ptr_attr_AST;
	}
	
	public void non_rparen() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST non_rparen_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt38=0;
				for (;;)
				{
					if ((tokenSet_12_.member(LA(1))))
					{
						AST tmp181_AST = null;
						tmp181_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp181_AST);
						matchNot(RPAREN);
					}
					else
					{
						if (_cnt38 >= 1) { goto _loop38_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt38++;
				}
_loop38_breakloop:				;
			}    // ( ... )+
			non_rparen_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_18_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = non_rparen_AST;
	}
	
	public void integer_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST integer_literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT:
			{
				AST tmp182_AST = null;
				tmp182_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp182_AST);
				match(INT);
				integer_literal_AST = currentAST.root;
				break;
			}
			case OCTAL:
			{
				AST tmp183_AST = null;
				tmp183_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp183_AST);
				match(OCTAL);
				integer_literal_AST = currentAST.root;
				break;
			}
			case HEX:
			{
				AST tmp184_AST = null;
				tmp184_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp184_AST);
				match(HEX);
				integer_literal_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_19_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = integer_literal_AST;
	}
	
	public void lib_definition() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST lib_definition_AST = null;
		
				Hashtable attributes = new Hashtable(); 
				CodeTypeMember ignored;
			
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LBRACKET:
			case LITERAL_interface:
			case LITERAL_dispinterface:
			{
				{
					switch ( LA(1) )
					{
					case LBRACKET:
					{
						AST tmp185_AST = null;
						tmp185_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp185_AST);
						match(LBRACKET);
						attribute_list(attributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp186_AST = null;
						tmp186_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp186_AST);
						match(RBRACKET);
						break;
					}
					case LITERAL_interface:
					case LITERAL_dispinterface:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				ignored=interf();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				lib_definition_AST = currentAST.root;
				break;
			}
			case SEMI:
			case LITERAL_typedef:
			case LITERAL_native:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_enum:
			{
				ignored=type_dcl();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				match(SEMI);
				lib_definition_AST = currentAST.root;
				break;
			}
			case LITERAL_const:
			{
				const_dcl();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				match(SEMI);
				lib_definition_AST = currentAST.root;
				break;
			}
			case LITERAL_importlib:
			{
				importlib();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				match(SEMI);
				lib_definition_AST = currentAST.root;
				break;
			}
			case LITERAL_import:
			{
				import();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				match(SEMI);
				lib_definition_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = lib_definition_AST;
	}
	
	public StringCollection  inheritance_spec() //throws RecognitionException, TokenStreamException
{
		StringCollection coll;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST inheritance_spec_AST = null;
		coll = new StringCollection();
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case COLON:
				{
					AST tmp191_AST = null;
					tmp191_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp191_AST);
					match(COLON);
					scoped_name_list(coll);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case EOF:
				case INT3264:
				case INT64:
				case SEMI:
				case LBRACKET:
				case LITERAL_module:
				case LBRACE:
				case RBRACE:
				case LITERAL_import:
				case LITERAL_library:
				case LITERAL_coclass:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_importlib:
				case LITERAL_interface:
				case LITERAL_dispinterface:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_typedef:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_string:
				case LITERAL_exception:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case LITERAL_SAFEARRAY:
				case IDENT:
				case LITERAL_cpp_quote:
				case LITERAL_midl_pragma_warning:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			inheritance_spec_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_21_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = inheritance_spec_AST;
		return coll;
	}
	
	public bool  interface_body(
		CodeTypeDeclaration type
	) //throws RecognitionException, TokenStreamException
{
		bool fForwardDeclaration;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interface_body_AST = null;
		
				CodeTypeMemberCollection members = null;
				CodeTypeMember member = null; 
				CodeTypeMember ignored;
				fForwardDeclaration = false;
				Hashtable funcAttributes = new Hashtable();
			
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_const:
			{
				const_dcl();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp192_AST = null;
				tmp192_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp192_AST);
				match(SEMI);
				interface_body_AST = currentAST.root;
				break;
			}
			case LITERAL_exception:
			{
				except_dcl();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp193_AST = null;
				tmp193_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp193_AST);
				match(SEMI);
				interface_body_AST = currentAST.root;
				break;
			}
			case LITERAL_cpp_quote:
			{
				cpp_quote();
				interface_body_AST = currentAST.root;
				break;
			}
			default:
				if ((tokenSet_1_.member(LA(1))))
				{
					ignored=type_dcl();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp194_AST = null;
					tmp194_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp194_AST);
					match(SEMI);
					interface_body_AST = currentAST.root;
				}
				else {
					bool synPredMatched53 = false;
					if (((LA(1)==LBRACKET||LA(1)==LITERAL_readonly||LA(1)==LITERAL_attribute)))
					{
						int _m53 = mark();
						synPredMatched53 = true;
						inputState.guessing++;
						try {
							{
								{
									switch ( LA(1) )
									{
									case LBRACKET:
									{
										function_attribute_list(funcAttributes);
										break;
									}
									case LITERAL_readonly:
									case LITERAL_attribute:
									{
										break;
									}
									default:
									{
										throw new NoViableAltException(LT(1), getFilename());
									}
									 }
								}
								{
									switch ( LA(1) )
									{
									case LITERAL_readonly:
									{
										match(LITERAL_readonly);
										break;
									}
									case LITERAL_attribute:
									{
										break;
									}
									default:
									{
										throw new NoViableAltException(LT(1), getFilename());
									}
									 }
								}
								match(LITERAL_attribute);
							}
						}
						catch (RecognitionException)
						{
							synPredMatched53 = false;
						}
						rewind(_m53);
						inputState.guessing--;
					}
					if ( synPredMatched53 )
					{
						{
							switch ( LA(1) )
							{
							case LBRACKET:
							{
								function_attribute_list(funcAttributes);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								break;
							}
							case LITERAL_readonly:
							case LITERAL_attribute:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						members=attr_dcl(type.Members, funcAttributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp195_AST = null;
						tmp195_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp195_AST);
						match(SEMI);
						if (0==inputState.guessing)
						{
							
										if (members != null)				
											type.Members.AddRange(members);
									
						}
						interface_body_AST = currentAST.root;
					}
					else if ((tokenSet_22_.member(LA(1)))) {
						{
							switch ( LA(1) )
							{
							case LBRACKET:
							{
								function_attribute_list(funcAttributes);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								break;
							}
							case INT3264:
							case INT64:
							case LITERAL_import:
							case LITERAL_uuid:
							case LITERAL_version:
							case LITERAL_object:
							case LITERAL_control:
							case LITERAL_entry:
							case LITERAL_hidden:
							case LITERAL_id:
							case LITERAL_message:
							case LITERAL_ref:
							case LITERAL_ptr:
							case LITERAL_scriptable:
							case LITERAL_jsval:
							case SCOPEOP:
							case LITERAL_native:
							case LITERAL_handle:
							case LITERAL_signed:
							case LITERAL_unsigned:
							case LITERAL_octet:
							case LITERAL_any:
							case LITERAL_void:
							case LITERAL_byte:
							case LITERAL_wchar_t:
							case LITERAL_handle_t:
							case LITERAL_unique:
							case LITERAL_small:
							case LITERAL_short:
							case LITERAL_long:
							case LITERAL_int:
							case LITERAL_hyper:
							case LITERAL_char:
							case LITERAL_float:
							case LITERAL_double:
							case LITERAL_boolean:
							case LITERAL_struct:
							case LITERAL_union:
							case LITERAL_string:
							case LITERAL_callback:
							case LITERAL_retval:
							case LITERAL_range:
							case LITERAL_array:
							case LITERAL_source:
							case LITERAL_SAFEARRAY:
							case IDENT:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						member=function_dcl(type.Members, funcAttributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp196_AST = null;
						tmp196_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp196_AST);
						match(SEMI);
						if (0==inputState.guessing)
						{
							
										if (member != null)
											type.Members.Add(member);
									
						}
						interface_body_AST = currentAST.root;
					}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				}break; }
			}
			catch (RecognitionException ex)
			{
				if (0 == inputState.guessing)
				{
					reportError(ex);
					recover(ex,tokenSet_23_);
				}
				else
				{
					throw ex;
				}
			}
			returnAST = interface_body_AST;
			return fForwardDeclaration;
		}
		
	public void function_attribute_list(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST function_attribute_list_AST = null;
		
		try {      // for error handling
			AST tmp197_AST = null;
			tmp197_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp197_AST);
			match(LBRACKET);
			{
				switch ( LA(1) )
				{
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_async_uuid:
				case LITERAL_local:
				case LITERAL_object:
				case LITERAL_pointer_default:
				case LITERAL_endpoint:
				case LITERAL_odl:
				case LITERAL_optimize:
				case LITERAL_proxy:
				case LITERAL_aggregatable:
				case LITERAL_appobject:
				case LITERAL_bindable:
				case LITERAL_control:
				case LITERAL_custom:
				case LITERAL_default:
				case LITERAL_defaultbind:
				case LITERAL_defaultcollelem:
				case LITERAL_defaultvtable:
				case LITERAL_displaybind:
				case LITERAL_dllname:
				case LITERAL_dual:
				case LITERAL_entry:
				case LITERAL_helpcontext:
				case LITERAL_helpfile:
				case LITERAL_helpstring:
				case LITERAL_helpstringdll:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_idempotent:
				case LITERAL_immediatebind:
				case LITERAL_lcid:
				case LITERAL_licensed:
				case LITERAL_message:
				case LITERAL_nonbrowsable:
				case LITERAL_noncreatable:
				case LITERAL_nonextensible:
				case LITERAL_oleautomation:
				case LITERAL_restricted:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_function:
				case LITERAL_scriptable:
				case LITERAL_deprecated:
				case LITERAL_Undefined:
				case LITERAL_noscript:
				case LITERAL_Null:
				case LITERAL_nsid:
				case LITERAL_domstring:
				case 68:
				case LITERAL_cstring:
				case LITERAL_astring:
				case LITERAL_jsval:
				case LITERAL_context_handle:
				case LITERAL_unique:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_broadcast:
				case LITERAL_ignore:
				case LITERAL_notxpcom:
				case LITERAL_propget:
				case LITERAL_propput:
				case LITERAL_propputref:
				case LITERAL_uidefault:
				case LITERAL_usesgetlasterror:
				case LITERAL_vararg:
				case LITERAL_optional_argc:
				case LITERAL_implicit_jscontext:
				case LITERAL_binaryname:
				{
					function_attribute(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								AST tmp198_AST = null;
								tmp198_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp198_AST);
								match(COMMA);
								function_attribute(attributes);
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else
							{
								goto _loop218_breakloop;
							}
							
						}
_loop218_breakloop:						;
					}    // ( ... )*
					break;
				}
				case RBRACKET:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp199_AST = null;
			tmp199_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp199_AST);
			match(RBRACKET);
			function_attribute_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_24_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = function_attribute_list_AST;
	}
	
	public CodeTypeMemberCollection  attr_dcl(
		CodeTypeMemberCollection types,  Hashtable funcAttributes
	) //throws RecognitionException, TokenStreamException
{
		CodeTypeMemberCollection membersRet;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST attr_dcl_AST = null;
		AST type_AST = null;
		
				bool fReadonly = false;
				string name; 
				Hashtable attributes = new Hashtable();
				membersRet = new CodeTypeMemberCollection();		
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_readonly:
				{
					AST tmp200_AST = null;
					tmp200_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp200_AST);
					match(LITERAL_readonly);
					if (0==inputState.guessing)
					{
						fReadonly=true;
					}
					break;
				}
				case LITERAL_attribute:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp201_AST = null;
			tmp201_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp201_AST);
			match(LITERAL_attribute);
			param_type_spec();
			if (0 == inputState.guessing)
			{
				type_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			name=declarator_list(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
							name = IDLConversions.UpperFirstLetter(name);						
							CodeMemberMethod getter = new CodeMemberMethod() { Name=name};			
				
							CodeParameterDeclarationExpression param = new CodeParameterDeclarationExpression();						
							IDLConversions.ConvertParaTypeResults results = m_Conv.ConvertParamTypeExtended(type_AST.ToStringList(), param, attributes);
							param.Type = results.newType;			
				
							// if this config files explicitly doesn't want this attribute to be a retval, then add type as first parameter.
							if (results.attributesRemoved.Contains("retval"))
							{			
								getter.ReturnType = new CodeTypeReference("System.Void");
								getter.Parameters.Add(new CodeParameterDeclarationExpression(param.Type, "a" + name));				
								getter.Parameters[0].CustomAttributes = param.CustomAttributes;
							}
							else
							{
								getter.ReturnType = param.Type;
								getter.CustomAttributes = param.CustomAttributes;
				
								// Review: The approach to add "return:" is hacky! a similar thing is also 
								// done in HandleFunction_dcl
								// TODO: expand the xml configuration spec (IDLImp.xml) to allow modifying method
								// attribute and not just type attributes.
								if (getter.CustomAttributes.Count > 0)
								{
									getter.CustomAttributes[0].Name = "return: " + getter.CustomAttributes[0].Name;
								}
							}
								
								m_Conv.HandleSizeIs(getter, funcAttributes);
								getter = (CodeMemberMethod)m_Conv.HandleFunction_dcl(getter, param.Type, types, attributes, true);
				
								membersRet.Add(getter);			
				
							if (!fReadonly)
							{
								var setter = new CodeMemberMethod() { Name="Set" + name, ReturnType=new CodeTypeReference("System.Void")};
								setter.Parameters.Add(new CodeParameterDeclarationExpression(type_AST.getText(), "a" + name));
				
								param = new CodeParameterDeclarationExpression();
								param.Type = m_Conv.ConvertParamType(type_AST.getText(), param, attributes);
								setter.Parameters[0].Type = param.Type;
								setter.Parameters[0].CustomAttributes = param.CustomAttributes;
				
								m_Conv.HandleSizeIs(setter, funcAttributes);
								setter = (CodeMemberMethod)m_Conv.HandleFunction_dcl(setter, param.Type, types, attributes, true);
				
								membersRet.Add(setter);
							}
						
			}
			attr_dcl_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attr_dcl_AST;
		return membersRet;
	}
	
	public CodeTypeMember  function_dcl(
		CodeTypeMemberCollection types, Hashtable funcAttributes
	) //throws RecognitionException, TokenStreamException
{
		CodeTypeMember memberRet;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST function_dcl_AST = null;
		AST rt_AST = null;
		AST name_AST = null;
		
				CodeParameterDeclarationExpressionCollection pars;
				CodeMemberMethod member = new CodeMemberMethod(); 
				memberRet = member;
			
		
		try {      // for error handling
			param_type_spec();
			if (0 == inputState.guessing)
			{
				rt_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					AST tmp202_AST = null;
					tmp202_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp202_AST);
					match(LITERAL_const);
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			identifier();
			if (0 == inputState.guessing)
			{
				name_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			pars=parameter_dcls();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					AST tmp203_AST = null;
					tmp203_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp203_AST);
					match(LITERAL_const);
					break;
				}
				case SEMI:
				case LITERAL_raises:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_raises:
				{
					raises();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case SEMI:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
							
							member.Name = IDLConversions.UpperFirstLetter(name_AST.getText());
							member.Parameters.AddRange(pars);
				
							if (rt_AST == null)
								memberRet = null;
							else
							{
								CodeParameterDeclarationExpression param = new CodeParameterDeclarationExpression();
								Hashtable attributes = new Hashtable();
								param.Type = m_Conv.ConvertParamType(rt_AST.ToString(), param, attributes);
								
								m_Conv.HandleSizeIs(member, funcAttributes);
								memberRet = m_Conv.HandleFunction_dcl(member, param.Type, types, funcAttributes);
							}
						
			}
			function_dcl_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = function_dcl_AST;
		return memberRet;
	}
	
	public void scoped_name_list(
		StringCollection coll
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST scoped_name_list_AST = null;
		AST name1_AST = null;
		AST name2_AST = null;
		
		try {      // for error handling
			scoped_name();
			if (0 == inputState.guessing)
			{
				name1_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				coll.Add(name1_AST.getText());
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp204_AST = null;
						tmp204_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp204_AST);
						match(COMMA);
						scoped_name();
						if (0 == inputState.guessing)
						{
							name2_AST = (AST)returnAST;
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							coll.Add(name2_AST.getText());
						}
					}
					else
					{
						goto _loop60_breakloop;
					}
					
				}
_loop60_breakloop:				;
			}    // ( ... )*
			scoped_name_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_25_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = scoped_name_list_AST;
	}
	
	public void scoped_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST scoped_name_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case SCOPEOP:
				{
					AST tmp205_AST = null;
					tmp205_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp205_AST);
					match(SCOPEOP);
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==SCOPEOP))
					{
						AST tmp206_AST = null;
						tmp206_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp206_AST);
						match(SCOPEOP);
						identifier();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop64_breakloop;
					}
					
				}
_loop64_breakloop:				;
			}    // ( ... )*
			scoped_name_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_26_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = scoped_name_AST;
	}
	
	public void const_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST const_type_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT3264:
			case INT64:
			case LITERAL_native:
			case LITERAL_signed:
			case LITERAL_unsigned:
			case LITERAL_octet:
			case LITERAL_any:
			case LITERAL_void:
			case LITERAL_byte:
			case LITERAL_wchar_t:
			case LITERAL_handle_t:
			case LITERAL_small:
			case LITERAL_short:
			case LITERAL_long:
			case LITERAL_int:
			case LITERAL_hyper:
			case LITERAL_char:
			case LITERAL_float:
			case LITERAL_double:
			case LITERAL_boolean:
			{
				base_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				const_type_AST = currentAST.root;
				break;
			}
			case LITERAL_string:
			{
				string_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				const_type_AST = currentAST.root;
				break;
			}
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case SCOPEOP:
			case LITERAL_handle:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case IDENT:
			{
				scoped_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==STAR))
						{
							AST tmp207_AST = null;
							tmp207_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp207_AST);
							match(STAR);
						}
						else
						{
							goto _loop68_breakloop;
						}
						
					}
_loop68_breakloop:					;
				}    // ( ... )*
				const_type_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_27_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = const_type_AST;
	}
	
	public string  const_exp() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST const_exp_AST = null;
		s = string.Empty;
		
		try {      // for error handling
			s=or_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			const_exp_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_28_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = const_exp_AST;
		return s;
	}
	
	public void base_type_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST base_type_spec_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT3264:
			case INT64:
			case LITERAL_signed:
			case LITERAL_unsigned:
			case LITERAL_octet:
			case LITERAL_any:
			case LITERAL_void:
			case LITERAL_byte:
			case LITERAL_wchar_t:
			case LITERAL_small:
			case LITERAL_short:
			case LITERAL_long:
			case LITERAL_int:
			case LITERAL_hyper:
			case LITERAL_char:
			case LITERAL_float:
			case LITERAL_double:
			case LITERAL_boolean:
			{
				{
					switch ( LA(1) )
					{
					case LITERAL_boolean:
					{
						boolean_type();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case LITERAL_float:
					case LITERAL_double:
					{
						floating_pt_type();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case LITERAL_any:
					{
						AST tmp208_AST = null;
						tmp208_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp208_AST);
						match(LITERAL_any);
						break;
					}
					case LITERAL_void:
					{
						AST tmp209_AST = null;
						tmp209_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp209_AST);
						match(LITERAL_void);
						break;
					}
					case LITERAL_byte:
					{
						AST tmp210_AST = null;
						tmp210_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp210_AST);
						match(LITERAL_byte);
						break;
					}
					case LITERAL_wchar_t:
					{
						AST tmp211_AST = null;
						tmp211_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp211_AST);
						match(LITERAL_wchar_t);
						break;
					}
					default:
						bool synPredMatched118 = false;
						if (((tokenSet_29_.member(LA(1)))))
						{
							int _m118 = mark();
							synPredMatched118 = true;
							inputState.guessing++;
							try {
								{
									{
										switch ( LA(1) )
										{
										case LITERAL_signed:
										{
											match(LITERAL_signed);
											break;
										}
										case LITERAL_unsigned:
										{
											match(LITERAL_unsigned);
											break;
										}
										case INT3264:
										case INT64:
										case LITERAL_octet:
										case LITERAL_small:
										case LITERAL_short:
										case LITERAL_long:
										case LITERAL_int:
										case LITERAL_hyper:
										case LITERAL_char:
										{
											break;
										}
										default:
										{
											throw new NoViableAltException(LT(1), getFilename());
										}
										 }
									}
									{
										switch ( LA(1) )
										{
										case INT3264:
										case INT64:
										case LITERAL_octet:
										case LITERAL_small:
										case LITERAL_short:
										case LITERAL_long:
										case LITERAL_int:
										case LITERAL_hyper:
										{
											integer_type();
											break;
										}
										case LITERAL_char:
										{
											char_type();
											break;
										}
										default:
										{
											throw new NoViableAltException(LT(1), getFilename());
										}
										 }
									}
								}
							}
							catch (RecognitionException)
							{
								synPredMatched118 = false;
							}
							rewind(_m118);
							inputState.guessing--;
						}
						if ( synPredMatched118 )
						{
							{
								switch ( LA(1) )
								{
								case LITERAL_signed:
								{
									AST tmp212_AST = null;
									tmp212_AST = astFactory.create(LT(1));
									astFactory.addASTChild(ref currentAST, tmp212_AST);
									match(LITERAL_signed);
									break;
								}
								case LITERAL_unsigned:
								{
									AST tmp213_AST = null;
									tmp213_AST = astFactory.create(LT(1));
									astFactory.addASTChild(ref currentAST, tmp213_AST);
									match(LITERAL_unsigned);
									break;
								}
								case INT3264:
								case INT64:
								case LITERAL_octet:
								case LITERAL_small:
								case LITERAL_short:
								case LITERAL_long:
								case LITERAL_int:
								case LITERAL_hyper:
								case LITERAL_char:
								{
									break;
								}
								default:
								{
									throw new NoViableAltException(LT(1), getFilename());
								}
								 }
							}
							{
								switch ( LA(1) )
								{
								case INT3264:
								case INT64:
								case LITERAL_octet:
								case LITERAL_small:
								case LITERAL_short:
								case LITERAL_long:
								case LITERAL_int:
								case LITERAL_hyper:
								{
									integer_type();
									if (0 == inputState.guessing)
									{
										astFactory.addASTChild(ref currentAST, returnAST);
									}
									break;
								}
								case LITERAL_char:
								{
									char_type();
									if (0 == inputState.guessing)
									{
										astFactory.addASTChild(ref currentAST, returnAST);
									}
									break;
								}
								default:
								{
									throw new NoViableAltException(LT(1), getFilename());
								}
								 }
							}
						}
						else if ((LA(1)==LITERAL_signed||LA(1)==LITERAL_unsigned)) {
							{
								switch ( LA(1) )
								{
								case LITERAL_signed:
								{
									AST tmp214_AST = null;
									tmp214_AST = astFactory.create(LT(1));
									astFactory.addASTChild(ref currentAST, tmp214_AST);
									match(LITERAL_signed);
									break;
								}
								case LITERAL_unsigned:
								{
									AST tmp215_AST = null;
									tmp215_AST = astFactory.create(LT(1));
									astFactory.addASTChild(ref currentAST, tmp215_AST);
									match(LITERAL_unsigned);
									break;
								}
								default:
								{
									throw new NoViableAltException(LT(1), getFilename());
								}
								 }
							}
						}
						else if ((LA(1)==LITERAL_octet)) {
							AST tmp216_AST = null;
							tmp216_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp216_AST);
							match(LITERAL_octet);
						}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					break; }
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==STAR))
						{
							AST tmp217_AST = null;
							tmp217_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp217_AST);
							match(STAR);
						}
						else
						{
							goto _loop123_breakloop;
						}
						
					}
_loop123_breakloop:					;
				}    // ( ... )*
				base_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_handle_t:
			{
				AST tmp218_AST = null;
				tmp218_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp218_AST);
				match(LITERAL_handle_t);
				base_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_native:
			{
				AST tmp219_AST = null;
				tmp219_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp219_AST);
				match(LITERAL_native);
				base_type_spec_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_30_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = base_type_spec_AST;
	}
	
	public void string_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST string_type_AST = null;
		
		try {      // for error handling
			AST tmp220_AST = null;
			tmp220_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp220_AST);
			match(LITERAL_string);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==STAR))
					{
						AST tmp221_AST = null;
						tmp221_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp221_AST);
						match(STAR);
					}
					else
					{
						goto _loop200_breakloop;
					}
					
				}
_loop200_breakloop:				;
			}    // ( ... )*
			string_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_31_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = string_type_AST;
	}
	
	public string  or_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST or_expr_AST = null;
		IToken  op = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=xor_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==OR))
					{
						op = LT(1);
						op_AST = astFactory.create(op);
						astFactory.addASTChild(ref currentAST, op_AST);
						match(OR);
						expr=xor_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop72_breakloop;
					}
					
				}
_loop72_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			or_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_28_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = or_expr_AST;
		return s;
	}
	
	public string  xor_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST xor_expr_AST = null;
		IToken  op = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=and_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==XOR))
					{
						op = LT(1);
						op_AST = astFactory.create(op);
						astFactory.addASTChild(ref currentAST, op_AST);
						match(XOR);
						expr=and_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop75_breakloop;
					}
					
				}
_loop75_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			xor_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_32_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = xor_expr_AST;
		return s;
	}
	
	public string  and_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST and_expr_AST = null;
		IToken  op = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=shift_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==AND))
					{
						op = LT(1);
						op_AST = astFactory.create(op);
						astFactory.addASTChild(ref currentAST, op_AST);
						match(AND);
						expr=shift_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop78_breakloop;
					}
					
				}
_loop78_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			and_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_33_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = and_expr_AST;
		return s;
	}
	
	public string  shift_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST shift_expr_AST = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=add_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==LSHIFT||LA(1)==RSHIFT))
					{
						shift_op();
						if (0 == inputState.guessing)
						{
							op_AST = (AST)returnAST;
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						expr=add_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop81_breakloop;
					}
					
				}
_loop81_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			shift_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_34_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = shift_expr_AST;
		return s;
	}
	
	public string  add_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST add_expr_AST = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=mult_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PLUS||LA(1)==MINUS))
					{
						add_op();
						if (0 == inputState.guessing)
						{
							op_AST = (AST)returnAST;
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						expr=mult_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop85_breakloop;
					}
					
				}
_loop85_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			add_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_35_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = add_expr_AST;
		return s;
	}
	
	public void shift_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST shift_op_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LSHIFT:
			{
				AST tmp222_AST = null;
				tmp222_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp222_AST);
				match(LSHIFT);
				shift_op_AST = currentAST.root;
				break;
			}
			case RSHIFT:
			{
				AST tmp223_AST = null;
				tmp223_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp223_AST);
				match(RSHIFT);
				shift_op_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_36_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = shift_op_AST;
	}
	
	public string  mult_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST mult_expr_AST = null;
		AST op_AST = null;
		
				StringBuilder bldr = new StringBuilder();
				string expr = string.Empty;
				s = string.Empty;
			
		
		try {      // for error handling
			expr=unary_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				bldr.Append(expr);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==STAR||LA(1)==DIV||LA(1)==MOD))
					{
						mult_op();
						if (0 == inputState.guessing)
						{
							op_AST = (AST)returnAST;
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						expr=unary_expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											bldr.Append(op_AST.getText()); 
											bldr.Append(expr); 
										
						}
					}
					else
					{
						goto _loop89_breakloop;
					}
					
				}
_loop89_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				s = bldr.ToString();
			}
			mult_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_37_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = mult_expr_AST;
		return s;
	}
	
	public void add_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST add_op_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case PLUS:
			{
				AST tmp224_AST = null;
				tmp224_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp224_AST);
				match(PLUS);
				add_op_AST = currentAST.root;
				break;
			}
			case MINUS:
			{
				AST tmp225_AST = null;
				tmp225_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp225_AST);
				match(MINUS);
				add_op_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_36_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = add_op_AST;
	}
	
	public string  unary_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unary_expr_AST = null;
		AST u_AST = null;
		
				string p = string.Empty;
				s = string.Empty; 
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case PLUS:
				case MINUS:
				case TILDE:
				{
					unary_operator();
					if (0 == inputState.guessing)
					{
						u_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LPAREN:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_TRUE:
				case LITERAL_true:
				case LITERAL_FALSE:
				case LITERAL_false:
				case LITERAL_handle:
				case INT:
				case HEX:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case OCTAL:
				case LITERAL_L:
				case STRING_LITERAL:
				case CHAR_LITERAL:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			p=primary_expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
							if (u_AST != null)
								s = u_AST.getText() + p;
							else
								s = p;
						
			}
			unary_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = unary_expr_AST;
		return s;
	}
	
	public void mult_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST mult_op_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case STAR:
			{
				AST tmp226_AST = null;
				tmp226_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp226_AST);
				match(STAR);
				mult_op_AST = currentAST.root;
				break;
			}
			case DIV:
			{
				AST tmp227_AST = null;
				tmp227_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp227_AST);
				match(DIV);
				mult_op_AST = currentAST.root;
				break;
			}
			case MOD:
			{
				AST tmp228_AST = null;
				tmp228_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp228_AST);
				match(MOD);
				mult_op_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_36_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = mult_op_AST;
	}
	
	public void unary_operator() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unary_operator_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case MINUS:
			{
				AST tmp229_AST = null;
				tmp229_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp229_AST);
				match(MINUS);
				unary_operator_AST = currentAST.root;
				break;
			}
			case PLUS:
			{
				AST tmp230_AST = null;
				tmp230_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp230_AST);
				match(PLUS);
				unary_operator_AST = currentAST.root;
				break;
			}
			case TILDE:
			{
				AST tmp231_AST = null;
				tmp231_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp231_AST);
				match(TILDE);
				unary_operator_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_38_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = unary_operator_AST;
	}
	
	public string  primary_expr() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST primary_expr_AST = null;
		AST sn_AST = null;
		AST l_AST = null;
		
				string c;
				s = string.Empty; 
			
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case SCOPEOP:
			case LITERAL_handle:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case IDENT:
			{
				scoped_name();
				if (0 == inputState.guessing)
				{
					sn_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					s = sn_AST.getText();
				}
				primary_expr_AST = currentAST.root;
				break;
			}
			case LITERAL_TRUE:
			case LITERAL_true:
			case LITERAL_FALSE:
			case LITERAL_false:
			case INT:
			case HEX:
			case OCTAL:
			case LITERAL_L:
			case STRING_LITERAL:
			case CHAR_LITERAL:
			{
				literal();
				if (0 == inputState.guessing)
				{
					l_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					s = l_AST.getText();
				}
				primary_expr_AST = currentAST.root;
				break;
			}
			case LPAREN:
			{
				AST tmp232_AST = null;
				tmp232_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp232_AST);
				match(LPAREN);
				c=const_exp();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp233_AST = null;
				tmp233_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp233_AST);
				match(RPAREN);
				if (0==inputState.guessing)
				{
					s = "(" + c + ")";
				}
				primary_expr_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = primary_expr_AST;
		return s;
	}
	
	public void literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT:
			case HEX:
			case OCTAL:
			{
				floating_pt_or_integer_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				literal_AST = currentAST.root;
				break;
			}
			case LITERAL_TRUE:
			case LITERAL_true:
			case LITERAL_FALSE:
			case LITERAL_false:
			{
				boolean_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				literal_AST = currentAST.root;
				break;
			}
			default:
				bool synPredMatched97 = false;
				if (((LA(1)==LITERAL_L||LA(1)==STRING_LITERAL)))
				{
					int _m97 = mark();
					synPredMatched97 = true;
					inputState.guessing++;
					try {
						{
							string_literal();
						}
					}
					catch (RecognitionException)
					{
						synPredMatched97 = false;
					}
					rewind(_m97);
					inputState.guessing--;
				}
				if ( synPredMatched97 )
				{
					string_literal();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					literal_AST = currentAST.root;
				}
				else if ((LA(1)==LITERAL_L||LA(1)==CHAR_LITERAL)) {
					character_literal();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					literal_AST = currentAST.root;
				}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			break; }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = literal_AST;
	}
	
	public void character_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST character_literal_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_L:
				{
					AST tmp234_AST = null;
					tmp234_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp234_AST);
					match(LITERAL_L);
					break;
				}
				case CHAR_LITERAL:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp235_AST = null;
			tmp235_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp235_AST);
			match(CHAR_LITERAL);
			character_literal_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = character_literal_AST;
	}
	
	public void floating_pt_or_integer_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST floating_pt_or_integer_literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT:
			{
				AST tmp236_AST = null;
				tmp236_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp236_AST);
				match(INT);
				{
					switch ( LA(1) )
					{
					case FLOAT:
					{
						AST tmp237_AST = null;
						tmp237_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp237_AST);
						match(FLOAT);
						break;
					}
					case SEMI:
					case RBRACKET:
					case RBRACE:
					case COMMA:
					case RPAREN:
					case COLON:
					case STAR:
					case OR:
					case XOR:
					case AND:
					case LSHIFT:
					case RSHIFT:
					case PLUS:
					case MINUS:
					case DIV:
					case MOD:
					case GT:
					case RANGE:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				floating_pt_or_integer_literal_AST = currentAST.root;
				break;
			}
			case OCTAL:
			{
				AST tmp238_AST = null;
				tmp238_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp238_AST);
				match(OCTAL);
				floating_pt_or_integer_literal_AST = currentAST.root;
				break;
			}
			case HEX:
			{
				AST tmp239_AST = null;
				tmp239_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp239_AST);
				match(HEX);
				floating_pt_or_integer_literal_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = floating_pt_or_integer_literal_AST;
	}
	
	public void boolean_literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_TRUE:
			{
				AST tmp240_AST = null;
				tmp240_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp240_AST);
				match(LITERAL_TRUE);
				boolean_literal_AST = currentAST.root;
				break;
			}
			case LITERAL_true:
			{
				AST tmp241_AST = null;
				tmp241_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp241_AST);
				match(LITERAL_true);
				boolean_literal_AST = currentAST.root;
				break;
			}
			case LITERAL_FALSE:
			{
				AST tmp242_AST = null;
				tmp242_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp242_AST);
				match(LITERAL_FALSE);
				boolean_literal_AST = currentAST.root;
				break;
			}
			case LITERAL_false:
			{
				AST tmp243_AST = null;
				tmp243_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp243_AST);
				match(LITERAL_false);
				boolean_literal_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_14_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = boolean_literal_AST;
	}
	
	public void positive_int_const() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST positive_int_const_AST = null;
		string s;
		
		try {      // for error handling
			s=const_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			positive_int_const_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_39_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = positive_int_const_AST;
	}
	
	public void type_attributes() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST type_attributes_AST = null;
		
		try {      // for error handling
			type_attribute();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp244_AST = null;
						tmp244_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp244_AST);
						match(COMMA);
						type_attribute();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop104_breakloop;
					}
					
				}
_loop104_breakloop:				;
			}    // ( ... )*
			type_attributes_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_6_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_attributes_AST;
	}
	
	public CodeTypeMember  type_declarator() //throws RecognitionException, TokenStreamException
{
		CodeTypeMember type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST type_declarator_AST = null;
		
				type = null; 
				string name;
				Hashtable attributes = new Hashtable();
			
		
		try {      // for error handling
			type=type_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			name=declarator_list(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
						#if DEBUG_IDLGRAMMAR
							System.Diagnostics.Debug.WriteLine(string.Format("typespec: {0}; {1}", type != null ? type.Name : "<empty>", name));
						#endif
							if (type.Name == string.Empty)
								type.Name = name;
						
			}
			type_declarator_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_declarator_AST;
		return type;
	}
	
	public CodeTypeDeclaration  struct_type() //throws RecognitionException, TokenStreamException
{
		CodeTypeDeclaration type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST struct_type_AST = null;
		AST name_AST = null;
		
				type = new CodeTypeDeclaration();
				type.IsStruct = true;
				// Add attribute: [StructLayout(LayoutKind.Sequential, Pack=4)]
				type.CustomAttributes.Add(new CodeAttributeDeclaration("StructLayout", 
					new CodeAttributeArgument(new CodeVariableReferenceExpression("LayoutKind.Sequential")),
					new CodeAttributeArgument("Pack", new CodePrimitiveExpression(4))));
			
		
		try {      // for error handling
			AST tmp245_AST = null;
			tmp245_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp245_AST);
			match(LITERAL_struct);
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					identifier();
					if (0 == inputState.guessing)
					{
						name_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case LBRACE:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp246_AST = null;
			tmp246_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp246_AST);
			match(LBRACE);
			{ // ( ... )+
				int _cnt153=0;
				for (;;)
				{
					if ((tokenSet_5_.member(LA(1))))
					{
						member(type.Members);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt153 >= 1) { goto _loop153_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt153++;
				}
_loop153_breakloop:				;
			}    // ( ... )+
			AST tmp247_AST = null;
			tmp247_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp247_AST);
			match(RBRACE);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==STAR))
					{
						AST tmp248_AST = null;
						tmp248_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp248_AST);
						match(STAR);
					}
					else
					{
						goto _loop155_breakloop;
					}
					
				}
_loop155_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				
							if (name_AST != null)
							{
								#if DEBUG_IDLGRAMMAR
								System.Console.WriteLine(string.Format("struct {0}", name_AST.getText()));
								#endif
								type.Name = name_AST.getText();
							}	
						
			}
			struct_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_40_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = struct_type_AST;
		return type;
	}
	
	public void union_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST union_type_AST = null;
		AST name_AST = null;
		
		try {      // for error handling
			AST tmp249_AST = null;
			tmp249_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp249_AST);
			match(LITERAL_union);
			identifier();
			if (0 == inputState.guessing)
			{
				name_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_switch:
				{
					AST tmp250_AST = null;
					tmp250_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp250_AST);
					match(LITERAL_switch);
					AST tmp251_AST = null;
					tmp251_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp251_AST);
					match(LPAREN);
					switch_type_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					identifier();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp252_AST = null;
					tmp252_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp252_AST);
					match(RPAREN);
					{
						switch ( LA(1) )
						{
						case LITERAL_import:
						case LITERAL_uuid:
						case LITERAL_version:
						case LITERAL_object:
						case LITERAL_control:
						case LITERAL_entry:
						case LITERAL_hidden:
						case LITERAL_id:
						case LITERAL_message:
						case LITERAL_ref:
						case LITERAL_ptr:
						case LITERAL_scriptable:
						case LITERAL_jsval:
						case LITERAL_handle:
						case LITERAL_unique:
						case LITERAL_struct:
						case LITERAL_union:
						case LITERAL_callback:
						case LITERAL_retval:
						case LITERAL_range:
						case LITERAL_array:
						case LITERAL_source:
						case IDENT:
						{
							identifier();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							break;
						}
						case LBRACE:
						{
							break;
						}
						default:
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						 }
					}
					AST tmp253_AST = null;
					tmp253_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp253_AST);
					match(LBRACE);
					switch_body();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp254_AST = null;
					tmp254_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp254_AST);
					match(RBRACE);
					break;
				}
				case LBRACE:
				{
					AST tmp255_AST = null;
					tmp255_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp255_AST);
					match(LBRACE);
					n_e_case_list();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp256_AST = null;
					tmp256_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp256_AST);
					match(RBRACE);
					break;
				}
				case SEMI:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
				
							if (name_AST != null)
							{
								#if DEBUG_IDLGRAMMAR
								System.Console.WriteLine(string.Format("union {0}", name_AST.getText()));
								#endif
								CodeTypeDeclaration type = new CodeTypeDeclaration();
								type.IsStruct = true; // IsUnion does not exist
								type.Name = name_AST.getText();
								m_Namespace.UserData[type.Name] = type;
							}	
						
			}
			union_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_40_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = union_type_AST;
	}
	
	public CodeTypeDeclaration  enum_type() //throws RecognitionException, TokenStreamException
{
		CodeTypeDeclaration type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST enum_type_AST = null;
		AST name_AST = null;
		
				type = new CodeTypeDeclaration();
				type.IsEnum = true;
				string name = string.Empty;
			
		
		try {      // for error handling
			AST tmp257_AST = null;
			tmp257_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp257_AST);
			match(LITERAL_enum);
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					identifier();
					if (0 == inputState.guessing)
					{
						name_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						if (name_AST != null) name = name_AST.getText();
					}
					break;
				}
				case LBRACE:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp258_AST = null;
			tmp258_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp258_AST);
			match(LBRACE);
			enumerator_list(name, type.Members);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp259_AST = null;
			tmp259_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp259_AST);
			match(RBRACE);
			if (0==inputState.guessing)
			{
				
							if (name_AST != null)
							{
								#if DEBUG_IDLGRAMMAR
								System.Console.WriteLine(string.Format("enum {0}", name_AST.getText()));
								#endif
								type.Name = name_AST.getText();
							}	
						
			}
			enum_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_41_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = enum_type_AST;
		return type;
	}
	
	public string  declarator(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declarator_AST = null;
		AST i_AST = null;
		
				s = string.Empty; 
				string f = string.Empty;
				List<string> arraySize = new List<string>();
			
		
		try {      // for error handling
			identifier();
			if (0 == inputState.guessing)
			{
				i_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==LBRACKET))
					{
						f=fixed_array_size();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							arraySize.Add(f);
						}
					}
					else
					{
						goto _loop149_breakloop;
					}
					
				}
_loop149_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				
						#if DEBUG_IDLGRAMMAR
							System.Diagnostics.Debug.WriteLine("declarator: " + i_AST.getText());
						#endif
							s = i_AST.getText();
							
							if (arraySize.Count > 0)
								attributes.Add("IsArray", arraySize);
						
			}
			declarator_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_42_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = declarator_AST;
		return s;
	}
	
	public void type_attribute() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST type_attribute_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_context_handle:
			{
				AST tmp260_AST = null;
				tmp260_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp260_AST);
				match(LITERAL_context_handle);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_handle:
			{
				AST tmp261_AST = null;
				tmp261_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp261_AST);
				match(LITERAL_handle);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_pipe:
			{
				AST tmp262_AST = null;
				tmp262_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp262_AST);
				match(LITERAL_pipe);
				type_attribute_AST = currentAST.root;
				break;
			}
			case V1_ENUM:
			{
				AST tmp263_AST = null;
				tmp263_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp263_AST);
				match(V1_ENUM);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_transmit_as:
			{
				AST tmp264_AST = null;
				tmp264_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp264_AST);
				match(LITERAL_transmit_as);
				AST tmp265_AST = null;
				tmp265_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp265_AST);
				match(LPAREN);
				simple_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp266_AST = null;
				tmp266_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp266_AST);
				match(RPAREN);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_wire_marshal:
			{
				AST tmp267_AST = null;
				tmp267_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp267_AST);
				match(LITERAL_wire_marshal);
				AST tmp268_AST = null;
				tmp268_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp268_AST);
				match(LPAREN);
				simple_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp269_AST = null;
				tmp269_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp269_AST);
				match(RPAREN);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_represent_as:
			{
				AST tmp270_AST = null;
				tmp270_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp270_AST);
				match(LITERAL_represent_as);
				AST tmp271_AST = null;
				tmp271_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp271_AST);
				match(LPAREN);
				simple_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp272_AST = null;
				tmp272_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp272_AST);
				match(RPAREN);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_user_marshal:
			{
				AST tmp273_AST = null;
				tmp273_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp273_AST);
				match(LITERAL_user_marshal);
				AST tmp274_AST = null;
				tmp274_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp274_AST);
				match(LPAREN);
				simple_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp275_AST = null;
				tmp275_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp275_AST);
				match(RPAREN);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_public:
			{
				AST tmp276_AST = null;
				tmp276_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp276_AST);
				match(LITERAL_public);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_string:
			{
				string_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_switch_type:
			{
				AST tmp277_AST = null;
				tmp277_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp277_AST);
				match(LITERAL_switch_type);
				AST tmp278_AST = null;
				tmp278_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp278_AST);
				match(LPAREN);
				switch_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp279_AST = null;
				tmp279_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp279_AST);
				match(RPAREN);
				type_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_unique:
			{
				ptr_attr();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				type_attribute_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_attribute_AST;
	}
	
	public void simple_type_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST simple_type_spec_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT3264:
			case INT64:
			case LITERAL_native:
			case LITERAL_signed:
			case LITERAL_unsigned:
			case LITERAL_octet:
			case LITERAL_any:
			case LITERAL_void:
			case LITERAL_byte:
			case LITERAL_wchar_t:
			case LITERAL_handle_t:
			case LITERAL_small:
			case LITERAL_short:
			case LITERAL_long:
			case LITERAL_int:
			case LITERAL_hyper:
			case LITERAL_char:
			case LITERAL_float:
			case LITERAL_double:
			case LITERAL_boolean:
			{
				base_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				simple_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_sequence:
			case LITERAL_string:
			{
				template_type_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				simple_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case SCOPEOP:
			case LITERAL_handle:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case IDENT:
			{
				scoped_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==STAR))
						{
							AST tmp280_AST = null;
							tmp280_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp280_AST);
							match(STAR);
						}
						else
						{
							goto _loop112_breakloop;
						}
						
					}
_loop112_breakloop:					;
				}    // ( ... )*
				simple_type_spec_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_43_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = simple_type_spec_AST;
	}
	
	public void switch_type_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST switch_type_spec_AST = null;
		CodeTypeDeclaration type;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case INT3264:
			case INT64:
			case LITERAL_signed:
			case LITERAL_unsigned:
			case LITERAL_octet:
			case LITERAL_small:
			case LITERAL_short:
			case LITERAL_long:
			case LITERAL_int:
			case LITERAL_hyper:
			case LITERAL_char:
			{
				{
					switch ( LA(1) )
					{
					case LITERAL_signed:
					{
						AST tmp281_AST = null;
						tmp281_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp281_AST);
						match(LITERAL_signed);
						break;
					}
					case LITERAL_unsigned:
					{
						AST tmp282_AST = null;
						tmp282_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp282_AST);
						match(LITERAL_unsigned);
						break;
					}
					case INT3264:
					case INT64:
					case LITERAL_octet:
					case LITERAL_small:
					case LITERAL_short:
					case LITERAL_long:
					case LITERAL_int:
					case LITERAL_hyper:
					case LITERAL_char:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				{
					switch ( LA(1) )
					{
					case INT3264:
					case INT64:
					case LITERAL_octet:
					case LITERAL_small:
					case LITERAL_short:
					case LITERAL_long:
					case LITERAL_int:
					case LITERAL_hyper:
					{
						integer_type();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case LITERAL_char:
					{
						char_type();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				switch_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_boolean:
			{
				boolean_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				switch_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_enum:
			{
				type=enum_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				switch_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case SCOPEOP:
			case LITERAL_handle:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case IDENT:
			{
				scoped_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				switch_type_spec_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_44_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = switch_type_spec_AST;
	}
	
	public CodeTypeMember  type_spec() //throws RecognitionException, TokenStreamException
{
		CodeTypeMember type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST type_spec_AST = null;
		AST s_AST = null;
		type = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					AST tmp283_AST = null;
					tmp283_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp283_AST);
					match(LITERAL_const);
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_sequence:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				if ((tokenSet_45_.member(LA(1))))
				{
					simple_type_spec();
					if (0 == inputState.guessing)
					{
						s_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
										type = new CodeMemberField(); 
										((CodeMemberField)type).Type = m_Conv.ConvertParamType(s_AST.getText(), null, new Hashtable());
										type.Attributes = (type.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
									
					}
				}
				else if ((LA(1)==LITERAL_struct||LA(1)==LITERAL_union||LA(1)==LITERAL_enum)) {
					type=constr_type_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			type_spec_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_40_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_spec_AST;
		return type;
	}
	
	public string  declarator_list(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST declarator_list_AST = null;
		
				string ignored;
				s = string.Empty;
			
		
		try {      // for error handling
			s=declarator(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp284_AST = null;
						tmp284_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp284_AST);
						match(COMMA);
						{    // ( ... )*
							for (;;)
							{
								if ((LA(1)==STAR))
								{
									AST tmp285_AST = null;
									tmp285_AST = astFactory.create(LT(1));
									astFactory.addASTChild(ref currentAST, tmp285_AST);
									match(STAR);
								}
								else
								{
									goto _loop145_breakloop;
								}
								
							}
_loop145_breakloop:							;
						}    // ( ... )*
						ignored=declarator(attributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop146_breakloop;
					}
					
				}
_loop146_breakloop:				;
			}    // ( ... )*
			declarator_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = declarator_list_AST;
		return s;
	}
	
	public CodeTypeDeclaration  constr_type_spec() //throws RecognitionException, TokenStreamException
{
		CodeTypeDeclaration type;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST constr_type_spec_AST = null;
		type = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_struct:
			{
				type=struct_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				constr_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_union:
			{
				union_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				constr_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_enum:
			{
				type=enum_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				constr_type_spec_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_40_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = constr_type_spec_AST;
		return type;
	}
	
	public void template_type_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST template_type_spec_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_sequence:
			{
				sequence_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				template_type_spec_AST = currentAST.root;
				break;
			}
			case LITERAL_string:
			{
				string_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				template_type_spec_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_43_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = template_type_spec_AST;
	}
	
	public void integer_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST integer_type_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_octet:
				{
					AST tmp286_AST = null;
					tmp286_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp286_AST);
					match(LITERAL_octet);
					break;
				}
				case LITERAL_small:
				{
					AST tmp287_AST = null;
					tmp287_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp287_AST);
					match(LITERAL_small);
					break;
				}
				case LITERAL_short:
				{
					AST tmp288_AST = null;
					tmp288_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp288_AST);
					match(LITERAL_short);
					break;
				}
				case LITERAL_long:
				{
					{ // ( ... )+
						int _cnt135=0;
						for (;;)
						{
							if ((LA(1)==LITERAL_long))
							{
								AST tmp289_AST = null;
								tmp289_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp289_AST);
								match(LITERAL_long);
							}
							else
							{
								if (_cnt135 >= 1) { goto _loop135_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
							}
							
							_cnt135++;
						}
_loop135_breakloop:						;
					}    // ( ... )+
					break;
				}
				case LITERAL_int:
				{
					AST tmp290_AST = null;
					tmp290_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp290_AST);
					match(LITERAL_int);
					break;
				}
				case LITERAL_hyper:
				{
					AST tmp291_AST = null;
					tmp291_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp291_AST);
					match(LITERAL_hyper);
					break;
				}
				case INT3264:
				{
					AST tmp292_AST = null;
					tmp292_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp292_AST);
					match(INT3264);
					break;
				}
				case INT64:
				{
					AST tmp293_AST = null;
					tmp293_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp293_AST);
					match(INT64);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_int:
				{
					AST tmp294_AST = null;
					tmp294_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp294_AST);
					match(LITERAL_int);
					break;
				}
				case SEMI:
				case LITERAL_import:
				case COMMA:
				case LITERAL_uuid:
				case LITERAL_version:
				case RPAREN:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_const:
				case STAR:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case GT:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			integer_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_46_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = integer_type_AST;
	}
	
	public void char_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_type_AST = null;
		
		try {      // for error handling
			AST tmp295_AST = null;
			tmp295_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp295_AST);
			match(LITERAL_char);
			char_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_46_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = char_type_AST;
	}
	
	public void boolean_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_type_AST = null;
		
		try {      // for error handling
			AST tmp296_AST = null;
			tmp296_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp296_AST);
			match(LITERAL_boolean);
			boolean_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_46_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = boolean_type_AST;
	}
	
	public void floating_pt_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST floating_pt_type_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_float:
			{
				AST tmp297_AST = null;
				tmp297_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp297_AST);
				match(LITERAL_float);
				floating_pt_type_AST = currentAST.root;
				break;
			}
			case LITERAL_double:
			{
				AST tmp298_AST = null;
				tmp298_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp298_AST);
				match(LITERAL_double);
				floating_pt_type_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_46_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = floating_pt_type_AST;
	}
	
	public void attr_vars() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST attr_vars_AST = null;
		
		try {      // for error handling
			attr_var();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp299_AST = null;
						tmp299_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp299_AST);
						match(COMMA);
						attr_var();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop126_breakloop;
					}
					
				}
_loop126_breakloop:				;
			}    // ( ... )*
			attr_vars_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_18_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attr_vars_AST;
	}
	
	public void attr_var() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST attr_var_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case STAR:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					{
						{
							switch ( LA(1) )
							{
							case STAR:
							{
								AST tmp300_AST = null;
								tmp300_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp300_AST);
								match(STAR);
								break;
							}
							case LITERAL_import:
							case LITERAL_uuid:
							case LITERAL_version:
							case LITERAL_object:
							case LITERAL_control:
							case LITERAL_entry:
							case LITERAL_hidden:
							case LITERAL_id:
							case LITERAL_message:
							case LITERAL_ref:
							case LITERAL_ptr:
							case LITERAL_scriptable:
							case LITERAL_jsval:
							case LITERAL_handle:
							case LITERAL_unique:
							case LITERAL_struct:
							case LITERAL_union:
							case LITERAL_callback:
							case LITERAL_retval:
							case LITERAL_range:
							case LITERAL_array:
							case LITERAL_source:
							case IDENT:
							{
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						identifier();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					break;
				}
				case INT:
				{
					AST tmp301_AST = null;
					tmp301_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp301_AST);
					match(INT);
					break;
				}
				case HEX:
				{
					AST tmp302_AST = null;
					tmp302_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp302_AST);
					match(HEX);
					break;
				}
				case COMMA:
				case RPAREN:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			attr_var_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_19_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attr_var_AST;
	}
	
	public void sequence_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sequence_type_AST = null;
		
		try {      // for error handling
			AST tmp303_AST = null;
			tmp303_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp303_AST);
			match(LITERAL_sequence);
			AST tmp304_AST = null;
			tmp304_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp304_AST);
			match(LT_);
			simple_type_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			opt_pos_int();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp305_AST = null;
			tmp305_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp305_AST);
			match(GT);
			sequence_type_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_43_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = sequence_type_AST;
	}
	
	public string  fixed_array_size() //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST fixed_array_size_AST = null;
		AST bounds_AST = null;
		s = string.Empty;
		
		try {      // for error handling
			AST tmp306_AST = null;
			tmp306_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp306_AST);
			match(LBRACKET);
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LPAREN:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case STAR:
				case PLUS:
				case MINUS:
				case TILDE:
				case LITERAL_TRUE:
				case LITERAL_true:
				case LITERAL_FALSE:
				case LITERAL_false:
				case LITERAL_handle:
				case INT:
				case HEX:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case OCTAL:
				case LITERAL_L:
				case STRING_LITERAL:
				case CHAR_LITERAL:
				case IDENT:
				{
					array_bounds();
					if (0 == inputState.guessing)
					{
						bounds_AST = (AST)returnAST;
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case RBRACKET:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp307_AST = null;
			tmp307_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp307_AST);
			match(RBRACKET);
			if (0==inputState.guessing)
			{
				
							if (bounds_AST != null)
								s = bounds_AST.getText();
						
			}
			fixed_array_size_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_47_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = fixed_array_size_AST;
		return s;
	}
	
	public void member(
		CodeTypeMemberCollection members
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST member_AST = null;
		
				Hashtable attributes = new Hashtable();
				CodeTypeMember type;
				string name;
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LBRACKET:
				{
					field_attribute_list(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_sequence:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			type=type_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			name=declarator_list(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp308_AST = null;
			tmp308_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp308_AST);
			match(SEMI);
			if (0==inputState.guessing)
			{
				
							if (type != null && name != string.Empty)
							{
								if (attributes["IsArray"] != null)
								{
									List<string> arraySizes = (List<string>)attributes["IsArray"];
									if (arraySizes.Count > 1)
									{
										Console.WriteLine(string.Format("Can't handle multi dimensional arrays: {0}",
											name));
									}
				
									if (arraySizes.Count == 1)
									{
										// Add attribute: [MarshalAs(UnmanagedType.ByValArray, SizeConst=x)]
										int val;
										if (int.TryParse(arraySizes[0], out val))
										{
											if (type is CodeMemberField)
												((CodeMemberField)type).Type.ArrayRank = 1;
											else
												Console.WriteLine(string.Format("Unhandled type: {0}", type.GetType()));
				
											type.CustomAttributes.Add(new CodeAttributeDeclaration("MarshalAs",
												new CodeAttributeArgument(
													new CodeSnippetExpression("UnmanagedType.ByValArray")),
												new CodeAttributeArgument("SizeConst",
													new CodePrimitiveExpression(val))));
										}
										else
										{
											Console.WriteLine(string.Format("Can't handle array dimension spec: '{0}' for {1}",
												arraySizes[0], name));
										}
									}
									attributes.Remove("IsArray");
								}
				
								type.Name = name;
								members.Add(type);
							}
						
			}
			member_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_48_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = member_AST;
	}
	
	public void field_attribute_list(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST field_attribute_list_AST = null;
		
		try {      // for error handling
			AST tmp309_AST = null;
			tmp309_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp309_AST);
			match(LBRACKET);
			field_attribute(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp310_AST = null;
						tmp310_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp310_AST);
						match(COMMA);
						field_attribute(attributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop248_breakloop;
					}
					
				}
_loop248_breakloop:				;
			}    // ( ... )*
			AST tmp311_AST = null;
			tmp311_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp311_AST);
			match(RBRACKET);
			field_attribute_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_49_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = field_attribute_list_AST;
	}
	
	public void switch_body() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST switch_body_AST = null;
		
		try {      // for error handling
			case_stmt_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			switch_body_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = switch_body_AST;
	}
	
	public void n_e_case_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST n_e_case_list_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt167=0;
				for (;;)
				{
					if ((LA(1)==LBRACKET))
					{
						n_e_case_stmt();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt167 >= 1) { goto _loop167_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt167++;
				}
_loop167_breakloop:				;
			}    // ( ... )+
			n_e_case_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = n_e_case_list_AST;
	}
	
	public void case_stmt_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_stmt_list_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt174=0;
				for (;;)
				{
					if ((LA(1)==LITERAL_default||LA(1)==LITERAL_case))
					{
						case_stmt();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt174 >= 1) { goto _loop174_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt174++;
				}
_loop174_breakloop:				;
			}    // ( ... )+
			case_stmt_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = case_stmt_list_AST;
	}
	
	public void n_e_case_stmt() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST n_e_case_stmt_AST = null;
		
		try {      // for error handling
			n_e_case_label();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case INT3264:
				case INT64:
				case LBRACKET:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_sequence:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					unnamed_element_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case SEMI:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp312_AST = null;
			tmp312_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp312_AST);
			match(SEMI);
			n_e_case_stmt_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_50_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = n_e_case_stmt_AST;
	}
	
	public void n_e_case_label() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST n_e_case_label_AST = null;
		string ignored;
		
		try {      // for error handling
			AST tmp313_AST = null;
			tmp313_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp313_AST);
			match(LBRACKET);
			{
				switch ( LA(1) )
				{
				case LITERAL_case:
				{
					AST tmp314_AST = null;
					tmp314_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp314_AST);
					match(LITERAL_case);
					AST tmp315_AST = null;
					tmp315_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp315_AST);
					match(LPAREN);
					ignored=const_exp();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp316_AST = null;
					tmp316_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp316_AST);
					match(RPAREN);
					break;
				}
				case LITERAL_default:
				{
					AST tmp317_AST = null;
					tmp317_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp317_AST);
					match(LITERAL_default);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp318_AST = null;
			tmp318_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp318_AST);
			match(RBRACKET);
			n_e_case_label_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_51_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = n_e_case_label_AST;
	}
	
	public void unnamed_element_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unnamed_element_spec_AST = null;
		
				Hashtable attributes = new Hashtable(); 
				CodeTypeMember type;
				string ignored;
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LBRACKET:
				{
					field_attribute_list(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_sequence:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			type=type_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					ignored=declarator(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case SEMI:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			unnamed_element_spec_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = unnamed_element_spec_AST;
	}
	
	public void case_stmt() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_stmt_AST = null;
		
		try {      // for error handling
			case_label_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			unnamed_element_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp319_AST = null;
			tmp319_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp319_AST);
			match(SEMI);
			case_stmt_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_52_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = case_stmt_AST;
	}
	
	public void case_label_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_label_list_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt178=0;
				for (;;)
				{
					if ((LA(1)==LITERAL_default||LA(1)==LITERAL_case))
					{
						case_label();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						if (_cnt178 >= 1) { goto _loop178_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt178++;
				}
_loop178_breakloop:				;
			}    // ( ... )+
			case_label_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_5_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = case_label_list_AST;
	}
	
	public void case_label() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_label_AST = null;
		string ignored;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_case:
			{
				AST tmp320_AST = null;
				tmp320_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp320_AST);
				match(LITERAL_case);
				ignored=const_exp();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp321_AST = null;
				tmp321_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp321_AST);
				match(COLON);
				case_label_AST = currentAST.root;
				break;
			}
			case LITERAL_default:
			{
				AST tmp322_AST = null;
				tmp322_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp322_AST);
				match(LITERAL_default);
				AST tmp323_AST = null;
				tmp323_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp323_AST);
				match(COLON);
				case_label_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_53_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = case_label_AST;
	}
	
	public void element_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST element_spec_AST = null;
		
				Hashtable attributes = new Hashtable(); 
				CodeTypeMember type;	
				string ignored;
			
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LBRACKET:
				{
					field_attribute_list(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_const:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_enum:
				case LITERAL_sequence:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			type=type_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			ignored=declarator(attributes);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			element_spec_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = element_spec_AST;
	}
	
	public void enumerator_list(
		string enumName, CodeTypeMemberCollection members
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST enumerator_list_AST = null;
		
				string s1 = string.Empty; 
				string s2 = string.Empty;
				string expr1 = string.Empty;
				string expr2 = string.Empty;
			
		
		try {      // for error handling
			s1=enumerator(ref expr1);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp324_AST = null;
						tmp324_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp324_AST);
						match(COMMA);
						s2=enumerator(ref expr2);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
												members.Add(IDLConversions.CreateEnumMember(enumName, s1, expr1));
												s1 = s2;
												expr1 = expr2;
											
						}
					}
					else
					{
						goto _loop189_breakloop;
					}
					
				}
_loop189_breakloop:				;
			}    // ( ... )*
			if (0==inputState.guessing)
			{
				
							if (s1 != string.Empty)
								members.Add(IDLConversions.CreateEnumMember(enumName, s1, expr1));
						
			}
			enumerator_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = enumerator_list_AST;
	}
	
	public string  enumerator(
		ref string e
	) //throws RecognitionException, TokenStreamException
{
		string s;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST enumerator_AST = null;
		AST name_AST = null;
		
				s = string.Empty; 
				e = string.Empty;
			
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case LITERAL_handle:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case IDENT:
			{
				identifier();
				if (0 == inputState.guessing)
				{
					name_AST = (AST)returnAST;
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					switch ( LA(1) )
					{
					case ASSIGN:
					{
						AST tmp325_AST = null;
						tmp325_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp325_AST);
						match(ASSIGN);
						e=const_exp();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case RBRACE:
					case COMMA:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				if (0==inputState.guessing)
				{
					
								s = name_AST.getText();
							
				}
				enumerator_AST = currentAST.root;
				break;
			}
			case RBRACE:
			case COMMA:
			{
				enumerator_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_54_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = enumerator_AST;
		return s;
	}
	
	public void enumerator_value() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST enumerator_value_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case MINUS:
				{
					AST tmp326_AST = null;
					tmp326_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp326_AST);
					match(MINUS);
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case INT:
				case HEX:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				switch ( LA(1) )
				{
				case INT:
				{
					AST tmp327_AST = null;
					tmp327_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp327_AST);
					match(INT);
					break;
				}
				case HEX:
				{
					AST tmp328_AST = null;
					tmp328_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp328_AST);
					match(HEX);
					break;
				}
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					identifier();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			enumerator_value_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = enumerator_value_AST;
	}
	
	public void opt_pos_int() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST opt_pos_int_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case COMMA:
				{
					AST tmp329_AST = null;
					tmp329_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp329_AST);
					match(COMMA);
					positive_int_const();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case GT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			opt_pos_int_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_55_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = opt_pos_int_AST;
	}
	
	public void array_bounds() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST array_bounds_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_import:
			case LITERAL_uuid:
			case LITERAL_version:
			case LPAREN:
			case LITERAL_object:
			case LITERAL_control:
			case LITERAL_entry:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_message:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_scriptable:
			case LITERAL_jsval:
			case SCOPEOP:
			case PLUS:
			case MINUS:
			case TILDE:
			case LITERAL_TRUE:
			case LITERAL_true:
			case LITERAL_FALSE:
			case LITERAL_false:
			case LITERAL_handle:
			case INT:
			case HEX:
			case LITERAL_unique:
			case LITERAL_struct:
			case LITERAL_union:
			case LITERAL_callback:
			case LITERAL_retval:
			case LITERAL_range:
			case LITERAL_array:
			case LITERAL_source:
			case OCTAL:
			case LITERAL_L:
			case STRING_LITERAL:
			case CHAR_LITERAL:
			case IDENT:
			{
				array_bound();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					switch ( LA(1) )
					{
					case RANGE:
					{
						AST tmp330_AST = null;
						tmp330_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp330_AST);
						match(RANGE);
						array_bound();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						break;
					}
					case RBRACKET:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				array_bounds_AST = currentAST.root;
				break;
			}
			case STAR:
			{
				AST tmp331_AST = null;
				tmp331_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp331_AST);
				match(STAR);
				array_bounds_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_6_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = array_bounds_AST;
	}
	
	public void array_bound() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST array_bound_AST = null;
		
		try {      // for error handling
			positive_int_const();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			array_bound_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_56_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = array_bound_AST;
	}
	
	public void raises() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST raises_AST = null;
		
		try {      // for error handling
			AST tmp332_AST = null;
			tmp332_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp332_AST);
			match(LITERAL_raises);
			match(LPAREN);
			identifier();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp334_AST = null;
						tmp334_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp334_AST);
						match(COMMA);
						identifier();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop222_breakloop;
					}
					
				}
_loop222_breakloop:				;
			}    // ( ... )*
			match(RPAREN);
			raises_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = raises_AST;
	}
	
	public void function_attribute(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST function_attribute_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_callback:
			{
				AST tmp336_AST = null;
				tmp336_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp336_AST);
				match(LITERAL_callback);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_broadcast:
			{
				AST tmp337_AST = null;
				tmp337_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp337_AST);
				match(LITERAL_broadcast);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_string:
			{
				string_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_ignore:
			{
				AST tmp338_AST = null;
				tmp338_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp338_AST);
				match(LITERAL_ignore);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_context_handle:
			{
				AST tmp339_AST = null;
				tmp339_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp339_AST);
				match(LITERAL_context_handle);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_notxpcom:
			{
				AST tmp340_AST = null;
				tmp340_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp340_AST);
				match(LITERAL_notxpcom);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_propget:
			{
				AST tmp341_AST = null;
				tmp341_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp341_AST);
				match(LITERAL_propget);
				if (0==inputState.guessing)
				{
					
								attributes.Add("propget", new CodeAttributeArgument());
							
				}
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_propput:
			{
				AST tmp342_AST = null;
				tmp342_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp342_AST);
				match(LITERAL_propput);
				if (0==inputState.guessing)
				{
					
								attributes.Add("propput", new CodeAttributeArgument());
							
				}
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_propputref:
			{
				AST tmp343_AST = null;
				tmp343_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp343_AST);
				match(LITERAL_propputref);
				if (0==inputState.guessing)
				{
					
								attributes.Add("propputref", new CodeAttributeArgument());
							
				}
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_uidefault:
			{
				AST tmp344_AST = null;
				tmp344_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp344_AST);
				match(LITERAL_uidefault);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_usesgetlasterror:
			{
				AST tmp345_AST = null;
				tmp345_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp345_AST);
				match(LITERAL_usesgetlasterror);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_vararg:
			{
				AST tmp346_AST = null;
				tmp346_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp346_AST);
				match(LITERAL_vararg);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_optional_argc:
			{
				AST tmp347_AST = null;
				tmp347_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp347_AST);
				match(LITERAL_optional_argc);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_implicit_jscontext:
			{
				AST tmp348_AST = null;
				tmp348_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp348_AST);
				match(LITERAL_implicit_jscontext);
				function_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_binaryname:
			{
				AST tmp349_AST = null;
				tmp349_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp349_AST);
				match(LITERAL_binaryname);
				match(LPAREN);
				identifier();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				match(RPAREN);
				function_attribute_AST = currentAST.root;
				break;
			}
			default:
				if ((LA(1)==LITERAL_ref||LA(1)==LITERAL_ptr||LA(1)==LITERAL_unique))
				{
					ptr_attr();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					function_attribute_AST = currentAST.root;
				}
				else if ((tokenSet_57_.member(LA(1)))) {
					attribute(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					function_attribute_AST = currentAST.root;
				}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			break; }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = function_attribute_AST;
	}
	
	public CodeParameterDeclarationExpression  param_dcl() //throws RecognitionException, TokenStreamException
{
		CodeParameterDeclarationExpression param;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST param_dcl_AST = null;
		AST strType_AST = null;
		
				param = new CodeParameterDeclarationExpression(); 
				Hashtable attributes = new Hashtable();
				string name = string.Empty;
			
		
		try {      // for error handling
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==LBRACKET))
					{
						AST tmp352_AST = null;
						tmp352_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp352_AST);
						match(LBRACKET);
						param_attributes(attributes);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp353_AST = null;
						tmp353_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp353_AST);
						match(RBRACKET);
					}
					else
					{
						goto _loop235_breakloop;
					}
					
				}
_loop235_breakloop:				;
			}    // ( ... )*
			param_nonattribute_modifiers();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			param_type_spec();
			if (0 == inputState.guessing)
			{
				strType_AST = (AST)returnAST;
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					AST tmp354_AST = null;
					tmp354_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp354_AST);
					match(LITERAL_const);
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==STAR))
							{
								AST tmp355_AST = null;
								tmp355_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp355_AST);
								match(STAR);
							}
							else
							{
								goto _loop238_breakloop;
							}
							
						}
_loop238_breakloop:						;
					}    // ( ... )*
					break;
				}
				case LITERAL_import:
				case COMMA:
				case LITERAL_uuid:
				case LITERAL_version:
				case RPAREN:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case LITERAL_handle:
				case LITERAL_unique:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case IDENT:
				{
					name=declarator(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case COMMA:
				case RPAREN:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
				
							string str = null;
							if (strType_AST != null && name != string.Empty) 
							{
								str = strType_AST.ToStringList();
								param.Name = IDLConversions.ConvertParamName(name);
								param.Type = m_Conv.ConvertParamType(str, param, attributes);
							}
						
			}
			param_dcl_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_19_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = param_dcl_AST;
		return param;
	}
	
	public void param_nonattribute_modifiers() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST param_nonattribute_modifiers_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_const:
				{
					AST tmp356_AST = null;
					tmp356_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp356_AST);
					match(LITERAL_const);
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_in:
				case LITERAL_out:
				case LITERAL_inout:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case LITERAL_SAFEARRAY:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			{
				switch ( LA(1) )
				{
				case LITERAL_in:
				{
					{
						AST tmp357_AST = null;
						tmp357_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp357_AST);
						match(LITERAL_in);
					}
					break;
				}
				case LITERAL_out:
				{
					{
						AST tmp358_AST = null;
						tmp358_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp358_AST);
						match(LITERAL_out);
					}
					break;
				}
				case LITERAL_inout:
				{
					{
						AST tmp359_AST = null;
						tmp359_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp359_AST);
						match(LITERAL_inout);
					}
					break;
				}
				case INT3264:
				case INT64:
				case LITERAL_import:
				case LITERAL_uuid:
				case LITERAL_version:
				case LITERAL_object:
				case LITERAL_control:
				case LITERAL_entry:
				case LITERAL_hidden:
				case LITERAL_id:
				case LITERAL_message:
				case LITERAL_ref:
				case LITERAL_ptr:
				case LITERAL_scriptable:
				case LITERAL_jsval:
				case SCOPEOP:
				case LITERAL_native:
				case LITERAL_handle:
				case LITERAL_signed:
				case LITERAL_unsigned:
				case LITERAL_octet:
				case LITERAL_any:
				case LITERAL_void:
				case LITERAL_byte:
				case LITERAL_wchar_t:
				case LITERAL_handle_t:
				case LITERAL_unique:
				case LITERAL_small:
				case LITERAL_short:
				case LITERAL_long:
				case LITERAL_int:
				case LITERAL_hyper:
				case LITERAL_char:
				case LITERAL_float:
				case LITERAL_double:
				case LITERAL_boolean:
				case LITERAL_struct:
				case LITERAL_union:
				case LITERAL_string:
				case LITERAL_callback:
				case LITERAL_retval:
				case LITERAL_range:
				case LITERAL_array:
				case LITERAL_source:
				case LITERAL_SAFEARRAY:
				case IDENT:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			param_nonattribute_modifiers_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_58_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = param_nonattribute_modifiers_AST;
	}
	
	public void param_attributes(
		IDictionary param
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST param_attributes_AST = null;
		
		try {      // for error handling
			param_attribute(param);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp360_AST = null;
						tmp360_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp360_AST);
						match(COMMA);
						param_attribute(param);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop242_breakloop;
					}
					
				}
_loop242_breakloop:				;
			}    // ( ... )*
			param_attributes_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_6_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = param_attributes_AST;
	}
	
	public void param_attribute(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST param_attribute_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_in:
			{
				AST tmp361_AST = null;
				tmp361_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp361_AST);
				match(LITERAL_in);
				if (0==inputState.guessing)
				{
					attributes["in"] = true;
				}
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_out:
			{
				AST tmp362_AST = null;
				tmp362_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp362_AST);
				match(LITERAL_out);
				if (0==inputState.guessing)
				{
					attributes["out"] = true;
				}
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_retval:
			{
				AST tmp363_AST = null;
				tmp363_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp363_AST);
				match(LITERAL_retval);
				if (0==inputState.guessing)
				{
					attributes["retval"] = true;
				}
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_defaultvalue:
			{
				AST tmp364_AST = null;
				tmp364_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp364_AST);
				match(LITERAL_defaultvalue);
				AST tmp365_AST = null;
				tmp365_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp365_AST);
				match(LPAREN);
				{ // ( ... )+
					int _cnt245=0;
					for (;;)
					{
						if ((tokenSet_12_.member(LA(1))))
						{
							AST tmp366_AST = null;
							tmp366_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp366_AST);
							matchNot(RPAREN);
						}
						else
						{
							if (_cnt245 >= 1) { goto _loop245_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
						}
						
						_cnt245++;
					}
_loop245_breakloop:					;
				}    // ( ... )+
				AST tmp367_AST = null;
				tmp367_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp367_AST);
				match(RPAREN);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_optional:
			{
				AST tmp368_AST = null;
				tmp368_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp368_AST);
				match(LITERAL_optional);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_readonly:
			{
				AST tmp369_AST = null;
				tmp369_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp369_AST);
				match(LITERAL_readonly);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_requestedit:
			{
				AST tmp370_AST = null;
				tmp370_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp370_AST);
				match(LITERAL_requestedit);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_iid_is:
			{
				AST tmp371_AST = null;
				tmp371_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp371_AST);
				match(LITERAL_iid_is);
				AST tmp372_AST = null;
				tmp372_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp372_AST);
				match(LPAREN);
				attr_vars();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp373_AST = null;
				tmp373_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp373_AST);
				match(RPAREN);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_range:
			{
				AST tmp374_AST = null;
				tmp374_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp374_AST);
				match(LITERAL_range);
				AST tmp375_AST = null;
				tmp375_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp375_AST);
				match(LPAREN);
				integer_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp376_AST = null;
				tmp376_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp376_AST);
				match(COMMA);
				integer_literal();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp377_AST = null;
				tmp377_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp377_AST);
				match(RPAREN);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_array:
			{
				AST tmp378_AST = null;
				tmp378_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp378_AST);
				match(LITERAL_array);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_const:
			{
				AST tmp379_AST = null;
				tmp379_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp379_AST);
				match(LITERAL_const);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_shared:
			{
				AST tmp380_AST = null;
				tmp380_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp380_AST);
				match(LITERAL_shared);
				param_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_uuid:
			case LITERAL_version:
			case LITERAL_async_uuid:
			case LITERAL_local:
			case LITERAL_object:
			case LITERAL_pointer_default:
			case LITERAL_endpoint:
			case LITERAL_odl:
			case LITERAL_optimize:
			case LITERAL_proxy:
			case LITERAL_aggregatable:
			case LITERAL_appobject:
			case LITERAL_bindable:
			case LITERAL_control:
			case LITERAL_custom:
			case LITERAL_default:
			case LITERAL_defaultbind:
			case LITERAL_defaultcollelem:
			case LITERAL_defaultvtable:
			case LITERAL_displaybind:
			case LITERAL_dllname:
			case LITERAL_dual:
			case LITERAL_entry:
			case LITERAL_helpcontext:
			case LITERAL_helpfile:
			case LITERAL_helpstring:
			case LITERAL_helpstringdll:
			case LITERAL_hidden:
			case LITERAL_id:
			case LITERAL_idempotent:
			case LITERAL_immediatebind:
			case LITERAL_lcid:
			case LITERAL_licensed:
			case LITERAL_message:
			case LITERAL_nonbrowsable:
			case LITERAL_noncreatable:
			case LITERAL_nonextensible:
			case LITERAL_oleautomation:
			case LITERAL_restricted:
			case LITERAL_ref:
			case LITERAL_ptr:
			case LITERAL_function:
			case LITERAL_scriptable:
			case LITERAL_deprecated:
			case LITERAL_Undefined:
			case LITERAL_noscript:
			case LITERAL_Null:
			case LITERAL_nsid:
			case LITERAL_domstring:
			case 68:
			case LITERAL_cstring:
			case LITERAL_astring:
			case LITERAL_jsval:
			case LITERAL_unique:
			case LITERAL_string:
			case LITERAL_ignore:
			case LITERAL_size_is:
			case LITERAL_max_is:
			case LITERAL_length_is:
			case LITERAL_first_is:
			case LITERAL_last_is:
			case LITERAL_switch_is:
			case LITERAL_source:
			{
				field_attribute(attributes);
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				param_attribute_AST = currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = param_attribute_AST;
	}
	
	public void field_attribute(
		IDictionary attributes
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST field_attribute_AST = null;
		string val;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_ignore:
			{
				AST tmp381_AST = null;
				tmp381_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp381_AST);
				match(LITERAL_ignore);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_size_is:
			{
				AST tmp382_AST = null;
				tmp382_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp382_AST);
				match(LITERAL_size_is);
				AST tmp383_AST = null;
				tmp383_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp383_AST);
				match(LPAREN);
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==STAR))
						{
							AST tmp384_AST = null;
							tmp384_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp384_AST);
							match(STAR);
						}
						else
						{
							goto _loop251_breakloop;
						}
						
					}
_loop251_breakloop:					;
				}    // ( ... )*
				val=const_exp();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp385_AST = null;
				tmp385_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp385_AST);
				match(RPAREN);
				if (0==inputState.guessing)
				{
					attributes.Add("size_is", val);
				}
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_max_is:
			{
				AST tmp386_AST = null;
				tmp386_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp386_AST);
				match(LITERAL_max_is);
				AST tmp387_AST = null;
				tmp387_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp387_AST);
				match(LPAREN);
				attr_vars();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp388_AST = null;
				tmp388_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp388_AST);
				match(RPAREN);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_length_is:
			{
				AST tmp389_AST = null;
				tmp389_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp389_AST);
				match(LITERAL_length_is);
				AST tmp390_AST = null;
				tmp390_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp390_AST);
				match(LPAREN);
				attr_vars();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp391_AST = null;
				tmp391_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp391_AST);
				match(RPAREN);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_first_is:
			{
				AST tmp392_AST = null;
				tmp392_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp392_AST);
				match(LITERAL_first_is);
				AST tmp393_AST = null;
				tmp393_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp393_AST);
				match(LPAREN);
				attr_vars();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp394_AST = null;
				tmp394_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp394_AST);
				match(RPAREN);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_last_is:
			{
				AST tmp395_AST = null;
				tmp395_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp395_AST);
				match(LITERAL_last_is);
				AST tmp396_AST = null;
				tmp396_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp396_AST);
				match(LPAREN);
				attr_vars();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp397_AST = null;
				tmp397_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp397_AST);
				match(RPAREN);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_switch_is:
			{
				AST tmp398_AST = null;
				tmp398_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp398_AST);
				match(LITERAL_switch_is);
				AST tmp399_AST = null;
				tmp399_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp399_AST);
				match(LPAREN);
				attr_var();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp400_AST = null;
				tmp400_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp400_AST);
				match(RPAREN);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_source:
			{
				AST tmp401_AST = null;
				tmp401_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp401_AST);
				match(LITERAL_source);
				field_attribute_AST = currentAST.root;
				break;
			}
			case LITERAL_string:
			{
				string_type();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					attributes.Add("string", new CodeAttributeArgument());
				}
				field_attribute_AST = currentAST.root;
				break;
			}
			default:
				if ((LA(1)==LITERAL_ref||LA(1)==LITERAL_ptr||LA(1)==LITERAL_unique))
				{
					ptr_attr();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					field_attribute_AST = currentAST.root;
				}
				else if ((tokenSet_57_.member(LA(1)))) {
					attribute(attributes);
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					field_attribute_AST = currentAST.root;
				}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			break; }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = field_attribute_AST;
	}
	
	public void raises_expr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST raises_expr_AST = null;
		StringCollection ignored = new StringCollection();
		
		try {      // for error handling
			AST tmp402_AST = null;
			tmp402_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp402_AST);
			match(LITERAL_raises);
			AST tmp403_AST = null;
			tmp403_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp403_AST);
			match(LPAREN);
			scoped_name_list(ignored);
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp404_AST = null;
			tmp404_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp404_AST);
			match(RPAREN);
			raises_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = raises_expr_AST;
	}
	
	public void context_expr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST context_expr_AST = null;
		
		try {      // for error handling
			AST tmp405_AST = null;
			tmp405_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp405_AST);
			match(LITERAL_context);
			AST tmp406_AST = null;
			tmp406_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp406_AST);
			match(LPAREN);
			string_literal_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp407_AST = null;
			tmp407_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp407_AST);
			match(RPAREN);
			context_expr_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = context_expr_AST;
	}
	
	public void string_literal_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST string_literal_list_AST = null;
		
		try {      // for error handling
			string_literal();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						string_literal();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop256_breakloop;
					}
					
				}
_loop256_breakloop:				;
			}    // ( ... )*
			string_literal_list_AST = currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_18_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = string_literal_list_AST;
	}
	
	private void initializeFactory()
	{
		if (astFactory == null)
		{
			astFactory = new ASTFactory();
		}
		initializeASTFactory( astFactory );
	}
	static public void initializeASTFactory( ASTFactory factory )
	{
		factory.setMaxNodeType(193);
	}
	
	public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""v1_enum""",
		@"""__int3264""",
		@"""__int64""",
		@""";""",
		@"""[""",
		@"""]""",
		@"""module""",
		@"""{""",
		@"""}""",
		@"""import""",
		@""",""",
		@"""library""",
		@"""coclass""",
		@"""uuid""",
		@"""version""",
		@"""(""",
		@""")""",
		@"""async_uuid""",
		@"""local""",
		@"""object""",
		@"""pointer_default""",
		@"""endpoint""",
		@"""odl""",
		@"""optimize""",
		@"""proxy""",
		@"""aggregatable""",
		@"""appobject""",
		@"""bindable""",
		@"""control""",
		@"""custom""",
		@"""default""",
		@"""defaultbind""",
		@"""defaultcollelem""",
		@"""defaultvtable""",
		@"""displaybind""",
		@"""dllname""",
		@"""dual""",
		@"""entry""",
		@"""helpcontext""",
		@"""helpfile""",
		@"""helpstring""",
		@"""helpstringdll""",
		@"""hidden""",
		@"""id""",
		@"""idempotent""",
		@"""immediatebind""",
		@"""lcid""",
		@"""licensed""",
		@"""message""",
		@"""nonbrowsable""",
		@"""noncreatable""",
		@"""nonextensible""",
		@"""oleautomation""",
		@"""restricted""",
		@"""ref""",
		@"""ptr""",
		@"""function""",
		@"""scriptable""",
		@"""deprecated""",
		@"""Undefined""",
		@"""noscript""",
		@"""Null""",
		@"""nsid""",
		@"""domstring""",
		@"""utf8string""",
		@"""cstring""",
		@"""astring""",
		@"""jsval""",
		@"""importlib""",
		@"""interface""",
		@"""dispinterface""",
		@"""readonly""",
		@"""attribute""",
		@""":""",
		@"""::""",
		@"""const""",
		@"""=""",
		@"""*""",
		@"""|""",
		@"""^""",
		@"""&""",
		@"""<<""",
		@""">>""",
		@"""+""",
		@"""-""",
		@"""/""",
		@"""%""",
		@"""~""",
		@"""TRUE""",
		@"""true""",
		@"""FALSE""",
		@"""false""",
		@"""typedef""",
		@"""native""",
		@"""context_handle""",
		@"""handle""",
		@"""pipe""",
		@"""transmit_as""",
		@"""wire_marshal""",
		@"""represent_as""",
		@"""user_marshal""",
		@"""public""",
		@"""switch_type""",
		@"""signed""",
		@"""unsigned""",
		@"""octet""",
		@"""any""",
		@"""void""",
		@"""byte""",
		@"""wchar_t""",
		@"""handle_t""",
		@"""an integer value""",
		@"""a hexadecimal value value""",
		@"""unique""",
		@"""small""",
		@"""short""",
		@"""long""",
		@"""int""",
		@"""hyper""",
		@"""char""",
		@"""float""",
		@"""double""",
		@"""boolean""",
		@"""struct""",
		@"""union""",
		@"""switch""",
		@"""case""",
		@"""enum""",
		@"""sequence""",
		@"""<""",
		@""">""",
		@"""string""",
		@"""..""",
		@"""exception""",
		@"""callback""",
		@"""broadcast""",
		@"""ignore""",
		@"""notxpcom""",
		@"""propget""",
		@"""propput""",
		@"""propputref""",
		@"""uidefault""",
		@"""usesgetlasterror""",
		@"""vararg""",
		@"""optional_argc""",
		@"""implicit_jscontext""",
		@"""binaryname""",
		@"""raises""",
		@"""in""",
		@"""out""",
		@"""inout""",
		@"""retval""",
		@"""defaultvalue""",
		@"""optional""",
		@"""requestedit""",
		@"""iid_is""",
		@"""range""",
		@"""array""",
		@"""shared""",
		@"""size_is""",
		@"""max_is""",
		@"""length_is""",
		@"""first_is""",
		@"""last_is""",
		@"""switch_is""",
		@"""source""",
		@"""context""",
		@"""SAFEARRAY""",
		@"""OCTAL""",
		@"""L""",
		@"""a string literal""",
		@"""a character literal""",
		@"""an floating point value""",
		@"""an identifer""",
		@"""cpp_quote""",
		@"""midl_pragma_warning""",
		@"""?""",
		@""".""",
		@"""!""",
		@"""double quotes""",
		@"""white space""",
		@"""a preprocessor directive""",
		@"""a comment""",
		@"""Other lang block like C++""",
		@"""a comment""",
		@"""an escape sequence""",
		@"""an escaped character value""",
		@"""a digit""",
		@"""an octal digit""",
		@"""a hexadecimal digit"""
	};
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = { 3175251046855845344L, -6764148289386624L, 3951657809348233L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { 128L, -9223372023969873920L, 9L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { 3175251046855844192L, -6764152584386944L, 573958088819841L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = { 3175251046855849442L, -6764148289386624L, 3951657809348233L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = { 128L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = { 3175251046855745888L, -6764152584355712L, 565161995797657L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = { 512L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = { 3175251046855746016L, -6764148289382272L, 1699857995662985L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = { 3175251046856810496L, -9214364803240263552L, 565161995797505L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = { 3175251046857441250L, -6764148155226240L, 3951657809348587L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	private static long[] mk_tokenSet_10_()
	{
		long[] data = { 128L, 32768L, 8388608L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());
	private static long[] mk_tokenSet_11_()
	{
		long[] data = { 3175251046855849442L, -6764148289380480L, 3951657809348233L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_11_ = new BitSet(mk_tokenSet_11_());
	private static long[] mk_tokenSet_12_()
	{
		long[] data = new long[8];
		data[0]=-1048592L;
		for (int i = 1; i<=2; i++) { data[i]=-1L; }
		data[3]=3L;
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_12_ = new BitSet(mk_tokenSet_12_());
	private static long[] mk_tokenSet_13_()
	{
		long[] data = { 4096L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_13_ = new BitSet(mk_tokenSet_13_());
	private static long[] mk_tokenSet_14_()
	{
		long[] data = { 1069696L, 134094848L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_14_ = new BitSet(mk_tokenSet_14_());
	private static long[] mk_tokenSet_15_()
	{
		long[] data = { 4480L, 1536L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_15_ = new BitSet(mk_tokenSet_15_());
	private static long[] mk_tokenSet_16_()
	{
		long[] data = { 16896L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_16_ = new BitSet(mk_tokenSet_16_());
	private static long[] mk_tokenSet_17_()
	{
		long[] data = { 1065472L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_17_ = new BitSet(mk_tokenSet_17_());
	private static long[] mk_tokenSet_18_()
	{
		long[] data = { 1048576L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_18_ = new BitSet(mk_tokenSet_18_());
	private static long[] mk_tokenSet_19_()
	{
		long[] data = { 1064960L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_19_ = new BitSet(mk_tokenSet_19_());
	private static long[] mk_tokenSet_20_()
	{
		long[] data = { 2L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_20_ = new BitSet(mk_tokenSet_20_());
	private static long[] mk_tokenSet_21_()
	{
		long[] data = { 3175251046855851490L, -6764148289386624L, 3951657809348233L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_21_ = new BitSet(mk_tokenSet_21_());
	private static long[] mk_tokenSet_22_()
	{
		long[] data = { 3175251046855745888L, -6764152584388480L, 573958088819841L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_22_ = new BitSet(mk_tokenSet_22_());
	private static long[] mk_tokenSet_23_()
	{
		long[] data = { 3175251046855750112L, -6764148289382272L, 1699857995662985L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_23_ = new BitSet(mk_tokenSet_23_());
	private static long[] mk_tokenSet_24_()
	{
		long[] data = { 3175251046855745632L, -6764152584382336L, 573958088819841L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_24_ = new BitSet(mk_tokenSet_24_());
	private static long[] mk_tokenSet_25_()
	{
		long[] data = { 3175251046856900066L, -6764148289386624L, 3951657809348233L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_25_ = new BitSet(mk_tokenSet_25_());
	private static long[] mk_tokenSet_26_()
	{
		long[] data = { 3175251046856916962L, -6764148155291776L, 3951657809348585L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_26_ = new BitSet(mk_tokenSet_26_());
	private static long[] mk_tokenSet_27_()
	{
		long[] data = { 3175251046855745536L, -9214364803240296320L, 565161995797505L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_27_ = new BitSet(mk_tokenSet_27_());
	private static long[] mk_tokenSet_28_()
	{
		long[] data = { 1069696L, 8192L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_28_ = new BitSet(mk_tokenSet_28_());
	private static long[] mk_tokenSet_29_()
	{
		long[] data = { 96L, 1134968678748520448L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_29_ = new BitSet(mk_tokenSet_29_());
	private static long[] mk_tokenSet_30_()
	{
		long[] data = { 3175251046856810624L, -9214364803240263552L, 565161995797569L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_30_ = new BitSet(mk_tokenSet_30_());
	private static long[] mk_tokenSet_31_()
	{
		long[] data = { 3175251046856811136L, -9214364803240263552L, 565161995797569L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_31_ = new BitSet(mk_tokenSet_31_());
	private static long[] mk_tokenSet_32_()
	{
		long[] data = { 1069696L, 270336L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_32_ = new BitSet(mk_tokenSet_32_());
	private static long[] mk_tokenSet_33_()
	{
		long[] data = { 1069696L, 794624L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_33_ = new BitSet(mk_tokenSet_33_());
	private static long[] mk_tokenSet_34_()
	{
		long[] data = { 1069696L, 1843200L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_34_ = new BitSet(mk_tokenSet_34_());
	private static long[] mk_tokenSet_35_()
	{
		long[] data = { 1069696L, 8134656L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_35_ = new BitSet(mk_tokenSet_35_());
	private static long[] mk_tokenSet_36_()
	{
		long[] data = { 3175251046856269824L, -9207609399613308800L, 829044786463745L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_36_ = new BitSet(mk_tokenSet_36_());
	private static long[] mk_tokenSet_37_()
	{
		long[] data = { 1069696L, 33300480L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_37_ = new BitSet(mk_tokenSet_37_());
	private static long[] mk_tokenSet_38_()
	{
		long[] data = { 3175251046856269824L, -9207609399772692352L, 829044786463745L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_38_ = new BitSet(mk_tokenSet_38_());
	private static long[] mk_tokenSet_39_()
	{
		long[] data = { 512L, 0L, 320L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_39_ = new BitSet(mk_tokenSet_39_());
	private static long[] mk_tokenSet_40_()
	{
		long[] data = { 3175251046855745664L, -9214364803240296320L, 565161995797505L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_40_ = new BitSet(mk_tokenSet_40_());
	private static long[] mk_tokenSet_41_()
	{
		long[] data = { 3175251046856794240L, -9214364803240296320L, 565161995797505L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_41_ = new BitSet(mk_tokenSet_41_());
	private static long[] mk_tokenSet_42_()
	{
		long[] data = { 1065090L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_42_ = new BitSet(mk_tokenSet_42_());
	private static long[] mk_tokenSet_43_()
	{
		long[] data = { 3175251046856810624L, -9214364803240296320L, 565161995797569L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_43_ = new BitSet(mk_tokenSet_43_());
	private static long[] mk_tokenSet_44_()
	{
		long[] data = { 3175251046856794112L, -9214364803240296320L, 565161995797505L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_44_ = new BitSet(mk_tokenSet_44_());
	private static long[] mk_tokenSet_45_()
	{
		long[] data = { 3175251046855745632L, -6764152584388480L, 565161995797649L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_45_ = new BitSet(mk_tokenSet_45_());
	private static long[] mk_tokenSet_46_()
	{
		long[] data = { 3175251046856810624L, -9214364803240132480L, 565161995797569L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_46_ = new BitSet(mk_tokenSet_46_());
	private static long[] mk_tokenSet_47_()
	{
		long[] data = { 1065346L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_47_ = new BitSet(mk_tokenSet_47_());
	private static long[] mk_tokenSet_48_()
	{
		long[] data = { 3175251046855749984L, -6764152584355712L, 565161995797657L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_48_ = new BitSet(mk_tokenSet_48_());
	private static long[] mk_tokenSet_49_()
	{
		long[] data = { 3175251046855745632L, -6764152584355712L, 565161995797657L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_49_ = new BitSet(mk_tokenSet_49_());
	private static long[] mk_tokenSet_50_()
	{
		long[] data = { 4352L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_50_ = new BitSet(mk_tokenSet_50_());
	private static long[] mk_tokenSet_51_()
	{
		long[] data = { 3175251046855746016L, -6764152584355712L, 565161995797657L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_51_ = new BitSet(mk_tokenSet_51_());
	private static long[] mk_tokenSet_52_()
	{
		long[] data = { 17179873280L, 0L, 4L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_52_ = new BitSet(mk_tokenSet_52_());
	private static long[] mk_tokenSet_53_()
	{
		long[] data = { 3175251064035615072L, -6764152584355712L, 565161995797661L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_53_ = new BitSet(mk_tokenSet_53_());
	private static long[] mk_tokenSet_54_()
	{
		long[] data = { 20480L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_54_ = new BitSet(mk_tokenSet_54_());
	private static long[] mk_tokenSet_55_()
	{
		long[] data = { 0L, 0L, 64L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_55_ = new BitSet(mk_tokenSet_55_());
	private static long[] mk_tokenSet_56_()
	{
		long[] data = { 512L, 0L, 256L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_56_ = new BitSet(mk_tokenSet_56_());
	private static long[] mk_tokenSet_57_()
	{
		long[] data = { -1703936L, 255L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_57_ = new BitSet(mk_tokenSet_57_());
	private static long[] mk_tokenSet_58_()
	{
		long[] data = { 3175251046855745632L, -6764152584388480L, 573958088819841L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_58_ = new BitSet(mk_tokenSet_58_());
	
}
}
