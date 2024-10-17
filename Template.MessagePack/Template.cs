﻿#nullable enable
using DTOMaker.Runtime;
using MessagePack;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace T_Namespace_.MessagePack
{
    //##if false
    using T_MemberType_ = System.Int64;
    //##endif

    public interface IT_EntityName_
    {
        T_MemberType_ T_MemberName_ { get; set; }
    }

    [MessagePackObject]
    public partial class T_EntityName_ : IT_EntityName_, IFreezable
    {
        //##if false
        private const int T_MemberSequence_ = 1;
        //##endif

        // todo move to base
        [IgnoreMember]
        private volatile bool _frozen;
        public bool IsFrozen() => _frozen;
        public IFreezable PartCopy() => new T_EntityName_(this);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T IfNotFrozen<T>(ref T value, [CallerMemberName] string? methodName = null)
        {
            if (_frozen) ThrowIsFrozenException(methodName);
            return ref value;
        }

        public void Freeze()
        {
            if (_frozen) return;
            _frozen = true;
            // todo freeze base
            // todo freeze model type refs
        }

        public T_EntityName_() { }
        public T_EntityName_(IT_EntityName_ source, bool frozen = false)
        {
            _frozen = frozen;
            // todo base ctor
            //##foreach Members
            // todo freezable members
            _T_MemberName_ = source.T_MemberName_;
            //##endfor
        }

        //##foreach Members
        [IgnoreMember]
        private T_MemberType_ _T_MemberName_;
        [Key(T_MemberSequence_)]
        public T_MemberType_ T_MemberName_
        {
            get => _T_MemberName_;
            set => _T_MemberName_ = IfNotFrozen(ref value);
        }

        //##endfor

    }
}