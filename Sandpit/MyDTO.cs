﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0414
#nullable enable
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DTOMaker.Runtime;
namespace MyOrg.Models.MemBlocks
{
    public sealed partial class MyDTO : IMyDTO, IFreezable
    {
        private const int BlockLength = 4;
        private readonly Memory<byte> _writableBlock;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;
        public ReadOnlyMemory<byte> Block => _frozen ? _readonlyBlock : _writableBlock.ToArray();

        public MyDTO() => _readonlyBlock = _writableBlock = new byte[BlockLength];

        public MyDTO(ReadOnlySpan<byte> source, bool frozen)
        {
            Memory<byte> memory = new byte[BlockLength];
            source.Slice(0, BlockLength).CopyTo(memory.Span);
            _readonlyBlock = memory;
            _writableBlock = memory;
            _frozen = frozen;
        }

        public MyDTO(ReadOnlyMemory<byte> source)
        {
            if (source.Length >= BlockLength)
            {
                _readonlyBlock = source.Slice(0, BlockLength);
            }
            else
            {
                // forced copy as source is too short
                Memory<byte> memory = new byte[BlockLength];
                source.Slice(0, BlockLength).Span.CopyTo(memory.Span);
                _readonlyBlock = memory;
            }
            _writableBlock = Memory<byte>.Empty;
            _frozen = true;
        }
        // todo move to base
        private volatile bool _frozen = false;
        public bool IsFrozen() => _frozen;
        public IFreezable PartCopy() => new MyDTO(this);

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

        public MyDTO(MyDTO source)
        {
            // todo base ctor
            // todo freezable members
            _writableBlock = source._writableBlock.ToArray();
            _readonlyBlock = _writableBlock;
            _frozen = false;
        }

        public MyDTO(IMyDTO source) : this(ReadOnlySpan<byte>.Empty, false)
        {
            // todo base ctor
            // todo freezable members
            this.Field1 = source.Field1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (T, byte) GetValueAndFlags<T>(T? input) where T : struct
        {
            if (input.HasValue)
                return (input.Value, 1);
            else
                return (default, 0);
        }

        public double? Fieldqqq
        {
            get
            {
                const int _flags_Offset = 0;
                const int _value_Offset = 8;
                const int _value_Length = 8;
                byte flags = DTOMaker.Runtime.Codec_Byte_LE.ReadFromSpan(_readonlyBlock.Slice(_flags_Offset, 1).Span);
                if (flags == 0) return null;
                return DTOMaker.Runtime.Codec_Double_LE.ReadFromSpan(_readonlyBlock.Slice(_value_Offset, _value_Length).Span);
            }

            set
            {
                const int _flags_Offset = 0;
                const int _value_Offset = 8;
                const int _value_Length = 8;
                if (_frozen) ThrowIsFrozenException(nameof(Fieldqqq));
                byte flags = value.HasValue ? (byte)1 : (byte)0;
                Double wireValue = value.HasValue ? value.Value : default;
                DTOMaker.Runtime.Codec_Byte_LE.WriteToSpan(_writableBlock.Slice(_flags_Offset, 1).Span, flags);
                DTOMaker.Runtime.Codec_Double_LE.WriteToSpan(_writableBlock.Slice(_value_Offset, _value_Length).Span, wireValue);
            }
        }

        private IReadOnlyList<Int16>? _facade_Field1;
        public IReadOnlyList<Int16>? Field1
        {
            get
            {
                const int _flags_Offset = 0;
                const int _countOffset = 2;
                //const int _value_Offset = 8;
                const int _fieldLength = 2;
                const int _arrayOffset = 16;
                const int _maxCapacity = 8;
                byte flags = DTOMaker.Runtime.Codec_Byte_LE.ReadFromSpan(_readonlyBlock.Slice(_flags_Offset, 1).Span);
                if (flags == 0) return null;
                if (_facade_Field1 is null)
                {
                    _facade_Field1 = new ArrayFacade<Int16>(nameof(Field1), DTOMaker.Runtime.Codec_Int16_LE.Instance, () => _frozen,
                        _readonlyBlock, _writableBlock, _countOffset, _fieldLength, _arrayOffset, _maxCapacity);
                }
                return _facade_Field1;
            }

            set
            {
                if (_frozen) ThrowIsFrozenException(nameof(Field1));
                // todo
                throw new NotImplementedException();
            }
        }
    }

    internal sealed class ArrayFacade<TWireType> : IReadOnlyList<TWireType>
    {
        private readonly string _fieldName;
        private readonly ITypedFieldCodec<TWireType> _codec;
        private readonly Func<bool> _isFrozenFn;
        private readonly int _countOffset;
        private readonly int _fieldLength;
        private readonly int _arrayOffset;
        private readonly int _maxCapacity;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;
        private readonly Memory<byte> _writableBlock;

        public ArrayFacade(string fieldName, ITypedFieldCodec<TWireType> codec, Func<bool> isFrozenFn,
            ReadOnlyMemory<byte> readonlyBlock, Memory<byte> writableBlock,
            int countOffset, int fieldLength, int arrayOffset, int maxCapacity)
        {
            _fieldName = fieldName;
            _codec = codec;
            _countOffset = countOffset;
            _arrayOffset = arrayOffset;
            _fieldLength = fieldLength;
            _maxCapacity = maxCapacity;
            _readonlyBlock = readonlyBlock;
            _writableBlock = writableBlock;
            _isFrozenFn = isFrozenFn;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        public TWireType this[int index]
        {
            get
            {
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), index, $"0 <= {nameof(index)} < {count}");
                // todo flagsBlock
                var valueBlock = _readonlyBlock.Slice(_arrayOffset, _fieldLength * _maxCapacity);
                return _codec.ReadFrom(valueBlock.Slice(_fieldLength * index, _fieldLength).Span);
            }
            set
            {
                if (_isFrozenFn()) ThrowIsFrozenException(_fieldName);
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), index, $"0 <= {nameof(index)} < {count}");
                throw new NotImplementedException();
            }
        }

        public int Count => DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);

        public IEnumerator<TWireType> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}