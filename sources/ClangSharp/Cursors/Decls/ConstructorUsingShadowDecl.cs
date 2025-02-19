// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using ClangSharp.Interop;

namespace ClangSharp;

public sealed class ConstructorUsingShadowDecl : UsingShadowDecl
{
    private readonly Lazy<CXXRecordDecl> _constructedBaseClass;
    private readonly Lazy<ConstructorUsingShadowDecl> _constructedBaseClassShadowDecl;
    private readonly Lazy<CXXRecordDecl> _nominatedBaseClass;
    private readonly Lazy<ConstructorUsingShadowDecl> _nominatedBaseClassShadowDecl;

    internal ConstructorUsingShadowDecl(CXCursor handle) : base(handle, CXCursorKind.CXCursor_UnexposedDecl, CX_DeclKind.CX_DeclKind_ConstructorUsingShadow)
    {
        _constructedBaseClass = new Lazy<CXXRecordDecl>(() => TranslationUnit.GetOrCreate<CXXRecordDecl>(Handle.ConstructedBaseClass));
        _constructedBaseClassShadowDecl = new Lazy<ConstructorUsingShadowDecl>(() => TranslationUnit.GetOrCreate<ConstructorUsingShadowDecl>(Handle.ConstructedBaseClassShadowDecl));
        _nominatedBaseClass = new Lazy<CXXRecordDecl>(() => TranslationUnit.GetOrCreate<CXXRecordDecl>(Handle.NominatedBaseClass));
        _nominatedBaseClassShadowDecl = new Lazy<ConstructorUsingShadowDecl>(() => TranslationUnit.GetOrCreate<ConstructorUsingShadowDecl>(Handle.NominatedBaseClassShadowDecl));
    }

    public CXXRecordDecl ConstructedBaseClass => _constructedBaseClass.Value;

    public ConstructorUsingShadowDecl ConstructedBaseClassShadowDecl => _constructedBaseClassShadowDecl.Value;

    public bool ConstructsVirtualBase => Handle.ConstructsVirtualBase;

    public CXXRecordDecl NominatedBaseClass => _nominatedBaseClass.Value;

    public ConstructorUsingShadowDecl NominatedBaseClassShadowDecl => _nominatedBaseClassShadowDecl.Value;

    public new CXXRecordDecl? Parent => (CXXRecordDecl?)DeclContext;
}
