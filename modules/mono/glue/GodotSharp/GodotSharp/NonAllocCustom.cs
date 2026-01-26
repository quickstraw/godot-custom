using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.NativeInterop;

namespace Godot;

#pragma warning disable IDE0040 // Add accessibility modifiers.

partial class Area2D
{
    /// <summary>
    /// <para>Stores overlapping areas into the provided <paramref name="results"/> span.</para>
    /// </summary>
    public unsafe int GetOverlappingAreasNonAlloc(Span<Area2D> results)
    {
        var ptr = GodotObject.GetPtr(this);
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[0] { };
        NativeFuncs.godotsharp_method_bind_ptrcall(MethodBind27, ptr, call_args, &ret);
        int numResults = Mathf.Min(ret.Size, results.Length);
        for (var i = 0; i < numResults; i++)
        {
            var item = ret.Elements[i];
            var obj = VariantUtils.ConvertToGodotObject(item);
            results[i] = (Area2D)obj;
        }
        return numResults;
    }

}

partial struct Variant
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe int AsByteSpan(Span<byte> bytes)
    {
        var pVar = (godot_variant)NativeVar;
        using var packedArray = NativeFuncs.godotsharp_variant_as_packed_byte_array(pVar);

        int size = packedArray.Size;
        var span = new Span<byte>(packedArray.Buffer, size);
        span.CopyTo(bytes);
        return size;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetByteArraySize()
    {
        var pVar = (godot_variant)NativeVar;
        using var packedArray = NativeFuncs.godotsharp_variant_as_packed_byte_array(pVar);

        int size = packedArray.Size;
        return size;
    }
}

partial class PhysicsDirectSpaceState2D
{
    /// <summary>
    /// Checks whether a point is inside any solid shape. Position and other parameters are defined through <see cref="Godot.PhysicsPointQueryParameters2D"/>. The shapes the point is inside of are filled into the <paramref name="results"/> span.
    /// </summary>
    /// <remarks>
    /// <see cref="Godot.ConcavePolygonShape2D"/>s and <see cref="Godot.CollisionPolygon2D"/>s in <c>Segments</c> build mode are not solid shapes. Therefore, they will not be detected.
    /// </remarks>
    public unsafe int IntersectPointNonAlloc(PhysicsPointQueryParameters2D parameters, Span<IntersectPointResult> results)
    {
        var method = MethodBind0;
        var ptr = GodotObject.GetPtr(this);
        var arg1 = GodotObject.GetPtr(parameters);
        var arg2 = results.Length;
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        int numResults = Mathf.Min(ret.Size, results.Length);
        int currResultIndex = 0;
        for (int i = 0; i < ret.Size; i++)
        {
            if (currResultIndex >= numResults) break;
            var item = ret.Elements[i];
            if (item.Type != Variant.Type.Dictionary) continue;

            var dict = item.Dictionary;
            if (!NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectPointResult.ColliderKey.NativeVar, out var colliderValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectPointResult.ColliderIdKey.NativeVar, out var colliderIdValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectPointResult.RidKey.NativeVar, out var ridValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectPointResult.ShapeKey.NativeVar, out var shapeValue).ToBool())
                continue;

            results[currResultIndex] = new IntersectPointResult(
                VariantUtils.ConvertToGodotObject(colliderValue),
                colliderIdValue.Int,
                ridValue.Rid,
                shapeValue.Int
            );
            currResultIndex++;
        }
        NativeFuncs.godotsharp_array_destroy(ref ret);
        return currResultIndex;
    }

        /// <summary>
    /// Checks whether a point is inside any solid shape. Position and other parameters are defined through <see cref="Godot.PhysicsPointQueryParameters2D"/>. Returns true if there is an intersection.
    /// </summary>
    /// <remarks>
    /// <see cref="Godot.ConcavePolygonShape2D"/>s and <see cref="Godot.CollisionPolygon2D"/>s in <c>Segments</c> build mode are not solid shapes. Therefore, they will not be detected.
    /// </remarks>
    public unsafe bool IntersectPointNonAlloc(PhysicsPointQueryParameters2D parameters)
    {
        var method = MethodBind0;
        var ptr = GodotObject.GetPtr(this);
        var arg1 = GodotObject.GetPtr(parameters);
        var arg2 = 1;
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);

        int numResults = Mathf.Min(ret.Size, 1);
        bool hasResults = numResults > 0;
        NativeFuncs.godotsharp_array_destroy(ref ret);

        return hasResults;
    }

    /// <summary>
    /// Checks the intersections of a shape, given through a <see cref="Godot.PhysicsShapeQueryParameters2D"/> object, against the space. The intersected shapes are filled into the <paramref name="results"/> span.
    /// </summary>
    public unsafe int IntersectShapeNonAlloc(PhysicsShapeQueryParameters2D parameters, Span<IntersectShapeResult> results)
    {
        var method = MethodBind2;
        var ptr = GodotObject.GetPtr(this);
        var arg1 = GodotObject.GetPtr(parameters);
        var arg2 = results.Length;
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        int numResults = Mathf.Min(ret.Size, results.Length);
        int currResultIndex = 0;
        for (int i = 0; i < numResults; i++)
        {
            if (currResultIndex >= numResults) break;
            var item = ret.Elements[i];
            if (item.Type != Variant.Type.Dictionary) continue;

            var dict = item.Dictionary;
            if (!NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectShapeResult.ColliderKey.NativeVar, out var colliderValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectShapeResult.ColliderIdKey.NativeVar, out var colliderIdValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectShapeResult.RidKey.NativeVar, out var ridValue).ToBool()
                || !NativeFuncs.godotsharp_dictionary_try_get_value(ref dict, (godot_variant)IntersectShapeResult.ShapeKey.NativeVar, out var shapeValue).ToBool())
                continue;

            results[currResultIndex] = new IntersectShapeResult(
                VariantUtils.ConvertToGodotObject(colliderValue),
                colliderIdValue.Int,
                ridValue.Rid,
                shapeValue.Int
            );
            currResultIndex++;
        }
        NativeFuncs.godotsharp_array_destroy(ref ret);
        return currResultIndex;
    }
}

partial class Node
{
    /// <summary>
    /// <para>Stores all children of this node into the provided <paramref name="results"/> span.</para>
    /// <para>If <paramref name="includeInternal"/> is <see langword="false"/>, excludes internal children when populating the list (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// </summary>
    public unsafe int GetChildrenNonAlloc(Span<Node> results, bool includeInternal = false)
    {
        var ptr = GodotObject.GetPtr(this);
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { &includeInternal };
        NativeFuncs.godotsharp_method_bind_ptrcall(MethodBind9, ptr, call_args, &ret);
        int numResults = Mathf.Min(ret.Size, results.Length);
        for (var i = 0; i < numResults; i++)
        {
            var item = ret.Elements[i];
            var obj = VariantUtils.ConvertToGodotObject(item);
            results[i] = (Node)obj;
        }
        return ret.Size;
    }
}
