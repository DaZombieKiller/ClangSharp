// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using ClangSharp.Interop;

namespace ClangSharp;

public sealed class BitIntType : Type
{
    internal BitIntType(CXType handle) : base(handle, CXTypeKind.CXType_Unexposed, CX_TypeClass.CX_TypeClass_BitInt)
    {
    }

    public bool IsSigned => Handle.IsSigned;

    public bool IsUnsigned => Handle.IsUnsigned;

    public uint NumBits => unchecked((uint)Handle.NumBits);
}
