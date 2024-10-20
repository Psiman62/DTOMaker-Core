﻿using System;
using System.Collections.Immutable;

namespace DTOMaker.Gentime
{
    internal sealed class ModelScope_Member : IModelScope
    {
        private readonly ILanguage _language;
        private readonly TargetMember _member;

        public ImmutableDictionary<string, object?> Tokens { get; }

        public ModelScope_Member(ILanguage language, TargetMember member, ImmutableDictionary<string, object?> parentTokens)
        {
            _language = language;
            _member = member;
            var builder = parentTokens.ToBuilder();
            builder.Add("MemberIsNullable", member.IsNullable);
            builder.Add("MemberIsObsolete", member.IsObsolete);
            builder.Add("MemberObsoleteMessage", member.ObsoleteMessage);
            builder.Add("MemberObsoleteIsError", member.ObsoleteIsError);
            builder.Add("MemberTypeIsEnum", member.IsEnumType);
            builder.Add("MemberType", _language.GetDataTypeToken(member.MemberTypeName));
            builder.Add("MemberWireType", _language.GetDataTypeToken(member.MemberWireTypeName));
            builder.Add("MemberSequence", member.Sequence);
            builder.Add("NullableMemberSequence", member.Sequence);
            builder.Add("MemberName", member.Name);
            builder.Add("NullableMemberName", member.Name);
            builder.Add("MemberJsonName", member.Name.ToCamelCase());
            builder.Add("MemberDefaultValue", _language.GetDefaultValue(member.MemberTypeName));
            builder.Add("MemberBELE", member.IsBigEndian ? "BE" : "LE");
            builder.Add("FlagsOffset", member.FlagsOffset);
            // todo builder.Add("MemberCountOffset", member.CountOffset); // array length
            builder.Add("FieldOffset", member.FieldOffset);
            builder.Add("FieldLength", member.FieldLength);
            Tokens = builder.ToImmutable();
        }

        public (bool?, IModelScope[]) GetInnerScopes(string iteratorName)
        {
            return (null, Array.Empty<IModelScope>());
        }
    }
}
